﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity 
    {
        public int UserId { get; set; }
        public string CustomerName { get; set; } 
    }
}
