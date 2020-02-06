using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagerAPI.Common
{
    public class ContextStorage
    {
        public string Who { get; set; }
        public string Where { get; set; }
        public DateTime When { get; set; }

        public bool isWhoAvailable { get { return !string.IsNullOrEmpty(Who); } }
        public bool isWhereAvailable { get { return !string.IsNullOrEmpty(Where); } }
        public bool isWhenAvailable { get { return (When != DateTime.MinValue); } }

        public bool isEverythingAvailable { get { return (!string.IsNullOrEmpty(Who) && !string.IsNullOrEmpty(Where) && When != DateTime.MinValue); } }

        public string LastAskedQuestion { get; set; }
    }
}
