using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiet_Attic_Films
{
    public partial class menuForm : Form
    {
        public menuForm()
        {
            InitializeComponent();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form next = new staffForm();
            this.Hide();
            next.Show();
        }

        private void clientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form next = new clientRegForm();
            this.Hide();
            next.Show();
        }

        private void miLocationReg_Click(object sender, EventArgs e)
        {
            Form next = new locationForm();
            this.Hide();
            next.Show();
        }

        private void miPropertyReg_Click(object sender, EventArgs e)
        {
            Form next = new propertyForm();
            this.Hide();
            next.Show();
        }

        private void miEmpReg_Click(object sender, EventArgs e)
        {
            Form next = new employeeForm();
            this.Hide();
            next.Show();
        }

        private void miProductionReg_Click(object sender, EventArgs e)
        {
            Form next = new productionForm();
            this.Hide();
            next.Show();
        }

        private void miAssignEmp_Click(object sender, EventArgs e)
        {
            Form next = new assignEmpForm();
            this.Hide();
            next.Show();
        }

        private void miAssignPro_Click(object sender, EventArgs e)
        {
            Form next = new assignPropertyForm();
            this.Hide();
            next.Show();
        }

        private void mPayment_Click(object sender, EventArgs e)
        {
            Form next = new paymentForm();
            this.Hide();
            next.Show();
        }

        private void mLogout_Click(object sender, EventArgs e)
        {
            Form next = new LoginForm();
            this.Hide();
            next.Show();
        }

        private void menuForm_Load(object sender, EventArgs e)
        {
            

            lblName.Text = "Welcome " + LoginForm.realname;
            string type = LoginForm.type;

            if (type == "Production Manager")
            {
                miStaffReg.Visible = false;
                miEmpReg.Visible = false;
                miAssignEmp.Visible = false;

            }
            if (type == "Employee Manager")
            {
                miClientReg.Visible = false;
                miProductionReg.Visible = false;
                miLocationReg.Visible = false;
                miPropertyReg.Visible = false;
                miAssignPro.Visible = false;
                mPayment.Visible = false;
            }

            
        }
    }
}
