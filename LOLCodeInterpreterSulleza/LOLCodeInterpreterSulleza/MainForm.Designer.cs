namespace LOLCodeInterpreterSulleza
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.codeTextBox = new System.Windows.Forms.RichTextBox();
            this.lexemeGridView = new System.Windows.Forms.DataGridView();
            this.keyWordCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classificationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executeButton = new System.Windows.Forms.Button();
            this.symbolTableGridView = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            consoleTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lexemeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolTableGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openFileButton.Location = new System.Drawing.Point(12, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(12, 41);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(195, 232);
            this.codeTextBox.TabIndex = 1;
            this.codeTextBox.Text = "";
            this.codeTextBox.WordWrap = false;
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // lexemeGridView
            // 
            this.lexemeGridView.AllowUserToAddRows = false;
            this.lexemeGridView.AllowUserToDeleteRows = false;
            this.lexemeGridView.AllowUserToResizeColumns = false;
            this.lexemeGridView.AllowUserToResizeRows = false;
            this.lexemeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyWordCol,
            this.classificationCol});
            this.lexemeGridView.Location = new System.Drawing.Point(241, 41);
            this.lexemeGridView.Name = "lexemeGridView";
            this.lexemeGridView.ReadOnly = true;
            this.lexemeGridView.RowHeadersVisible = false;
            this.lexemeGridView.RowHeadersWidth = 50;
            this.lexemeGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lexemeGridView.Size = new System.Drawing.Size(274, 175);
            this.lexemeGridView.TabIndex = 2;
            // 
            // keyWordCol
            // 
            this.keyWordCol.HeaderText = "Lexemes";
            this.keyWordCol.Name = "keyWordCol";
            this.keyWordCol.ReadOnly = true;
            this.keyWordCol.Width = 120;
            // 
            // classificationCol
            // 
            this.classificationCol.HeaderText = "Classification";
            this.classificationCol.Name = "classificationCol";
            this.classificationCol.ReadOnly = true;
            this.classificationCol.Width = 150;
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.executeButton.Location = new System.Drawing.Point(241, 222);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(274, 51);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // symbolTableGridView
            // 
            this.symbolTableGridView.AllowUserToAddRows = false;
            this.symbolTableGridView.AllowUserToDeleteRows = false;
            this.symbolTableGridView.AllowUserToResizeColumns = false;
            this.symbolTableGridView.AllowUserToResizeRows = false;
            this.symbolTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symbolTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.valueCol});
            this.symbolTableGridView.Location = new System.Drawing.Point(521, 41);
            this.symbolTableGridView.Name = "symbolTableGridView";
            this.symbolTableGridView.RowHeadersVisible = false;
            this.symbolTableGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.symbolTableGridView.Size = new System.Drawing.Size(243, 175);
            this.symbolTableGridView.TabIndex = 4;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nameCol.Width = 120;
            // 
            // valueCol
            // 
            this.valueCol.HeaderText = "Value";
            this.valueCol.Name = "valueCol";
            this.valueCol.ReadOnly = true;
            this.valueCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.valueCol.Width = 120;
            // 
            // consoleTextBox
            // 
            consoleTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            consoleTextBox.ForeColor = System.Drawing.SystemColors.Info;
            consoleTextBox.Location = new System.Drawing.Point(12, 279);
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ReadOnly = true;
            consoleTextBox.Size = new System.Drawing.Size(752, 226);
            consoleTextBox.TabIndex = 5;
            consoleTextBox.Text = "";
            consoleTextBox.TextChanged += new System.EventHandler(consoleTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 517);
            this.Controls.Add(consoleTextBox);
            this.Controls.Add(this.symbolTableGridView);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.lexemeGridView);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.openFileButton);
            this.Name = "MainForm";
            this.Text = "LOLterpreter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lexemeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolTableGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox codeTextBox;
        private System.Windows.Forms.DataGridView lexemeGridView;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyWordCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn classificationCol;
        private System.Windows.Forms.DataGridView symbolTableGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCol;
        public static System.Windows.Forms.RichTextBox consoleTextBox;
    }
}

