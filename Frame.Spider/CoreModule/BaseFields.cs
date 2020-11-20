using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Frame.Spider
{
    public class BaseFieldsItem: List<BaseField>
    {



    }

    public class BaseField
    {
        public virtual string FieldName { get; set; }
        public virtual object FieldValue { get; set; }
    }


}
