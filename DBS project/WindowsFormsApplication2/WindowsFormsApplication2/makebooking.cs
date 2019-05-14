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
    public partial class makebooking : Form
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

        String route;
        String train;
        String day;
        String meal;
        String dat;
        String book_id;
        String nos;
        int cost = 100;
        int nosn;
        String time;

        public makebooking()
        {
            InitializeComponent();
        }
        public makebooking(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9)
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
            int i = 0;
            String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.CommandText = "select distinct route from TRAIN";
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_train_schedule");
            DataTable dt = ds.Tables["Tbl_train_schedule"];
            int t1 = dt.Rows.Count;
            for (int j = 0; j < t1; j++)
            {
                DataRow dr = dt.Rows[j];
                comboBox1.Items.Add(dr["ROUTE"].ToString());
            }
            comboBox3.Items.Add("MONDAY");
            comboBox3.Items.Add("TUESDAY");
            comboBox3.Items.Add("WEDNESDAY");
            comboBox3.Items.Add("THURSDAY");
            comboBox3.Items.Add("FRIDAY");
            comboBox3.Items.Add("SATURDAY");
            comboBox3.Items.Add("SUNDAY");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void makebooking_Load(object sender, EventArgs e)
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
            if (radioButton1.Checked == true)
            {
                meal = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                meal = radioButton2.Text;
            }
            if (radioButton3.Checked == true)
            {
                meal = radioButton3.Text;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Select meal preference!");
            }
            else if(nos == "") 
            {
                MessageBox.Show("Select seats!");
            }
            else
            {
                try
                {
                    nosn = int.Parse(nos);
                    cost = cost * nosn;
                    dat = DateTime.Now.ToString("yyyy-MM-dd");
                    book_id = train + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    confirmbooking c = new confirmbooking(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2, dat, meal, book_id, nos, cost+"", train, day, route, time);
                    c.Show();
                    this.Hide();
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Select seats!");
                }
              
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            nos = comboBox4.SelectedItem.ToString(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            day = comboBox3.SelectedItem.ToString();
            route = comboBox1.SelectedItem.ToString();
            try
            {
                String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                comm.CommandText = "select train_id from TRAIN natural join TRAIN_SCHEDULE where route = '"+ route +"' and day = '"+day+"'";
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_train_schedule");
                DataTable dt = ds.Tables["Tbl_train_schedule"];
                int t1 = dt.Rows.Count;
                if (t1 == 0)
                {
                    MessageBox.Show("No such train exists!");
                }
                else
                {
                    for (int j = 0; j < t1; j++)
                    {
                        DataRow dr = dt.Rows[j];
                        comboBox2.Items.Add(dr["TRAIN_ID"].ToString());
                    }
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex+"");
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = 0;
            train = comboBox2.SelectedItem.ToString();
            String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.CommandText = "select time from TRAIN_SCHEDULE where train_id = '" + train + "' and day = '" + day + "'";
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_train_schedule");
            DataTable dt = ds.Tables["Tbl_train_schedule"];
            int t = dt.Rows.Count;
            DataRow dr = dt.Rows[j];
            time = dr["TIME"].ToString();
            textBox4.Text = dr["TIME"].ToString();
            

            OracleConnection conn1 = new OracleConnection(oradb);
            conn1.Open();
            OracleCommand comm1 = new OracleCommand();
            comm1.CommandText = "select cap from TRAIN where train_id = '" + train + "'";
            comm1.CommandType = CommandType.Text;
            DataSet ds1 = new DataSet();
            OracleDataAdapter da1 = new OracleDataAdapter(comm1.CommandText, conn1);
            da1.Fill(ds1, "Tbl_train");
            DataTable dt1 = ds1.Tables["Tbl_train"];
            int t1 = dt1.Rows.Count;
            DataRow dr1 = dt1.Rows[j];
            int c = int.Parse(dr1["CAP"].ToString());
            if (c == 0)
                MessageBox.Show("Train is completely booked!");
            else
            {
                for (int x = 1; x <= c; x++)
                {
                    if (x == 11)
                        break;
                    comboBox4.Items.Add("" + x);
                }
            }
            conn.Close();
            conn1.Close();
        }
    }
}
