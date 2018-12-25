using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Handles anything to do with tasks
    /// </summary>
    public interface ITaskManager
    {

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the Task
        /// </summary>
        /// <param name="function">Function to run</param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <remarks>The passed in Task cannot be awaited as it is to be run and forgotten.</remarks>
        /// <returns></returns>
        void RunAndForget(Func<Task> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the Task
        /// </summary>
        /// <param name="function">Function to run</param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        Task Run(Func<Task> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the Task
        /// </summary>
        /// <param name="function">Function to run</param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        void RunAndForget<TResult>(Func<Task<TResult>> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the Task
        /// </summary>
        /// <param name="function">Function to run</param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a Task(TResult)
        ///     object that represents that work. A cancellation token allows the work to be
        ///     canceled.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function">Function to run</param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        ///  Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        ///    object that represents that work.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        ///  Queues the specified work to run on the thread pool and returns a proxy for the
        ///    task returned by function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);

        /// <summary>
        ///  Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        ///     object that represents that work. A cancellation token allows the work to be
        ///     canceled.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);
        
        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        ///     object that represents that work.
        /// </summary>
        /// <param name="action">Action for the task to run</param>
        /// <returns></returns>
        Task Run(Action action, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0);
    }
}
