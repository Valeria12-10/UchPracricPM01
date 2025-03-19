using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WM
{
    public static class BitmapExtensions
    {
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                // Сохраняем Bitmap в MemoryStream в формате PNG
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0; // Сбрасываем позицию потока на начало

                // Создаем BitmapImage
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory; // Указываем источник данных
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Загружаем изображение сразу
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Замораживаем BitmapImage для использования в других потоках

                return bitmapImage;
            }
        }
    }
}
