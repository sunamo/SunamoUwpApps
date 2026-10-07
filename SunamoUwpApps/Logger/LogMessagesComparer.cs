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

        public int Compare(LogMessage logMessage, LogMessage logMessage2)
        {
            return Desc(logMessage, logMessage2);
        }

        public int Desc(LogMessage logMessage, LogMessage logMessage2)
        {
            return logMessage.Dt.CompareTo(logMessage2.Dt);
        }
    }
