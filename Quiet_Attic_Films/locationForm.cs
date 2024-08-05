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
    public partial class locationForm : Form
    {
        public locationForm()
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
                query = "SELECT LID FROM Location";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(LID) FROM Location";
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
                cmbLID.Text = serialNo.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Serial No Generation" + Environment.NewLine + err);
                con.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT LID FROM Location;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbLID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbLID.Items.Clear();
                    cmbLID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbLID.Items.Add(line["LID"]);
                    }
                    cmbLID.SelectedIndex = 0;
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
            cmbLID.Enabled = false;
            txtName.Text = "";
            txtAddress.Text = "";
            txtConNo.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtConNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbCID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLID.SelectedIndex > 0)
                {
                    ID = cmbLID.SelectedItem.ToString();
                    query = "SELECT * FROM Location WHERE LID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtName.Text = r.GetValue(1).ToString();
                        txtConNo.Text = r.GetValue(2).ToString();
                        txtAddress.Text = r.GetValue(3).ToString();
                    }
                    con.Close();
                }
                else
                {
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtConNo.Text = "";

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
            if (cmbLID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information
                MessageBox.Show("Please select an Location ID from the list");

            }
            else
            {
                // update new changes 
                try
                {
                    query = "UPDATE Location SET Name = '" + txtName.Text + "', ConNo = '" + txtConNo.Text + "', LAddress= '" + txtAddress.Text +  "' WHERE LID= '" + cmbLID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Location ID: " + cmbLID.SelectedItem.ToString() + " updated successfully");
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
           
            // save to database
            try
            {
                query = "INSERT INTO Location(Name,ConNo,LAddress) VALUES('" + txtName.Text + "','" + txtConNo.Text + "','" + txtAddress.Text + "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Location ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ID = cmbLID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + ID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Location WHERE LID = '" + ID + "'";
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

        private void locationForm_Load(object sender, EventArgs e)
        {
            UniqueNumberGenerator();
        }
    }
}
