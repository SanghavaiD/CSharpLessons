using Microsoft.EntityFrameworkCore;

namespace FirstMVCefApp.Models
{
    public class RepositoryDoctor
    {
        public static List<Doctor> GetDoctors()
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var list = ctx.Doctor.ToList();
            return list;
        }
        public static Doctor GetDoctor(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var doctor = ctx.Doctor.Find(id);
            return doctor;

        }
        public static void  AddNewDoctor(Doctor doctor)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Doctor.Add(doctor);
            ctx.SaveChanges();
            
        }
        public static void ModifyDoctor(Doctor doctor)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Entry(doctor).State=EntityState.Modified;
            ctx.SaveChanges();

        }
        public static void RemoveDoctor(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            Doctor doctor = ctx.Doctor.Find(id);
            ctx.Doctor.Remove(doctor);
            ctx.SaveChanges();
        }
    }
}
