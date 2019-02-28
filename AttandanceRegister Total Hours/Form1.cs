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

namespace AttandanceRegister_Total_Hours
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DUWAYNE-JACK-PC;Initial Catalog=ARegister;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //call the loadData Method to load the data from the DB into the DataGridView
            loadData();
        }

        public void loadData()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from ARegister";
            cmd.ExecuteNonQuery();
            DataTable dTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable; 
            connection.Close();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
           try{
                connection.Open();
                     SqlCommand cmd = connection.CreateCommand();
                      cmd.CommandType = CommandType.Text;
                      cmd.CommandText = "Insert into ARegister values ('"+txtID.Text+"', '"+txtName.Text+"', '"+txtSurname.Text+"', '"+txtDate.Text+"', '"+txtHours.Text+"')";
                      cmd.ExecuteNonQuery();
                       connection.Close();
               MessageBox.Show("Data Inserted");
                
                txtHours.Text = "";
                txtID.Text = "";
                txtName.Text = "";
                txtSurname.Text = "";
            }
            catch
            {
                MessageBox.Show("Data Inserted");
            }
            //After the data are inserted display it in the datagridview
            loadData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
              {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update ARegister set Name= '" + txtName.Text + "',  Surname='" + txtSurname.Text + "', Date='" + txtDate.Text + "', Hours='" + txtHours.Text + "' where ID='" + txtID.Text + "'";
                cmd.ExecuteNonQuery();
                connection.Close();
                loadData();                 //Diaplay updated data
                MessageBox.Show("The users '" + txtID.Text + "' have been updated");
            }
            catch
             {
               MessageBox.Show("Please make sure the user ID are correct");

            }
            txtHours.Text = " ";
            txtID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResults = MessageBox.Show("Are you sure you want to remove the user '" + txtID.Text + "'", "Delete", MessageBoxButtons.YesNo);
                if (dResults == DialogResult.Yes)
                {

                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from ARegister where ID='" + txtID.Text + "'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    loadData();
                    MessageBox.Show("The user '" + txtID.Text + "' have been removed");
                }

            }
            catch
            {
                MessageBox.Show("Please Make sure the User ID you have entered are correct");
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHours.Text = " ";
            txtID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from ARegister where ID='"+txtID.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
            connection.Close();

        }

        private void calculateHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caculations nForm = new caculations();
            nForm.TopLevel = true;
            nForm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

