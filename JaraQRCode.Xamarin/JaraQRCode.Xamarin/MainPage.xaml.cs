using System.ComponentModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace JaraQRCode.Xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        JaraQRCode.QRCode qr = new QRCode()
        {
            //QRCodeBackgroundColor = Color.White,              // leave it default (default: White)
            //QRCodeForegroundColor = Color.Black,              // leave it default (default: Black)
            //QRCodeEncodeMode = QRCode.MODE.BYTE,              // leave it default (default: QRCode.MODE.BYTE)
            //QRCodeErrorCorrect = QRCode.ERRORCORRECTION.M,    // leave it default (default: QRCode.ERRORCORRECTION.M)
            //QRCodeScale = 4,                                  // leave it default (default: 4)

            // leave it default (default: 2 which has a maximum char of 28)
            // values can be upto 40. The higher the value, the higher the max character, the denser the blocks
            QRCodeVersion = 2
        };

        public MainPage()
        {
            InitializeComponent();

            txText.TextChanged += TxText_TextChanged;
        }

        private void TxText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var byt = qr.Generate(txText.Text);

            //if (byt != null && byt.Length > 1)
            //{
            //    //imgQRCode.Source = ImageSource.FromStream(() => { return new MemoryStream(byt); });
                
            //}

            txQRstring.Text = qr.GenerateQRCodeString(txText.Text, Encoding.UTF8);
        }
    }
}
