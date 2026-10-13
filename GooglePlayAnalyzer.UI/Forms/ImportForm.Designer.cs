namespace GooglePlayAnalyzer.UI.Forms
{
    partial class ImportForm
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
            buttonSelectFile = new Button();
            buttonImport = new Button();
            labelFile = new Label();
            labelInfo = new Label();
            labelResult = new Label();
            dataGridViewErrors = new DataGridView();
            dataGridViewApps = new DataGridView();
            buttonClose = new Button();
            labelEmptyValues = new Label();
            labelFieldTypes = new Label();
            labelColumnCount = new Label();
            labelRowCount = new Label();
            comboBoxDelimiter = new ComboBox();
            comboBoxEncoding = new ComboBox();
            comboBoxNumberFormat = new ComboBox();
            comboBoxDateFormat = new ComboBox();
            checkBoxHasHeader = new CheckBox();
            buttonPreview = new Button();
            labelDelimiter = new Label();
            labelEncoding = new Label();
            labelNumberFormat = new Label();
            labelDateFormat = new Label();
            labelErrors = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridViewErrors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApps).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSelectFile
            // 
            buttonSelectFile.BackColor = Color.Gainsboro;
            buttonSelectFile.FlatAppearance.BorderSize = 0;
            buttonSelectFile.FlatStyle = FlatStyle.Flat;
            buttonSelectFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSelectFile.Location = new Point(3, 41);
            buttonSelectFile.Name = "buttonSelectFile";
            buttonSelectFile.Size = new Size(156, 29);
            buttonSelectFile.TabIndex = 0;
            buttonSelectFile.Text = "Вибрати файл";
            buttonSelectFile.UseVisualStyleBackColor = false;
            buttonSelectFile.Click += buttonSelectFile_Click;
            // 
            // buttonImport
            // 
            buttonImport.BackColor = Color.Gainsboro;
            buttonImport.FlatAppearance.BorderSize = 0;
            buttonImport.FlatStyle = FlatStyle.Flat;
            buttonImport.Location = new Point(399, 488);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(144, 42);
            buttonImport.TabIndex = 1;
            buttonImport.Text = "Імпортувати";
            buttonImport.UseVisualStyleBackColor = false;
            buttonImport.Click += buttonImport_Click;
            // 
            // labelFile
            // 
            labelFile.AutoSize = true;
            labelFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelFile.Location = new Point(165, 45);
            labelFile.Name = "labelFile";
            labelFile.Size = new Size(131, 20);
            labelFile.TabIndex = 2;
            labelFile.Text = "Файл не вибрано";
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(6, 108);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(160, 20);
            labelInfo.TabIndex = 3;
            labelInfo.Text = "Інформація про файл";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(6, 72);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(143, 20);
            labelResult.TabIndex = 4;
            labelResult.Text = "Результати імпорту";
            // 
            // dataGridViewErrors
            // 
            dataGridViewErrors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewErrors.Dock = DockStyle.Fill;
            dataGridViewErrors.Location = new Point(3, 3);
            dataGridViewErrors.Name = "dataGridViewErrors";
            dataGridViewErrors.RowHeadersWidth = 51;
            dataGridViewErrors.Size = new Size(1047, 530);
            dataGridViewErrors.TabIndex = 5;
            // 
            // dataGridViewApps
            // 
            dataGridViewApps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewApps.Location = new Point(3, 154);
            dataGridViewApps.Name = "dataGridViewApps";
            dataGridViewApps.RowHeadersWidth = 51;
            dataGridViewApps.Size = new Size(763, 328);
            dataGridViewApps.TabIndex = 6;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Gainsboro;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(181, 488);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(144, 42);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Закрити";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelEmptyValues
            // 
            labelEmptyValues.AutoSize = true;
            labelEmptyValues.Location = new Point(249, 57);
            labelEmptyValues.Name = "labelEmptyValues";
            labelEmptyValues.Size = new Size(142, 20);
            labelEmptyValues.TabIndex = 8;
            labelEmptyValues.Text = "Порожніх значень:";
            // 
            // labelFieldTypes
            // 
            labelFieldTypes.AutoSize = true;
            labelFieldTypes.Location = new Point(784, 154);
            labelFieldTypes.Name = "labelFieldTypes";
            labelFieldTypes.Size = new Size(89, 20);
            labelFieldTypes.TabIndex = 9;
            labelFieldTypes.Text = "Типи полів:";
            // 
            // labelColumnCount
            // 
            labelColumnCount.AutoSize = true;
            labelColumnCount.Location = new Point(484, 24);
            labelColumnCount.Name = "labelColumnCount";
            labelColumnCount.Size = new Size(84, 20);
            labelColumnCount.TabIndex = 10;
            labelColumnCount.Text = "Колонок: 0";
            // 
            // labelRowCount
            // 
            labelRowCount.AutoSize = true;
            labelRowCount.Location = new Point(249, 24);
            labelRowCount.Name = "labelRowCount";
            labelRowCount.Size = new Size(67, 20);
            labelRowCount.TabIndex = 11;
            labelRowCount.Text = "Рядків: 0";
            // 
            // comboBoxDelimiter
            // 
            comboBoxDelimiter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDelimiter.FormattingEnabled = true;
            comboBoxDelimiter.Items.AddRange(new object[] { ",", "", ";", "TAB", "", "|" });
            comboBoxDelimiter.Location = new Point(101, 30);
            comboBoxDelimiter.Name = "comboBoxDelimiter";
            comboBoxDelimiter.Size = new Size(151, 28);
            comboBoxDelimiter.TabIndex = 12;
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Items.AddRange(new object[] { "UTF-8", "", "Windows-1251", "", "Unicode" });
            comboBoxEncoding.Location = new Point(396, 30);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(151, 28);
            comboBoxEncoding.TabIndex = 13;
            // 
            // comboBoxNumberFormat
            // 
            comboBoxNumberFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNumberFormat.FormattingEnabled = true;
            comboBoxNumberFormat.Items.AddRange(new object[] { "1.23", "", "1,23" });
            comboBoxNumberFormat.Location = new Point(66, 75);
            comboBoxNumberFormat.Name = "comboBoxNumberFormat";
            comboBoxNumberFormat.Size = new Size(151, 28);
            comboBoxNumberFormat.TabIndex = 14;
            // 
            // comboBoxDateFormat
            // 
            comboBoxDateFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDateFormat.FormattingEnabled = true;
            comboBoxDateFormat.Items.AddRange(new object[] { "yyyy-MM-dd", "", "dd.MM.yyyy", "", "MM/dd/yyyy" });
            comboBoxDateFormat.Location = new Point(357, 72);
            comboBoxDateFormat.Name = "comboBoxDateFormat";
            comboBoxDateFormat.Size = new Size(151, 28);
            comboBoxDateFormat.TabIndex = 15;
            // 
            // checkBoxHasHeader
            // 
            checkBoxHasHeader.AutoSize = true;
            checkBoxHasHeader.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBoxHasHeader.Location = new Point(6, 109);
            checkBoxHasHeader.Name = "checkBoxHasHeader";
            checkBoxHasHeader.Size = new Size(264, 24);
            checkBoxHasHeader.TabIndex = 16;
            checkBoxHasHeader.Text = "Перший рядок містить заголовки";
            checkBoxHasHeader.UseVisualStyleBackColor = true;
            // 
            // buttonPreview
            // 
            buttonPreview.BackColor = Color.Gainsboro;
            buttonPreview.FlatAppearance.BorderSize = 0;
            buttonPreview.FlatStyle = FlatStyle.Flat;
            buttonPreview.Location = new Point(6, 24);
            buttonPreview.Name = "buttonPreview";
            buttonPreview.Size = new Size(190, 29);
            buttonPreview.TabIndex = 17;
            buttonPreview.Text = "Попередній перегляд";
            buttonPreview.UseVisualStyleBackColor = false;
            // 
            // labelDelimiter
            // 
            labelDelimiter.AutoSize = true;
            labelDelimiter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDelimiter.Location = new Point(6, 33);
            labelDelimiter.Name = "labelDelimiter";
            labelDelimiter.Size = new Size(89, 20);
            labelDelimiter.TabIndex = 18;
            labelDelimiter.Text = "Роздільник:";
            // 
            // labelEncoding
            // 
            labelEncoding.AutoSize = true;
            labelEncoding.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelEncoding.Location = new Point(303, 33);
            labelEncoding.Name = "labelEncoding";
            labelEncoding.Size = new Size(87, 20);
            labelEncoding.TabIndex = 19;
            labelEncoding.Text = "Кодування:";
            // 
            // labelNumberFormat
            // 
            labelNumberFormat.AutoSize = true;
            labelNumberFormat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelNumberFormat.Location = new Point(6, 78);
            labelNumberFormat.Name = "labelNumberFormat";
            labelNumberFormat.Size = new Size(54, 20);
            labelNumberFormat.TabIndex = 20;
            labelNumberFormat.Text = "Числа:";
            // 
            // labelDateFormat
            // 
            labelDateFormat.AutoSize = true;
            labelDateFormat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDateFormat.Location = new Point(303, 75);
            labelDateFormat.Name = "labelDateFormat";
            labelDateFormat.Size = new Size(44, 20);
            labelDateFormat.TabIndex = 21;
            labelDateFormat.Text = "Дата:";
            // 
            // labelErrors
            // 
            labelErrors.AutoSize = true;
            labelErrors.Location = new Point(20, 29);
            labelErrors.Name = "labelErrors";
            labelErrors.Size = new Size(76, 20);
            labelErrors.TabIndex = 22;
            labelErrors.Text = "Помилки:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSelectFile);
            groupBox1.Controls.Add(labelFile);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(9, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1061, 125);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Вибір файлу";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelDelimiter);
            groupBox2.Controls.Add(comboBoxDelimiter);
            groupBox2.Controls.Add(labelEncoding);
            groupBox2.Controls.Add(labelDateFormat);
            groupBox2.Controls.Add(checkBoxHasHeader);
            groupBox2.Controls.Add(comboBoxEncoding);
            groupBox2.Controls.Add(comboBoxDateFormat);
            groupBox2.Controls.Add(labelNumberFormat);
            groupBox2.Controls.Add(comboBoxNumberFormat);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(9, 155);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1057, 168);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметри імпорту";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(9, 334);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1061, 569);
            tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonPreview);
            tabPage1.Controls.Add(labelResult);
            tabPage1.Controls.Add(dataGridViewApps);
            tabPage1.Controls.Add(labelInfo);
            tabPage1.Controls.Add(buttonImport);
            tabPage1.Controls.Add(buttonClose);
            tabPage1.Controls.Add(labelRowCount);
            tabPage1.Controls.Add(labelFieldTypes);
            tabPage1.Controls.Add(labelColumnCount);
            tabPage1.Controls.Add(labelEmptyValues);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1053, 536);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Перегляд таблиці";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewErrors);
            tabPage2.Controls.Add(labelErrors);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1053, 536);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Помилки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 906);
            Controls.Add(tabControl1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "ImportForm";
            Text = "ImportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewErrors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApps).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSelectFile;
        private Button buttonImport;
        private Label labelFile;
        private Label labelInfo;
        private Label labelResult;
        private DataGridView dataGridViewErrors;
        private DataGridView dataGridViewApps;
        private Button buttonClose;
        private Label labelEmptyValues;
        private Label labelFieldTypes;
        private Label labelColumnCount;
        private Label labelRowCount;
        private ComboBox comboBoxDelimiter;
        private ComboBox comboBoxEncoding;
        private ComboBox comboBoxNumberFormat;
        private ComboBox comboBoxDateFormat;
        private CheckBox checkBoxHasHeader;
        private Button buttonPreview;
        private Label labelDelimiter;
        private Label labelEncoding;
        private Label labelNumberFormat;
        private Label labelDateFormat;
        private Label labelErrors;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}