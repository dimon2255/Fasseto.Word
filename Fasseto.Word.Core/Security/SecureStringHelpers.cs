using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecured <see cref="SecureString"> to plain text
        /// </summary>
        /// <param name="securePassword">the SecureString</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString securePassword)
        {
            if (securePassword == null)
                return string.Empty;


            var unmanagedString = IntPtr.Zero;
            try
            {
                //Unsecured
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean up any memory allocation
                Marshal.ZeroFreeCoTaskMemUnicode(unmanagedString);
            }

        }
    }
}
