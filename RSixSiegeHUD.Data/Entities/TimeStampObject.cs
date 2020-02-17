using System;
using System.Collections.Generic;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class TimeStampObject
    {
        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            set
            {
                _timeStamp = DateTime.Now;
            }

            get
            {
                return _timeStamp;
            }
        }
    }
}
