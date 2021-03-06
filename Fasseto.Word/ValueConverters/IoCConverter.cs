﻿using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// Converters a string name to a service pulled from an IoC container
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find and appropriate page
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return ViewModelApplication;
                default:
                    Debugger.Break();
                    return null;

            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
