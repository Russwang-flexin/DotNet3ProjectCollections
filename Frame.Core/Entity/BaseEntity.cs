﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Frame.EFCore.Interfaces;

namespace Frame.EFCore.Entity
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}