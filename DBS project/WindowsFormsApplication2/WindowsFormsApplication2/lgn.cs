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
    public partial class lgn : Form
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
        public lgn()
        {
            InitializeComponent();
        }
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            SIGNUP f = new SIGNUP();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String oradb = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                comm.CommandText = "select * from passenger where fname = '" + textBox1.Text + "' and aadhar_id = '" + textBox2.Text + "'";
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_passenger");
                DataTable dt = ds.Tables["Tbl_passenger"];
                int t1 = dt.Rows.Count;
                DataRow dr = dt.Rows[i];
                if (t1 != 0)
                {
                    aad = dr["AADHAR_ID"].ToString();
                    fnam = dr["FNAME"].ToString();
                    mnam = dr["MNAME"].ToString();
                    lnam = dr["LNAME"].ToString();
                    age = dr["AGE"].ToString();
                    sex = dr["SEX"].ToString();
                    eml = dr["EMAIL_ID"].ToString();
                    OracleConnection conn1 = new OracleConnection(oradb);
                    conn1.Open();
                    OracleCommand comm1 = new OracleCommand();
                    comm1.CommandText = "select * from passenger_phone where aadhar_id = '" + aad + "'";
                    comm1.CommandType = CommandType.Text;
                    DataSet ds1 = new DataSet();
                    OracleDataAdapter da1 = new OracleDataAdapter(comm1.CommandText, conn1);
                    da1.Fill(ds1, "Tbl_passenger_phone");
                    DataTable dt1 = ds1.Tables["Tbl_passenger_phone"];
                    int t2 = dt1.Rows.Count;
                    DataRow dr1 = dt1.Rows[i];
                    if (t2 == 1)
                    {
                        ph1 = dr1["PHONE"].ToString();
                        ph2 = "";
                    }
                    if (t2 == 2)
                    {
                        ph1 = dr1["PHONE"].ToString();
                        dr1 = dt1.Rows[i + 1];
                        ph2 = dr1["PHONE"].ToString();
                    }
                    Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
                    m.Show();
                    this.Hide();
                    conn1.Close();
                }

                conn.Close();
            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid Details!");
                textBox1.Text = "";
               textBox2.Text = "";
            }
        }

    }
}
