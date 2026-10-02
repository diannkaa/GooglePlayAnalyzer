namespace GooglePlayAnalyzer.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            dataGridViewApps = new DataGridView();
            labelMaxPrice = new Label();
            labelMinRating = new Label();
            textBoxMinRating = new TextBox();
            textBoxMaxPrice = new TextBox();
            buttonFilter = new Button();
            buttonResetFilter = new Button();
            labelSearchByName = new Label();
            labelResultsCount = new Label();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem1 = new ToolStripMenuItem();
            menuItemExportXlsxReport = new ToolStripMenuItem();
            menuItemExportDocxReport = new ToolStripMenuItem();
            ImportToolStripMenuItem = new ToolStripMenuItem();
            ExportXMLToolStripMenuItem = new ToolStripMenuItem();
            ExportJSONToolStripMenuItem = new ToolStripMenuItem();
            ExportXLSXToolStripMenuItem = new ToolStripMenuItem();
            ExportCSVToolStripMenuItem = new ToolStripMenuItem();
            buttonSortRating = new Button();
            buttonSortReviews = new Button();
            buttonSortPrice = new Button();
            groupBoxStatistics = new GroupBox();
            labelPaidApps = new Label();
            labelFreeApps = new Label();
            labelAveragePrice = new Label();
            labelMaxRating = new Label();
            labelAverageRating = new Label();
            labelTotalApps = new Label();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            groupBox1 = new GroupBox();
            labelSortBy = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApps).BeginInit();
            menuStrip1.SuspendLayout();
            groupBoxStatistics.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(146, 36);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(160, 27);
            textBoxSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.Gainsboro;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSearch.ForeColor = Color.Black;
            buttonSearch.Location = new Point(312, 35);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Знайти";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridViewApps
            // 
            dataGridViewApps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewApps.Location = new Point(173, 131);
            dataGridViewApps.Name = "dataGridViewApps";
            dataGridViewApps.RowHeadersWidth = 51;
            dataGridViewApps.Size = new Size(1010, 295);
            dataGridViewApps.TabIndex = 3;
            // 
            // labelMaxPrice
            // 
            labelMaxPrice.AutoSize = true;
            labelMaxPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelMaxPrice.Location = new Point(723, 40);
            labelMaxPrice.Name = "labelMaxPrice";
            labelMaxPrice.Size = new Size(142, 20);
            labelMaxPrice.TabIndex = 7;
            labelMaxPrice.Text = "Максимальна ціна:";
            // 
            // labelMinRating
            // 
            labelMinRating.AutoSize = true;
            labelMinRating.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelMinRating.Location = new Point(412, 40);
            labelMinRating.Name = "labelMinRating";
            labelMinRating.Size = new Size(164, 20);
            labelMinRating.TabIndex = 8;
            labelMinRating.Text = "Мінімальний рейтинг:";
            // 
            // textBoxMinRating
            // 
            textBoxMinRating.Location = new Point(871, 39);
            textBoxMinRating.Name = "textBoxMinRating";
            textBoxMinRating.Size = new Size(135, 27);
            textBoxMinRating.TabIndex = 9;
            // 
            // textBoxMaxPrice
            // 
            textBoxMaxPrice.Location = new Point(582, 39);
            textBoxMaxPrice.Name = "textBoxMaxPrice";
            textBoxMaxPrice.Size = new Size(135, 27);
            textBoxMaxPrice.TabIndex = 10;
            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = Color.Gainsboro;
            buttonFilter.FlatAppearance.BorderSize = 0;
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonFilter.Location = new Point(550, 80);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(211, 29);
            buttonFilter.TabIndex = 11;
            buttonFilter.Text = "Фільтрувати";
            buttonFilter.UseVisualStyleBackColor = false;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // buttonResetFilter
            // 
            buttonResetFilter.BackColor = Color.Gainsboro;
            buttonResetFilter.FlatAppearance.BorderSize = 0;
            buttonResetFilter.FlatStyle = FlatStyle.Flat;
            buttonResetFilter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonResetFilter.Location = new Point(795, 80);
            buttonResetFilter.Name = "buttonResetFilter";
            buttonResetFilter.Size = new Size(211, 29);
            buttonResetFilter.TabIndex = 12;
            buttonResetFilter.Text = "Скинути фільтри";
            buttonResetFilter.UseVisualStyleBackColor = false;
            buttonResetFilter.Click += buttonResetFilter_Click;
            // 
            // labelSearchByName
            // 
            labelSearchByName.AutoSize = true;
            labelSearchByName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSearchByName.Location = new Point(6, 36);
            labelSearchByName.Name = "labelSearchByName";
            labelSearchByName.Size = new Size(134, 20);
            labelSearchByName.TabIndex = 13;
            labelSearchByName.Text = "Пошук за назвою:";
            // 
            // labelResultsCount
            // 
            labelResultsCount.AutoSize = true;
            labelResultsCount.Location = new Point(1062, 443);
            labelResultsCount.Name = "labelResultsCount";
            labelResultsCount.Size = new Size(92, 20);
            labelResultsCount.TabIndex = 14;
            labelResultsCount.Text = "Знайдено: 0";
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(179, 535);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(307, 265);
            formsPlot1.TabIndex = 15;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Gainsboro;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, ImportToolStripMenuItem, ExportXMLToolStripMenuItem, ExportJSONToolStripMenuItem, ExportXLSXToolStripMenuItem, ExportCSVToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Margin = new Padding(2, 4, 10, 2);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 20, 6, 20);
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(173, 844);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { звітиToolStripMenuItem1 });
            файлToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            файлToolStripMenuItem.Size = new Size(144, 40);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // звітиToolStripMenuItem1
            // 
            звітиToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { menuItemExportXlsxReport, menuItemExportDocxReport });
            звітиToolStripMenuItem1.Name = "звітиToolStripMenuItem1";
            звітиToolStripMenuItem1.Size = new Size(127, 26);
            звітиToolStripMenuItem1.Text = "Звіти";
            // 
            // menuItemExportXlsxReport
            // 
            menuItemExportXlsxReport.Name = "menuItemExportXlsxReport";
            menuItemExportXlsxReport.Size = new Size(253, 26);
            menuItemExportXlsxReport.Text = "Згенерувати XLSX-звіт";
            menuItemExportXlsxReport.Click += menuItemExportXlsxReport_Click_1;
            // 
            // menuItemExportDocxReport
            // 
            menuItemExportDocxReport.Name = "menuItemExportDocxReport";
            menuItemExportDocxReport.Size = new Size(253, 26);
            menuItemExportDocxReport.Text = "Згенерувати DOCX-звіт";
            menuItemExportDocxReport.Click += menuItemExportDocxReport_Click_1;
            // 
            // ImportToolStripMenuItem
            // 
            ImportToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            ImportToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            ImportToolStripMenuItem.Size = new Size(144, 40);
            ImportToolStripMenuItem.Text = "Імпортувати";
            ImportToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
            // 
            // ExportXMLToolStripMenuItem
            // 
            ExportXMLToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            ExportXMLToolStripMenuItem.Name = "ExportXMLToolStripMenuItem";
            ExportXMLToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            ExportXMLToolStripMenuItem.Size = new Size(144, 40);
            ExportXMLToolStripMenuItem.Text = "Експортувати  XML";
            ExportXMLToolStripMenuItem.Click += ExportXMLToolStripMenuItem_Click;
            // 
            // ExportJSONToolStripMenuItem
            // 
            ExportJSONToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            ExportJSONToolStripMenuItem.Name = "ExportJSONToolStripMenuItem";
            ExportJSONToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            ExportJSONToolStripMenuItem.Size = new Size(144, 40);
            ExportJSONToolStripMenuItem.Text = "Експортувати JSON";
            ExportJSONToolStripMenuItem.Click += ExportJSONToolStripMenuItem_Click;
            // 
            // ExportXLSXToolStripMenuItem
            // 
            ExportXLSXToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            ExportXLSXToolStripMenuItem.Name = "ExportXLSXToolStripMenuItem";
            ExportXLSXToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            ExportXLSXToolStripMenuItem.Size = new Size(144, 40);
            ExportXLSXToolStripMenuItem.Text = "Експортувати XLSX";
            ExportXLSXToolStripMenuItem.Click += ExportXLSXToolStripMenuItem_Click;
            // 
            // ExportCSVToolStripMenuItem
            // 
            ExportCSVToolStripMenuItem.Margin = new Padding(2, 4, 2, 4);
            ExportCSVToolStripMenuItem.Name = "ExportCSVToolStripMenuItem";
            ExportCSVToolStripMenuItem.Padding = new Padding(6, 8, 6, 8);
            ExportCSVToolStripMenuItem.Size = new Size(144, 40);
            ExportCSVToolStripMenuItem.Text = "Експортувати CSV";
            ExportCSVToolStripMenuItem.Click += ExportCSVToolStripMenuItem_Click;
            // 
            // buttonSortRating
            // 
            buttonSortRating.BackColor = Color.Gainsboro;
            buttonSortRating.FlatAppearance.BorderSize = 0;
            buttonSortRating.FlatStyle = FlatStyle.Flat;
            buttonSortRating.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSortRating.Location = new Point(257, 80);
            buttonSortRating.Name = "buttonSortRating";
            buttonSortRating.Size = new Size(137, 29);
            buttonSortRating.TabIndex = 17;
            buttonSortRating.Text = "Рейтингом";
            buttonSortRating.UseVisualStyleBackColor = false;
            buttonSortRating.Click += buttonSortRating_Click;
            // 
            // buttonSortReviews
            // 
            buttonSortReviews.BackColor = Color.Gainsboro;
            buttonSortReviews.FlatAppearance.BorderSize = 0;
            buttonSortReviews.FlatStyle = FlatStyle.Flat;
            buttonSortReviews.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSortReviews.Location = new Point(114, 80);
            buttonSortReviews.Name = "buttonSortReviews";
            buttonSortReviews.Size = new Size(137, 29);
            buttonSortReviews.TabIndex = 18;
            buttonSortReviews.Text = "Відгуками";
            buttonSortReviews.UseVisualStyleBackColor = false;
            buttonSortReviews.Click += buttonSortReviews_Click;
            // 
            // buttonSortPrice
            // 
            buttonSortPrice.BackColor = Color.Gainsboro;
            buttonSortPrice.FlatAppearance.BorderSize = 0;
            buttonSortPrice.FlatStyle = FlatStyle.Flat;
            buttonSortPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSortPrice.Location = new Point(400, 80);
            buttonSortPrice.Name = "buttonSortPrice";
            buttonSortPrice.Size = new Size(137, 29);
            buttonSortPrice.TabIndex = 19;
            buttonSortPrice.Text = "Ціною";
            buttonSortPrice.UseVisualStyleBackColor = false;
            buttonSortPrice.Click += buttonSortPrice_Click;
            // 
            // groupBoxStatistics
            // 
            groupBoxStatistics.Controls.Add(labelPaidApps);
            groupBoxStatistics.Controls.Add(labelFreeApps);
            groupBoxStatistics.Controls.Add(labelAveragePrice);
            groupBoxStatistics.Controls.Add(labelMaxRating);
            groupBoxStatistics.Controls.Add(labelAverageRating);
            groupBoxStatistics.Controls.Add(labelTotalApps);
            groupBoxStatistics.Location = new Point(876, 535);
            groupBoxStatistics.Name = "groupBoxStatistics";
            groupBoxStatistics.Size = new Size(307, 265);
            groupBoxStatistics.TabIndex = 20;
            groupBoxStatistics.TabStop = false;
            groupBoxStatistics.Text = "Статистика";
            // 
            // labelPaidApps
            // 
            labelPaidApps.AutoSize = true;
            labelPaidApps.Location = new Point(11, 205);
            labelPaidApps.Name = "labelPaidApps";
            labelPaidApps.Size = new Size(82, 20);
            labelPaidApps.TabIndex = 5;
            labelPaidApps.Text = "Платних: 0";
            // 
            // labelFreeApps
            // 
            labelFreeApps.AutoSize = true;
            labelFreeApps.Location = new Point(11, 175);
            labelFreeApps.Name = "labelFreeApps";
            labelFreeApps.Size = new Size(124, 20);
            labelFreeApps.TabIndex = 4;
            labelFreeApps.Text = "Безкоштовних: 0";
            // 
            // labelAveragePrice
            // 
            labelAveragePrice.AutoSize = true;
            labelAveragePrice.Location = new Point(11, 140);
            labelAveragePrice.Name = "labelAveragePrice";
            labelAveragePrice.Size = new Size(117, 20);
            labelAveragePrice.TabIndex = 3;
            labelAveragePrice.Text = "Середня ціна: 0";
            // 
            // labelMaxRating
            // 
            labelMaxRating.AutoSize = true;
            labelMaxRating.Location = new Point(11, 105);
            labelMaxRating.Name = "labelMaxRating";
            labelMaxRating.Size = new Size(190, 20);
            labelMaxRating.TabIndex = 2;
            labelMaxRating.Text = "Максимальний рейтинг: 0";
            // 
            // labelAverageRating
            // 
            labelAverageRating.AutoSize = true;
            labelAverageRating.Location = new Point(11, 72);
            labelAverageRating.Name = "labelAverageRating";
            labelAverageRating.Size = new Size(148, 20);
            labelAverageRating.TabIndex = 1;
            labelAverageRating.Text = "Середній рейтинг: 0";
            // 
            // labelTotalApps
            // 
            labelTotalApps.AutoSize = true;
            labelTotalApps.Location = new Point(11, 39);
            labelTotalApps.Name = "labelTotalApps";
            labelTotalApps.Size = new Size(155, 20);
            labelTotalApps.TabIndex = 0;
            labelTotalApps.Text = "Всього застосунків: 0";
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(526, 535);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(307, 265);
            formsPlot2.TabIndex = 25;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.Gainsboro;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Location = new Point(179, 443);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(123, 48);
            buttonAdd.TabIndex = 26;
            buttonAdd.Text = "Додати";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.Gainsboro;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Location = new Point(337, 443);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(123, 48);
            buttonEdit.TabIndex = 27;
            buttonEdit.Text = "Редагувати";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Gainsboro;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Location = new Point(503, 443);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(123, 48);
            buttonDelete.TabIndex = 28;
            buttonDelete.Text = "Видалити ";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelSortBy);
            groupBox1.Controls.Add(labelSearchByName);
            groupBox1.Controls.Add(textBoxSearch);
            groupBox1.Controls.Add(buttonSearch);
            groupBox1.Controls.Add(labelMinRating);
            groupBox1.Controls.Add(textBoxMaxPrice);
            groupBox1.Controls.Add(buttonSortPrice);
            groupBox1.Controls.Add(labelMaxPrice);
            groupBox1.Controls.Add(buttonResetFilter);
            groupBox1.Controls.Add(buttonSortRating);
            groupBox1.Controls.Add(buttonFilter);
            groupBox1.Controls.Add(buttonSortReviews);
            groupBox1.Controls.Add(textBoxMinRating);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(173, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1010, 125);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фільтрація та пошук";
            // 
            // labelSortBy
            // 
            labelSortBy.AutoSize = true;
            labelSortBy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSortBy.Location = new Point(6, 84);
            labelSortBy.Name = "labelSortBy";
            labelSortBy.Size = new Size(102, 20);
            labelSortBy.TabIndex = 14;
            labelSortBy.Text = "Сортувати за:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 844);
            Controls.Add(groupBox1);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(formsPlot2);
            Controls.Add(groupBoxStatistics);
            Controls.Add(formsPlot1);
            Controls.Add(labelResultsCount);
            Controls.Add(dataGridViewApps);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewApps).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBoxStatistics.ResumeLayout(false);
            groupBoxStatistics.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private DataGridView dataGridViewApps;
        private Label labelMaxPrice;
        private Label labelMinRating;
        private TextBox textBoxMinRating;
        private TextBox textBoxMaxPrice;
        private Button buttonFilter;
        private Button buttonResetFilter;
        private Label labelSearchByName;
        private Label labelResultsCount;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem звітиToolStripMenuItem1;
        private ToolStripMenuItem menuItemExportXlsxReport;
        private ToolStripMenuItem menuItemExportDocxReport;
        private Button buttonSortRating;
        private Button buttonSortReviews;
        private Button buttonSortPrice;
        private GroupBox groupBoxStatistics;
        private Label labelPaidApps;
        private Label labelFreeApps;
        private Label labelAveragePrice;
        private Label labelMaxRating;
        private Label labelAverageRating;
        private Label labelTotalApps;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private ToolStripMenuItem ExportXMLToolStripMenuItem;
        private ToolStripMenuItem ExportJSONToolStripMenuItem;
        private ToolStripMenuItem ExportXLSXToolStripMenuItem;
        private ToolStripMenuItem ExportCSVToolStripMenuItem;
        private GroupBox groupBox1;
        private Label labelSortBy;
        private ToolStripMenuItem ImportToolStripMenuItem;
    }
}
