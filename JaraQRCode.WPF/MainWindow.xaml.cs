using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace JaraQRCode.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JaraQRCode.QRCode qr = new QRCode()
        {
            //QRCodeBackgroundColor = Color.Black,              // leave it default (default: Black)
            //QRCodeForegroundColor = Color.White,              // leave it default (default: White)
            //QRCodeEncodeMode = QRCode.MODE.BYTE,              // leave it default (defalt: QRCode.MODE.BYTE)
            //QRCodeErrorCorrect = QRCode.ERRORCORRECTION.M,    // leave it default (default: QRCode.ERRORCORRECTION.M)
            //QRCodeScale = 4,                                  // leave it default (4)
            //QRCodeVersion = 0                                 // leave it default (0)
        };

        public MainWindow()
        {
            InitializeComponent();

            txText.TextChanged += TxText_TextChanged;
        }

        private void TxText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var byt = qr.Generate(txText.Text);

            if (byt != null)
            {
                imgQRCode.Source = Convert(byt);
                txQRstring.Text = qr.GenerateQRCodeString(txText.Text, Encoding.UTF8);
            }
        }

        public BitmapImage Convert(byte[] src)
        {
            MemoryStream ms = new MemoryStream(src);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        //public BitmapImage Convert(Bitmap src)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    ((System.Drawing.Bitmap)src).Save(ms, ImageFormat.Png);
        //    BitmapImage image = new BitmapImage();
        //    image.BeginInit();
        //    ms.Seek(0, SeekOrigin.Begin);
        //    image.StreamSource = ms;
        //    image.EndInit();
        //    return image;
        //}
    }
}
