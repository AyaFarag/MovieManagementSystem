﻿using MovieSystem.Domain.Entities.Commen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class Customer : User
    {
        [Key]
        [Required]
        public int id { get; set; }
    }
}