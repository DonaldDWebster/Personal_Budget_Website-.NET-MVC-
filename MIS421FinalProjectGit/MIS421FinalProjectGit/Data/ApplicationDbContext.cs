using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Added ina  attempt to use ApplicationUser
           // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        //public DbSet<MIS421FinalProjectGit.Models.UserAccount> UserAccount { get; set; }
        //public DbSet<MIS421FinalProjectGit.Models.Bill> Bill { get; set; }
        //public DbSet<MIS421FinalProjectGit.Models.Transaction> Transactions { get; set; }
        //public DbSet<MIS421FinalProjectGit.Models.Budget> Budget { get; set; }

       // public DbSet<MIS421FinalProjectGit.Models.AdminAccounts> AdminAccount { get; set; }
        public DbSet<MIS421FinalProjectGit.Models.Investments> Investments { get; set; }

        public DbSet<MIS421FinalProjectGit.Models.ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MIS421FinalProjectGit.Models.MyBill> MyBill { get; set; }

        public DbSet<MIS421FinalProjectGit.Models.MyTransaction> MyTransaction { get; set; }

        public DbSet<MIS421FinalProjectGit.Models.BudgetViewModel> BudgetViewModel { get; set; }

        public DbSet<MIS421FinalProjectGit.Models.Mortgage>? Mortgage { get; set; }


       


        

        //Added in an attempt to use ApplicationUser
        //public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        //{
        //    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        //    {
        //        builder.Property(u => u.FirstName).HasMaxLength(255);
        //    }
        //}
    }
}
