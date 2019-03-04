using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Utilities
{
    public class UserFriendlyException
    {
        public string Messge { get; set; }
        public UserFriendlyException(string message ,Exception exp)
        {

        }
    }
}