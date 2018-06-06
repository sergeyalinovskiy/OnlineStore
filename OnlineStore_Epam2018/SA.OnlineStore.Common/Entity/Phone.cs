using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Entity
{
    public class Phone
    {
        public int PhoneId { get; set; }

        public int UserId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
