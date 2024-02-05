using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ProjektContext: DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<PhotoItem> PhotoItems { get; set; }
        public DbSet<User> Users { get; set; }

        public ProjektContext(DbContextOptions<ProjektContext> options) : base(options)
        {

        }
    }
}
