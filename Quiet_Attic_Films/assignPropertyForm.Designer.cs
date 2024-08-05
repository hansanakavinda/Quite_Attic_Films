
namespace Quiet_Attic_Films
{
    partial class assignPropertyForm
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
            this.cmbProID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbPID = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbProID
            // 
            this.cmbProID.FormattingEnabled = true;
            this.cmbProID.Location = new System.Drawing.Point(240, 182);
            this.cmbProID.Name = "cmbProID";
            this.cmbProID.Size = new System.Drawing.Size(121, 34);
            this.cmbProID.TabIndex = 115;
            this.cmbProID.SelectedIndexChanged += new System.EventHandler(this.cmbProID_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 27);
            this.label5.TabIndex = 114;
            this.label5.Text = "Property ID";
            // 
            // cmbLID
            // 
            this.cmbLID.FormattingEnabled = true;
            this.cmbLID.Location = new System.Drawing.Point(239, 126);
            this.cmbLID.Name = "cmbLID";
            this.cmbLID.Size = new System.Drawing.Size(121, 34);
            this.cmbLID.TabIndex = 113;
            this.cmbLID.SelectedIndexChanged += new System.EventHandler(this.cmbLID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 112;
            this.label4.Text = "Location ID";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 328);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 42);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(200, 328);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 42);
            this.btnClear.TabIndex = 110;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(42, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 42);
            this.btnSave.TabIndex = 108;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPID
            // 
            this.cmbPID.FormattingEnabled = true;
            this.cmbPID.Location = new System.Drawing.Point(239, 70);
            this.cmbPID.Name = "cmbPID";
            this.cmbPID.Size = new System.Drawing.Size(121, 34);
            this.cmbPID.TabIndex = 107;
            this.cmbPID.SelectedIndexChanged += new System.EventHandler(this.cmbPID_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(372, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 42);
            this.btnSearch.TabIndex = 106;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(239, 247);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(248, 34);
            this.txtCount.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 102;
            this.label2.Text = "Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 27);
            this.label1.TabIndex = 101;
            this.label1.Text = "Production ID";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(423, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 42);
            this.btnExit.TabIndex = 128;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // assignPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(536, 437);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbProID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbPID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "assignPropertyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Property";
            this.Load += new System.EventHandler(this.assignPropertyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbProID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbPID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}