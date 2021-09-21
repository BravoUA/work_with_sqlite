using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;

namespace WindowsFormsApplication4
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        SQLiteConnection ObjConnection = new SQLiteConnection("Data Source=DATA.dll");
        DataSet dataSet = new DataSet();
        DataSet dataSet1 = new DataSet();
        int k = 0;
        int i = 0;

        private void Editor_Load(object sender, EventArgs e)
        {
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM Town ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "town");
            comboBox2.DataSource = dataSet.Tables["town"]; comboBox2.DisplayMember = dataSet.Tables["town"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM BankAndInfo", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "Bank");
            comboBox1.DataSource = dataSet.Tables["Bank"]; comboBox1.DisplayMember = dataSet.Tables["Bank"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM InfoPoTawn ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "InfoPoTawn");
            dataGridView1.DataSource = dataSet1.Tables["InfoPoTawn"];   
        }
        private void button2_Click(object sender, EventArgs e)
        {
            i = 1;
            for (int l = 0; l < 300; l++)
            {
                SQLiteCommand ObjCommand = new SQLiteCommand("SELECT id FROM InfoPoTawn ORDER BY id ", ObjConnection);
                ObjCommand.CommandType = CommandType.Text;
                SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                ObjDataAdapter.Fill(dataSet1, "id");

                string Adres = textBox6.Text;
                string Phone = textBox3.Text;
                int b = int.Parse(comboBox1.SelectedIndex.ToString());
                int bt = int.Parse(comboBox2.SelectedIndex.ToString());
                string j = dataSet1.Tables["id"].Rows[k++].ItemArray[0].ToString();

                if (i == int.Parse(j)) { i++; }
                else
                {
                    ObjCommand = new SQLiteCommand("INSERT INTO InfoPoTawn VALUES('" + Adres + "','" + Phone + "','" +b+ "','" +bt+ "','" + i + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    l = 300;
                    i = 1;
                    k = 0;
                    dataSet1.Clear();
                    ObjCommand = new SQLiteCommand("SELECT * FROM InfoPoTawn ", ObjConnection);
                    ObjCommand.CommandType = CommandType.Text;
                    ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                    ObjDataAdapter.Fill(dataSet1, "InfoPoTawn");
                    dataGridView1.DataSource = dataSet1.Tables["InfoPoTawn"];
                }
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT id FROM InfoPoTawn ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "InfoPoTawn");
            
            int delete  ;
            int d;
            
            delete =  int.Parse(dataGridView1.SelectedRows[0].Index.ToString());
            string j = dataSet.Tables["InfoPoTawn"].Rows[delete].ItemArray[0].ToString();
            d = int.Parse(j);

            ObjCommand = new SQLiteCommand("DELETE FROM InfoPoTawn WHERE id=" + (d) + "", ObjConnection);
            ObjCommand.Connection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjCommand.Connection.Close();

            dataSet1.Clear();
            ObjCommand = new SQLiteCommand("SELECT * FROM InfoPoTawn ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "InfoPoTawn");
            dataGridView1.DataSource = dataSet1.Tables["InfoPoTawn"];
        }
    }
}