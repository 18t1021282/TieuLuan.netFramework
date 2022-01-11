using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLDeTai.DAL
{
    public partial class QLDeTaiModel : DbContext
    {
        public QLDeTaiModel()
            : base("name=AppConnectionString")
        {
        }

        public virtual DbSet<DeTai> DeTais { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.DeTais)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.IDMonHoc);
        }
    }
}
