using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TopoDroidTranslator
{
    public class SymbolFile
    {
        static string[] eolSequences = new string[] { System.Environment.NewLine, "\r\n", "\r", "\n" };
        static char[] eolChars = new char[] { '\r', '\n' };

        string filePath;

        string relativeFilePath;

        GeometryTypes geometryType;

        string categoryTitle;

        string fileContents;

        string symbolName;

        string symbolThName;

        Dictionary<string, string> langValues;

        string selectedLangValue;

        //int index;

        public string FilePath { get => filePath; set => filePath = value; }
        public GeometryTypes GeometryType { get => geometryType; set => geometryType = value; }
        public string CategoryTitle { get => categoryTitle; set => categoryTitle = value; }
        public string FileContents { get => fileContents; set => fileContents = value; }
        public string SymbolName { get => symbolName; set => symbolName = value; }
        public string SymbolThName { get => symbolThName; set => symbolThName = value; }
        public string RelativeFilePath { get => relativeFilePath; set => relativeFilePath = value; }
        public Dictionary<string, string> LangValues { get => langValues; set => langValues = value; }
        public string SelectedLangValue { get => selectedLangValue; set => selectedLangValue = value; }
        //public int Index { get => index; set => index = value; }

        public static GeometryTypes GetGeometryTypeFromText(string geometryText)
        {
            if (geometryText.IndexOf("point", StringComparison.OrdinalIgnoreCase) >= 0)
                return GeometryTypes.Point;
            else
            if (geometryText.IndexOf("line", StringComparison.OrdinalIgnoreCase) >= 0)
                return GeometryTypes.Line;
            else
            if (geometryText.IndexOf("area", StringComparison.OrdinalIgnoreCase) >= 0)
                return GeometryTypes.Area;
            else
                return GeometryTypes.Undefined;
        }

        // public static Dictionary<string, string> GetLangValuesFromText(string text)
        // public SymbolFile(string filePath, relativeFilePath, GeometryTypes geometryType, string categoryTitle, string fileContents, string symbolName, string symbolThName)
        public SymbolFile Build()
        {
            LangValues = new Dictionary<string, string>();


            if (string.IsNullOrWhiteSpace(fileContents))
                throw new Exception("empty file");

            string[] lines = this.fileContents.Split(eolSequences, StringSplitOptions.None);

            foreach (string line in lines)
            {
                // if (line.Length >= 2)
                if (line.IndexOf("th_name ") >= 0)
                    this.symbolThName = line.Replace("th_name ", "");
                else
                    if (line.IndexOf("name ") >= 0)
                    this.symbolName = line.Replace("name ", "");


                int indexOfKey = line.IndexOf("name-");

                if (indexOfKey >= 0)
                {
                    try
                    {
                        int indexOfFirstSpace = line.IndexOf(' ');

                        string key = line.Substring(indexOfKey, indexOfFirstSpace);
                        string langCode = key.Replace("name-", "");

                        string langValue = line.Replace(key + " ", "").Trim();

                        if (this.langValues.ContainsKey(langCode))
                            GlobalContext.MainWindow.Output(string.Format("Warning: lang code {0} is defined multiple times for element '{1}' in file {2} !", langCode, this.symbolName, this.relativeFilePath));
                        else
                        if (string.IsNullOrWhiteSpace(langCode))
                            GlobalContext.MainWindow.Output(string.Format("Warning: lang code {0} is empty for element '{1}' in file {2} !", langCode, this.symbolName, this.relativeFilePath));
                        else
                            this.langValues.Add(langCode, langValue);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return this;
        }

        public void UpdateFile(string selectedLangCode)
        {
            if (string.IsNullOrWhiteSpace(this.selectedLangValue))
            {
                GlobalContext.MainWindow.Output(string.Format("Language value is empty for symbol {0} in '..{1}'. File not modified.", this.symbolName, this.relativeFilePath));
                return;
            }
            
            // reread file to update it in case it was changed since first read
            fileContents = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(fileContents))
                throw new Exception("empty file");

            //Dictionary<string, string> resultValues = new Dictionary<string, string>();

            string[] lines = fileContents.Split(eolSequences, StringSplitOptions.None);

            //foreach (string line in lines)
            {
                int indexOfKey = fileContents.IndexOf("name-" + selectedLangCode);

                if (indexOfKey >= 0)
                {
                    // replace the old value

                    int indexOfEOL = fileContents.IndexOfAny(eolChars, indexOfKey); // first index of any eol character on that line
                    int indexOfEOLEnd = fileContents.LastIndexOfAny(eolChars, indexOfEOL + 4); // last index of any eol character on that line
                    // this would ensure it works with variable end of line endings

                    if (indexOfEOLEnd >= 0)
                    {
                        int indexOfNextEOLEnd = fileContents.LastIndexOfAny(eolChars, indexOfEOLEnd + 4);

                        if (indexOfNextEOLEnd >= 0)
                        {
                            try
                            {
                                string updatedFileContents =
                                    fileContents.Substring(0, indexOfKey) +
                                    "name-" + selectedLangCode + " " + this.selectedLangValue + System.Environment.NewLine +
                                    fileContents.Substring(indexOfNextEOLEnd + 1); // , fileContents.Length - indexOfEOLEnd

                                WriteToFile(updatedFileContents);
                            }
                            catch (Exception ex)
                            {
                                GlobalContext.MainWindow.Output(string.Format("Error writing element {3} to file {4}: \r\n{0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite, this.symbolName, this.relativeFilePath));
                            }
                        }
                    }
                }
                else
                {
                    // not found so we need to add it

                    int indexOfThName = fileContents.IndexOf("th_name");

                    if (indexOfThName >= 0)
                    {
                        string updatedFileContents =
                            fileContents.Insert(indexOfThName, "name-" + selectedLangCode + " " + this.selectedLangValue + System.Environment.NewLine);

                        WriteToFile(updatedFileContents);
                    }
                }
            }
        }

        private void WriteToFile(string updatedFileContents)
        {
            File.WriteAllText(FilePath, updatedFileContents);
            GlobalContext.MainWindow.Output(string.Format("Language value was updated for symbol {0} in '..{1}'", this.symbolName, this.relativeFilePath));
        }
    }

    public enum GeometryTypes
    {
        Undefined,
        Point,
        Line,
        Area
    }
}
