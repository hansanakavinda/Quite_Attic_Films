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
    public partial class staffForm : Form
    {
        public staffForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        int serialNo;
        string query, ID;

        private void UniqueNumberGenerator()
        {
            // generates serial number for the database and employee ID
            try
            {
                serialNo = 0;
                query = "SELECT StID FROM Staff";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(StID) FROM Staff";
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
                cmbSID.Text = serialNo.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Serial No Generation" + Environment.NewLine + err);
                con.Close();
            }

        }

        private void staffForm_Load(object sender, EventArgs e)
        {
            UniqueNumberGenerator();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
                    cmbSID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbSID.Items.Clear();
                    cmbSID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbSID.Items.Add(line["StID"]);
                    }
                    cmbSID.SelectedIndex = 0;
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

        private void cmbSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSID.SelectedIndex > 0)
                {
                    ID = cmbSID.SelectedItem.ToString();
                    query = "SELECT * FROM Staff WHERE StID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtType.Text = r.GetValue(1).ToString();
                        txtFeePerDay.Text = r.GetValue(2).ToString();
                    }
                    con.Close();
                }
                else
                {
                    txtFeePerDay.Text = "";
                    txtType.Text = "";

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
            if (cmbSID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information
                MessageBox.Show("Please select an Staff ID from the list");

            }
            else
            {
                // update new changes 
                try
                {
                    query = "UPDATE Staff SET StType = '" + txtType.Text + "', FeePerDay = '" + txtFeePerDay.Text + "' WHERE StID= '" + cmbSID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Staff ID: " + cmbSID.SelectedItem.ToString() + " updated successfully");
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
            if (txtType.Text == "")
            {
                txtType.Text = null;
            }
            if (txtFeePerDay.Text == "")
            {
                txtFeePerDay.Text = null;
            }
            try
            {
                query = "INSERT INTO Staff(StType,FeePerDay) VALUES('" + txtType.Text + "','" + txtFeePerDay.Text + "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Staff ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ID = cmbSID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + ID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Staff WHERE StID = '" + ID + "'";
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

        private void clear()
        {
            UniqueNumberGenerator();
            cmbSID.Enabled = false;
            txtFeePerDay.Text = "";
            txtType.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }
    }
}
