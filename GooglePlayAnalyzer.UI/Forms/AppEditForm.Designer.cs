namespace GooglePlayAnalyzer.UI.Forms
{
    partial class AppEditForm
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
            labelName = new Label();
            labelCategory = new Label();
            labelRating = new Label();
            labelReviews = new Label();
            labelSize = new Label();
            label6 = new Label();
            labelType = new Label();
            labelPrice = new Label();
            labelContentRating = new Label();
            labelGenres = new Label();
            labelLastUpdated = new Label();
            labelCurrentVer = new Label();
            labelAndroidVer = new Label();
            textBoxName = new TextBox();
            textBoxCategory = new TextBox();
            textBoxRating = new TextBox();
            textBoxReviews = new TextBox();
            textBoxSize = new TextBox();
            textBoxInstalls = new TextBox();
            textBoxPrice = new TextBox();
            textBoxContentRating = new TextBox();
            textBoxGenres = new TextBox();
            textBoxCurrentVer = new TextBox();
            textBoxAndroidVer = new TextBox();
            dateTimePickerLastUpdated = new DateTimePicker();
            comboBoxType = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(6, 29);
            labelName.Name = "labelName";
            labelName.Size = new Size(51, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Назва";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(6, 71);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(76, 20);
            labelCategory.TabIndex = 1;
            labelCategory.Text = "Категорія";
            // 
            // labelRating
            // 
            labelRating.AutoSize = true;
            labelRating.Location = new Point(6, 23);
            labelRating.Name = "labelRating";
            labelRating.Size = new Size(64, 20);
            labelRating.TabIndex = 2;
            labelRating.Text = "Рейтинг";
            // 
            // labelReviews
            // 
            labelReviews.AutoSize = true;
            labelReviews.Location = new Point(6, 65);
            labelReviews.Name = "labelReviews";
            labelReviews.Size = new Size(126, 20);
            labelReviews.TabIndex = 3;
            labelReviews.Text = "Кількість відгуків";
            // 
            // labelSize
            // 
            labelSize.AutoSize = true;
            labelSize.Location = new Point(6, 105);
            labelSize.Name = "labelSize";
            labelSize.Size = new Size(57, 20);
            labelSize.TabIndex = 4;
            labelSize.Text = "Розмір";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 143);
            label6.Name = "label6";
            label6.Size = new Size(162, 20);
            label6.TabIndex = 5;
            label6.Text = "Кількість встановлень";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(6, 146);
            labelType.Name = "labelType";
            labelType.Size = new Size(35, 20);
            labelType.TabIndex = 6;
            labelType.Text = "Тип";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(6, 199);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(41, 20);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "Ціна";
            // 
            // labelContentRating
            // 
            labelContentRating.AutoSize = true;
            labelContentRating.Location = new Point(0, 248);
            labelContentRating.Name = "labelContentRating";
            labelContentRating.Size = new Size(124, 20);
            labelContentRating.TabIndex = 8;
            labelContentRating.Text = "Віковий рейтинг";
            // 
            // labelGenres
            // 
            labelGenres.AutoSize = true;
            labelGenres.Location = new Point(6, 108);
            labelGenres.Name = "labelGenres";
            labelGenres.Size = new Size(57, 20);
            labelGenres.TabIndex = 9;
            labelGenres.Text = "Жанри";
            // 
            // labelLastUpdated
            // 
            labelLastUpdated.AutoSize = true;
            labelLastUpdated.Location = new Point(10, 180);
            labelLastUpdated.Name = "labelLastUpdated";
            labelLastUpdated.Size = new Size(122, 20);
            labelLastUpdated.TabIndex = 10;
            labelLastUpdated.Text = "Дата оновлення";
            // 
            // labelCurrentVer
            // 
            labelCurrentVer.AutoSize = true;
            labelCurrentVer.Location = new Point(10, 226);
            labelCurrentVer.Name = "labelCurrentVer";
            labelCurrentVer.Size = new Size(117, 20);
            labelCurrentVer.TabIndex = 11;
            labelCurrentVer.Text = "Поточна версія";
            // 
            // labelAndroidVer
            // 
            labelAndroidVer.AutoSize = true;
            labelAndroidVer.Location = new Point(10, 268);
            labelAndroidVer.Name = "labelAndroidVer";
            labelAndroidVer.Size = new Size(112, 20);
            labelAndroidVer.TabIndex = 12;
            labelAndroidVer.Text = "Версія Android";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(67, 26);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(125, 27);
            textBoxName.TabIndex = 13;
            // 
            // textBoxCategory
            // 
            textBoxCategory.Location = new Point(88, 65);
            textBoxCategory.Name = "textBoxCategory";
            textBoxCategory.Size = new Size(125, 27);
            textBoxCategory.TabIndex = 15;
            // 
            // textBoxRating
            // 
            textBoxRating.Location = new Point(76, 20);
            textBoxRating.Name = "textBoxRating";
            textBoxRating.Size = new Size(125, 27);
            textBoxRating.TabIndex = 16;
            // 
            // textBoxReviews
            // 
            textBoxReviews.Location = new Point(138, 64);
            textBoxReviews.Name = "textBoxReviews";
            textBoxReviews.Size = new Size(125, 27);
            textBoxReviews.TabIndex = 17;
            // 
            // textBoxSize
            // 
            textBoxSize.Location = new Point(69, 102);
            textBoxSize.Name = "textBoxSize";
            textBoxSize.Size = new Size(125, 27);
            textBoxSize.TabIndex = 18;
            // 
            // textBoxInstalls
            // 
            textBoxInstalls.Location = new Point(175, 140);
            textBoxInstalls.Name = "textBoxInstalls";
            textBoxInstalls.Size = new Size(125, 27);
            textBoxInstalls.TabIndex = 19;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(53, 196);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(125, 27);
            textBoxPrice.TabIndex = 21;
            // 
            // textBoxContentRating
            // 
            textBoxContentRating.Location = new Point(130, 245);
            textBoxContentRating.Name = "textBoxContentRating";
            textBoxContentRating.Size = new Size(125, 27);
            textBoxContentRating.TabIndex = 22;
            // 
            // textBoxGenres
            // 
            textBoxGenres.Location = new Point(73, 105);
            textBoxGenres.Name = "textBoxGenres";
            textBoxGenres.Size = new Size(125, 27);
            textBoxGenres.TabIndex = 23;
            // 
            // textBoxCurrentVer
            // 
            textBoxCurrentVer.Location = new Point(133, 223);
            textBoxCurrentVer.Name = "textBoxCurrentVer";
            textBoxCurrentVer.Size = new Size(125, 27);
            textBoxCurrentVer.TabIndex = 24;
            // 
            // textBoxAndroidVer
            // 
            textBoxAndroidVer.Location = new Point(128, 268);
            textBoxAndroidVer.Name = "textBoxAndroidVer";
            textBoxAndroidVer.Size = new Size(125, 27);
            textBoxAndroidVer.TabIndex = 25;
            // 
            // dateTimePickerLastUpdated
            // 
            dateTimePickerLastUpdated.Location = new Point(138, 180);
            dateTimePickerLastUpdated.Name = "dateTimePickerLastUpdated";
            dateTimePickerLastUpdated.Size = new Size(185, 27);
            dateTimePickerLastUpdated.TabIndex = 26;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Free", "Paid" });
            comboBoxType.Location = new Point(47, 143);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(151, 28);
            comboBoxType.TabIndex = 27;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Gainsboro;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(213, 349);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(124, 48);
            buttonSave.TabIndex = 28;
            buttonSave.Text = "Зберегти";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Gainsboro;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(397, 349);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(124, 48);
            buttonCancel.TabIndex = 29;
            buttonCancel.Text = "Скасувати";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelName);
            groupBox1.Controls.Add(textBoxName);
            groupBox1.Controls.Add(labelCategory);
            groupBox1.Controls.Add(comboBoxType);
            groupBox1.Controls.Add(textBoxCategory);
            groupBox1.Controls.Add(textBoxContentRating);
            groupBox1.Controls.Add(textBoxPrice);
            groupBox1.Controls.Add(labelContentRating);
            groupBox1.Controls.Add(textBoxGenres);
            groupBox1.Controls.Add(labelType);
            groupBox1.Controls.Add(labelPrice);
            groupBox1.Controls.Add(labelGenres);
            groupBox1.Location = new Point(8, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(329, 331);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основна інформація ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelRating);
            groupBox2.Controls.Add(textBoxRating);
            groupBox2.Controls.Add(labelReviews);
            groupBox2.Controls.Add(textBoxReviews);
            groupBox2.Controls.Add(textBoxAndroidVer);
            groupBox2.Controls.Add(dateTimePickerLastUpdated);
            groupBox2.Controls.Add(labelAndroidVer);
            groupBox2.Controls.Add(textBoxCurrentVer);
            groupBox2.Controls.Add(labelSize);
            groupBox2.Controls.Add(textBoxSize);
            groupBox2.Controls.Add(labelCurrentVer);
            groupBox2.Controls.Add(textBoxInstalls);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(labelLastUpdated);
            groupBox2.Location = new Point(399, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(329, 331);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Метрики та версія";
            // 
            // AppEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 436);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            MaximizeBox = false;
            Name = "AppEditForm";
            Text = "AppEditForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelName;
        private Label labelCategory;
        private Label labelRating;
        private Label labelReviews;
        private Label labelSize;
        private Label label6;
        private Label labelType;
        private Label labelPrice;
        private Label labelContentRating;
        private Label labelGenres;
        private Label labelLastUpdated;
        private Label labelCurrentVer;
        private Label labelAndroidVer;
        private TextBox textBoxName;
        private TextBox textBoxCategory;
        private TextBox textBoxRating;
        private TextBox textBoxReviews;
        private TextBox textBoxSize;
        private TextBox textBoxInstalls;
        private TextBox textBoxPrice;
        private TextBox textBoxContentRating;
        private TextBox textBoxGenres;
        private TextBox textBoxCurrentVer;
        private TextBox textBoxAndroidVer;
        private DateTimePicker dateTimePickerLastUpdated;
        private ComboBox comboBoxType;
        private Button buttonSave;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}