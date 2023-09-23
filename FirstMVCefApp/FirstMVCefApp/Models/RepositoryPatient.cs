using Microsoft.EntityFrameworkCore;

namespace FirstMVCefApp.Models
{h
    public class RepositoryPatient
    {
        public static List<Patient> GetPatients()
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var list = ctx.Patient.ToList();
            return list;
        }
        public static Patient GetPatient(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var patient = ctx.Patient.Find(id);
            return patient;
        }
        public static void AddNewPatient(Patient patient)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Patient.Add(patient);
            ctx.SaveChanges();

        }
        public static void ModifyPatient(Patient patient)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Entry(patient).State = EntityState.Modified;
            ctx.SaveChanges();

        }
        public static void RemovePatient(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            Patient patient = ctx.Patient.Find(id);
            ctx.Patient.Remove(patient);
            ctx.SaveChanges();
        }
    }
}
