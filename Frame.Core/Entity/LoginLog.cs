using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.EFCore.Entity
{
    public class LoginLog : BaseEntity
    {
        public string Account { get; set; }

        public DateTime CurrentTime { get; set; }
    }
}
