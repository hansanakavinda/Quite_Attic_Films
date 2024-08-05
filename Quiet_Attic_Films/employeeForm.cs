using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quiet_Attic_Films
{
    public partial class employeeForm : Form
    {
        public employeeForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        int serialNo;
        string query, ID, sid;

        private void UniqueNumberGenerator()
        {
            // generates serial number for the database and employee ID
            try
            {
                serialNo = 0;
                query = "SELECT EID FROM Employee";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(EID) FROM Employee";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader R = cmd.ExecuteReader();

                    while (R.Read())
                    {
                        serialNo = int.Parse(R.GetValue(0).ToString());
                    }
                    serialNo += 1;
                }
                else
                {
                    serialNo = 1;
                }
                con.Close();
                cmbEID.Text = serialNo.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Serial No Generation" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void clear()
        {
            UniqueNumberGenerator();
            cmbEID.Enabled = false;
            txtName.Text = "";
            txtConNo.Text = "";
            txtNIC.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }
        private void employeeForm_Load(object sender, EventArgs e)
        {
            UniqueNumberGenerator();
            try
            {
                query = "SELECT StID FROM Staff;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {

                    cmbSID.Items.Clear();
                    cmbSID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbSID.Items.Add(line["StID"]);
                    }
                    cmbSID.SelectedIndex = 0;
                }
                

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                con.Close();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtFeePerDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT EID FROM Employee;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbEID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbEID.Items.Clear();
                    cmbEID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbEID.Items.Add(line["EID"]);
                    }
                    cmbEID.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("There is no data in the database");
                    clear();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                con.Close();
            }
        }

        private void cmbEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEID.SelectedIndex > 0)
                {
                    ID = cmbEID.SelectedItem.ToString();
                    query = "SELECT * FROM Employee WHERE EID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtName.Text = r.GetValue(1).ToString();
                        txtConNo.Text = r.GetValue(2).ToString();
                        txtNIC.Text = r.GetValue(3).ToString();
                        cmbSID.Text = r.GetValue(4).ToString();
                    }
                    con.Close();
                }
                else
                {
                   txtName.Text = "";
                    txtConNo.Text = "";
                    txtNIC.Text = "";
                    cmbSID.Text = "";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information
                MessageBox.Show("Please select an Employee ID from the list");

            }
            else
            {
                // update new changes 
                try
                {
                    query = "UPDATE Employee SET Name = '" + txtName.Text + "', ConNo = '" + txtConNo.Text + "', NIC = '" + txtNIC.Text + "', StID = '" + cmbSID.SelectedItem.ToString() + "' WHERE EID= '" + cmbEID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Employee ID: " + cmbEID.SelectedItem.ToString() + " updated successfully");
                    clear();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while updating" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSID.SelectedItem == null)
            {
                sid = cmbSID.Text;
            }else
            {
                sid = cmbSID.SelectedItem.ToString();
            }
            try
            {
                query = "INSERT INTO Employee(Name,ConNO,NIC,StID) VALUES('" + txtName.Text + "','" + txtConNo.Text + "','" + txtNIC.Text + "','" + sid + "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Property ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Saving" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ID = cmbEID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + ID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Employee WHERE EID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("record deleted successfully");
                    clear();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while deleting" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form back = new menuForm();
            this.Close();
            back.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
