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
    public partial class confirmbooking : Form
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

        String train;
        String meal;
        String dat;
        String day;
        String book_id;
        String nos;
        String cost;

        public confirmbooking()
        {
            InitializeComponent();
        }

        public confirmbooking(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9, String dat, String meal, String book_id,String nos, String cost, String train, String day, String route, String time)
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

            this.dat = dat;
            this.day = day;
            this.meal = meal;
            this.book_id = book_id;
            this.nos = nos;
            this.cost = cost;
            this.train = train;

            textBox5.Text = route;
            textBox1.Text = train;
            textBox7.Text = day;
            textBox4.Text = time;
            textBox2.Text = nos;
            textBox6.Text = cost;
            textBox8.Text = meal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            makebooking ma = new makebooking(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            ma.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oradb3 = "Data Source=xe;Persist Security Info=True;User ID=SYSTEM;Password=pogkaku";

            OracleConnection conn3 = new OracleConnection(oradb3);
            conn3.Open();
            OracleCommand comm3 = new OracleCommand();
            comm3.Connection = conn3;
            comm3.CommandText = "insert into passenger_booking values('" + aad + "', '" + dat + "','" + meal + "','" + book_id + "','" + nos + "','" + cost + "')";
            comm3.CommandType = CommandType.Text;
            comm3.ExecuteNonQuery();
           
            conn3.Close();

            OracleConnection conn4 = new OracleConnection(oradb3);
            conn4.Open();
            OracleCommand comm4 = new OracleCommand();
            comm4.Connection = conn4;
            comm4.CommandText = "insert into train_booking values('" + train + "','" + book_id + "','" + dat + "')";
            comm4.CommandType = CommandType.Text;
            comm4.ExecuteNonQuery();
         
            conn4.Close();
            MessageBox.Show("Booking Confirmed!");
            Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
