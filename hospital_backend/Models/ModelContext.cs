using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hospital_backend.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<ConsultationInfo> ConsultationInfos { get; set; } = null!;
        public virtual DbSet<ConsultingRoom> ConsultingRooms { get; set; } = null!;
        public virtual DbSet<Department1> Department1s { get; set; } = null!;
        public virtual DbSet<Department2> Department2s { get; set; } = null!;
        public virtual DbSet<Disease> Diseases { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<LeaveApplication> LeaveApplications { get; set; } = null!;
        public virtual DbSet<MedicineDescription> MedicineDescriptions { get; set; } = null!;
        public virtual DbSet<MedicineOut> MedicineOuts { get; set; } = null!;
        public virtual DbSet<MedicinePurchase> MedicinePurchases { get; set; } = null!;
        public virtual DbSet<MedicineSell> MedicineSells { get; set; } = null!;
        public virtual DbSet<MedicineStock> MedicineStocks { get; set; } = null!;
        public virtual DbSet<OutpatientOrder> OutpatientOrders { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; } = null!;
        public virtual DbSet<Referral> Referrals { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<TreatmentFeedback> TreatmentFeedbacks { get; set; } = null!;
        public virtual DbSet<TreatmentRecord> TreatmentRecords { get; set; } = null!;
        public virtual DbSet<TreatmentRecord2> TreatmentRecord2s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=124.223.143.21/xe;Password=TEST_PASSWORD;User ID=TEST_ACCOUNT;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TEST_ACCOUNT");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("ADMINISTRATOR");

                entity.Property(e => e.AdministratorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADMINISTRATOR_ID");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Gender)
                    .HasPrecision(1)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<ConsultationInfo>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.ClinicName })
                    .HasName("CONSULTATION_INFO_PK");

                entity.ToTable("CONSULTATION_INFO");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_NAME");

                entity.Property(e => e.EndTime)
                    .HasPrecision(6)
                    .HasColumnName("END_TIME");

                entity.Property(e => e.StartTime)
                    .HasPrecision(6)
                    .HasColumnName("START_TIME");

                entity.HasOne(d => d.ClinicNameNavigation)
                    .WithMany(p => p.ConsultationInfos)
                    .HasForeignKey(d => d.ClinicName)
                    .HasConstraintName("CONSULTATION_INFO_CONSULT_FK1");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ConsultationInfos)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("CONSULTATION_INFO_DOCTOR_FK1");
            });

            modelBuilder.Entity<ConsultingRoom>(entity =>
            {
                entity.HasKey(e => e.ConsultingRoomName)
                    .HasName("CONSULTING_ROOM_PK");

                entity.ToTable("CONSULTING_ROOM");

                entity.Property(e => e.ConsultingRoomName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CONSULTING_ROOM_NAME");

                entity.Property(e => e.ConsultantCapacity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONSULTANT_CAPACITY");
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasKey(e => e.DepartmentName)
                    .HasName("DEPARTMENT1_PK");

                entity.ToTable("DEPARTMENT1");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Department2>(entity =>
            {
                entity.HasKey(e => e.DepartmentName)
                    .HasName("DEPARTMENT2_PK");

                entity.ToTable("DEPARTMENT2");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.DepartmentDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_DESCRIPTION");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(e => e.DiseaseName)
                    .HasName("DISEASE_PK");

                entity.ToTable("DISEASE");

                entity.Property(e => e.DiseaseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISEASE_NAME");

                entity.Property(e => e.CureMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CURE_METHOD");

                entity.Property(e => e.SecondaryDepartmentId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SECONDARY_DEPARTMENT_ID");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SYMPTOM");

                entity.HasOne(d => d.DiseaseNameNavigation)
                    .WithOne(p => p.Disease)
                    .HasForeignKey<Disease>(d => d.DiseaseName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("DISEASE_DEPARTMENT2_FK1");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("DOCTOR");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.CertificateId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CERTIFICATE_ID");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Gender)
                    .HasPrecision(1)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.SecondaryDepartment)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SECONDARY_DEPARTMENT");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.SecondaryDepartmentNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SecondaryDepartment)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("DOCTOR_DEPARTMENT2_FK1");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => new { e.ConsultingRoomName, e.EquipmentType })
                    .HasName("EQUIPMENT_PK");

                entity.ToTable("EQUIPMENT");

                entity.Property(e => e.ConsultingRoomName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CONSULTING_ROOM_NAME");

                entity.Property(e => e.EquipmentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EQUIPMENT_TYPE");

                entity.Property(e => e.EquipmentAmount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EQUIPMENT_AMOUNT");

                entity.HasOne(d => d.ConsultingRoomNameNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ConsultingRoomName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EQUIPMENT_CONSULTING_ROOM_FK1");
            });

            modelBuilder.Entity<LeaveApplication>(entity =>
            {
                entity.HasKey(e => e.LeaveNoteId)
                    .HasName("LEAVE_APPLICATION_PK");

                entity.ToTable("LEAVE_APPLICATION");

                entity.Property(e => e.LeaveNoteId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LEAVE_NOTE_ID");

                entity.Property(e => e.LeaveApplicationTime)
                    .HasPrecision(6)
                    .HasColumnName("LEAVE_APPLICATION_TIME");

                entity.Property(e => e.LeaveEndDate)
                    .HasPrecision(6)
                    .HasColumnName("LEAVE_END_DATE");

                entity.Property(e => e.LeaveNoteRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LEAVE_NOTE_REMARK");

                entity.Property(e => e.LeaveStartDate)
                    .HasPrecision(6)
                    .HasColumnName("LEAVE_START_DATE");
            });

            modelBuilder.Entity<MedicineDescription>(entity =>
            {
                entity.HasKey(e => e.MedicineName)
                    .HasName("MEDICINE_DESCRIPTION_PK");

                entity.ToTable("MEDICINE_DESCRIPTION");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.ApplicableSymptom)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APPLICABLE_SYMPTOM");

                entity.Property(e => e.MedicineDescription1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_DESCRIPTION");

                entity.Property(e => e.MedicineType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_TYPE");
            });

            modelBuilder.Entity<MedicineOut>(entity =>
            {
                entity.HasKey(e => new { e.MedicineName, e.Manufacturer })
                    .HasName("MEDICINE_OUT_PK");

                entity.ToTable("MEDICINE_OUT");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MANUFACTURER");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DELIVER_DATE");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCTION_DATE");

                entity.Property(e => e.PurchaseAmount)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicineOuts)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("MEDICINE_OUT_PATIENT_FK1");
            });

            modelBuilder.Entity<MedicinePurchase>(entity =>
            {
                entity.HasKey(e => new { e.MedicineName, e.Manufacturer, e.ProductionDate, e.PurchaseDate })
                    .HasName("MEDICINE_PURCHASE_PK");

                entity.ToTable("MEDICINE_PURCHASE");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MANUFACTURER");

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PRODUCTION_DATE");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PURCHASE_DATE");

                entity.Property(e => e.AdministratorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADMINISTRATOR_ID");

                entity.Property(e => e.PurchaseAmount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("PURCHASE_PRICE");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.MedicinePurchases)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("MEDICINE_PURCHASE_ADMINIS_FK1");
            });

            modelBuilder.Entity<MedicineSell>(entity =>
            {
                entity.HasKey(e => new { e.MedicineName, e.Manufacturer })
                    .HasName("MEDICINE_SELL_PK");

                entity.ToTable("MEDICINE_SELL");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MANUFACTURER");

                entity.Property(e => e.SellingPrice)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("SELLING_PRICE");
            });

            modelBuilder.Entity<MedicineStock>(entity =>
            {
                entity.HasKey(e => new { e.MedicineName, e.Manufacturer, e.ProductionDate })
                    .HasName("MEDICINE_STOCK_PK");

                entity.ToTable("MEDICINE_STOCK");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MANUFACTURER");

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PRODUCTION_DATE");

                entity.Property(e => e.CleanAdministrator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLEAN_ADMINISTRATOR");

                entity.Property(e => e.CleanDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLEAN_DATE");

                entity.Property(e => e.MedicineAmount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MEDICINE_AMOUNT");

                entity.Property(e => e.MedicineShelflife)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MEDICINE_SHELFLIFE");

                entity.Property(e => e.ThresholdValue)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("THRESHOLD_VALUE");

                entity.HasOne(d => d.CleanAdministratorNavigation)
                    .WithMany(p => p.MedicineStocks)
                    .HasForeignKey(d => d.CleanAdministrator)
                    .HasConstraintName("MEDICINE_STOCK_ADMINISTRA_FK1");
            });

            modelBuilder.Entity<OutpatientOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OUTPATIENT_ORDER_PK");

                entity.ToTable("OUTPATIENT_ORDER");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderTime)
                    .HasPrecision(6)
                    .HasColumnName("ORDER_TIME");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.OutpatientOrders)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("OUTPATIENT_ORDER_PATIENT_FK1");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("PATIENT");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.College)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLLEGE");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Counsellor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COUNSELLOR");

                entity.Property(e => e.Gender)
                    .HasPrecision(1)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("PRESCRIPTION");

                entity.Property(e => e.PrescriptionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRESCRIPTION_ID");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("TOTAL_PRICE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("PRESCRIPTION_DOCTOR_FK1");
            });

            modelBuilder.Entity<PrescriptionMedicine>(entity =>
            {
                entity.HasKey(e => new { e.PrescriptionId, e.MedicineName })
                    .HasName("PRESCRIPTION_MEDICINE_PK");

                entity.ToTable("PRESCRIPTION_MEDICINE");

                entity.Property(e => e.PrescriptionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRESCRIPTION_ID");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.MedicationInstruction)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MEDICATION_INSTRUCTION");

                entity.Property(e => e.MedicineDose)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MEDICINE_DOSE");

                entity.Property(e => e.MedicinePrice)
                    .HasColumnType("NUMBER(6,2)")
                    .HasColumnName("MEDICINE_PRICE");

                entity.HasOne(d => d.MedicineNameNavigation)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.MedicineName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESCRIPTION_MEDICINE_MED_FK1");
            });

            modelBuilder.Entity<Referral>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.PatientId })
                    .HasName("REFERRAL_PK");

                entity.ToTable("REFERRAL");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Disease)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISEASE");

                entity.Property(e => e.ReferralHospital)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REFERRAL_HOSPITAL");

                entity.Property(e => e.ReferralTime)
                    .HasColumnType("DATE")
                    .HasColumnName("REFERRAL_TIME");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REFERRAL_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REFERRAL_PATIENT_FK1");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.DoctorId, e.AppointmentTime })
                    .HasName("REGISTRATION_PK");

                entity.ToTable("REGISTRATION");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.AppointmentTime)
                    .HasPrecision(6)
                    .HasColumnName("APPOINTMENT_TIME");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Period)
                    .HasPrecision(1)
                    .HasColumnName("PERIOD");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("REGISTRATION_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("REGISTRATION_PATIENT_FK1");
            });

            modelBuilder.Entity<TreatmentFeedback>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.DoctorId })
                    .HasName("TREATMENT_FEEDBACK_PK");

                entity.ToTable("TREATMENT_FEEDBACK");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.Evaluation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EVALUATION");

                entity.Property(e => e.FollowUpMatters)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOLLOW_UP_MATTERS");

                entity.Property(e => e.TreatmentScore)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TREATMENT_SCORE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TreatmentFeedbacks)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TREATMENT_FEEDBACK_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TreatmentFeedbacks)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TREATMENT_FEEDBACK_PATIEN_FK1");
            });

            modelBuilder.Entity<TreatmentRecord>(entity =>
            {
                entity.HasKey(e => e.DiagnosisRecordId)
                    .HasName("TRANSFER_TREATMENT_PK");

                entity.ToTable("TREATMENT_RECORD");

                entity.Property(e => e.DiagnosisRecordId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIAGNOSIS_RECORD_ID");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.LeaveNoteId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LEAVE_NOTE_ID");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TreatmentRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("TREATMENT_RECORD_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TreatmentRecords)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("TREATMENT_RECORD_PATIENT_FK1");
            });

            modelBuilder.Entity<TreatmentRecord2>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId)
                    .HasName("CONSULTING_RECORD_PK");

                entity.ToTable("TREATMENT_RECORD2");

                entity.Property(e => e.DiagnoseId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIAGNOSE_ID");

                entity.Property(e => e.DiagnoseTime)
                    .HasPrecision(6)
                    .HasColumnName("DIAGNOSE_TIME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
