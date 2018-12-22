using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word
{
    public class RelayParameterizedCommand : ICommand
    {
        private Action<object> _action;

        /// <summary>
        /// The event that's fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayParameterizedCommand(Action<object> action)
        {
            this._action = action;
        }

        /// <summary>
        /// Relay Command Can Always Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this._action(parameter);
        }
    }
}
