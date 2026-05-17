namespace LibraryClient
{
    partial class AddEditBookForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle     = new System.Windows.Forms.Label();
            this.txtTitle     = new System.Windows.Forms.TextBox();
            this.lblAuthor    = new System.Windows.Forms.Label();
            this.txtAuthor    = new System.Windows.Forms.TextBox();
            this.lblStock     = new System.Windows.Forms.Label();
            this.numTotalStock = new System.Windows.Forms.NumericUpDown();
            this.lblCategory  = new System.Windows.Forms.Label();
            this.cmbCategory  = new System.Windows.Forms.ComboBox();
            this.btnSave      = new System.Windows.Forms.Button();
            this.btnCancel    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalStock)).BeginInit();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(130, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(230, 23);
            this.txtTitle.TabIndex = 1;
            // lblAuthor
            this.lblAuthor.Location = new System.Drawing.Point(20, 60);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(100, 23);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author:";
            // txtAuthor
            this.txtAuthor.Location = new System.Drawing.Point(130, 60);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(230, 23);
            this.txtAuthor.TabIndex = 3;
            // lblStock
            this.lblStock.Location = new System.Drawing.Point(20, 100);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(100, 23);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Total Stock:";
            // numTotalStock
            this.numTotalStock.Location = new System.Drawing.Point(130, 100);
            this.numTotalStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numTotalStock.Name = "numTotalStock";
            this.numTotalStock.Size = new System.Drawing.Size(230, 23);
            this.numTotalStock.TabIndex = 5;
            // lblCategory
            this.lblCategory.Location = new System.Drawing.Point(20, 140);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";
            // cmbCategory
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(130, 140);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(230, 23);
            this.cmbCategory.TabIndex = 7;
            this.cmbCategory.ValueMember = "Id";
            // btnSave
            this.btnSave.Location = new System.Drawing.Point(130, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(260, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            // AddEditBookForm
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numTotalStock);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddEditBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Book";
            ((System.ComponentModel.ISupportInitialize)(this.numTotalStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.TextBox        txtTitle;
        private System.Windows.Forms.Label          lblAuthor;
        private System.Windows.Forms.TextBox        txtAuthor;
        private System.Windows.Forms.Label          lblStock;
        private System.Windows.Forms.NumericUpDown  numTotalStock;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cmbCategory;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnCancel;
    }
}
