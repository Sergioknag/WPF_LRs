using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace WPF_LR9.Infrastructure
{
    // Класс конвертер значений. преобразует имя файла-картинки, которое
    // хранится в свойстве CarImageFileName в путь к этому файлу
    public class ImageSourceConverter : IValueConverter
    {
        string imageDirectory = Directory.GetCurrentDirectory();
        string ImageDirectory
        {
            get { return Path.Combine(imageDirectory, "Images"); }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Path.Combine(ImageDirectory, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
