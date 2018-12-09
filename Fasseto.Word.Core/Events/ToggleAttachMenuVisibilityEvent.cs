using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// An Event to toggle Attach Menu visibility to show or hide
    /// </summary>
    public class ToggleAttachMenuVisibilityEvent : IPubslishSubscribeEvent<bool>
    {
        /// <summary>
        /// List of subscriptions
        /// </summary>
        private IList<Action<bool>> _subscritpions = null;

        /// <summary>
        /// List of subscriptions
        /// </summary>
        public IList<Action<bool>> Subscriptions
        {
            get
            {
                if(_subscritpions == null)
                {
                    _subscritpions = new List<Action<bool>>();
                }

                return _subscritpions;
            }
        }

        /// <summary>
        /// Check if subscritpion contains action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool Contains(Action<bool> action)
        {
            return Subscriptions.Contains(action);
        }

        /// <summary>
        /// Publishes the event to all listeners
        /// </summary>
        /// <param name="tpayload"></param>
        public void Publish(bool tpayload)
        {
            foreach (var action in Subscriptions)
            {
                action(tpayload);
            }
        }

        /// <summary>
        /// Subscribe to the event
        /// </summary>
        /// <param name="action"></param>
        public void Subscribe(Action<bool> action)
        {
            if (!Subscriptions.Contains(action))
            {
                Subscriptions.Add(action);
            }
        }

        /// <summary>
        /// Unsubscribe to the event
        /// </summary>
        /// <param name="action"></param>
        public void UnSubscribe(Action<bool> action)
        {
            Subscriptions.Remove(action);
        }
    }
}
