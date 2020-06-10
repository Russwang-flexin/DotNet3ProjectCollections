using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.EFCore.Entity
{
    public class GroupUser : BaseEntity
    {
        public string GroupCode { get; set; }

        public string Account { get; set; }
    }
}
