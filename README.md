![](https://raw.githubusercontent.com/jaysonragasa/JaraQRCode/master/JaraQRCode.WPF/prev.gif)
# Jara QRCode
QRCode Generator - A .NET Standard version of Hyun.QRCode originally written for Windows Phone.  

# Hyun.QRCode
Unfortunately, the original source cannot be found anymore anywhere in Google.

# Usage
```csharp
JaraQRCode.QRCode qr = new QRCode()
{
	//QRCodeBackgroundColor = Color.White,              // leave it default (default: White)
	//QRCodeForegroundColor = Color.Black,              // leave it default (default: Black)
	//QRCodeEncodeMode = QRCode.MODE.BYTE,              // leave it default (default: QRCode.MODE.BYTE)
	//QRCodeErrorCorrect = QRCode.ERRORCORRECTION.M,    // leave it default (default: QRCode.ERRORCORRECTION.M)
	//QRCodeScale = 4,                                  // leave it default (default: 4)

	// leave it default (default: 2 which has a maximum char of 28)
	// values can be upto 40. The higher the value, the more char can handle and the blocks will be denser
	QRCodeVersion = 2
};

var byt = qr.Generate(txText.Text);
if (byt != null)
{
	imgQRCode.Source = Convert(byt);
	txQRstring.Text = qr.GenerateQRCodeString(txText.Text, Encoding.UTF8);
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
```
