using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public class TaskManager : ITaskManager
    {

        #region Task Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public async Task Run(Func<Task> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                await Task.Run(function);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber); 

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public async Task Run(Action action, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        /// <returns></returns>
        public Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "", [CallerFilePath]string filepath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //Log Error
                LogError(ex, origin, filepath, lineNumber);

                //Throw it as normal
                throw;
            }
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Logs a given error to ILogFactory
        /// </summary>
        /// <param name="e">Exception error</param>
        /// <param name="origin">The method/function this message was logged from</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the file this message was logged from</param>
        private void LogError(Exception e, string origin, string filepath, int lineNumber)
        {
             IoC.Logger.Log($"AN unexpected error occurred running a IoC.Task.Run. {e.Message}", LogLevel.Debug, origin, filepath, lineNumber);
        }

        #endregion

    }
}