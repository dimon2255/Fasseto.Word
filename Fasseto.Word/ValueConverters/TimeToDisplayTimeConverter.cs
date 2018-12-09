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
    /// A converter that converts datetime to user displayable time string
    /// </summary>
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        /// <summary>
        /// A converter that converts datetime to user displayable time string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //get the time passed in
            var time = (DateTimeOffset)value;

            //if it is today
            if(time.Date == DateTimeOffset.UtcNow.Date)
            {
                return time.ToLocalTime().ToString("HH:mm");
            }

            //Otherwise, return a full date
            return time.ToLocalTime().ToString("HH:mm, d MMM yyyy");

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
            throw new NotImplementedException();
        }
    }
}
