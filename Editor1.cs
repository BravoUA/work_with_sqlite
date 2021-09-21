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
    public partial class Editor1 : Form
    {
        public Editor1()
        {
            InitializeComponent();
            checkBox = new CheckBox[24];
            for(int i=0;i<24;i++){
                checkBox[i] = new CheckBox();
                checkBox[i].Size = new Size(176,17);
                checkBox[i].Visible = true;
                checkBox[i].Text = "AAAAAAAAAAa";
                checkBox[i].Location=new Point(16,192+17*i);
                this.Controls.Add(checkBox[i]);
               
            } 
        }

        SQLiteConnection ObjConnection = new SQLiteConnection("Data Source=DATA.dll;");
        DataSet dataSet = new DataSet();
        DataSet dataSet2 = new DataSet();
        int k = 0;
        int i = 1;
   
        private void Editor1_Load(object sender, EventArgs e)
        {
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM Town ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "town");
            for (k = 0; k < 24; k++) {string j = dataSet.Tables["town"].Rows[k].ItemArray[0].ToString(); checkBox[k].Text = j;}

            ObjCommand = new SQLiteCommand("SELECT * FROM BankAndInfo", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "BankAndInfo");
            comboBox1.DataSource = dataSet.Tables["BankAndInfo"]; comboBox1.DisplayMember = dataSet.Tables["BankAndInfo"].Columns[0].ToString();

            ObjCommand = new SQLiteCommand("SELECT * FROM ID", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "ID");
        }
        public void ADD()
        {
            int k = 0;
            for (int l = 0; l < 300; l++)
            {
                SQLiteCommand ObjCommand = new SQLiteCommand("SELECT id_bank FROM bank ORDER BY id_bank ", ObjConnection);
                ObjCommand.CommandType = CommandType.Text;
                SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                ObjDataAdapter.Fill(dataSet, "id_bank");

                ObjCommand = new SQLiteCommand("SELECT ID FROM CASH  ORDER BY ID ASC", ObjConnection);
                ObjCommand.CommandType = CommandType.Text;
                ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
                ObjDataAdapter.Fill(dataSet, "ID");

                string usa = textBox2.Text;
                string eur = textBox3.Text;
                string rub = textBox4.Text;
                string bank = textBox5.Text;
                string data = textBox1.Text;
                string ADRES = textBox2.Text;
                string Phone = textBox3.Text;
                string Mail = textBox4.Text;
                string Website = textBox5.Text;
                int MFO = int.Parse(textBox1.Text);
                
                
                string j = dataSet.Tables["id_bank"].Rows[k++].ItemArray[0].ToString();

                if (i == int.Parse(j)){i++;}
                else
                {
                    ObjCommand = new SQLiteCommand("INSERT INTO BankAndInfo VALUES ('" + bank + "','" + ADRES + "','" + Phone + "','" + Mail + "','" + Website + "','" + MFO + "','" + i + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    ObjCommand = new SQLiteCommand("INSERT INTO CASH VALUES ('" + usa + "','" + eur + "','" + rub + "','" + data + "','" + i + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    ObjCommand = new SQLiteCommand("INSERT INTO ID2 VALUES ('" + i + "','" + i + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    ObjCommand = new SQLiteCommand("INSERT INTO ID3 VALUES ('" + i + "','" + i + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    
                    l = 300;
                    k = 0;
                }
            }
        }
        public void CHECKADD()
        {
            for (int g = 0; g<24; g++)
            {
                   if (checkBox[g].Checked == true) 
                   {
                       g = g + 1;
                       SQLiteCommand ObjCommand = new SQLiteCommand("INSERT INTO ID VALUES ('" + g + "','" + i + "')", ObjConnection);
                       ObjCommand.Connection.Open();
                       ObjCommand.ExecuteNonQuery();
                       ObjCommand.Connection.Close();
                       g = g - 1;
                   }
            }
            for (int gg = 0; gg < 24; gg++) { checkBox[gg].Checked = false; }
        }
        public void DELETE()
        {
            
            int delete=0;
            delete = int.Parse(dataGridView1.SelectedRows[0].Index.ToString())+1;
            
                SQLiteCommand ObjCommand = new SQLiteCommand("DELETE FROM bank WHERE id_bank=" + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM CASH WHERE ID=" + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM ID WHERE id_bank= " + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM ID2 WHERE id_bank= " + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM ID3 WHERE id_bank= " + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM InfoPoTawn WHERE id_bank= " + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                ObjCommand = new SQLiteCommand("DELETE FROM Into WHERE id=" + (delete) + "", ObjConnection);
                ObjCommand.Connection.Open();
                ObjCommand.ExecuteNonQuery();
                ObjCommand.Connection.Close();
                   
                for (int gg = 0; gg < 24; gg++){ checkBox[gg].Checked = false; } 
        }
        //ADD
        private void button1_Click(object sender, EventArgs e)
        {
            ADD(); CHECKADD();  
        } 
        //Update
        private void button2_Click(object sender, EventArgs e)
        {
            dataSet.Clear();
            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM bank ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet, "bank");
            dataGridView1.DataSource = dataSet.Tables["bank"];  
        }
        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            DELETE();          
        }
        private void button6_Click(object sender, EventArgs e)
        {
            for (k = 0; k < 24; k++){checkBox[k].Checked = false;}

            dataSet2.Clear();
            int BT;
            BT = int.Parse(dataGridView1.SelectedRows[0].Index.ToString())+1;

            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT id_town FROM ID where id_bank= "+BT+"   ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet2, "id_town");
            
            int bt = 0;
            int btt = dataSet2.Tables["id_town"].Rows.Count;

            for (k = 0; k < btt; k++)
            {
                string j = dataSet2.Tables["id_town"].Rows[k].ItemArray[0].ToString();
                bt=int.Parse(j);
                checkBox[bt-1].Checked = true;
            }
        }
        //Видалення Звязків
        private void button7_Click(object sender, EventArgs e)
        {
            int BT;
            BT = int.Parse(comboBox1.SelectedIndex.ToString()) + 1;

            for (int g = 0; g < 24; g++)
            {
                if (checkBox[g].Checked == true)
                {
                    g = g + 1;
                    SQLiteCommand ObjCommand = new SQLiteCommand("DELETE FROM ID WHERE id_town= " + g + " and id_bank=" + BT + "", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    g = g - 1;
                }
            }
            for (int gg = 0; gg < 24; gg++){checkBox[gg].Checked = false;}
        }
        //Добавленя Звязків
        private void button8_Click(object sender, EventArgs e)
        {
            int BT;
            BT = int.Parse(comboBox1.SelectedIndex.ToString()) + 1;
            for (int g = 0; g < 24; g++)
            {
                if (checkBox[g].Checked == true)
                {
                    g = g + 1;
                    SQLiteCommand ObjCommand = new SQLiteCommand("INSERT INTO ID VALUES ('" + g + "','" + BT + "')", ObjConnection);
                    ObjCommand.Connection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjCommand.Connection.Close();
                    g = g - 1;
                }
            }
            for (int gg = 0; gg < 24; gg++){checkBox[gg].Checked = false;}
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (k = 0; k < 24; k++) { checkBox[k].Checked = false; }

            dataSet2.Clear();
            int BT;
            int BTT;
            BTT = comboBox1.Items.Count;
            BT = int.Parse(comboBox1.SelectedIndex.ToString())+1;

            SQLiteCommand ObjCommand = new SQLiteCommand("SELECT id_town FROM ID where id_bank= " + BT + "   ", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            SQLiteDataAdapter ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            ObjDataAdapter.Fill(dataSet2, "id_town");


            int bt = 0;
            int btt = dataSet2.Tables["id_town"].Rows.Count;

            for (k = 0; k < btt; k++)
            {
                string j = dataSet2.Tables["id_town"].Rows[k].ItemArray[0].ToString();
                bt = int.Parse(j);
                checkBox[bt - 1].Checked = true;
            }
        }
    }
}


           