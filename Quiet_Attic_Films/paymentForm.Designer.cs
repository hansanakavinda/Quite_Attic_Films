
namespace Quiet_Attic_Films
{
    partial class paymentForm
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
            this.cmbPID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbPayID = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYetToPay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPID
            // 
            this.cmbPID.FormattingEnabled = true;
            this.cmbPID.Location = new System.Drawing.Point(248, 147);
            this.cmbPID.Name = "cmbPID";
            this.cmbPID.Size = new System.Drawing.Size(121, 34);
            this.cmbPID.TabIndex = 96;
            this.cmbPID.SelectedIndexChanged += new System.EventHandler(this.cmbPID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 27);
            this.label4.TabIndex = 95;
            this.label4.Text = "Production ID";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(365, 456);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 42);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(215, 456);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 42);
            this.btnClear.TabIndex = 93;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(57, 456);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 42);
            this.btnUpdate.TabIndex = 92;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 42);
            this.btnSave.TabIndex = 91;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPayID
            // 
            this.cmbPayID.Enabled = false;
            this.cmbPayID.FormattingEnabled = true;
            this.cmbPayID.Location = new System.Drawing.Point(248, 91);
            this.cmbPayID.Name = "cmbPayID";
            this.cmbPayID.Size = new System.Drawing.Size(121, 34);
            this.cmbPayID.TabIndex = 90;
            this.cmbPayID.SelectedIndexChanged += new System.EventHandler(this.cmbPayID_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(381, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 42);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(248, 325);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(248, 34);
            this.txtPaid.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 27);
            this.label3.TabIndex = 87;
            this.label3.Text = "Paid";
            // 
            // txtTotalPay
            // 
            this.txtTotalPay.Location = new System.Drawing.Point(248, 268);
            this.txtTotalPay.Name = "txtTotalPay";
            this.txtTotalPay.Size = new System.Drawing.Size(248, 34);
            this.txtTotalPay.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 27);
            this.label2.TabIndex = 85;
            this.label2.Text = "Total Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 27);
            this.label1.TabIndex = 84;
            this.label1.Text = "Pay ID";
            // 
            // cmbCID
            // 
            this.cmbCID.FormattingEnabled = true;
            this.cmbCID.Location = new System.Drawing.Point(248, 203);
            this.cmbCID.Name = "cmbCID";
            this.cmbCID.Size = new System.Drawing.Size(121, 34);
            this.cmbCID.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 27);
            this.label5.TabIndex = 97;
            this.label5.Text = "Client ID";
            // 
            // txtYetToPay
            // 
            this.txtYetToPay.Location = new System.Drawing.Point(248, 387);
            this.txtYetToPay.Name = "txtYetToPay";
            this.txtYetToPay.Size = new System.Drawing.Size(248, 34);
            this.txtYetToPay.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 27);
            this.label6.TabIndex = 99;
            this.label6.Text = "Yet To Pay";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(433, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 42);
            this.btnExit.TabIndex = 131;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // paymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(555, 546);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtYetToPay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbPayID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "paymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Form";
            this.Load += new System.EventHandler(this.paymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbPayID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYetToPay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExit;
    }
}