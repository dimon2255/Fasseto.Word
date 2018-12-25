using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fasseto.Word.Core;


namespace Fasseto.Word
{
    /// <summary>
    /// Base View Model fires property changed event
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Implementation of INotifyPropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event to use if needed
        /// </summary>
        /// <param name="name"></param>
        public void RaisePropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set, executes action
        /// If the flag true function indicates command is running, false not running start action
        /// </summary>
        /// <param name="updatingFlag">The boolean flag indicating whether the command is already running</param>
        /// <param name="action">Action --> command to execute depending on the flag true or false --> ex</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
                return;

            //set the value to true indicating that command is running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed in action
                await action();
            }
            finally
            {
                //set the property flag back to false
                updatingFlag.SetPropertyValue(false);
            }
            
        }

        #endregion
    }
}