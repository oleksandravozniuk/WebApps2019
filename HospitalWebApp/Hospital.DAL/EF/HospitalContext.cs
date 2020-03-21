using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Hospital.DAL.EF
{
    public class HospitalContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<PatientCard> PatientCards { get; set; }
        public DbSet<Timetable> Timetables { get; set; }

        static HospitalContext()
        {
            Database.SetInitializer<HospitalContext>(new HospitalDbInitializer());
        }
        public HospitalContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class HospitalDbInitializer : DropCreateDatabaseIfModelChanges<HospitalContext>
    {
        protected override void Seed(HospitalContext db)
        {

            Doctor d1 = new Doctor { FirstName = "Иван", SecondName="Иванов", Specialization="Хирург" };
            Doctor d2 = new Doctor { FirstName = "Петр", SecondName = "Петров", Specialization = "Офтальмолог" };
            db.Doctors.Add(d1);
            db.Doctors.Add(d2);
            db.SaveChanges();

            db.DoctorSchedules.Add(new DoctorSchedule {DoctorId=d1.Id, NumOfWeek = 1, StartTime = new DateTime(1,1,1,9,1,1), EndTime = new DateTime(1,1,1,12,0,0) });
            db.DoctorSchedules.Add(new DoctorSchedule { DoctorId = d1.Id, NumOfWeek = 2, StartTime = new DateTime(1, 1, 1, 9, 0, 0), EndTime = new DateTime(1, 1, 1, 12, 0, 0) });

            db.DoctorSchedules.Add(new DoctorSchedule { DoctorId = d2.Id, NumOfWeek = 1, StartTime = new DateTime(1, 1, 1, 14, 0, 0), EndTime = new DateTime(1, 1, 1, 17, 0, 0) });
            db.DoctorSchedules.Add(new DoctorSchedule { DoctorId = d2.Id, NumOfWeek = 2, StartTime = new DateTime(1, 1, 1, 14, 0, 0), EndTime = new DateTime(1, 1, 1, 17, 0, 0) });
            db.SaveChanges();

            Patient p1 = new Patient { FirstName = "Николай", SecondName = "Николаев" };
            Patient p2 = new Patient { FirstName = "Василий", SecondName = "Васильев" };
            db.Patients.Add(p1);
            db.Patients.Add(p2);
            db.SaveChanges();

            db.PatientCards.Add(new PatientCard { Id = p1.Id, TextInfo = "Text1", DateOfRecord = DateTime.Now });
            db.PatientCards.Add(new PatientCard { Id = p1.Id, TextInfo = "Text2", DateOfRecord = DateTime.Now });
            db.PatientCards.Add(new PatientCard { Id = p2.Id, TextInfo = "Text3", DateOfRecord = DateTime.Now });
            db.SaveChanges();

            db.Timetables.Add(new Timetable { DoctorId = d1.Id, PatientId = p1.Id, StartTime=new DateTime(2019,12,19,9,0,0), EndTime = new DateTime(2019,12,19,9,20,0)});
            db.SaveChanges();
        }
    }
}
