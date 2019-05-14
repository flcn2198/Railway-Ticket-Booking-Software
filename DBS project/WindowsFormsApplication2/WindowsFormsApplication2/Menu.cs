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
    public partial class Menu : Form
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
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9)
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
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            makebooking m = new makebooking(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USERDETAILS f = new USERDETAILS(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String oradb2 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";
            OracleConnection conn2 = new OracleConnection(oradb2);
            conn2.Open();
            OracleCommand comm2 = new OracleCommand();
            comm2.CommandText = "select booking_id from passenger_booking where aadhar_id = '" + aad + "'";
            comm2.CommandType = CommandType.Text;
            DataSet ds2 = new DataSet();
            OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
            da2.Fill(ds2, "Tbl_passenger");
            DataTable dt2 = ds2.Tables["Tbl_passenger"];
            int t2 = dt2.Rows.Count;
            if (t2 == 0)
            {
                MessageBox.Show("No previous bookings!");
            }
            else
            {
                PREVBOOK f = new PREVBOOK(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
                f.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lgn f = new lgn();
            f.Show();
            this.Hide();
        }
    }
}
