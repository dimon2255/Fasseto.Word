using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// A converter that converts boolean to visibilty and back
    /// </summary>
    public class IconTypeToFontAwesomeConverter : BaseValueConverter<IconTypeToFontAwesomeConverter>
    {
        /// <summary>
        /// Convert from IconType to FontAwesome string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icontype = (IconType)value;

            switch (icontype)
            {
                case IconType.None:
                    return null;

                case IconType.Picture:
                    return "\uf1c5";

                case IconType.File:
                    return "\uf15b";

                default:
                    return null;
            }
        }


        /// <summary>
        /// Convert from Visibility to Boolean
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Visibility)value)
            {
                case Visibility.Visible:
                    return true;
                default:
                    return false;
            }
        }
    }
}
