using MedicalStore.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalStore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


            
        }
        public DbSet<StoreKeeper> StoreKeepers { get; set; }
        public DbSet<StoreManager> StoreManagers { get; set; }

    }
}
