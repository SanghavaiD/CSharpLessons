using FirstMVCefApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FirstMVCefApp.Models
{
    public class HospitalDbContext:DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            String conString = @"server=200411LTP2857\SQLEXPRESS;database=HospitalDB;
                                integrated security=true;Encrypt=false";
            options.UseSqlServer(conString);
        }
    }
}
