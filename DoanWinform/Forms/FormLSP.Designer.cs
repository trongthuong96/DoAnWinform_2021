﻿
namespace DoanWinform.Forms
{
    partial class frmProductType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductType));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProductType = new System.Windows.Forms.DataGridView();
            this.dgvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInsertUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductType)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Sản Phẩm";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTypeName.Location = new System.Drawing.Point(158, 133);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(95, 20);
            this.txtTypeName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên LSP";
            // 
            // dgvProductType
            // 
            this.dgvProductType.AllowUserToAddRows = false;
            this.dgvProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNumber,
            this.dgvTypeID,
            this.dgvProductTypeName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductType.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductType.Location = new System.Drawing.Point(310, 12);
            this.dgvProductType.Name = "dgvProductType";
            this.dgvProductType.Size = new System.Drawing.Size(257, 318);
            this.dgvProductType.TabIndex = 3;
            this.dgvProductType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductType_CellClick);
            // 
            // dgvNumber
            // 
            this.dgvNumber.FillWeight = 56.81672F;
            this.dgvNumber.HeaderText = "STT";
            this.dgvNumber.Name = "dgvNumber";
            // 
            // dgvTypeID
            // 
            this.dgvTypeID.FillWeight = 76.14214F;
            this.dgvTypeID.HeaderText = "Mã LSP";
            this.dgvTypeID.Name = "dgvTypeID";
            // 
            // dgvProductTypeName
            // 
            this.dgvProductTypeName.FillWeight = 167.0412F;
            this.dgvProductTypeName.HeaderText = "Tên loại SP";
            this.dgvProductTypeName.Name = "dgvProductTypeName";
            // 
            // btnInsertUpdate
            // 
            this.btnInsertUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInsertUpdate.Location = new System.Drawing.Point(25, 184);
            this.btnInsertUpdate.Name = "btnInsertUpdate";
            this.btnInsertUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnInsertUpdate.TabIndex = 4;
            this.btnInsertUpdate.Text = "Thêm";
            this.btnInsertUpdate.UseVisualStyleBackColor = true;
            this.btnInsertUpdate.Click += new System.EventHandler(this.btnInsertUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.Location = new System.Drawing.Point(217, 184);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(121, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTypeID.Location = new System.Drawing.Point(158, 85);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(95, 20);
            this.txtTypeID.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã LSP";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEdit.Location = new System.Drawing.Point(121, 184);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(579, 342);
            this.Controls.Add(this.dgvProductType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnInsertUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTypeID);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại sản phẩm";
            this.Load += new System.EventHandler(this.frmProductType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProductType;
        private System.Windows.Forms.Button btnInsertUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProductTypeName;
        private System.Windows.Forms.TextBox txtTypeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
    }
}