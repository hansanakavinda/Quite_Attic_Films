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
    public partial class assignPropertyForm : Form
    {
        public assignPropertyForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        
        string query, ID, pid, proID, lid;

        private void clear()
        {
            
            
            cmbPID.Text = "";
            cmbProID.Text = "";
            cmbLID.Text = "";
            txtCount.Text = "";
            btnSave.Visible = true;
            btnSearch.Visible = true;
          
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT DISTINCT PID FROM AssignProperty;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    btnSave.Visible = false;
                
                    btnDelete.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Text = "Back";

                    cmbPID.Items.Clear();
                    cmbPID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbPID.Items.Add(line["PID"]);
                    }
                    cmbPID.SelectedIndex = 0;
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

        private void cmbPID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSearch.Visible == false)
            {
                try
                {
                    if (cmbPID.SelectedIndex > 0)
                    {
                        ID = cmbPID.SelectedItem.ToString();
                        query = "SELECT DISTINCT LID FROM AssignProperty WHERE PID = '" + ID + "'";
                        con.Open();
                        adap = new SqlDataAdapter(query, con);
                        DataTable tab = new DataTable();
                        adap.Fill(tab);
                        con.Close();

                        if (tab.Rows.Count > 0)
                        {

                            cmbLID.Items.Clear();
                            cmbLID.Items.Add("--SELECT--");
                            foreach (DataRow line in tab.Rows)
                            {
                                cmbLID.Items.Add(line["LID"]);
                            }
                            cmbLID.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPID.SelectedItem == null) { pid = cmbPID.Text; }
            else { pid = cmbPID.SelectedItem.ToString(); }
            if (cmbLID.SelectedItem == null) { lid = cmbLID.Text; }
            else { lid = cmbLID.SelectedItem.ToString(); }      
            if (cmbProID.SelectedItem == null) { proID = cmbPID.Text; }
            else { proID = cmbProID.SelectedItem.ToString(); }
            try
            {
                query = "INSERT INTO AssignProperty(PID,LID,ProID,ProCount) VALUES('" + pid + "','" + lid + "','" + proID + "','"  + txtCount.Text + "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show( " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Saving" + Environment.NewLine + err);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                pid = cmbPID.SelectedItem.ToString();
                lid = cmbLID.SelectedItem.ToString();
                proID = cmbProID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record PID " + ID + " and LID " + lid + " and ProID " + proID, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM AssignProperty WHERE PID = '" + ID + "' AND LID = '" + lid + "' AND ProID = '" + proID + "'";
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

        private void cmbProID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSearch.Visible == false)
            {
                try
                {
                    if (cmbProID.SelectedIndex > 0)
                    {
                        pid = cmbPID.SelectedItem.ToString();
                        lid = cmbLID.SelectedItem.ToString();
                        proID = cmbProID.SelectedItem.ToString();
                        query = "SELECT * FROM AssignProperty WHERE PID = '" + pid + "' AND LID = '" + lid + "' AND ProID = '" + proID + "'";
                        con.Open();
                        cmd = new SqlCommand(query, con);
                        SqlDataReader r = cmd.ExecuteReader();

                        while (r.Read())
                        {
                            txtCount.Text = r.GetValue(3).ToString();
                            
                        }
                        con.Close();


                    }
                    else
                    {
                        
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void cmbLID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSearch.Visible == false)
            {
                try
                {
                    if (cmbLID.SelectedIndex > 0)
                    {
                        pid = cmbPID.SelectedItem.ToString();
                        lid = cmbLID.SelectedItem.ToString();
                        query = "SELECT DISTINCT ProID FROM AssignProperty WHERE LID = '" + lid + "' AND PID= '" + pid+ "'";
                        con.Open();
                        adap = new SqlDataAdapter(query, con);
                        DataTable tab = new DataTable();
                        adap.Fill(tab);
                        con.Close();

                        if (tab.Rows.Count > 0)
                        {

                            cmbProID.Items.Clear();
                            cmbProID.Items.Add("--SELECT--");
                            foreach (DataRow line in tab.Rows)
                            {
                                cmbProID.Items.Add(line["ProID"]);
                            }
                            cmbProID.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cmbLID.SelectedIndex = 0;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void assignPropertyForm_Load(object sender, EventArgs e)
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

                    cmbLID.Items.Clear();
                    cmbLID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbLID.Items.Add(line["LID"]);
                    }
                    cmbLID.SelectedIndex = 0;
                }


            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                con.Close();
            }

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

            try
            {
                query = "SELECT ProID FROM Properties;";
                con.Open();
                adap = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                adap.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {

                    cmbProID.Items.Clear();
                    cmbProID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbProID.Items.Add(line["ProID"]);
                    }
                    cmbProID.SelectedIndex = 0;
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
