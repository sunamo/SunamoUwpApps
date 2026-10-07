namespace apps.Logger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class LogMessagesComparer : IComparer<LogMessage>
    {
        //public int Asc(LogMessage x, LogMessage y)
        //{
        //    return x.datum.CompareTo(y.datum) * -1;
        //}

        public int Compare(LogMessage logMessage, LogMessage otherLogMessage)
        {
            return Desc(logMessage, otherLogMessage);
        }

        public int Desc(LogMessage logMessage, LogMessage otherLogMessage)
        {
            return logMessage.Dt.CompareTo(otherLogMessage.Dt);
        }
    }
