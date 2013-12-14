using System;
using System.Diagnostics;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for creating a new CheckListNotFoundException.
    /// </summary>
    public class CheckListNotFoundException : Exception
    {
        /// <summary>
        /// Constructor for new CheckListNotFoundException class.
        /// </summary>
        /// <param name="message"> Parameter for incoming message. </param>
        /// <param name="ex"> Parameter for incoming thrown exception. </param>
        public CheckListNotFoundException(String message, Exception ex)
        {
            Debug.WriteLine("A EquipListNotFoundException has been thrown:");
            Debug.WriteLine("Method: {0}", ex.TargetSite);
            Debug.WriteLine("Exception Message: {0}", ex.Message);
            Debug.WriteLine("Exception Stack: {0}", ex.StackTrace);
        }
    }
}
