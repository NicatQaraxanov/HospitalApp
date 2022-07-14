using DbDll.Models;
using Microsoft.EntityFrameworkCore;

namespace DbDll.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J450DMQ;Initial Catalog=Hospital;Trusted_Connection=True;");
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        
        public DbSet<Patient> Patients { get; set; }

        public DbSet<DoctorPatients> DoctorPatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorPatients>().HasKey(dp => new { dp.DoctorId, dp.PatientId });

            modelBuilder.Entity<DoctorPatients>()
                .HasOne<Patient>(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId);


            modelBuilder.Entity<DoctorPatients>()
                .HasOne<Doctor>(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId);
        }
    }
}
