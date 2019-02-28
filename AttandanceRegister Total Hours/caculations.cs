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
using System.Globalization;

namespace AttandanceRegister_Total_Hours
{
    public partial class caculations : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DUWAYNE-JACK-PC;Initial Catalog=ARegister;Integrated Security=True");

        public caculations()
        {
            InitializeComponent();
        }

        private void caculations_Load(object sender, EventArgs e)                        //load event
        {
            comboBox1.Items.Add("January"); 
            comboBox1.Items.Add("February");
            comboBox1.Items.Add("March");
            comboBox1.Items.Add("April");
            comboBox1.Items.Add("May");
            comboBox1.Items.Add("June");
            comboBox1.Items.Add("July");
            comboBox1.Items.Add("August");
            comboBox1.Items.Add("September");
            comboBox1.Items.Add("October");
            comboBox1.Items.Add("November");
            comboBox1.Items.Add("December");


            comboBox2.Items.Add("2019");
            comboBox2.Items.Add("2020");
            comboBox2.Items.Add("2021");
            comboBox2.Items.Add("2022");
            comboBox2.Items.Add("2023");


            //   loadData();
        }

        public void loadData()                                    //Method that can be called in the load event that will display all the users                  
        {
      
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Name, Surname, Date, Hours from ARegister";
            cmd.ExecuteNonQuery();
            DataTable dTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
            connection.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)      //button to display
        {
            try
            {
                        String YearVal = comboBox2.SelectedItem.ToString();
                    int yearSelected = 0;
                    switch (YearVal)
                    {
                        case "2019":                                        //Switch statement with the Year 2019 - 2023
                            yearSelected = 2019;
                           break;
                        case "2020":
                            yearSelected = 2020;
                           break;
                        case "2021":
                            yearSelected = 2021;
                           break;
                        case "2022":
                            yearSelected = 2022;
                           break;
                        case "2023":
                            yearSelected = 2023;
                           break;
                    }
                /////////////////////End of Switch Statement for the Year Values //////////////////////////
          
                    string MonthIntVal = comboBox1.SelectedItem.ToString();
                    int numVal = 0;
                    switch (MonthIntVal)
                    {
                        case "January":
                            numVal = 01;
                            break;
                        case "February":
                            numVal = 02;
                            break;
                        case "March":
                            numVal = 03;
                            break;
                        case "April":
                            numVal = 04;
                            break;
                        case "May":
                            numVal = 05;
                            break;
                        case "June":
                            numVal = 06;
                            break;
                        case "July":
                            numVal = 07;
                            break;
                        case "August":
                            numVal = 08;
                            break;
                        case "September":
                            numVal = 09;
                            break;
                        case "October":
                            numVal = 10;
                            break;
                        case "November":
                            numVal = 11;
                            break;
                        case "December":
                            numVal = 12;
                            break;
                    }
                /////////////////////End of Switch Statement for the Month Values //////////////////////////
                
                //////////////////////Connection To the database with Query to select the specified data
                             connection.Open();
                            SqlCommand cmd = connection.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select * from ARegister where month(Date)= '"+numVal+"' AND year(Date)='"+yearSelected.ToString()+"' AND  ID='"+txtID.Text+"'";
                            cmd.ExecuteNonQuery();
                            DataTable dTable = new DataTable();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            dataAdapter.Fill(dTable);
                            dataGridView1.DataSource = dTable;
                            connection.Close();

                ///////////////////////////////////// Sum Loop////////////////////////////////////////

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)                   //Count the number of rows
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);   //Add the entries 
                }
                labelTotalHours.Text = sum.ToString();                                //Display the Sum  
            }

            catch
                 {
                     MessageBox.Show("Please select a month", "Error");
                 }

            //Display The month and Year(User selected) in the label.

            labelMonthDisplay.Text = comboBox1.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


 
