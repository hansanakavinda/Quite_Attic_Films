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
    public partial class clientRegForm : Form
    {
        public clientRegForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        int serialNo;
        string query, gen, ID;

        private void UniqueNumberGenerator()
        {
            // generates serial number for the database and employee ID
            try
            {
                serialNo = 0;
                query = "SELECT CID FROM Client";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(CID) FROM Client";
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
                cmbCID.Text = serialNo.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Serial No Generation" + Environment.NewLine + err);
                con.Close();
            }

        }

        private void clientRegForm_Load(object sender, EventArgs e)
        {
            UniqueNumberGenerator();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                query = "SELECT CID FROM Client;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbCID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbCID.Items.Clear();
                    cmbCID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbCID.Items.Add(line["CID"]);
                    }
                    cmbCID.SelectedIndex = 0;
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

        private void clear()
        {
            UniqueNumberGenerator();
            cmbCID.Enabled = false;
            txtCName.Text = "";
            txtAddress.Text = "";
            txtConNo.Text = "";
            txtNIC.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            btnClear.Text = "Clear";
            
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbCID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information
                MessageBox.Show("Please select an Client ID from the list");

            }
            else
            {
                // update new changes 
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gen = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gen = "Female";
                    }
                    query = "UPDATE Client SET Name = '" + txtCName.Text + "', NIC = '" + txtNIC.Text + "', ConNo = '" + txtConNo.Text + "', CAddress= '" + txtAddress.Text + "', Gender= '" + gen + "' WHERE CID= '" + cmbCID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Client ID: " + cmbCID.SelectedItem.ToString() + " updated successfully");
                    clear();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while updating" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ID = cmbCID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + ID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Client WHERE CID = '" + ID + "'";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form back = new menuForm();
            this.Close();
            back.Show();
        }

        private void cmbCID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCID.SelectedIndex > 0)
                {
                    ID = cmbCID.SelectedItem.ToString();
                    query = "SELECT * FROM Client WHERE CID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtCName.Text = r.GetValue(1).ToString();
                        txtConNo.Text = r.GetValue(2).ToString();
                        txtNIC.Text = r.GetValue(3).ToString();
                        gen = r.GetValue(4).ToString();
                        txtAddress.Text = r.GetValue(5).ToString();
                    }
                    if (gen.Equals("Male")) { rbMale.Checked = true; }
                    else if (gen.Equals("Female")) { rbFemale.Checked = true; }

                    con.Close();
                }
                else
                {
                    txtCName.Text = "";
                    txtAddress.Text = "";
                    txtNIC.Text = "";
                    txtConNo.Text = "";
                    rbMale.Checked = false;
                    rbFemale.Checked = false;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbFemale.Checked == false && rbMale.Checked == false)
            {
                MessageBox.Show("Please select Gender");
            }
            else
            {
                // save to database
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gen = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gen = "Female";
                    }

                    query = "INSERT INTO Client(Name,ConNo,NIC,Gender,CAddress) VALUES('"+ txtCName.Text + "','" + txtConNo.Text + "','" + txtNIC.Text + "','" + gen + "','" + txtAddress.Text + "');";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Client ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();

                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while Saving" + Environment.NewLine + err);
                    con.Close();
                }
            }

        }
    }
}
