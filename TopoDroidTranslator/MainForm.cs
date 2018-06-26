using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace TopoDroidTranslator
{
    public partial class MainForm : Form
    {
        string symbolsDirectory;
        List<SymbolFile> symbolFiles;
        List<string> langCodes;
        string confLanguageCode;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalContext.MainWindow = this;
            this.Text = GlobalContext.ApplicationTitle;

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["SymbolsDirectory"] != null)
                    symbolsDirectory = config.AppSettings.Settings["SymbolsDirectory"].Value;

                if (config.AppSettings.Settings["LanguageCode"] != null)
                    confLanguageCode = config.AppSettings.Settings["LanguageCode"].Value;

                OpenSymbolsDirectory(symbolsDirectory);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error reading from configuration file: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }

            UpdateRadioEnabledOptions();
        }

        void ReadFiles()
        {
            symbolFiles = new List<SymbolFile>();
            langCodes = new List<string>();

            int index = 0;

            foreach (string filePath in GetFiles(symbolsDirectory))
            {
                if (filePath.Contains("readme.symbols"))
                    continue;

                try
                {
                    string parentDir1 = new FileInfo(filePath).Directory.Name;
                    string parentDir2 = new FileInfo(Path.GetDirectoryName(filePath)).Directory.Name; // Path.GetDirectoryName

                    string categoryTitle = parentDir2.Replace("symbols_", "");

                    string text = File.ReadAllText(filePath);

                    string relativeFilePath = filePath.Replace(symbolsDirectory, "");

                    index++;

                    symbolFiles.Add(
                        new SymbolFile()
                        {
                            FilePath = filePath,
                            RelativeFilePath = relativeFilePath,
                            CategoryTitle = categoryTitle,
                            GeometryType = SymbolFile.GetGeometryTypeFromText(parentDir1),
                            FileContents = text,
                            //Index = index
                        }.Build());
                }
                catch (Exception ex)
                {
                    Output(string.Format("Error: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
                }
            }

            foreach (SymbolFile sf in symbolFiles)
                foreach (var kv in sf.LangValues)
                    if (langCodes.IndexOf(kv.Key) < 0)
                        langCodes.Add(kv.Key);

            PopulateLangCodesComboBox(langCodes);

            symbolFileBindingSource.DataSource = symbolFiles;

            Output(string.Format("Found {0} file(s)", symbolFiles.Count));
        }

        void PopulateLangCodesComboBox(List<string> langCodes)
        {
            langCodesComboBox.Items.AddRange(langCodes.ToArray());

            if (!string.IsNullOrEmpty(confLanguageCode))
                if (langCodesComboBox.Items.Contains(confLanguageCode))
                    langCodesComboBox.SelectedItem = confLanguageCode;
        }

        // adapted from https://stackoverflow.com/a/929418
        IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Output(string.Format("Error: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
                }

                string[] files = null;

                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Output(string.Format("Error: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
                }

                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }

        private delegate void SetTextCallback(string text);

        public void Output(string text)
        {
            if (this.logTextBox != null)
                if (this.logTextBox.InvokeRequired)
                {
                    SetTextCallback stc = new SetTextCallback(Output);
                    this.Invoke(stc, new object[] { text });
                }
                else
                {
                    try
                    {
                        logTextBox.AppendText("[" + DateTime.Now.ToString("hh:mm:ss") + "] " + text);
                        logTextBox.AppendText("\r\n");
                    }
                    catch (ObjectDisposedException ex)
                    {

                    }
                }
        }

        private void langCodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AddLanguageToObjects(langCodesComboBox.SelectedItem.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioEnabledOptions();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioEnabledOptions();
            //AddLanguageToObjects(newLangTextBox.Text);
        }

        void UpdateRadioEnabledOptions()
        {
            langCodesComboBox.Enabled = radioButton1.Checked;
            newLangTextBox.Enabled = radioButton2.Checked;
        }

        private void changeLangButton_Click(object sender, EventArgs e)
        {
            ChangeLanguage();
        }

        void ChangeLanguage()
        {
            if (radioButton1.Checked)
            {
                if (langCodesComboBox.SelectedItem == null)
                {
                    MessageBox.Show("You must select a language from the combobox!");
                    return;
                }

                UpdateSelectedLang(langCodesComboBox.SelectedItem.ToString());
            }
            else
                if (radioButton2.Checked)
            {
                if (string.IsNullOrWhiteSpace(newLangTextBox.Text) && (newLangTextBox.Text.Length != 2))
                {
                    MessageBox.Show("You must enter a 2 letter language code!");
                    return;
                }

                UpdateSelectedLang(newLangTextBox.Text);
            }
        }

        string selectedLangCode = string.Empty;

        void UpdateSelectedLang(string langCode)
        {
            if (!string.IsNullOrEmpty(selectedLangCode) &&
                MessageBox.Show("If you change the language then the language strings defined by you that are unsaved to symbol files will be lost. Continue?", GlobalContext.ApplicationTitle, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    langCodesComboBox.SelectedItem = selectedLangCode;
                    return;
                }

            //AddLanguageToObjects(langCodesComboBox.SelectedItem.ToString());

            selectedLangCode = langCode;

            SaveSelectedLangToConf(langCode);

            foreach (SymbolFile sf in symbolFiles)
            {
                if (!sf.LangValues.ContainsKey(langCode))
                    sf.LangValues.Add(langCode, "");

                sf.SelectedLangValue = sf.LangValues[langCode];
            }

            symbolFileBindingSource.ResetBindings(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
                ListInformation(e.RowIndex);
            else
                if (e.ColumnIndex == 6)
                OpenFileWithEditor(e.RowIndex);
        }

        void ListInformation(int rowIndex)
        {
            SymbolFile sf = symbolFiles[rowIndex];

            if (sf.FilePath == null)
                return;

            string text = System.Environment.NewLine + System.Environment.NewLine +
                sf.SymbolName + System.Environment.NewLine +
                string.Join(System.Environment.NewLine, sf.LangValues.Select(x => x.Key + " = " + x.Value).ToArray());

            Output(text);
        }

        void OpenFileWithEditor(int rowIndex)
        {
            SymbolFile sf = symbolFiles[rowIndex];

            try
            {
                Process.Start("notepad.exe", sf.FilePath);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }
        }

        private void updateFilesButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("This tool is experimental and may lead to information loss. Please backup your repository file before going forward. Continue modifying the files?", GlobalContext.ApplicationTitle, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                
                return;
            }

            UpdateFiles();
        }

        void UpdateFiles()
        {
            foreach (SymbolFile sf in symbolFiles)
            {
                sf.UpdateFile(selectedLangCode);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenSymbolsDirectory();
        }

        void OpenSymbolsDirectory()
        {
            if (symbolsRepFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OpenSymbolsDirectory(symbolsRepFolderBrowserDialog.SelectedPath);
            }
        }

        void OpenSymbolsDirectory(string directoryPath)
        {            
            symbolsDirectory = directoryPath;
            Output("Using directory " + symbolsDirectory);

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings.Remove("SymbolsDirectory");
                config.AppSettings.Settings.Add("SymbolsDirectory", symbolsDirectory);

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error writing to configuration file: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }

            repositoryDirectoryLabel.Text = symbolsDirectory;

            ReadFiles();

            ChangeLanguage();
        }

        void RefreshInformationLabel(int rowIndex)
        {
            SymbolFile sf = symbolFiles[rowIndex];

            if (sf.FilePath == null)
                return; 

            string text = 
                sf.SymbolName + System.Environment.NewLine +
                sf.SymbolThName + System.Environment.NewLine +
                string.Join("     " /*System.Environment.NewLine*/, sf.LangValues.Select(x => x.Key + " = " + x.Value).ToArray());

            symbolInfoLabel.Text = text;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
                RefreshInformationLabel(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (e.Row.Index > 0)
                    RefreshInformationLabel(e.Row.Index);
            }
            catch (Exception ex)
            {
            }
        }

        void SaveSelectedLangToConf(string selectedLanguageCode)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings.Remove("LanguageCode");
                config.AppSettings.Settings.Add("LanguageCode", selectedLangCode);

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error writing to configuration file: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.carto.net/neumann/caving/cave-symbols/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.uisic.uis-speleo.org/lexuni.html");
        }
    }
}
