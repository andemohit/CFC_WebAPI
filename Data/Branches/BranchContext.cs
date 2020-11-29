using Branches.Models;
using Categories.Models;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Branches.Data
{
    public class BranchContext : DbContext
    {
        public BranchContext(DbContextOptions<BranchContext> opt): base(opt)
        {

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}