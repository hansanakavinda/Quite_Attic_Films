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
    public partial class paymentForm : Form
    {
        public paymentForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        int serialNo;
        string query, ID, pid, cid;

        private void UniqueNumberGenerator()
        {
            // generates serial number for the database and employee ID
            try
            {
                serialNo = 0;
                query = "SELECT PayID FROM Payment";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(PayID) FROM Payment";
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
                cmbPayID.Text = serialNo.ToString();
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
            cmbPayID.Enabled = false;
            cmbPID.Text = "";
            cmbCID.Text = "";
            txtPaid.Text = "";
            txtTotalPay.Text = "";
            txtYetToPay.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT PayID FROM Payment;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbPayID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbPayID.Items.Clear();
                    cmbPayID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbPayID.Items.Add(line["PayID"]);
                    }
                    cmbPayID.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("There is no data in the database");
                    clear();
                    con.Close();
                }
                

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                con.Close();
            }
        }

        private void cmbPayID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPayID.SelectedIndex > 0)
                {
                    ID = cmbPayID.SelectedItem.ToString();
                    query = "SELECT * FROM Payment WHERE PayID = '" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        cmbPID.Text = r.GetValue(1).ToString();
                        cmbCID.Text = r.GetValue(2).ToString();
                        txtTotalPay.Text = r.GetValue(3).ToString();
                        txtPaid.Text = r.GetValue(4).ToString();
                        txtYetToPay.Text = r.GetValue(5).ToString();
                    }
                    con.Close();
                }
                else
                {
                    cmbPID.Text = "";
                    cmbCID.Text = "";
                    txtTotalPay.Text = "";
                    txtPaid.Text = "";
                    txtYetToPay.Text = "";
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
            if (cmbPayID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information
                MessageBox.Show("Please select an Payment ID from the list");

            }
            else
            {
                // update new changes 
                try
                {
                    if (cmbPID.SelectedItem == null) { pid = cmbPID.Text; }
                    else { pid = cmbPID.SelectedItem.ToString(); }
                    if (cmbCID.SelectedItem == null) { cid = cmbPID.Text; }
                    else { cid = cmbCID.SelectedItem.ToString(); }
                    query = "UPDATE Payment SET PID = '" + pid + "', CID = '" + cid + "',  TotalPay = '" + txtTotalPay.Text + "',  Paid = '" + txtPaid.Text + "',  YetToPay = '" + txtYetToPay.Text + "' WHERE PID= '" + cmbPayID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Payment ID: " + cmbPID.SelectedItem.ToString() + " updated successfully");
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
            if (cmbPID.SelectedItem == null) { pid = cmbPID.Text; }
            else { pid = cmbPID.SelectedItem.ToString(); }
            if (cmbCID.SelectedItem == null) { cid = cmbPID.Text; }
            else { cid = cmbCID.SelectedItem.ToString(); }
            try
            {
                query = "INSERT INTO Payment(PID,CID,TotalPay,Paid,YetToPay) VALUES('" +pid + "','" + cid + "','" + txtTotalPay.Text + "','" + txtPaid.Text + "','" + txtYetToPay.Text + "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Payment ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ID = cmbPayID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + ID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Payment WHERE PayID = '" + ID + "'";
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

        private void cmbPID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSearch.Visible == true)
            {
                try
                {
                    if (cmbPID.SelectedIndex > 0)
                    {
                        ID = cmbPID.SelectedItem.ToString();
                        query = "SELECT * FROM Production WHERE PID = '" + ID + "'";
                        con.Open();
                        cmd = new SqlCommand(query, con);
                        SqlDataReader r = cmd.ExecuteReader();

                        while (r.Read())
                        {
                            cmbCID.Text = r.GetValue(3).ToString();


                        }
                        con.Close();
                    }
                    else
                    {
                        cmbPID.Text = "";
                        cmbCID.Text = "";
                        txtTotalPay.Text = "";
                        txtPaid.Text = "";
                        txtYetToPay.Text = "";
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void paymentForm_Load(object sender, EventArgs e)
        {
            UniqueNumberGenerator();
           

            try
            {
                query = "SELECT PID FROM Production;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {

                    cmbPID.Items.Clear();
                    cmbPID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbPID.Items.Add(line["PID"]);
                    }
                    cmbPID.SelectedIndex = 0;
                }


            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                con.Close();
            }
        }
    }
}
