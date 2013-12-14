using System;
using System.Diagnostics;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for creating a new EquipListFoundException.
    /// </summary>
    public class EquipListNotFoundException : Exception
    {
        /// <summary>
        /// Constructor for new EquipListNotFoundException class.
        /// </summary>
        /// <param name="message"> Parameter for incoming message. </param>
        /// <param name="ex"> Parameter for incoming thrown exception. </param>
        public EquipListNotFoundException(String message, Exception ex)
        {
            Debug.WriteLine("A EquipListNotFoundException has been thrown:");
            Debug.WriteLine("Method: {0}", ex.TargetSite);
            Debug.WriteLine("Exception Message: {0}", ex.Message);
            Debug.WriteLine("Exception Stack: {0}", ex.StackTrace);
        }
    }
}
