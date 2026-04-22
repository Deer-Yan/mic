using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameTebakHewan
{
    public partial class Form1 : Form
    {
        // Deklarasi Tools
        private PictureBox pbHewan;
        private TextBox txtPetunjuk1, txtPetunjuk2, txtJawaban;
        private ComboBox cmbKategori;
        private Button btnBantuan, btnHapus, btnCek;
        private Label lblStatus;

        public Form1()
        {
            this.Text = "Tebak-tebakan Nama Hewan v1.0";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            InisialisasiGameHewan();
        }

        private void InisialisasiGameHewan()
        {
            // HEADER
            Label lblJudul = new Label()
            {
                Text = "TEBAK-TEBAKAN NAMA HEWAN",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(0, 10),
                Size = new Size(500, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // PICTURE BOX (Untuk Gambar Singa)
            pbHewan = new PictureBox()
            {
                Location = new Point(150, 60),
                Size = new Size(200, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray
            };
            // Catatan: Pastikan file singa.jpg ada di folder bin/debug atau ganti path ini
             pbHewan.Image = Image.FromFile("singa.jfif"); 

            Font fontLabel = new Font("Arial", 11);

            // INPUT FIELDS
            Label lblP1 = new Label() { Text = "Petunjuk 1 (Ciri):", Location = new Point(30, 200), Font = fontLabel, AutoSize = true };
            txtPetunjuk1 = new TextBox() { Location = new Point(180, 197), Width = 250, Font = fontLabel };

            Label lblP2 = new Label() { Text = "Petunjuk 2 (Ciri):", Location = new Point(30, 235), Font = fontLabel, AutoSize = true };
            txtPetunjuk2 = new TextBox() { Location = new Point(180, 232), Width = 250, Font = fontLabel };

            Label lblJawab = new Label() { Text = "Jawaban Anda:", Location = new Point(30, 270), Font = fontLabel, AutoSize = true };
            txtJawaban = new TextBox() { Location = new Point(180, 267), Width = 250, Font = fontLabel };

            Label lblKategori = new Label() { Text = "Kategori:", Location = new Point(30, 305), Font = fontLabel, AutoSize = true };
            cmbKategori = new ComboBox() { Location = new Point(180, 302), Width = 250, Font = fontLabel, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbKategori.Items.AddRange(new string[] { "Mamalia", "Burung", "Reptil", "Amfibi" });
            cmbKategori.SelectedIndex = 0;

            // TOMBOL-TOMBOL
            btnBantuan = new Button() { Text = "⚽ Bantuan", Location = new Point(40, 360), Width = 120, Height = 45 };
            btnHapus = new Button() { Text = "🗑️ Hapus", Location = new Point(180, 360), Width = 120, Height = 45 };
            btnCek = new Button() { Text = "✔️ Cek", Location = new Point(320, 360), Width = 120, Height = 45 };

            // STATUS
            lblStatus = new Label()
            {
                Text = "STATUS: Menunggu Input...",
                Location = new Point(30, 430),
                Font = new Font("Arial", 14),
                AutoSize = true
            };

            // EVENT HANDLERS
            btnBantuan.Click += (s, e) => {
                txtPetunjuk1.Text = "Raja hutan yang gagah.";
                txtPetunjuk2.Text = "Memiliki rambut surai lebat.";
                lblStatus.Text = "STATUS: Bantuan diberikan!";
            };

            btnCek.Click += (s, e) => {
                string jawaban = txtJawaban.Text.Trim().ToLower();
                if (jawaban == "singa" && cmbKategori.Text == "Mamalia")
                {
                    lblStatus.Text = "STATUS: Benar! Itu adalah Singa.";
                    lblStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lblStatus.Text = "STATUS: Salah! Cek jawaban/kategori.";
                    lblStatus.ForeColor = Color.Red;
                }
            };

            btnHapus.Click += (s, e) => {
                txtPetunjuk1.Clear(); txtPetunjuk2.Clear(); txtJawaban.Clear();
                lblStatus.Text = "STATUS: Menunggu Input...";
                lblStatus.ForeColor = Color.Black;
            };

            // TAMBAHKAN KE FORM
            this.Controls.Add(lblJudul); this.Controls.Add(pbHewan);
            this.Controls.Add(lblP1); this.Controls.Add(txtPetunjuk1);
            this.Controls.Add(lblP2); this.Controls.Add(txtPetunjuk2);
            this.Controls.Add(lblJawab); this.Controls.Add(txtJawaban);
            this.Controls.Add(lblKategori); this.Controls.Add(cmbKategori);
            this.Controls.Add(btnBantuan); this.Controls.Add(btnHapus); this.Controls.Add(btnCek);
            this.Controls.Add(lblStatus);
        }
    }
}