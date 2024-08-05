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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=BADASS;Initial Catalog=Quiet_Attic_Films;Integrated Security=True");

        public static string realname, type;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) //login button
        {
            if (txtPword.Text == "" || txtUname.Text == "" || cmbType.SelectedIndex == 0) 
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                try
                {
                    string query = "SELECT Realname FROM userLogin WHERE Username = '" + txtUname.Text + "' AND Password = '" + txtPword.Text+ "'";
                    con.Open();
                    adap = new SqlDataAdapter(query, con);
                    DataTable tab = new DataTable();
                    adap.Fill(tab);
                    con.Close();

                    if (tab.Rows.Count > 0)
                    {
                        query  = "SELECT Realname FROM userLogin WHERE Username = '" + txtUname.Text + "' AND Password = '" + txtPword.Text + "'";
                        con.Open();
                        cmd = new SqlCommand(query, con);
                        SqlDataReader r = cmd.ExecuteReader();

                        while (r.Read())
                        {
                            realname = r.GetValue(0).ToString();

                        }
                        con.Close();
                        type = cmbType.SelectedItem.ToString();
                        Form next = new menuForm();
                        next.Show();
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and password");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while login " + Environment.NewLine + err);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUname.Text = "";
            txtPword.Text = "";
            cmbType.SelectedIndex = 0;
        }
    }
}
