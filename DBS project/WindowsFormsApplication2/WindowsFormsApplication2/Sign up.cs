using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace WindowsFormsApplication2
{
    public partial class SIGNUP : Form
    {
        public SIGNUP()
        {
            InitializeComponent();
        }

        int ph1err=0;
        int ph2err=0;
        int aaderr=0;
        int namerr=0;
        String sex;
        String ph1;
        String ph2;
        String nam;
        String aad;
        String age;
        String email;
        String mnam;
        String lnam;


        private void button3_Click(object sender, EventArgs e)
        {
             sex = "xyz" ;
             ph1 = textBox10.Text;
             ph2 = textBox1.Text;
             nam = textBox5.Text;
             aad = textBox8.Text;
             age = numericUpDown2.Value.ToString();
             email = textBox9.Text;
             mnam = textBox6.Text;
             lnam = textBox7.Text;
            
          foreach (char c in ph1)
          {
            if (!Char.IsNumber(c))
              {
                 ph1err = 1;
              }
          }

          if (ph2 != "")
          {
              foreach (char c in ph2)
              {
                  if (!Char.IsNumber(c))
                  {
                      ph2err = 1;
                  }
              }
          }

          foreach (char c in aad)
          {
              if (!Char.IsNumber(c))
              {
                  aaderr = 1;
              }
          }
          foreach (char c in nam)
          {
              if (!Char.IsLetter(c))
              {
                  namerr = 1;
              }
          }

          foreach (char c in mnam)
          {
              if (!Char.IsLetter(c))
              {
                  namerr = 1;
              }
          }

          foreach (char c in lnam)
          {
              if (!Char.IsLetter(c))
              {
                  namerr = 1;
              }
          }

           
           

            if (radioButton3.Checked == true)
            {
                sex = "M";
            }
            
            else if (radioButton4.Checked == true)
            {
                sex = "F";
            }
            
            if(radioButton3.Checked==false && radioButton4.Checked == false)
            {
                MessageBox.Show("Select Gender!");
            }
                      
             else if (textBox10.Text.Length != 10 || (ph1err==1))
            {
                MessageBox.Show("Invalid Phone Number");
                textBox10.Text = "";
                ph1err = 0;
            }

            else if (textBox5.Text.Length == 0 || namerr == 1)
            {
                MessageBox.Show("Enter Proper Name!");
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                namerr = 0;
            }
            
            
            else if (!((textBox1.Text.Length == 10)||(textBox1.Text.Length==0)) || (ph2err==1))
            {
                MessageBox.Show("Invalid Phone Number");
                textBox1.Text = "";
                ph2err = 0;
            }


            else if (!textBox9.Text.Contains("@") || !textBox9.Text.Contains(".com") || !(textBox9.Text.Length >= 6))
            {
                MessageBox.Show("Invalid Email");
                textBox9.Text = "";
            }
            else if (textBox8.Text.Length != 12 ||(aaderr==1))
            {
                MessageBox.Show("Invalid Aadhar");
                textBox8.Text = "";
                aaderr = 0;
            }
            else
            {
                String oradb2 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                OracleConnection conn1 = new OracleConnection(oradb2);
                conn1.Open();
                OracleCommand comm1 = new OracleCommand();
                comm1.CommandText = "select * from passenger where aadhar_id = '" + aad + "'";
                comm1.CommandType = CommandType.Text;
                DataSet ds1 = new DataSet();
                OracleDataAdapter da1 = new OracleDataAdapter(comm1.CommandText, conn1);
                da1.Fill(ds1, "Tbl_passenger1");
                DataTable dt1 = ds1.Tables["Tbl_passenger1"];
                int t1 = dt1.Rows.Count;

                
                OracleConnection conn2 = new OracleConnection(oradb2);
                conn2.Open();
                OracleCommand comm2 = new OracleCommand();
                comm2.CommandText = "select * from passenger_phone where phone = '" + ph1 + "'";
                comm2.CommandType = CommandType.Text;
                DataSet ds2 = new DataSet();
                OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
                da2.Fill(ds2, "Tbl_passenger");
                DataTable dt2 = ds2.Tables["Tbl_passenger"];
                int t2 = dt2.Rows.Count;

                OracleConnection conn5 = new OracleConnection(oradb2);
                conn5.Open();
                OracleCommand comm5 = new OracleCommand();
                comm5.CommandText = "select * from passenger_phone where phone = '" + ph2 + "'";
                comm5.CommandType = CommandType.Text;
                DataSet ds5 = new DataSet();
                OracleDataAdapter da5 = new OracleDataAdapter(comm5.CommandText, conn5);
                da5.Fill(ds5, "Tbl_passenger2");
                DataTable dt5 = ds5.Tables["Tbl_passenger2"];
                int t3 = dt5.Rows.Count;

                if (t2 == 0 && t1==0 && t3==0 && ph1!=ph2)
                {

                    
                    try
                    {
                        String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                        OracleConnection conn = new OracleConnection(oradb);
                        conn.Open();
                        OracleCommand comm = new OracleCommand();
                        comm.Connection = conn;
                        comm.CommandText = "insert into passenger values('" + aad + "','" + nam + "','" + mnam + "','" + lnam + "','" + age + "','" + sex + "','" + email + "')";
                        comm.CommandType = CommandType.Text;
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (OracleException ex)
                    {
                         MessageBox.Show("SQL Query Failed : " + ex.ToString());
                         MessageBox.Show(age);
                    }

                    try
                    {
                         String oradb1 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                         OracleConnection conn4 = new OracleConnection(oradb1);
                         conn4.Open();
                         OracleCommand comm4 = new OracleCommand();
                         comm4.Connection = conn4;
                         comm4.CommandText = "insert into passenger_phone values('" + textBox8.Text + "','" + textBox10.Text + "')";
                         comm4.CommandType = CommandType.Text;
                         comm4.ExecuteNonQuery();
                         conn4.Close();

                     }
                     catch (OracleException ex1)
                     {
                         MessageBox.Show(""+ex1.ToString());
                     }

                     if (textBox1.Text.Length != 0)
                     {
                         try
                         {
                            String oradb3 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                            OracleConnection conn3 = new OracleConnection(oradb3);
                            conn3.Open();
                            OracleCommand comm3 = new OracleCommand();
                            comm3.Connection = conn3;
                            comm3.CommandText = "insert into passenger_phone values('" + textBox8.Text + "','" + textBox1.Text + "')";
                            comm3.CommandType = CommandType.Text;
                            comm3.ExecuteNonQuery();
                            conn3.Close();
                            //MessageBox.Show("Account Created");
                            
                         }
                         catch (OracleException ex1)
                         {
                            MessageBox.Show("" + ex1.ToString());
                         }

                     }

                     MessageBox.Show("Account Created");

                     Menu m = new Menu(aad, nam, mnam, lnam, age, sex, email, ph1, ph2);
                     m.Show();
                     this.Hide();
                }
                else if(t1!=0)
                {
                    MessageBox.Show("Aadhar ID already registered!");
                }
                else if (t2 != 0)
                {
                    MessageBox.Show("Phone Number already registered!");
                }
                else if (t3 != 0)
                {
                    MessageBox.Show("Phone Number already registered!");
                }
                else if (ph1==ph2)
                {
                    MessageBox.Show("Enter Different Numbers");
                    textBox1.Text = "";
                }
                conn2.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lgn f= new lgn();
            f.Show();
            this.Hide();
        }

        private void SIGNUP_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
