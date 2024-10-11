namespace WindowsFormsApp5
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            productName = new System.Windows.Forms.TextBox();
            createBtn = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            stockQuantity = new System.Windows.Forms.TextBox();
            description = new System.Windows.Forms.TextBox();
            price = new System.Windows.Forms.TextBox();
            saveCreateBtn = new System.Windows.Forms.Button();
            categoryDTOBindingSource = new System.Windows.Forms.BindingSource(components);
            searchBtn = new System.Windows.Forms.Button();
            searchedProdName = new System.Windows.Forms.TextBox();
            searchAllBtn = new System.Windows.Forms.Button();
            deleteBtn = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            updateQuantTxt = new System.Windows.Forms.TextBox();
            updateDescTxt = new System.Windows.Forms.TextBox();
            updatePriceTxt = new System.Windows.Forms.TextBox();
            saveUpdatebtn = new System.Windows.Forms.Button();
            updateNameTxt = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            dataGridViewCategories = new System.Windows.Forms.DataGridView();
            searchByCatbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoryDTOBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(22, 16);
            dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new System.Drawing.Size(747, 252);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // productName
            // 
            productName.Location = new System.Drawing.Point(150, 23);
            productName.Name = "productName";
            productName.Size = new System.Drawing.Size(125, 27);
            productName.TabIndex = 1;
            // 
            // createBtn
            // 
            createBtn.Location = new System.Drawing.Point(144, 584);
            createBtn.Name = "createBtn";
            createBtn.Size = new System.Drawing.Size(196, 29);
            createBtn.TabIndex = 2;
            createBtn.Text = "CREATE PRODUCT";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(stockQuantity);
            groupBox1.Controls.Add(description);
            groupBox1.Controls.Add(price);
            groupBox1.Controls.Add(saveCreateBtn);
            groupBox1.Controls.Add(productName);
            groupBox1.Enabled = false;
            groupBox1.Location = new System.Drawing.Point(22, 316);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(486, 262);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "CREATE NEW PRODUCT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(41, 198);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(103, 20);
            label4.TabIndex = 4;
            label4.Text = "Stock quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 89);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(138, 20);
            label3.TabIndex = 10;
            label3.Text = "Product description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(47, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(97, 20);
            label2.TabIndex = 9;
            label2.Text = "Product price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(43, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 20);
            label1.TabIndex = 8;
            label1.Text = "Product name";
            // 
            // stockQuantity
            // 
            stockQuantity.Location = new System.Drawing.Point(150, 191);
            stockQuantity.Name = "stockQuantity";
            stockQuantity.Size = new System.Drawing.Size(125, 27);
            stockQuantity.TabIndex = 7;
            // 
            // description
            // 
            description.Location = new System.Drawing.Point(150, 86);
            description.Multiline = true;
            description.Name = "description";
            description.Size = new System.Drawing.Size(312, 99);
            description.TabIndex = 6;
            // 
            // price
            // 
            price.Location = new System.Drawing.Point(150, 53);
            price.Name = "price";
            price.Size = new System.Drawing.Size(125, 27);
            price.TabIndex = 5;
            // 
            // saveCreateBtn
            // 
            saveCreateBtn.Location = new System.Drawing.Point(332, 214);
            saveCreateBtn.Name = "saveCreateBtn";
            saveCreateBtn.Size = new System.Drawing.Size(94, 29);
            saveCreateBtn.TabIndex = 4;
            saveCreateBtn.Text = "SAVE";
            saveCreateBtn.UseVisualStyleBackColor = true;
            saveCreateBtn.Click += saveCreateBtn_Click;
            // 
            // categoryDTOBindingSource
            // 
            categoryDTOBindingSource.DataSource = typeof(Core.DTOs.CategoryDTO);
            // 
            // searchBtn
            // 
            searchBtn.Location = new System.Drawing.Point(1220, 50);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new System.Drawing.Size(249, 29);
            searchBtn.TabIndex = 4;
            searchBtn.Text = "SEARCH PRODUCT BY NAME";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchedProdName
            // 
            searchedProdName.Location = new System.Drawing.Point(1220, 16);
            searchedProdName.Name = "searchedProdName";
            searchedProdName.Size = new System.Drawing.Size(249, 27);
            searchedProdName.TabIndex = 5;
            // 
            // searchAllBtn
            // 
            searchAllBtn.Location = new System.Drawing.Point(1243, 119);
            searchAllBtn.Name = "searchAllBtn";
            searchAllBtn.Size = new System.Drawing.Size(193, 29);
            searchAllBtn.TabIndex = 6;
            searchAllBtn.Text = "SEARCH ALL";
            searchAllBtn.UseVisualStyleBackColor = true;
            searchAllBtn.Click += searchAllBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new System.Drawing.Point(777, 239);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new System.Drawing.Size(249, 29);
            deleteBtn.TabIndex = 7;
            deleteBtn.Text = "DELETE SELECTED PRODUCT";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(updateQuantTxt);
            groupBox2.Controls.Add(updateDescTxt);
            groupBox2.Controls.Add(updatePriceTxt);
            groupBox2.Controls.Add(saveUpdatebtn);
            groupBox2.Controls.Add(updateNameTxt);
            groupBox2.Enabled = false;
            groupBox2.Location = new System.Drawing.Point(950, 316);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(486, 262);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "UPDATE PRODUCT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(41, 198);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Stock quantity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 89);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(138, 20);
            label6.TabIndex = 10;
            label6.Text = "Product description";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(47, 56);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(97, 20);
            label7.TabIndex = 9;
            label7.Text = "Product price";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(43, 26);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(101, 20);
            label8.TabIndex = 8;
            label8.Text = "Product name";
            // 
            // updateQuantTxt
            // 
            updateQuantTxt.Location = new System.Drawing.Point(150, 191);
            updateQuantTxt.Name = "updateQuantTxt";
            updateQuantTxt.Size = new System.Drawing.Size(125, 27);
            updateQuantTxt.TabIndex = 7;
            // 
            // updateDescTxt
            // 
            updateDescTxt.Location = new System.Drawing.Point(150, 86);
            updateDescTxt.Multiline = true;
            updateDescTxt.Name = "updateDescTxt";
            updateDescTxt.Size = new System.Drawing.Size(312, 99);
            updateDescTxt.TabIndex = 6;
            // 
            // updatePriceTxt
            // 
            updatePriceTxt.Location = new System.Drawing.Point(150, 53);
            updatePriceTxt.Name = "updatePriceTxt";
            updatePriceTxt.Size = new System.Drawing.Size(125, 27);
            updatePriceTxt.TabIndex = 5;
            // 
            // saveUpdatebtn
            // 
            saveUpdatebtn.Location = new System.Drawing.Point(332, 214);
            saveUpdatebtn.Name = "saveUpdatebtn";
            saveUpdatebtn.Size = new System.Drawing.Size(94, 29);
            saveUpdatebtn.TabIndex = 4;
            saveUpdatebtn.Text = "SAVE";
            saveUpdatebtn.UseVisualStyleBackColor = true;
            saveUpdatebtn.Click += saveUpdatebtn_Click;
            // 
            // updateNameTxt
            // 
            updateNameTxt.Location = new System.Drawing.Point(150, 23);
            updateNameTxt.Name = "updateNameTxt";
            updateNameTxt.Size = new System.Drawing.Size(125, 27);
            updateNameTxt.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(1110, 584);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(181, 29);
            button2.TabIndex = 11;
            button2.Text = "UPDATE PRODUCT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridViewCategories
            // 
            dataGridViewCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Location = new System.Drawing.Point(775, 16);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.RowHeadersWidth = 51;
            dataGridViewCategories.RowTemplate.Height = 29;
            dataGridViewCategories.Size = new System.Drawing.Size(421, 198);
            dataGridViewCategories.TabIndex = 12;
            dataGridViewCategories.SelectionChanged += dataGridViewCategories_SelectionChanged;
            // 
            // searchByCatbtn
            // 
            searchByCatbtn.Location = new System.Drawing.Point(1220, 85);
            searchByCatbtn.Name = "searchByCatbtn";
            searchByCatbtn.Size = new System.Drawing.Size(249, 28);
            searchByCatbtn.TabIndex = 13;
            searchByCatbtn.Text = "SEARCH BY CATEGORY";
            searchByCatbtn.UseVisualStyleBackColor = true;
            searchByCatbtn.Click += searchByCatbtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1492, 675);
            Controls.Add(searchByCatbtn);
            Controls.Add(dataGridViewCategories);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(deleteBtn);
            Controls.Add(searchAllBtn);
            Controls.Add(searchedProdName);
            Controls.Add(searchBtn);
            Controls.Add(groupBox1);
            Controls.Add(createBtn);
            Controls.Add(dataGridView1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoryDTOBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveCreateBtn;
#pragma warning disable CS0169 // The field 'Form1.textBox4' is never used
        private System.Windows.Forms.TextBox textBox4;
#pragma warning restore CS0169 // The field 'Form1.textBox4' is never used
        private System.Windows.Forms.TextBox stockQuantity;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchedProdName;
        private System.Windows.Forms.Button searchAllBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox updateQuantTxt;
        private System.Windows.Forms.TextBox updateDescTxt;
        private System.Windows.Forms.TextBox updatePriceTxt;
        private System.Windows.Forms.Button saveUpdatebtn;
        private System.Windows.Forms.TextBox updateNameTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewCategories;
        private System.Windows.Forms.Button searchByCatbtn;
        private System.Windows.Forms.BindingSource categoryDTOBindingSource;
    }
}

