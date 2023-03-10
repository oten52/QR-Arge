using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QRCodeGenerater
{
    /// <summary>
    /// Autor : Orçun TEN
    /// Mail : oten52@gmai.com
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // btnGenerate_Click - QR oluşturma Click Event
        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Input is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtInput.Text.Trim(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            var img = new Bitmap(QRCodeGenerater.Properties.Resources.smile);
            //var localImg = (Bitmap)Bitmap.FromFile("C:\\smile.png");

            // Düz QR oluşturur
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // QR'ın ortasına resim yerleştirir
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, img);

            pbOutput.Image = qrCodeImage;
        }

    }
}
