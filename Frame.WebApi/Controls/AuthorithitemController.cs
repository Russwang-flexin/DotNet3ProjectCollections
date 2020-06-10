using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frame.EFCore.Common;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;

namespace ZFS.Api.Controls
{
    
    /// <summary>
    /// 权限定义
    /// </summary>
    public class AuthorithitemController : BaseController
    {
        public readonly IAuthorithitemRepository repository;

        public AuthorithitemController(IUnitDbWork work, IAuthorithitemRepository repository)
            : base(work)
        {
            this.repository = repository;
        }
        
    }
}
