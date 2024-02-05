using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Like { get; set; }
    }
}
