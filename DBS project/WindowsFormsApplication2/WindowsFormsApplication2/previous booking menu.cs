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
    public partial class PREVBOOK : Form
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

        public PREVBOOK()
        {
            InitializeComponent();
        }

        public PREVBOOK(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9)
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

            String oradb2 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";

            OracleConnection conn2 = new OracleConnection(oradb2);
            conn2.Open();
            OracleCommand comm2 = new OracleCommand();
            comm2.CommandText = "select booking_id from passenger_booking where aadhar_id = '" + s1 + "'";
            comm2.CommandType = CommandType.Text;
            DataSet ds2 = new DataSet();
            OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
            da2.Fill(ds2, "Tbl_passenger");
            DataTable dt2 = ds2.Tables["Tbl_passenger"];
            int t2 = dt2.Rows.Count;
                for (int j = 0; j < t2; j++)
                {
                    DataRow dr = dt2.Rows[j];
                    comboBox1.Items.Add(dr["BOOKING_ID"].ToString());
                }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (book_id == "")
                MessageBox.Show("Make selection!");
            else
            {
                PREVBOOKDET f = new PREVBOOKDET(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2, book_id);
                f.Show();
                this.Hide();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                book_id = comboBox1.SelectedItem.ToString();
                String oradb2 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                OracleConnection conn2 = new OracleConnection(oradb2);
                conn2.Open();
                OracleCommand comm2 = new OracleCommand();
                comm2.CommandText = "select dat from passenger_booking where booking_id = '" + book_id + "'";
                comm2.CommandType = CommandType.Text;
                DataSet ds2 = new DataSet();
                OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
                da2.Fill(ds2, "Tbl_passenger");
                DataTable dt2 = ds2.Tables["Tbl_passenger"];
                int t2 = dt2.Rows.Count;
                DataRow dr = dt2.Rows[0];
                textBox5.Text = dr["DAT"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make a selection!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
