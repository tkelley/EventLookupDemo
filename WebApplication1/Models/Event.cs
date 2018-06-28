﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookupDemo.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
