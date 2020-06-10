using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Interfaces;

namespace Frame.EFCore.Services.OrderBys
{
    public interface IPropertyMappingContainer
    {
        void Register<T>() where T : IPropertyMapping, new();
        IPropertyMapping Resolve<TSource, TDestination>() where TDestination : IBaseEntity;
        bool ValidateMappingExistsFor<TSource, TDestination>(string fields) where TDestination : IBaseEntity;
    }
}
