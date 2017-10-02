namespace MyExpenses.WinForm.Mvp.View
{
    partial class ExpenseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseView));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.tlpDetails.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvExpenses, 0, 0);
            this.tlpMain.Controls.Add(this.tlpDetails, 0, 1);
            this.tlpMain.Controls.Add(this.tlpFooter, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(762, 420);
            this.tlpMain.TabIndex = 0;
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpenses.Location = new System.Drawing.Point(3, 3);
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(756, 249);
            this.dgvExpenses.TabIndex = 0;
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 2;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Controls.Add(this.lblId, 0, 0);
            this.tlpDetails.Controls.Add(this.lblName, 0, 1);
            this.tlpDetails.Controls.Add(this.lblValue, 0, 2);
            this.tlpDetails.Controls.Add(this.lblDate, 0, 3);
            this.tlpDetails.Controls.Add(this.txtId, 1, 0);
            this.tlpDetails.Controls.Add(this.txtName, 1, 1);
            this.tlpDetails.Controls.Add(this.txtValue, 1, 2);
            this.tlpDetails.Controls.Add(this.txtDate, 1, 3);
            this.tlpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetails.Location = new System.Drawing.Point(0, 255);
            this.tlpDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 4;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDetails.Size = new System.Drawing.Size(762, 125);
            this.tlpDetails.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(3, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(44, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(3, 68);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(44, 13);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(3, 101);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(53, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(706, 20);
            this.txtId.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(53, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(706, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(53, 65);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(706, 20);
            this.txtValue.TabIndex = 5;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Location = new System.Drawing.Point(53, 97);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(706, 20);
            this.txtDate.TabIndex = 7;
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 4;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFooter.Controls.Add(this.btnAdd, 1, 0);
            this.tlpFooter.Controls.Add(this.btnUpdate, 2, 0);
            this.tlpFooter.Controls.Add(this.btnDelete, 3, 0);
            this.tlpFooter.Controls.Add(this.picIcon, 0, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(3, 383);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(756, 34);
            this.tlpFooter.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(121, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.Location = new System.Drawing.Point(359, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Location = new System.Drawing.Point(598, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImage = global::MyExpenses.WinForm.Properties.Resources._32x32;
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIcon.Location = new System.Drawing.Point(0, 0);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(40, 34);
            this.picIcon.TabIndex = 3;
            this.picIcon.TabStop = false;
            // 
            // ExpenseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 420);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpenseView";
            this.Text = "Expenses";
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.tlpDetails.ResumeLayout(false);
            this.tlpDetails.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.PictureBox picIcon;
    }
}