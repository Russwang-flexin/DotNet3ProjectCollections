﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;

namespace ZFS.Api.Controls
{
    /// <summary>
    /// 组行为
    /// </summary>
    public class GroupFuncController : BaseController
    {
        public readonly IGroupFuncRepository repository;

        public GroupFuncController(IUnitDbWork work, IGroupFuncRepository repository)
            : base(work)
        {
            this.repository = repository;
        }
        
    }
}
