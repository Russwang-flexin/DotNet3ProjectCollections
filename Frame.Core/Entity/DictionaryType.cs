using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Frame.EFCore.Entity
{
    public class DictionaryType : BaseEntity
    {
        public string TypeCode { get; set; }

        public string TypeName { get; set; }
    }
}
