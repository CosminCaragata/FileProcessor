using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2FAProject
{
    public class AuthenticationToken
    {
        public string username { get; set; }
        public string PinToken { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
