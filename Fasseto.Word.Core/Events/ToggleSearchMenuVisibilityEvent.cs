using System;
using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// An Event To Toggle Visibility to show or hide the event
    /// </summary>
    public class ToggleSearchMenuVisibilityEvent : IPubslishSubscribeEvent<bool>
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
                return _subscritpions == null ? new List<Action<bool>>() : _subscritpions;
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
