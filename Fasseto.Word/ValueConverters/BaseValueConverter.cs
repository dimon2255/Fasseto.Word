using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasseto.Word
{
    /// <summary>
    /// A base value Converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of the value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        #region Private Members
        
        /// <summary> single static method of the value converter
        /// </summary>
        private static T _converter = null;

        #endregion

        #region MarkupExtension Methods

        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Value Converter Methods

        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// A method to convert back from one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
