using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiKalkulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mengaktifkan gaya visual modern untuk kontrol Windows
            Application.EnableVisualStyles();

            // Menentukan cara rendering teks (GDI+ atau GDI)
            Application.SetCompatibleTextRenderingDefault(false);

            // Menjalankan Form1 sebagai jendela utama aplikasi
            // Pastikan nama class di Form1.cs adalah Form1
            Application.Run(new Form1());
        }
    }
}