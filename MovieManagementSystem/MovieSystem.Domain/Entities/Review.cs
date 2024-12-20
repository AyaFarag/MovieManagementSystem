﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public short rate { get; set; }
        public DateTime date { get; set; }
        // no reverse property for user
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public bool isHide { get; set; }
    }
}
