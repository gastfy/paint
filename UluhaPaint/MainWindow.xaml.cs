using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UluhaPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel attrs;
        public MainWindow()
        {
            InitializeComponent();
            attrs = new ViewModel();
            Canvas.DataContext = attrs;
            // data
            BrushHeight.DataContext = attrs;
            BrushWidth.DataContext = attrs;
            isHighlighter.DataContext = attrs;
            isFitToCurve.DataContext = attrs;
        }
        private void getColor(object sender, ExecutedRoutedEventArgs e)
        {
            ColorPickerWindow CPW = new ColorPickerWindow(attrs);
            CPW.ShowDialog();
        }

        private void SavePicture(object sender, ExecutedRoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)Canvas.Width, (int)Canvas.Height, 96d, 96d, PixelFormats.Default);
            rtb.Render(Canvas);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            Random rand = new Random();
            string path = @"C:\Users\gastf\Documents\test" + rand.NextInt64().ToString() + ".bmp";
            while (File.Exists(path)) 
            {
                rand = new Random();
                path = @"C:\Users\gastf\Documents\test" + rand.NextInt64().ToString() + ".bmp";
            }
            
            FileStream fs = File.Open(path, FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }

    }
}
