using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pansiyon_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=EMIRMONSTER\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True");
        
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From Müsteriler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyadı"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into müsteriler (id,Ad,Soyadı,OdaNo,GTarih,Telefon,Hesap,CTarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            komut.CommandText = ("insert into dolu(doluyerler) values ('" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete From bosoda where bosyerler='" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();

            baglan.Close();
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Text = "";
        }

        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand ("Delete From Müsteriler where id=("+id+")",baglan);
            komut.ExecuteNonQuery();
            komut.CommandText = ("insert into bosoda(bosyerler) values ('" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete From doluoda where doluyerler='" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();

            baglan.Close();
            verilerigoster();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);


            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Müsteriler set id='" + textBox1.Text.ToString() + "',Ad='" + textBox2.Text.ToString() + "',Soyadı='" + textBox3.Text.ToString() + "',OdaNo='" + comboBox1.Text.ToString() + "',GTarih='" + dateTimePicker1.Text.ToString() + "',Telefon='" + textBox5.Text.ToString() + "',Hesap='" + textBox6.Text.ToString() + "',CTarih='" + dateTimePicker2.Text.ToString() + "' where id=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From Müsteriler where ad like '%" + textBox7.Text + "%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyadı"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text  = label10.Text.Substring(1)+ label10.Text.Substring(0,1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from bosoda", baglan);
            SqlDataReader oda = komut.ExecuteReader();
            while (oda.Read())
            {
                comboBox1.Items.Add(oda[0].ToString());

            }
            baglan.Close();
        }
    }
}
