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
    public partial class USERDETAILS : Form
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
        public USERDETAILS()
        {
            InitializeComponent();
        }
        public USERDETAILS(String s1, String s2, String s3, String s4, String s5, String s6, String s7, String s8, String s9)
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
            textBox8.Text = s1;
            textBox5.Text = s2;
            textBox6.Text = s3;
            textBox7.Text = s4;
            textBox2.Text = s5;
            textBox1.Text = s6;
            textBox9.Text = s7;
            textBox10.Text = s8;
            textBox3.Text = s9;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu m = new Menu(aad, fnam, mnam, lnam, age, sex, eml, ph1, ph2);
            m.Show();
            this.Hide();
        }
    }
}
