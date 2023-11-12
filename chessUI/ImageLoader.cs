using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using chessgame;

namespace chessUI
{
    public class ImageLoader
    {
        public BitmapImage[] LoadImages(string[] imageNames)
        {
            
            List<BitmapImage> images = new List<BitmapImage>();
            foreach(var imageName in imageNames)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri($"pack://application:,,,/resources/{imageName}");
                image.EndInit();
                images.Add(image);
            }
            return images.ToArray();
        }
        
    }
}
