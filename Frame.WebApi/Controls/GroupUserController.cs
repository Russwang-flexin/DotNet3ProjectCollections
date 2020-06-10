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
    /// 组用户
    /// </summary>
    public class GroupUserController : BaseController
    {
        public readonly IGroupUserRepository repository;

        public GroupUserController(IUnitDbWork work, IGroupUserRepository repository)
            : base(work)
        {
            this.repository = repository;
        }
        
    }
}
