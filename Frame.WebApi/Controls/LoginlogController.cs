using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;

namespace ZFS.Api.Controls
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class LoginlogController:BaseController
    {
        public readonly ILoginLogRepository repository;

        public LoginlogController(IUnitDbWork work, ILoginLogRepository repository)
            : base(work)
        {
            this.repository = repository;
        }
        
    }
}
