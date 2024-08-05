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
    public partial class assignEmpForm : Form
    {
        public assignEmpForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        
        string query, ID, eid, pid;

        private void clear()
        {


            cmbPID.Text = "";
            cmbEID.Text = "";
            
            btnSave.Visible = true;
            btnSearch.Visible = true;
           
            btnDelete.Visible = false;
            btnClear.Text = "Clear";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPID.SelectedItem == null){pid = cmbPID.Text;}
            else{pid = cmbPID.SelectedItem.ToString();}
            if (cmbEID.SelectedItem == null) { eid = cmbPID.Text; }
            else { eid = cmbEID.SelectedItem.ToString(); }
            try
            {
                query = "INSERT INTO AssignEmp(PID,EID) VALUES('" + pid + "','" + eid +  "');";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Saving" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            try
            {
                query = "SELECT DISTINCT PID FROM AssignEmp;";
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
                        query = "SELECT EID FROM AssignEmp WHERE PID = '" + ID + "'";
                        con.Open();
                        adap = new SqlDataAdapter(query, con);
                        DataTable tab = new DataTable();
                        adap.Fill(tab);
                        con.Close();

                        if (tab.Rows.Count > 0)
                        {

                            cmbEID.Items.Clear();
                            cmbEID.Items.Add("--SELECT--");
                            foreach (DataRow line in tab.Rows)
                            {
                                cmbEID.Items.Add(line["EID"]);
                            }
                            cmbEID.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cmbEID.Items.Clear();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                    con.Close();
                }
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
                if (cmbPID.SelectedItem == null) { pid = cmbPID.Text; }
                else { pid = cmbPID.SelectedItem.ToString(); }
                if (cmbEID.SelectedItem == null) { eid = cmbEID.Text; }
                else { eid = cmbEID.SelectedItem.ToString(); }
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record PID " + pid + " and EID " + eid, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM AssignEmp WHERE PID = '" + pid + "' AND EID = '" + eid +"'";
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

        private void assignEmpForm_Load(object sender, EventArgs e)
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

                    cmbEID.Items.Clear();
                    cmbEID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbEID.Items.Add(line["EID"]);
                    }
                    cmbEID.SelectedIndex = 0;
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
        }
    }
}
