using System;
using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// All publishers and Subscribers will have to implement this interface
    /// </summary>
    /// <typeparam name="TPayload">Payload</typeparam>
    public interface IPubslishSubscribeEvent<TPayload>
    {
        /// <summary>
        /// Subscribes to the event
        /// </summary>
        /// <param name="action"></param>
        void Subscribe(Action<TPayload> action);

        /// <summary>
        /// Publishes an event
        /// </summary>
        /// <param name="tpayload"></param>
        void Publish(TPayload tpayload);

        /// <summary>
        /// Unsubscribes
        /// </summary>
        /// <param name="action"></param>
        void UnSubscribe(Action<TPayload> action);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        bool Contains(Action<TPayload> action);

        /// <summary>
        /// Subscription Collection
        /// </summary>
        IList<Action<TPayload>> Subscriptions { get; }

    }
}
