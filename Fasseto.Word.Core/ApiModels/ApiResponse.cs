using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The response for all web API calls made
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse
    {
        /// <summary>
        /// True if no error has occurred, false if error had occurred
        /// </summary>
        public bool Successful => ErrorMessage == null;

        /// <summary>
        /// Error Message for fail API call
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The API Response object
        /// </summary>
        public object Response { get; set; }
    }

    /// <summary>
    /// Response for all WEB API calls made
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// Response from server
        /// </summary>
        public new T Response
        {
            get => (T)base.Response;
            set => base.Response = value;
        }
    }
}
