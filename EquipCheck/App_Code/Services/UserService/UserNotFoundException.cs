using System;
using System.Diagnostics;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for creating a new UserNotFoundException.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// Constructor for new UserNotFoundException class.
        /// </summary>
        /// <param name="message"> Parameter for incoming message. </param>
        /// <param name="ex"> Parameter for incoming thrown exception. </param>
        public UserNotFoundException(String message, Exception ex)
        {
            Debug.WriteLine(message);
            Debug.WriteLine("A UserNotFoundException has been thrown:");
            Debug.WriteLine("Method: {0}", ex.TargetSite);
            Debug.WriteLine("Exception Message: {0}", ex.Message);
            Debug.WriteLine("Exception Stack: {0}", ex.StackTrace);
        }
    }
}
