using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication4
{
    public partial class ServisEdit : Form
    {
        public ServisEdit()
        {
            InitializeComponent();
        }
        SQLiteConnection ObjConnection = new SQLiteConnection("Data Source=DATA.dll;");

        DataSet dataSet = new DataSet();
        DataSet dataSet1 = new DataSet();
        int i = 1;
        int k = 0;

        private void ServisEdit_Load(object sender, EventArgs e)
        {
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM BankAndInfo ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "BankAndInfo");
            comboBox1.DataSource = dataSet.Tables["BankAndInfo"]; comboBox1.DisplayMember = dataSet.Tables["BankAndInfo"].Columns[0].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        
             
                //ObjCommand = new SQLiteCommand("SELECT * FROM VB ", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "VB");

                //ObjCommand = new SQLiteCommand("SELECT * FROM PK ", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "PK");

                //ObjCommand = new SQLiteCommand("SELECT * FROM PER", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "PER");

                //ObjCommand = new SQLiteCommand("SELECT * FROM STRAX", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "STRAX");

                //ObjCommand = new SQLiteCommand("SELECT * FROM CRED", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "CRED");

                //ObjCommand = new SQLiteCommand("SELECT * FROM OTHER", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "OTHER");

                //ObjCommand = new SQLiteCommand("SELECT * FROM OSBIS", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "OSBIS");

                //ObjCommand = new SQLiteCommand("SELECT * FROM BIGBIS", ObjConnection);
                //ObjCommand.CommandType = CommandType.Text;
                //ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                //ObjDataAdapter.Fill(dataSet, "BIGBIS");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (k = 0; k < 10;k++ ){
                if (comboBox2.SelectedIndex == 0)
                {
                    dataSet1.Clear();
                    string u = dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex].ItemArray[6].ToString();

                    SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM DP ", ObjConnection);
                    ObjCommand.CommandType = CommandType.Text;
                    SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                    ObjDataAdapter.Fill(dataSet1, "DP");

                    string j = dataSet1.Tables["DP"].Rows[k].ItemArray[3].ToString();

                    if (i == int.Parse(j)) { i++; }
                    else
                    {

                        string namee = textBox1.Text;
                        string info = textBox2.Text;

                        ObjCommand = new SQLiteCommand("INSERT INTO DP VALUES ('" + namee + "','" + info + "','" + u + "','" + i + "')", ObjConnection);
                        ObjCommand.Connection.Open();
                        ObjCommand.ExecuteNonQuery();
                        ObjCommand.Connection.Close();
                    }
                }
                }
        }
    }
}
