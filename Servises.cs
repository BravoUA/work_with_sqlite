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
    public partial class Servises : Form
    {
        public Servises()
        {
            InitializeComponent();
        }
        SQLiteConnection ObjConnection = new SQLiteConnection("Data Source=DATA.dll;");

        DataSet dataSet = new DataSet();
        DataSet dataSet1 = new DataSet();

        private void Servises_Load(object sender, EventArgs e)
        {
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM BankAndInfo ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "BankAndInfo");
            comboBox1.DataSource = dataSet.Tables["BankAndInfo"]; comboBox1.DisplayMember = dataSet.Tables["BankAndInfo"].Columns[0].ToString();
 
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSet1.Clear();
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM DP where (DP.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "DP");
            comboBox4.DataSource = dataSet1.Tables["DP"]; comboBox4.DisplayMember = dataSet1.Tables["DP"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM VB where (VB.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "VB");
            comboBox5.DataSource = dataSet1.Tables["VB"]; comboBox5.DisplayMember = dataSet1.Tables["VB"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM PK where (PK.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "PK");
            comboBox6.DataSource = dataSet1.Tables["PK"]; comboBox6.DisplayMember = dataSet1.Tables["PK"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM PER where (PER.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "PER");
            comboBox9.DataSource = dataSet1.Tables["PER"]; comboBox9.DisplayMember = dataSet1.Tables["PER"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM STRAX where (STRAX.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "STRAX");
            comboBox8.DataSource = dataSet1.Tables["STRAX"]; comboBox8.DisplayMember = dataSet1.Tables["STRAX"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM CRED where (CRED.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "CRED");
            comboBox7.DataSource = dataSet1.Tables["CRED"]; comboBox7.DisplayMember = dataSet1.Tables["CRED"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM OTHER where (OTHER.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "OTHER");
            comboBox11.DataSource = dataSet1.Tables["OTHER"]; comboBox11.DisplayMember = dataSet1.Tables["OTHER"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM OSBIS where (OSBIS.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "OSBIS");
            comboBox10.DataSource = dataSet1.Tables["OSBIS"]; comboBox10.DisplayMember = dataSet1.Tables["OSBIS"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM BIGBIS where (BIGBIS.id_bank = " + dataSet.Tables["BankAndInfo"].Rows[comboBox1.SelectedIndex]["id_bank"].ToString() + ")", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "BIGBIS");
            comboBox12.DataSource = dataSet1.Tables["BIGBIS"]; comboBox12.DisplayMember = dataSet1.Tables["BIGBIS"].Columns[0].ToString();
            
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["DP"].Rows[comboBox4.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["VB"].Rows[comboBox5.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["PK"].Rows[comboBox6.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["PER"].Rows[comboBox9.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["STRAX"].Rows[comboBox8.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["CRED"].Rows[comboBox7.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["OTHER"].Rows[comboBox11.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["OSBIS"].Rows[comboBox10.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uuuuu = dataSet1.Tables["BIGBIS"].Rows[comboBox10.SelectedIndex].ItemArray[1].ToString();
            textBox1.Text = uuuuu;
        }
    }
}
