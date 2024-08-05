
namespace Quiet_Attic_Films
{
    partial class menuForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miClientReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miStaffReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miLocationReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miPropertyReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miEmpReg = new System.Windows.Forms.ToolStripMenuItem();
            this.mProduction = new System.Windows.Forms.ToolStripMenuItem();
            this.miProductionReg = new System.Windows.Forms.ToolStripMenuItem();
            this.miAssignEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAssignPro = new System.Windows.Forms.ToolStripMenuItem();
            this.mPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.mLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mReg,
            this.mProduction,
            this.mPayment,
            this.mLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(619, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mReg
            // 
            this.mReg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClientReg,
            this.miStaffReg,
            this.miLocationReg,
            this.miPropertyReg,
            this.miEmpReg});
            this.mReg.Name = "mReg";
            this.mReg.Size = new System.Drawing.Size(155, 36);
            this.mReg.Text = "Registration";
            // 
            // miClientReg
            // 
            this.miClientReg.Name = "miClientReg";
            this.miClientReg.Size = new System.Drawing.Size(342, 36);
            this.miClientReg.Text = "Client Registration";
            this.miClientReg.Click += new System.EventHandler(this.clientRegistrationToolStripMenuItem_Click);
            // 
            // miStaffReg
            // 
            this.miStaffReg.Name = "miStaffReg";
            this.miStaffReg.Size = new System.Drawing.Size(342, 36);
            this.miStaffReg.Text = "Staff Registration";
            this.miStaffReg.Click += new System.EventHandler(this.employeeRegistrationToolStripMenuItem_Click);
            // 
            // miLocationReg
            // 
            this.miLocationReg.Name = "miLocationReg";
            this.miLocationReg.Size = new System.Drawing.Size(342, 36);
            this.miLocationReg.Text = "Location Registration";
            this.miLocationReg.Click += new System.EventHandler(this.miLocationReg_Click);
            // 
            // miPropertyReg
            // 
            this.miPropertyReg.Name = "miPropertyReg";
            this.miPropertyReg.Size = new System.Drawing.Size(342, 36);
            this.miPropertyReg.Text = "Property Registration";
            this.miPropertyReg.Click += new System.EventHandler(this.miPropertyReg_Click);
            // 
            // miEmpReg
            // 
            this.miEmpReg.Name = "miEmpReg";
            this.miEmpReg.Size = new System.Drawing.Size(342, 36);
            this.miEmpReg.Text = "Employee Registration";
            this.miEmpReg.Click += new System.EventHandler(this.miEmpReg_Click);
            // 
            // mProduction
            // 
            this.mProduction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProductionReg,
            this.miAssignEmp,
            this.miAssignPro});
            this.mProduction.Name = "mProduction";
            this.mProduction.Size = new System.Drawing.Size(145, 36);
            this.mProduction.Text = "Production";
            // 
            // miProductionReg
            // 
            this.miProductionReg.Name = "miProductionReg";
            this.miProductionReg.Size = new System.Drawing.Size(314, 36);
            this.miProductionReg.Text = "Manage Production";
            this.miProductionReg.Click += new System.EventHandler(this.miProductionReg_Click);
            // 
            // miAssignEmp
            // 
            this.miAssignEmp.Name = "miAssignEmp";
            this.miAssignEmp.Size = new System.Drawing.Size(314, 36);
            this.miAssignEmp.Text = "Assign Employee";
            this.miAssignEmp.Click += new System.EventHandler(this.miAssignEmp_Click);
            // 
            // miAssignPro
            // 
            this.miAssignPro.Name = "miAssignPro";
            this.miAssignPro.Size = new System.Drawing.Size(314, 36);
            this.miAssignPro.Text = "Assign Property";
            this.miAssignPro.Click += new System.EventHandler(this.miAssignPro_Click);
            // 
            // mPayment
            // 
            this.mPayment.Name = "mPayment";
            this.mPayment.Size = new System.Drawing.Size(121, 36);
            this.mPayment.Text = "Payment";
            this.mPayment.Click += new System.EventHandler(this.mPayment_Click);
            // 
            // mLogout
            // 
            this.mLogout.Name = "mLogout";
            this.mLogout.Size = new System.Drawing.Size(111, 36);
            this.mLogout.Text = "Log out";
            this.mLogout.Click += new System.EventHandler(this.mLogout_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(165, 184);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 35);
            this.lblName.TabIndex = 1;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quite Attic Films";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(619, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "menuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.menuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mReg;
        private System.Windows.Forms.ToolStripMenuItem miClientReg;
        private System.Windows.Forms.ToolStripMenuItem miStaffReg;
        private System.Windows.Forms.ToolStripMenuItem miLocationReg;
        private System.Windows.Forms.ToolStripMenuItem miPropertyReg;
        private System.Windows.Forms.ToolStripMenuItem mProduction;
        private System.Windows.Forms.ToolStripMenuItem miProductionReg;
        private System.Windows.Forms.ToolStripMenuItem miAssignEmp;
        private System.Windows.Forms.ToolStripMenuItem miAssignPro;
        private System.Windows.Forms.ToolStripMenuItem mPayment;
        private System.Windows.Forms.ToolStripMenuItem mLogout;
        private System.Windows.Forms.ToolStripMenuItem miEmpReg;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
    }
}