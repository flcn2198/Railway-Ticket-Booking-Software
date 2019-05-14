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
    public partial class Feedback : Form
    {
        String aad;
        String fnam;
        String mnam;
        String lnam;
        String age;
        String sex;
        String eml;
        String ph1;
        String ph2;
        String book_id;
        String train;
        String feed;
        String qos;
        int count;
        int count2;

        
        public Feedback(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9,String book)
        {
            InitializeComponent();
            aad = s1;
            fnam = s2;
            mnam = s3;
            lnam = s4;
            age = s5;
            sex = s6;
            eml = s7;
            ph1 = s8;
            ph2 = s9;
            book_id = book;
           
        }
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            PREVBOOKDET f = new PREVBOOKDET(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2, book_id);
            f.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("Select QOS!");
            }

            else
            {
                String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                comm.CommandText = "select * from feedback where booking_id = '" + book_id + "'";
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_feedback");
                DataTable dt = ds.Tables["Tbl_feedback"];
                count = dt.Rows.Count;
                conn.Close();

                if (count == 0)
                {

                    try
                    {
                        String oradb1 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                        OracleConnection conn1 = new OracleConnection(oradb1);
                        conn1.Open();
                        OracleCommand comm1 = new OracleCommand();
                        comm1.CommandText = "select * from feedback";
                        comm1.CommandType = CommandType.Text;
                        DataSet ds1 = new DataSet();
                        OracleDataAdapter da1 = new OracleDataAdapter(comm1.CommandText, conn1);
                        da1.Fill(ds1, "Tbl_feedback");
                        DataTable dt1 = ds1.Tables["Tbl_feedback"];
                        count2 = dt1.Rows.Count;
                        conn1.Close();

                        feed = "FD_" + count2;

                        String oradb3 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                        OracleConnection conn3 = new OracleConnection(oradb3);
                        conn3.Open();
                        OracleCommand comm3 = new OracleCommand();
                        comm3.Connection = conn3;
                        comm3.CommandText = "insert into feedback values('" + feed + "','" + book_id + "','" + qos + "')";
                        comm3.CommandType = CommandType.Text;
                       
                        comm3.ExecuteNonQuery();
                        conn3.Close();

                        MessageBox.Show("Thanks for feedback");

                        PREVBOOK f = new PREVBOOK(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
                        f.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            feed = "FD_" + 0;

                            String oradb3 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                            OracleConnection conn3 = new OracleConnection(oradb3);
                            conn3.Open();
                            OracleCommand comm3 = new OracleCommand();
                            comm3.Connection = conn3;
                            comm3.CommandText = "insert into feedback values('" + feed + "','" + book_id + "','" + qos + "')";
                            comm3.CommandType = CommandType.Text;
                           
                            comm3.ExecuteNonQuery();
                            conn3.Close();

                            MessageBox.Show("Thanks for feedback");

                            PREVBOOK f = new PREVBOOK(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
                            f.Show();
                            this.Hide();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show("error");
                        }

                    }
                }

                else
                {
                    MessageBox.Show("Feedback already provided!");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            qos = radioButton2.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            qos = radioButton1.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            qos = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            qos = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            qos = radioButton5.Text;
        }
    }
}
