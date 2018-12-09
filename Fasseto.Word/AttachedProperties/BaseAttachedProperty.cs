using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{

    /// <summary>
    /// A base attached property to replace the vanilla attached WPF property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be attached property</typeparam>
    /// <typeparam name="Property">The type of the attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {

        #region Pubic Events

        /// <summary>
        /// Fired when Value Changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        /// <summary>
        /// Fired when Value Changes, even if the value is the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// Singleton Instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// Attached Property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property),
                                                                                        typeof(BaseAttachedProperty<Parent, Property>),
                                                                                        new UIPropertyMetadata(
                                                                                            default(Property),
                                                                                            new PropertyChangedCallback(OnValuePropertyChanged),
                                                                                            new CoerceValueCallback(OnValuePropertyUpdated)));

        /// <summary>
        /// The coerce callback event when <see cref="ValueProperty"/> is changed even if its the same value
        /// </summary>
        /// <param name="d">UI element that had it's property changed</param>
        /// <param name="e">Arguments for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //Call the Parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            //Call Listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        /// <summary>
        /// The callback event when <see cref="ValueProperty"/> has changed
        /// </summary>
        /// <param name="d">UI element that had it's property changed</param>
        /// <param name="e">Arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Call the Parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            //Call Listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the Attached Property
        /// </summary>
        /// <param name="d">The Element to get a property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property) d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the Attached Property
        /// </summary>
        /// <param name="d">The UI element to set an Attached property for</param>
        /// <param name="value">Attached property Value</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">UI element that has an Attached property changed</param>
        /// <param name="args">The value to set the property to</param>
        protected virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) { }


        /// <summary>
        /// The method that is called when any attached property of this type is update, even of the value is the same
        /// </summary>
        /// <param name="sender">UI element that has an Attached property changed</param>
        /// <param name="value">The value to set the property to</param>
        protected virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}
