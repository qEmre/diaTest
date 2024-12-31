using diaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace diaTest.DataLayer
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<FaturaTablo> FaturaTablo { get; set; }
        public DbSet<CariTablo> CariTablo { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<CariKart> CariKart { get; set; }
        public DbSet<CariKartAdresi> CariKartAdresi { get; set; }
    }
}