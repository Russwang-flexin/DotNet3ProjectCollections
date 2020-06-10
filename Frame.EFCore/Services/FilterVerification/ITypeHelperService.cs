using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.EFCore.Services.FilterVerification
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
