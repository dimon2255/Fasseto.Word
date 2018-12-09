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
    /// A Converter that takes a boolean if message was sent by me and return alignment left/right
    /// </summary>
    public class SentByMeToAlignment : BaseValueConverter<SentByMeToAlignment>
    {
        /// <summary>
        /// Convert from Boolean to Alignment
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter == null)
                return ((bool)value) ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            else
                return ((bool)value) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        }


        /// <summary>
        /// Convert from Alignment to Boolean
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
