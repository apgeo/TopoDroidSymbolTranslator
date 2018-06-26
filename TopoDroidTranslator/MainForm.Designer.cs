namespace TopoDroidTranslator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.relativeFilePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geometryTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedLangValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListTranslations = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OpenFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.symbolFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.langCodesComboBox = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.newLangTextBox = new System.Windows.Forms.TextBox();
            this.changeLangButton = new System.Windows.Forms.Button();
            this.updateFilesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.repositoryDirectoryLabel = new System.Windows.Forms.Label();
            this.symbolsRepFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.symbolInfoLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(1, 546);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(1417, 183);
            this.logTextBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relativeFilePathDataGridViewTextBoxColumn,
            this.geometryTypeDataGridViewTextBoxColumn,
            this.categoryTitleDataGridViewTextBoxColumn,
            this.symbolNameDataGridViewTextBoxColumn,
            this.selectedLangValueDataGridViewTextBoxColumn,
            this.ListTranslations,
            this.OpenFile});
            this.dataGridView1.DataSource = this.symbolFileBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1406, 419);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // relativeFilePathDataGridViewTextBoxColumn
            // 
            this.relativeFilePathDataGridViewTextBoxColumn.DataPropertyName = "RelativeFilePath";
            this.relativeFilePathDataGridViewTextBoxColumn.HeaderText = "Relative file path";
            this.relativeFilePathDataGridViewTextBoxColumn.Name = "relativeFilePathDataGridViewTextBoxColumn";
            this.relativeFilePathDataGridViewTextBoxColumn.ReadOnly = true;
            this.relativeFilePathDataGridViewTextBoxColumn.Width = 83;
            // 
            // geometryTypeDataGridViewTextBoxColumn
            // 
            this.geometryTypeDataGridViewTextBoxColumn.DataPropertyName = "GeometryType";
            this.geometryTypeDataGridViewTextBoxColumn.HeaderText = "Geometry type";
            this.geometryTypeDataGridViewTextBoxColumn.Name = "geometryTypeDataGridViewTextBoxColumn";
            this.geometryTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.geometryTypeDataGridViewTextBoxColumn.Width = 92;
            // 
            // categoryTitleDataGridViewTextBoxColumn
            // 
            this.categoryTitleDataGridViewTextBoxColumn.DataPropertyName = "CategoryTitle";
            this.categoryTitleDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryTitleDataGridViewTextBoxColumn.Name = "categoryTitleDataGridViewTextBoxColumn";
            this.categoryTitleDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryTitleDataGridViewTextBoxColumn.Width = 74;
            // 
            // symbolNameDataGridViewTextBoxColumn
            // 
            this.symbolNameDataGridViewTextBoxColumn.DataPropertyName = "SymbolName";
            this.symbolNameDataGridViewTextBoxColumn.HeaderText = "Symbol name";
            this.symbolNameDataGridViewTextBoxColumn.Name = "symbolNameDataGridViewTextBoxColumn";
            this.symbolNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.symbolNameDataGridViewTextBoxColumn.Width = 87;
            // 
            // selectedLangValueDataGridViewTextBoxColumn
            // 
            this.selectedLangValueDataGridViewTextBoxColumn.DataPropertyName = "SelectedLangValue";
            this.selectedLangValueDataGridViewTextBoxColumn.HeaderText = "Translated value";
            this.selectedLangValueDataGridViewTextBoxColumn.Name = "selectedLangValueDataGridViewTextBoxColumn";
            this.selectedLangValueDataGridViewTextBoxColumn.Width = 102;
            // 
            // ListTranslations
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.ListTranslations.DefaultCellStyle = dataGridViewCellStyle1;
            this.ListTranslations.HeaderText = "List info";
            this.ListTranslations.Name = "ListTranslations";
            this.ListTranslations.Text = "List";
            this.ListTranslations.Width = 44;
            // 
            // OpenFile
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            this.OpenFile.DefaultCellStyle = dataGridViewCellStyle2;
            this.OpenFile.HeaderText = "Open";
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Width = 39;
            // 
            // symbolFileBindingSource
            // 
            this.symbolFileBindingSource.DataSource = typeof(TopoDroidTranslator.SymbolFile);
            // 
            // langCodesComboBox
            // 
            this.langCodesComboBox.FormattingEnabled = true;
            this.langCodesComboBox.Location = new System.Drawing.Point(144, 35);
            this.langCodesComboBox.Name = "langCodesComboBox";
            this.langCodesComboBox.Size = new System.Drawing.Size(54, 21);
            this.langCodesComboBox.TabIndex = 2;
            this.langCodesComboBox.SelectedIndexChanged += new System.EventHandler(this.langCodesComboBox_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(108, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Existing language";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(24, 63);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(114, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Add new language";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // newLangTextBox
            // 
            this.newLangTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.newLangTextBox.Location = new System.Drawing.Point(144, 62);
            this.newLangTextBox.MaxLength = 2;
            this.newLangTextBox.Name = "newLangTextBox";
            this.newLangTextBox.Size = new System.Drawing.Size(54, 20);
            this.newLangTextBox.TabIndex = 5;
            // 
            // changeLangButton
            // 
            this.changeLangButton.Location = new System.Drawing.Point(204, 48);
            this.changeLangButton.Name = "changeLangButton";
            this.changeLangButton.Size = new System.Drawing.Size(108, 23);
            this.changeLangButton.TabIndex = 6;
            this.changeLangButton.Text = "Change language";
            this.changeLangButton.UseVisualStyleBackColor = true;
            this.changeLangButton.Click += new System.EventHandler(this.changeLangButton_Click);
            // 
            // updateFilesButton
            // 
            this.updateFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateFilesButton.Location = new System.Drawing.Point(1332, 83);
            this.updateFilesButton.Name = "updateFilesButton";
            this.updateFilesButton.Size = new System.Drawing.Size(75, 23);
            this.updateFilesButton.TabIndex = 7;
            this.updateFilesButton.Text = "Update files";
            this.updateFilesButton.UseVisualStyleBackColor = true;
            this.updateFilesButton.Click += new System.EventHandler(this.updateFilesButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Open directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // repositoryDirectoryLabel
            // 
            this.repositoryDirectoryLabel.AutoSize = true;
            this.repositoryDirectoryLabel.Location = new System.Drawing.Point(106, 11);
            this.repositoryDirectoryLabel.Name = "repositoryDirectoryLabel";
            this.repositoryDirectoryLabel.Size = new System.Drawing.Size(197, 13);
            this.repositoryDirectoryLabel.TabIndex = 9;
            this.repositoryDirectoryLabel.Text = "<no repository symbols directory loaded>";
            // 
            // symbolInfoLabel
            // 
            this.symbolInfoLabel.Location = new System.Drawing.Point(559, 6);
            this.symbolInfoLabel.Name = "symbolInfoLabel";
            this.symbolInfoLabel.Size = new System.Drawing.Size(424, 100);
            this.symbolInfoLabel.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1254, 716);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cave terms 1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(1329, 716);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(69, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Cave terms 2";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 732);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.symbolInfoLabel);
            this.Controls.Add(this.repositoryDirectoryLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.updateFilesButton);
            this.Controls.Add(this.changeLangButton);
            this.Controls.Add(this.newLangTextBox);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.langCodesComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.logTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolFileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox langCodesComboBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox newLangTextBox;
        private System.Windows.Forms.Button changeLangButton;
        private System.Windows.Forms.BindingSource symbolFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeFilePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn geometryTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedLangValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ListTranslations;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFile;
        private System.Windows.Forms.Button updateFilesButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label repositoryDirectoryLabel;
        private System.Windows.Forms.FolderBrowserDialog symbolsRepFolderBrowserDialog;
        private System.Windows.Forms.Label symbolInfoLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

