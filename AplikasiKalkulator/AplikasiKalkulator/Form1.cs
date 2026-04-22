using System;
using System.Drawing;
using System.Windows.Forms;

namespace AplikasiKalkulator
{
    public partial class Form1 : Form
    {
        // Deklarasi Tools (Objek dari Class Tool WinForms)
        private TextBox txtAngka1, txtAngka2;
        private Label lblHasil;
        private Button btnTambah, btnKurang, btnKali, btnBagi;

        public Form1()
        {
            // Pengaturan dasar Jendela (Form)
            this.Text = "Kalkulator Simpel v1.0";
            this.Size = new Size(450, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White; 
            InisialisasiKomponen();
        }

        private void InisialisasiKomponen()
        {
            // --- HEADER TITLE ---
            Label lblJudul = new Label() { 
                Text = "ARITMATIKA DASAR", 
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(0, 30), 
                Size = new Size(450, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // --- INPUT FIELDS ---
            Label lblAngka1 = new Label() { Text = "Angka 1:", Font = new Font("Arial", 14), Location = new Point(40, 100), AutoSize = true };
            txtAngka1 = new TextBox() { Location = new Point(150, 100), Width = 250, Font = new Font("Arial", 14) };

            Label lblAngka2 = new Label() { Text = "Angka 2:", Font = new Font("Arial", 14), Location = new Point(40, 150), AutoSize = true };
            txtAngka2 = new TextBox() { Location = new Point(150, 150), Width = 250, Font = new Font("Arial", 14) };

            // --- BUTTONS (OPERATORS) ---
            int btnWidth = 85;
            int btnHeight = 70;
            int startY = 220;

            btnTambah = new Button() { Text = "+\nbtnTambah", Location = new Point(40, startY), Width = btnWidth, Height = btnHeight, BackColor = Color.AliceBlue };
            btnKurang = new Button() { Text = "-\nbtnKurang", Location = new Point(130, startY), Width = btnWidth, Height = btnHeight };
            btnKali = new Button() { Text = "×\nbtnKali", Location = new Point(220, startY), Width = btnWidth, Height = btnHeight };
            btnBagi = new Button() { Text = "/\nbtnBagi", Location = new Point(310, startY), Width = btnWidth, Height = btnHeight };

            // Menambahkan Event Handler untuk setiap tombol
            btnTambah.Click += (s, e) => Hitung("+");
            btnKurang.Click += (s, e) => Hitung("-");
            btnKali.Click += (s, e) => Hitung("*");
            btnBagi.Click += (s, e) => Hitung("/");

            // --- RESULT LABEL ---
            lblHasil = new Label() { 
                Text = "HASIL: 0.00", 
                Font = new Font("Arial", 22, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                Location = new Point(0, 350), 
                Size = new Size(450, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Memasukkan semua tools ke dalam Form
            this.Controls.Add(lblJudul);
            this.Controls.Add(lblAngka1); this.Controls.Add(txtAngka1);
            this.Controls.Add(lblAngka2); this.Controls.Add(txtAngka2);
            this.Controls.Add(btnTambah); this.Controls.Add(btnKurang);
            this.Controls.Add(btnKali); this.Controls.Add(btnBagi);
            this.Controls.Add(lblHasil);
        }

        private void Hitung(string operasi)
        {
            // Validasi Input: Pastikan berupa angka
            if (!double.TryParse(txtAngka1.Text, out double a1) || !double.TryParse(txtAngka2.Text, out double a2))
            {
                MessageBox.Show("Masukkan angka yang valid!");
                return;
            }

            double hasil = 0;

            // Logika Perhitungan
            switch (operasi)
            {
                case "+": hasil = a1 + a2; break;
                case "-": hasil = a1 - a2; break;
                case "*": hasil = a1 * a2; break;
                case "/": 
                    if (a2 != 0) hasil = a1 / a2; 
                    else { MessageBox.Show("Tidak bisa membagi dengan nol!"); return; }
                    break;
            }

            // Update Label Hasil dengan format 2 desimal seperti di foto
            lblHasil.Text = "HASIL: " + hasil.ToString("F2");
        }
    }
}