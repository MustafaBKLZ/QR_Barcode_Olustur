using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QR_Barcode_Olustur
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_qr_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)0;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txt_qr.Text, eccLevel);

            QRCode qrCode = new QRCode(qrCodeData);
            pictureBox1.Image = qrCode.GetGraphic(Convert.ToInt32(txt_qr_oran.Text), Color.Black, Color.White, bm, Convert.ToInt32(txt_ikon_oran.Text), Convert.ToInt32(txt_ikon_knearlık.Text));

            foreach (System.Collections.BitArray line in qrCodeData.ModuleMatrix)
            {
                foreach (bool block in line)
                {
                    //Write your own rendering algorithm here
                    //When block==true then render dark, else render light
                }
            }
        }
        Bitmap bm;
        private void btn_icon_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                txt_ikon_path.Text = opf.FileName;
                bm = new Bitmap(txt_ikon_path.Text);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
