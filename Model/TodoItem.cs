﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Complated { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
