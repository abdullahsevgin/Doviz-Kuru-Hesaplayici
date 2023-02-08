using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace döviz
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        public static string gonderilecekveri;
        public static string gonderilecekveri2;
        private void Form1_Load(object sender, EventArgs e)
        {
             dataGridView1.DataSource = source();
        }

        public DataTable source()
       {
           DataRow dr;
           dt.Columns.Add(new DataColumn("Adı", typeof(string)));
           dt.Columns.Add(new DataColumn("Birimi", typeof(string)));
           dt.Columns.Add(new DataColumn("Döviz alış", typeof(decimal)));
           dt.Columns.Add(new DataColumn("Döviz satış", typeof(decimal)));
           XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
           XmlDocument myxml = new XmlDocument();
           myxml.Load(rdr);
           XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
           XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
           XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
           XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
           XmlNodeList doviz_alis = myxml.SelectNodes(string.Format("/Tarih_Date/Currency/ForexBuying"));
           XmlNodeList doviz_satis = myxml.SelectNodes(string.Format("/Tarih_Date/Currency/ForexSelling"));
           int x =20;
           for (int i = 0; i < x; i++)
           {
               dr = dt.NewRow();
               dr[0] = adi.Item(i).InnerText.ToString(); 
               dr[1] = kod.Item(i).InnerText.ToString();
               dr[2] = doviz_alis.Item(i).InnerText.Replace('.',',').ToString();
               dr[3] = doviz_satis.Item(i).InnerText.Replace('.', ',').ToString();
               
                dt.Rows.Add(dr);
           }
           dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            
            return dt;
       } 

       
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Birimi LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gonderilecekveri = dataGridView1.CurrentRow.Cells["Adı"].Value.ToString();
            gonderilecekveri2 = dataGridView1.CurrentRow.Cells["Döviz alış"].Value.ToString();
            hesap hesapla = new hesap();
            hesapla.Show();
        }
    }
}
