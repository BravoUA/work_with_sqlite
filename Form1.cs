using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }
        SQLiteConnection ObjConnection = new SQLiteConnection("Data Source=DATA.dll;");
        public SQLiteCommand ObjCommand;
        public SQLiteDataAdapter ObjDataAdapter;

        public DataSet dataSet = new DataSet();
        public DataSet dataSet1 = new DataSet();
        public DataSet dataSet2 = new DataSet();
        public DataSet dataSet3 = new DataSet();
        public DataSet dataSet4 = new DataSet();
        
        double USA;
        double RUB;
        double EUR;
        public string IdTown, Idbank;
        private void Form1_Load(object sender, EventArgs e)
        {

            ObjCommand = new SQLiteCommand("SELECT town  FROM Town order by id asc", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "town");
            comboBox1.DataSource = dataSet.Tables["town"];
            comboBox1.DisplayMember = dataSet.Tables["town"].Columns[0].ToString();
            comboBox1.SelectedIndex = 0;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSet2.Clear(); 
             ObjCommand = new SQLiteCommand("SELECT id_bank FROM ID where id_town ="+ comboBox1.SelectedIndex.ToString()+ " order by id_bank asc ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
             ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet2, "id_town");
            string iDnow = dataSet2.Tables["id_town"].Columns[0].ToString(); 

            ObjCommand = new SQLiteCommand("SELECT Bank FROM BankAndInfo where id_bank ="+ iDnow + " order by id_bank asc ", ObjConnection);
            dataSet2.Clear();
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet2, "Bank");
            comboBox2.DataSource = dataSet2.Tables["Bank"];
            comboBox2.DisplayMember = dataSet2.Tables["Bank"].Columns[0].ToString();
            IdTown = comboBox1.SelectedIndex.ToString();
            comboBox2.SelectedIndex = 0;



        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSet1.Clear();
            Idbank = comboBox2.SelectedIndex.ToString();
             ObjCommand = new SQLiteCommand("SELECT USA, EUR, RUB, CASHDATA, ID FROM CASH where ID =" + Idbank + "  ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
             ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "CASHDATA");
            comboBox3.DataSource = dataSet1.Tables["CASHDATA"];
            comboBox3.DisplayMember = dataSet1.Tables["CASHDATA"].Columns[3].ToString();
            

            Idbank = comboBox2.SelectedIndex.ToString();
            ObjCommand = new SQLiteCommand("SELECT  Adres, Phone, Mail, Website, MFO from BankAndInfo  WHERE id_bank = "+ comboBox2.SelectedIndex.ToString() + "", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "Info");

         /*   ObjCommand = new SQLiteCommand("SELECT Adres, Phone FROM  InfoPoTawn where id_town = " + IdTown + "  ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet1, "InfoPoTawn");*/

            

                   listBox4.DataSource = dataSet1.Tables["Info"]; listBox4.DisplayMember = dataSet1.Tables["Info"].Columns[0].ToString();
                   listBox5.DataSource = dataSet1.Tables["Info"]; listBox5.DisplayMember = dataSet1.Tables["Info"].Columns[1].ToString();
                   listBox6.DataSource = dataSet1.Tables["Info"]; listBox6.DisplayMember = dataSet1.Tables["Info"].Columns[2].ToString();
                   listBox7.DataSource = dataSet1.Tables["Info"]; listBox7.DisplayMember = dataSet1.Tables["Info"].Columns[3].ToString();
                   listBox8.DataSource = dataSet1.Tables["Info"]; listBox8.DisplayMember = dataSet1.Tables["Info"].Columns[4].ToString();

            /* listBox12.DataSource = dataSet1.Tables["InfoPoTawn"]; listBox12.DisplayMember = dataSet1.Tables["InfoPoTawn"].Columns[0].ToString();
             listBox13.DataSource = dataSet1.Tables["InfoPoTawn"]; listBox13.DisplayMember = dataSet1.Tables["InfoPoTawn"].Columns[1].ToString();*/
           
        }
        private void abautToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataSet2.Clear();
             ObjCommand = new SQLiteCommand("SELECT Adres, Phone FROM InfoPoTawn WHERE Adres like '%" + textBox1.Text + "%' or id=0 ORDER BY Adres DESC", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
             ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet2, "InfoPoTawn");
            
            listBox12.DataSource = dataSet2.Tables["InfoPoTawn"];listBox12.DisplayMember = dataSet2.Tables["InfoPoTawn"].Columns[0].ToString();
            listBox13.DataSource = dataSet2.Tables["InfoPoTawn"];listBox13.DisplayMember = dataSet2.Tables["InfoPoTawn"].Columns[1].ToString();

            

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataSet3.Clear();
            ObjCommand = new SQLiteCommand("SELECT * FROM bank WHERE bank like '%" + textBox2.Text + "%' ORDER BY bank DESC", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet3, "bank");
            comboBox2.DataSource = dataSet3.Tables["bank"];
            comboBox2.DisplayMember = dataSet3.Tables["bank"].Columns[0].ToString();
        }
        private void додатиВіділеняКонтактиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor f1 = new Editor();
            f1.Show();
        }
        private void додаиБанкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor1 f2 = new Editor1(); 
            f2.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                double kalcul = double.Parse(textBox3.Text);
                double vidp;
                listBox9.Items.Clear();
                vidp = kalcul * USA;     listBox9.Items.Add(vidp);
                listBox10.Items.Clear();
                vidp = kalcul * EUR;     listBox10.Items.Add(vidp);
                listBox11.Items.Clear();
                vidp = kalcul * RUB;     listBox11.Items.Add(vidp);

                listBox16.Items.Clear();
                vidp = kalcul / USA; listBox16.Items.Add(vidp);
                listBox15.Items.Clear();
                vidp = kalcul / EUR; listBox15.Items.Add(vidp);
                listBox14.Items.Clear();
                vidp = kalcul / RUB; listBox14.Items.Add(vidp);
            }
            catch { }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            dataSet4.Reset();

           


            DataRowView row = (DataRowView)comboBox3.SelectedItem;
            if (row != null)
            {

            ObjCommand = new SQLiteCommand("select USA, EUR, RUB, CASHDATA FROM CASH where ID = " + Idbank + " AND CASHDATA = '"+ row[3] + "'", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet4, "DATAA");

            
            listBox1.DataSource = dataSet4.Tables["DATAA"]; listBox1.DisplayMember = dataSet4.Tables["DATAA"].Columns[0].ToString();
            listBox2.DataSource = dataSet4.Tables["DATAA"]; listBox2.DisplayMember = dataSet4.Tables["DATAA"].Columns[1].ToString();
            listBox3.DataSource = dataSet4.Tables["DATAA"]; listBox3.DisplayMember = dataSet4.Tables["DATAA"].Columns[2].ToString();


           
            
            string u = dataSet4.Tables["DATAA"].Rows[0].ItemArray[0].ToString(); USA = double.Parse(u);
            string eu = dataSet4.Tables["DATAA"].Rows[0].ItemArray[1].ToString(); EUR = double.Parse(eu);
            string r = dataSet4.Tables["DATAA"].Rows[0].ItemArray[2].ToString(); RUB = double.Parse(r);
            string d = dataSet4.Tables["DATAA"].Rows[0].ItemArray[3].ToString();
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Servises f3 = new Servises();
            f3.Show();
        }
        private void додатиПослугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServisEdit f4 = new ServisEdit();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log f5 = new log();
            f5.Show();
        }

    }
   
}

