using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HatipOglu1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Musteri-----------------------
        OleDbConnection baglanti = new OleDbConnection();
        OleDbCommand SorguCalistir;
        string sorgu, islem;
        OleDbDataReader SorguSonucu;
        DataTable dt = new DataTable();

        //Kasa**************************
        OleDbConnection baglanti2 = new OleDbConnection();
        OleDbCommand SorguCalistir2;
        string sorgu2, islem2;
        OleDbDataReader SorguSonucu2;
        DataTable dt2 = new DataTable();


        //musteri------------------------
        public void musteriVeri_oku() //verit tabanından verileri okuyan bir metod tanımlandı
        {
            if (baglanti.State == ConnectionState.Closed) { baglanti.Open(); }
            //baglanti.Open();
            SorguCalistir = new OleDbCommand(sorgu, baglanti);
            SorguSonucu = SorguCalistir.ExecuteReader();

            dt.Clear();
            dt.Load(SorguSonucu);

            // dataGridView1.Rows[0].Selected = true;
            baglanti.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                metroGrid1.Rows[i].Cells["SNo"].Value = i + 1;
            }

        }

        //kasa***************************
        public void kasaVeri_oku() //verit tabanından verileri okuyan bir metod tanımlandı
        {
            if (baglanti2.State == ConnectionState.Closed) { baglanti2.Open(); }
            //baglanti.Open();
            SorguCalistir2 = new OleDbCommand(sorgu2, baglanti2);
            SorguSonucu2 = SorguCalistir2.ExecuteReader();

            dt2.Clear();
            dt2.Load(SorguSonucu2);

            // dataGridView1.Rows[0].Selected = true;
            baglanti2.Close();

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                metroGrid2.Rows[i].Cells["SNo"].Value = i + 1;
            }

        }

        //musteri----------------------------------
        public void musteriText_doldur()
        {
            try
            {
                metroDateTime1.Text = metroGrid1.SelectedRows[0].Cells["tarih"].Value.ToString();
                txtTC.Text = metroGrid1.SelectedRows[0].Cells["tcKimlik"].Value.ToString();
                txtAdi.Text = metroGrid1.SelectedRows[0].Cells["adi"].Value.ToString();
                txtSoyadi.Text = metroGrid1.SelectedRows[0].Cells["soyadi"].Value.ToString();
                txtTutar.Text = metroGrid1.SelectedRows[0].Cells["toplamTutar"].Value.ToString();
                metroComboBox1.Text = metroGrid1.SelectedRows[0].Cells["odendi"].Value.ToString();
                txtOdenenTutar.Text = metroGrid1.SelectedRows[0].Cells["odenenTutar"].Value.ToString();
                txtKalanTutar.Text = metroGrid1.SelectedRows[0].Cells["kalanTutar"].Value.ToString();
                txtAciklama.Text = metroGrid1.SelectedRows[0].Cells["aciklama"].Value.ToString();
            }
            catch
            {
                //Burada herhangi bir kod yazmadık buda yukarıdai kodlar çalışırken herhangi bir nedenden dolayı
                //program hatayla karşılaşırsa (seçili satırın negatif gözükmesi yani seçili satır olmaması) kırılmadan devam edecek
            }


        }

        //musteri----------------------------------------------------------------------------
        private void TxtAdAra_TextChanged(object sender, EventArgs e)//ada göre arama
        {
            sorgu = "Select * from musteri where adi like '" + txtAdAra.Text + "%'";
            musteriVeri_oku();
        }

        //musteri-----------------------------------------------------------------------------
        private void TxtOdendiAra_TextChanged(object sender, EventArgs e)//odemeye göre ara
        {
            sorgu = "Select * from musteri where odendi like '" + txtOdendiAra.Text + "%'";
            musteriVeri_oku();
        }

        //kasa********************************************************************************
        private void TxtCAdAra_TextChanged(object sender, EventArgs e)//çalısan ismine göre arama
        {
            sorgu2 = "Select * from kasa where calisanAdi like '" + txtCAdAra.Text + "%'";
            kasaVeri_oku();
        }
        //kasa******************************************************************************
        private void TxtCOdendi_TextChanged(object sender, EventArgs e)
        {
            sorgu2 = "Select * from kasa where ucretOdendi like '" + txtCOdendi.Text + "%'";
            kasaVeri_oku();
        }

        //muster-----------------------------------------------------------------------------
        private void MetroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            musteriText_doldur();
        }
        //kasa******************************************************************************
        private void MetroGrid2_SelectionChanged(object sender, EventArgs e)
        {
            kasaText_doldur();
        }

        //musteri-----------------------------------------------------------------------------
        private void Mduzenle_Click(object sender, EventArgs e)
        {
            metroDateTime1.Enabled = true;
            txtTC.Enabled = true;
            txtAdi.Enabled = true;
            txtSoyadi.Enabled = true;
            txtTutar.Enabled = true;
            metroComboBox1.Enabled = true;
            txtOdenenTutar.Enabled = true;
            txtKalanTutar.Enabled = true;
            txtAciklama.Enabled = true;
            Mkaydet.Enabled = true;
            Miptal.Enabled = true;
            islem = "DÜZENLE";
            Myeni.Enabled = false;
            Mduzenle.Enabled = false;
            Msil.Enabled = false;
            
        }
        //kasa***************************************************
        private void Kduzenle_Click(object sender, EventArgs e)
        {
            metroDateTime2.Enabled = true;
            txtGelir.Enabled = true;
            txtGider.Enabled = true;
            txtKasa.Enabled = true;
            txtCAdi.Enabled = true;
            txtCSoyadi.Enabled = true;
            txtCUcreti.Enabled = true;
            metroComboBox2.Enabled = true;
            txtCOdenen.Enabled = true;
            txtCKalan.Enabled = true;
            txtCAciklama.Enabled = true;
            Kiptal.Enabled = true;
            Kkaydet.Enabled = true;
            Kyeni.Enabled = false;
            Kduzenle.Enabled = false;
            Ksil.Enabled = false;
            islem2 = "DÜZENLE2";
        }

        //musteri----------------------------------------------
        private void Myeni_Click(object sender, EventArgs e)
        {
            metroDateTime1.Enabled = true;
            txtTC.Enabled = true;
            txtAdi.Enabled = true;
            txtSoyadi.Enabled = true;
            txtTutar.Enabled = true;
            metroComboBox1.Enabled = true;
            txtOdenenTutar.Enabled = true;
            txtKalanTutar.Enabled = true;
            txtAciklama.Enabled = true;
            Mkaydet.Enabled = true;
            Miptal.Enabled = true;
            islem = "YENİ";
            Myeni.Enabled = false;
            Mduzenle.Enabled = false;
            Msil.Enabled = false;
            metroDateTime1.Text= DateTime.Today.ToString();
            txtTC.Text = "";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            txtTutar.Text = "";
            txtOdenenTutar.Text = "";
            txtKalanTutar.Text = "";
            txtAciklama.Text = "";

        }

        private void Kkaydet_Click(object sender, EventArgs e)
        {
            if (islem2 == "YENİ2")
            {
                sorgu2 = "insert into kasa(tarih,gelir,gider,kasa,calisanAdi,calisanSoyadi,calisanUcreti,ucretOdendi,odenenTutar,kalanTutar,aciklama) values('" + Convert.ToDateTime(metroDateTime2.Text).ToShortDateString() + "','" + txtGelir.Text + "','" + txtGider.Text + "','" + txtKasa.Text + "','" + txtCAdi.Text + "','" + txtCSoyadi.Text + "','" + txtCUcreti.Text + "','" + metroComboBox2.Text + "','" + txtCOdenen.Text + "','" + txtCKalan.Text + "','" + txtCAciklama.Text + "')";
            }

            if (islem2 == "DÜZENLE2")
            {
                // sorgu = "update Satis set UrunAdi='" + txt_UrunAdi.Text + "' where SatisKodu=" + dataGridView1.SelectedRows[0].Cells["SatisKodu"].Value;
                // sorgu= "update Satis set Tarih='10.4.2021', UrunAdi='Vişne', BirimFiyat=4, Miktar=4 where SatisKodu=" + dataGridView1.SelectedRows[0].Cells["SatisKodu"].Value;
                sorgu2 = "update kasa set tarih='" + Convert.ToDateTime(metroDateTime2.Text).ToShortDateString() + "',gelir='" + txtGelir.Text + "',gider='" + txtGider.Text + "',kasa='" + txtKasa.Text + "',calisanAdi='" + txtCAdi.Text + "',calisanSoyadi='" + txtCSoyadi.Text + "',calisanUcreti='" + txtCUcreti.Text + "',ucretOdendi='" + metroComboBox2.Text + "',odenenTutar='" + txtCOdenen.Text + "',kalanTutar='"+ txtCKalan.Text+ "',aciklama='"+ txtCAciklama.Text + "' where ID=" + metroGrid2.SelectedRows[0].Cells["ID"].Value;

            }
            baglanti2.Open();
            SorguCalistir2 = new OleDbCommand(sorgu2, baglanti2);
            SorguCalistir2.ExecuteNonQuery();
            baglanti2.Close();

            sorgu2 = "select * from kasa";
            kasaVeri_oku();


            metroDateTime2.Enabled = false;
            txtGelir.Enabled = false;
            txtGider.Enabled = false;
            txtKasa.Enabled = false;
            txtCAdi.Enabled = false;
            txtCSoyadi.Enabled = false;
            txtCUcreti.Enabled = false;
            metroComboBox2.Enabled = false;
            txtCOdenen.Enabled = false;
            txtCKalan.Enabled = false;
            txtCAciklama.Enabled = false;
            Kiptal.Enabled = false;
            Kkaydet.Enabled = false;

            Kyeni.Enabled = true;
            Kduzenle.Enabled = true;
            Ksil.Enabled = true;

        }

        private void Kyeni_Click(object sender, EventArgs e)
        {
            metroDateTime2.Enabled = true;
            txtGelir.Enabled = true;
            txtGider.Enabled = true;
            txtKasa.Enabled = true;
            txtCAdi.Enabled = true;
            txtCSoyadi.Enabled = true;
            txtCUcreti.Enabled = true;
            metroComboBox2.Enabled = true;
            txtCOdenen.Enabled = true;
            txtCKalan.Enabled = true;
            txtCAciklama.Enabled = true;
            Kiptal.Enabled = true;
            Kkaydet.Enabled = true;
            Kyeni.Enabled = false;
            Kduzenle.Enabled = false;
            Ksil.Enabled = false;
            islem2 = "YENİ2";

            metroDateTime2.Text= DateTime.Today.ToString();
            txtGelir.Text = "";
            txtGider.Text = "";
            txtKasa.Text = "";
            txtCAdi.Text = "";
            txtCSoyadi.Text = "";
            txtCUcreti.Text = "";
            txtCOdendi.Text = "";
            txtCOdenen.Text = "";
            txtCKalan.Text = "";
            txtCAciklama.Text = "";

        }

        private void Miptal_Click(object sender, EventArgs e)
        {
            metroDateTime1.Enabled = false;
            txtTC.Enabled = false;
            txtAdi.Enabled = false;
            txtSoyadi.Enabled = false;
            txtTutar.Enabled = false;
            metroComboBox1.Enabled = false;
            txtOdenenTutar.Enabled = false;
            txtKalanTutar.Enabled = false;
            txtAciklama.Enabled = false;
            Mkaydet.Enabled = false;
            Miptal.Enabled = false;
            Msil.Enabled = true;
            Myeni.Enabled = true;
            Mduzenle.Enabled = true;

            musteriText_doldur();
        }

        private void Kiptal_Click(object sender, EventArgs e)
        {
            metroDateTime2.Enabled = false;
            txtGelir.Enabled = false;
            txtGider.Enabled = false;
            txtKasa.Enabled = false;
            txtCAdi.Enabled = false;
            txtCSoyadi.Enabled = false;
            txtCUcreti.Enabled = false;
            metroComboBox2.Enabled = false;
            txtCOdenen.Enabled = false;
            txtCKalan.Enabled = false;
            txtCAciklama.Enabled = false;
            Kiptal.Enabled = false;
            Kkaydet.Enabled = false;
            Ksil.Enabled = true;
            Kyeni.Enabled = true;
            Kduzenle.Enabled = true;
            kasaText_doldur();
        }

        private void Mkaydet_Click(object sender, EventArgs e)
        {
            if (islem == "YENİ")
            {
                sorgu = "insert into musteri(tarih,tcKimlik,adi,soyadi,toplamTutar,odendi,odenenTutar,kalanTutar,aciklama) values('" + Convert.ToDateTime(metroDateTime1.Text).ToShortDateString() + "','" + txtTC.Text + "','" + txtAdi.Text + "','" + txtSoyadi.Text + "','" + txtTutar.Text + "','" + metroComboBox1.Text + "','" + txtOdenenTutar.Text + "','" + txtKalanTutar.Text + "','" + txtAciklama.Text + "')";
            }

            if (islem == "DÜZENLE")
            {
                // sorgu = "update Satis set UrunAdi='" + txt_UrunAdi.Text + "' where SatisKodu=" + dataGridView1.SelectedRows[0].Cells["SatisKodu"].Value;
                // sorgu= "update Satis set Tarih='10.4.2021', UrunAdi='Vişne', BirimFiyat=4, Miktar=4 where SatisKodu=" + dataGridView1.SelectedRows[0].Cells["SatisKodu"].Value;
                sorgu = "update musteri set tarih='" + Convert.ToDateTime(metroDateTime1.Text).ToShortDateString() + "',tcKimlik='" + txtTC.Text + "',adi='" + txtAdi.Text + "',soyadi='" + txtSoyadi.Text + "',toplamTutar='" + txtTutar.Text + "',odendi='"+ metroComboBox1.Text + "',odenenTutar='"+ txtOdenenTutar.Text + "',kalanTutar='"+txtKalanTutar.Text + "',aciklama='"+ txtAciklama.Text+ "' where ID=" + metroGrid1.SelectedRows[0].Cells["ID"].Value;

            }
            baglanti.Open();
            SorguCalistir = new OleDbCommand(sorgu, baglanti);
            SorguCalistir.ExecuteNonQuery();
            baglanti.Close();

            sorgu = "select * from musteri";
            musteriVeri_oku();


            metroDateTime1.Enabled = false;
            txtTC.Enabled = false;
            txtAdi.Enabled = false;
            txtSoyadi.Enabled = false;
            txtTutar.Enabled = false;
            metroComboBox1.Enabled = false;
            txtOdenenTutar.Enabled = false;
            txtKalanTutar.Enabled = false;
            txtAciklama.Enabled = false;
            Mkaydet.Enabled = false;
            Miptal.Enabled = false;
            Myeni.Enabled = true;
            Mduzenle.Enabled = true;
            Msil.Enabled = true;
        }

        private void TarihAra_TextChanged(object sender, EventArgs e)//kasa tarihe göre ara
        {
            sorgu2 = "Select * from kasa where tarih like '" + tarihAra.Text + "%'";
            kasaVeri_oku();
        }

        //kasa sil************************************************
        private void Ksil_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "DİKKAT!! Seçtiğiniz veriyi silerseniz bir daha geri getiremezsiniz.Bu veriyi silmek istediğinizden emin misiniz?", "VERİ SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (metroGrid2.SelectedRows.Count > 0)
                {
                    int selectedRowIndex3 = metroGrid2.SelectedRows[0].Index;
                    int selectedRecordId3 = Convert.ToInt32(metroGrid2.Rows[selectedRowIndex3].Cells["Id"].Value); // Burada "Id", DataGridView'deki ilgili sütunun adını temsil etmelidir.

                    // Access veritabanı bağlantısını yapın
                    string connectionString3 = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\\veriTabani.mdb"; // Veritabanı yolunu ve bağlantı sağlayıcıyı uygun şekilde değiştirin
                    using (OleDbConnection connection3 = new OleDbConnection(connectionString3))
                    {
                        connection3.Open();

                        // Silme sorgusunu oluşturun
                        string deleteQuery3 = "DELETE FROM kasa WHERE Id = @ID"; // TabloAdi, silinecek kaydın bulunduğu tablo adıdır. "Id", ilgili sütunun adını temsil etmelidir.

                        // Parametreleri ayarlayın
                        using (OleDbCommand command3 = new OleDbCommand(deleteQuery3, connection3))
                        {
                            command3.Parameters.AddWithValue("@ID", selectedRecordId3);

                            // Sorguyu çalıştırın
                            command3.ExecuteNonQuery();
                        }

                        // Veritabanı bağlantısını kapatın
                        connection3.Close();
                    }

                    // DataGridView'den seçili satırı kaldırın
                    metroGrid2.Rows.RemoveAt(selectedRowIndex3);

                    ////////////////////////////////////////////////
                    baglanti2.Open();
                    SorguCalistir2 = new OleDbCommand(sorgu2, baglanti2);
                    SorguCalistir2.ExecuteNonQuery();
                    baglanti2.Close();

                    sorgu2 = "select * from kasa";
                    kasaVeri_oku();

                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }
        }

        private void Msil_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "DİKKAT!! Seçtiğiniz veriyi silerseniz bir daha geri getiremezsiniz.Bu veriyi silmek istediğinizden emin misiniz?", "VERİ SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (metroGrid1.SelectedRows.Count > 0)
                {
                    int selectedRowIndex4 = metroGrid1.SelectedRows[0].Index;
                    int selectedRecordId4 = Convert.ToInt32(metroGrid1.Rows[selectedRowIndex4].Cells["Id"].Value); // Burada "Id", DataGridView'deki ilgili sütunun adını temsil etmelidir.

                    // Access veritabanı bağlantısını yapın
                    string connectionString4 = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\\veriTabani.mdb"; // Veritabanı yolunu ve bağlantı sağlayıcıyı uygun şekilde değiştirin
                    using (OleDbConnection connection4 = new OleDbConnection(connectionString4))
                    {
                        connection4.Open();

                        // Silme sorgusunu oluşturun
                        string deleteQuery4 = "DELETE FROM musteri WHERE Id = @ID"; // TabloAdi, silinecek kaydın bulunduğu tablo adıdır. "Id", ilgili sütunun adını temsil etmelidir.

                        // Parametreleri ayarlayın
                        using (OleDbCommand command4 = new OleDbCommand(deleteQuery4, connection4))
                        {
                            command4.Parameters.AddWithValue("@ID", selectedRecordId4);

                            // Sorguyu çalıştırın
                            command4.ExecuteNonQuery();
                        }

                        // Veritabanı bağlantısını kapatın
                        connection4.Close();
                    }

                    // DataGridView'den seçili satırı kaldırın
                    metroGrid1.Rows.RemoveAt(selectedRowIndex4);

                    ////////////////////////////////////////////////
                    baglanti.Open();
                    SorguCalistir = new OleDbCommand(sorgu, baglanti);
                    SorguCalistir.ExecuteNonQuery();
                    baglanti.Close();

                    sorgu2 = "select * from musteri";
                    musteriVeri_oku();

                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }
        }



        //kasa***********************************
        public void kasaText_doldur()
        {
            try
            {
                metroDateTime2.Text = metroGrid2.SelectedRows[0].Cells["tarih"].Value.ToString();
                txtGelir.Text = metroGrid2.SelectedRows[0].Cells["gelir"].Value.ToString();
                txtGider.Text = metroGrid2.SelectedRows[0].Cells["gider"].Value.ToString();
                txtKasa.Text = metroGrid2.SelectedRows[0].Cells["kasa"].Value.ToString();
                txtCAdi.Text = metroGrid2.SelectedRows[0].Cells["calisanAdi"].Value.ToString();
                txtCSoyadi.Text = metroGrid2.SelectedRows[0].Cells["calisanSoyadi"].Value.ToString();
                txtCUcreti.Text = metroGrid2.SelectedRows[0].Cells["calisanUcreti"].Value.ToString();
                metroComboBox2.Text = metroGrid2.SelectedRows[0].Cells["ucretOdendi"].Value.ToString();
                txtCOdenen.Text = metroGrid2.SelectedRows[0].Cells["odenenTutar"].Value.ToString();
                txtCKalan.Text = metroGrid2.SelectedRows[0].Cells["kalanTutar"].Value.ToString();
                txtCAciklama.Text = metroGrid2.SelectedRows[0].Cells["aciklama"].Value.ToString();

            }
            catch
            {
                //Burada herhangi bir kod yazmadık buda yukarıdai kodlar çalışırken herhangi bir nedenden dolayı
                //program hatayla karşılaşırsa (seçili satırın negatif gözükmesi yani seçili satır olmaması) kırılmadan devam edecek
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
            //musteri----------------------------------------------------------------------------------------

            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1 de tüm satırın seçili olmasını sağladık

            metroGrid1.DataSource = dt;
            metroGrid1.Columns.Add("SNo", "No");

            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            baglanti.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\\veriTabani.mdb";

            sorgu = "Select * from musteri";
            musteriVeri_oku();

            metroGrid1.Columns["ID"].Visible = false;
            

            //   veri_oku();
            // dataGridView1.Columns["SatisKodu"].Visible = false;
            

            //dataGridView1.Rows[0].Selected = true;
            musteriText_doldur();

            metroDateTime1.Enabled = false;
            txtTC.Enabled = false;
            txtAdi.Enabled = false;
            txtSoyadi.Enabled = false;
            txtTutar.Enabled = false;
            metroComboBox1.Enabled = false;
            txtOdenenTutar.Enabled = false;
            txtKalanTutar.Enabled = false;
            txtAciklama.Enabled = false;
            Mkaydet.Enabled = false;
            Miptal.Enabled = false;

            //kasa**********************************************************************************************

            metroGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1 de tüm satırın seçili olmasını sağladık

            metroGrid2.DataSource = dt2;
            metroGrid2.Columns.Add("SNo", "No");

            metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            baglanti2.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\\veriTabani.mdb";

            sorgu2 = "Select * from kasa";
            kasaVeri_oku();

            metroGrid2.Columns["ID"].Visible = false;


            //   veri_oku();
            // dataGridView1.Columns["SatisKodu"].Visible = false;


            //dataGridView1.Rows[0].Selected = true;
            kasaText_doldur();

            metroDateTime2.Enabled = false;
            txtGelir.Enabled = false;
            txtGider.Enabled = false;
            txtKasa.Enabled = false;
            txtCAdi.Enabled = false;
            txtCSoyadi.Enabled = false;
            txtCUcreti.Enabled = false;
            metroComboBox2.Enabled = false;
            txtCOdenen.Enabled = false;
            txtCKalan.Enabled = false;
            txtCAciklama.Enabled = false;
            Kiptal.Enabled = false;
            Kkaydet.Enabled = false;

        }

        
    }
}
