﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Frame.EFCore.Entity
{
    public class Menu : BaseEntity
    {
        public string MenuCode { get; set; }

        public string MenuName { get; set; }

        public string MenuCaption { get; set; }

        public string MenuNameSpace { get; set; }

        [DefaultValue(0)]
        public int MenuAuthorities { get; set; }

        public string ParentName { get; set; }
    }
}
