using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frame.EFCore.Common
{
    /// <summary>  
    /// 标记接口，生成到swagger文档展示  
    /// </summary>  
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

    public partial class SwgApiAttribute : Attribute { }
    public class SwgApiFilter : Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var descriptor = context.ApiDescriptions;

            foreach (var apiDescription in descriptor)
            {
                var actiondes = apiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
                var isSwgApi = methodInfo.CustomAttributes.Count(x => x.AttributeType == typeof(SwgApiAttribute)) == 0;
                if (isSwgApi)
                {
                    var key = "/" + apiDescription.RelativePath.TrimEnd('/');
                }

            }
        }
    }
}
