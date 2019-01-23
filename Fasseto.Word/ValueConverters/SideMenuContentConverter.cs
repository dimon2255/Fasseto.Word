using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasseto.Word
{
    /// <summary>
    /// A converter that takes a <see cref="SideMenuContent"/> and converts it to the
    /// correct UI element
    /// </summary>
    public class SideMenuContentConverter : BaseValueConverter<SideMenuContentConverter>
    {
        #region Protected Members

        /// <summary>
        /// An instance of the current ChatList
        /// </summary>
        protected ChatList mChatList = new ChatList();

        #endregion

        /// <summary>
        /// Converts <see cref="SideMenuContent"/> to Content
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sideMenuType  = (SideMenuContent)value;

            switch (sideMenuType)
            {
                case SideMenuContent.Chat:
                    return mChatList;

                default:
                    return "No UI yet, sorry!";
            }
        }


        /// <summary>
        /// 
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