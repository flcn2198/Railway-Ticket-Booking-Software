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
    public partial class PREVBOOKDET : Form
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

        public PREVBOOKDET()
        {
            InitializeComponent();
        }

        public PREVBOOKDET(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9,String book)
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
            String oradb2 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";

            OracleConnection conn2 = new OracleConnection(oradb2);
            conn2.Open();
            OracleCommand comm2 = new OracleCommand();
            comm2.CommandText = "select * from passenger_booking where booking_id = '" + book + "'";
            comm2.CommandType = CommandType.Text;
            DataSet ds2 = new DataSet();
            OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
            da2.Fill(ds2, "Tbl_passenger_booking");
            DataTable dt2 = ds2.Tables["Tbl_passenger_booking"];
            int t2 = dt2.Rows.Count;
            DataRow dr2 = dt2.Rows[0];
            textBox1.Text = dr2["BOOKING_ID"].ToString();
            textBox4.Text = dr2["CATERING"].ToString();
            textBox8.Text = dr2["COST"].ToString();
            conn2.Close();

            OracleConnection conn= new OracleConnection(oradb2);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.CommandText = "select * from train_booking where booking_id = '" + book + "'";
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_train_booking");
            DataTable dt = ds.Tables["Tbl_train_booking"];
            int t = dt.Rows.Count;
            DataRow dr = dt.Rows[0];
            textBox7.Text = dr["TRAIN_ID"].ToString();
            train = dr["TRAIN_ID"].ToString();
            conn.Close();

            OracleConnection conn1 = new OracleConnection(oradb2);
            conn1.Open();
            OracleCommand comm1 = new OracleCommand();
            comm1.CommandText = "select * from train where train_id = '" + train + "'";
            comm1.CommandType = CommandType.Text;
            DataSet ds1 = new DataSet();
            OracleDataAdapter da1 = new OracleDataAdapter(comm1.CommandText, conn1);
            da1.Fill(ds1, "Tbl_train");
            DataTable dt1 = ds1.Tables["Tbl_train"];
            int t1 = dt1.Rows.Count;
            DataRow dr1 = dt1.Rows[0];
            textBox6.Text = dr1["ROUTE"].ToString();
            conn1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PREVBOOK f = new PREVBOOK(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Feedback fe = new Feedback(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2,book_id);
            fe.Show();
            this.Hide();
            
        }
    }
}
