using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Global Aggregator Event Locator
    /// </summary>
    public static class GlobalEventLocator
    {
        /// <summary>
        /// Static Instance of Attach Menu Visibility Event
        /// </summary>
        private static ToggleAttachMenuVisibilityEvent _toggleAttachButtonEvent;

        /// <summary>
        /// Static Instance of Search Menu Visibility Event
        /// </summary>
        private static ToggleSearchMenuVisibilityEvent _toggleSearchButtonEvent;

        /// <summary>
        /// Static Instance of Settings Menu Visibility Event
        /// </summary>
        private static ToggleSettingsMenuVisibilityEvent _toggleSettingsButtonEvent;


        /// <summary>
        /// Singleton Instance ToggleAttachMenuVisibilityEvent event locator
        /// </summary>
        public static ToggleAttachMenuVisibilityEvent ToggleAttachMenuEvent
        {
            get
            {
                if (_toggleAttachButtonEvent == null)
                    _toggleAttachButtonEvent = new ToggleAttachMenuVisibilityEvent();

                return _toggleAttachButtonEvent;
            }
        }


        /// <summary>
        /// Singleton Instance ToggleAttachMenuVisibilityEvent event locator
        /// </summary>
        public static ToggleSettingsMenuVisibilityEvent ToggleSettingsMenuEvent
        {
            get
            {
                if (_toggleSettingsButtonEvent == null)
                    _toggleSettingsButtonEvent = new ToggleSettingsMenuVisibilityEvent();

                return _toggleSettingsButtonEvent;
            }
        }

        /// <summary>
        /// Singleton Instance ToggleSearchMenuVisibilityEvent event locator
        /// </summary>
        public static ToggleSearchMenuVisibilityEvent ToggleSearchMenuEvent
        {
            get
            {
                if (_toggleSearchButtonEvent == null)
                    _toggleSearchButtonEvent = new ToggleSearchMenuVisibilityEvent();

                return _toggleSearchButtonEvent;
            }
        }


    }
}
