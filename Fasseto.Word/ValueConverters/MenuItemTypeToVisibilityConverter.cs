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
    public class MenuItemTypeToVisibilityConverter : BaseValueConverter<MenuItemTypeToVisibilityConverter>
    {
        /// <summary>
        /// Convert from Boolean to Visibility
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If we have no parameter return invisible
            if (parameter == null)
                return Visibility.Collapsed;

            //Try to convert parameter string to Enum
            if (!Enum.TryParse(parameter as string, out MenuItemType menutype))
                return Visibility.Collapsed;

            // Return  visible or hidden
            return (MenuItemType)value == menutype ? Visibility.Visible : Visibility.Collapsed;

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
