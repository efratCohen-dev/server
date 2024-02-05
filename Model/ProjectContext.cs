using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProjectContext:DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<PhotoItem> PhotoItems { get; set; }
        public DbSet<User> Users { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
    }
}
