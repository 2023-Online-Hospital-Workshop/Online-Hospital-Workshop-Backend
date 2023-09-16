using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test.Models
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
        public virtual DbSet<ConsultInformation> ConsultInformations { get; set; } = null!;
        public virtual DbSet<ConsultRoom> ConsultRooms { get; set; } = null!;
        public virtual DbSet<ConsultationInfo> ConsultationInfos { get; set; } = null!;
        public virtual DbSet<Department1st> Department1sts { get; set; } = null!;
        public virtual DbSet<Department2nd> Department2nds { get; set; } = null!;
        public virtual DbSet<Diagnose> Diagnoses { get; set; } = null!;
        public virtual DbSet<Disease> Diseases { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<LeaveNoteApp> LeaveNoteApps { get; set; } = null!;
        public virtual DbSet<MedicineOut> MedicineOuts { get; set; } = null!;
        public virtual DbSet<MedicinePurchase> MedicinePurchases { get; set; } = null!;
        public virtual DbSet<MedicineSell> MedicineSells { get; set; } = null!;
        public virtual DbSet<MedicineSpec> MedicineSpecs { get; set; } = null!;
        public virtual DbSet<MedicineStock> MedicineStocks { get; set; } = null!;
        public virtual DbSet<OutpatientOrder> OutpatientOrders { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<ReferralRecord> ReferralRecords { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<TransferTreatment> TransferTreatments { get; set; } = null!;
        public virtual DbSet<TreatmentFeedback> TreatmentFeedbacks { get; set; } = null!;

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

            modelBuilder.Entity<ConsultInformation>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.ClinicName })
                    .HasName("CONSULT_INFORMATION_PK");

                entity.ToTable("CONSULT_INFORMATION");

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

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ConsultInformations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("CONSULT_INFORMATION_CONSU_FK1");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.ConsultInformations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("CONSULT_INFORMATION_DOCTO_FK1");
            });

            modelBuilder.Entity<ConsultRoom>(entity =>
            {
                entity.HasKey(e => e.ConsultingRoomName)
                    .HasName("CONSULT_ROOM_PK");

                entity.ToTable("CONSULT_ROOM");

                entity.Property(e => e.ConsultingRoomName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CONSULTING_ROOM_NAME");

                entity.Property(e => e.ConsultantCapacity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONSULTANT_CAPACITY");
            });

            modelBuilder.Entity<ConsultationInfo>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.ClinicName })
                    .HasName("CONSULTATION_INFO_PK");

                entity.ToTable("CONSULTATION_INFO");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_NAME");

                entity.Property(e => e.EndTime)
                    .HasPrecision(0)
                    .HasColumnName("END_TIME");

                entity.Property(e => e.StartTime)
                    .HasPrecision(0)
                    .HasColumnName("START_TIME");
            });

            modelBuilder.Entity<Department1st>(entity =>
            {
                entity.HasKey(e => e.DepartmentName)
                    .HasName("DEPARTMENT_1ST_PK");

                entity.ToTable("DEPARTMENT_1ST");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Department2nd>(entity =>
            {
                entity.HasKey(e => e.DepartmentName)
                    .HasName("DEPARTMENT_2ND_PK");

                entity.ToTable("DEPARTMENT_2ND");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.DepartmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_DESCRIPTION");
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.ToTable("DIAGNOSE");

                entity.Property(e => e.DiagnoseId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIAGNOSE_ID");

                entity.Property(e => e.DiagnoseTime)
                    .HasPrecision(6)
                    .HasColumnName("DIAGNOSE_TIME");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(e => e.DeseaseName)
                    .HasName("SYS_C0010002");

                entity.ToTable("DISEASE");

                entity.Property(e => e.DeseaseName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DESEASE_NAME");

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

                entity.HasOne(d => d.SecondaryDepartment)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.SecondaryDepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("DISEASE_DEPARTMENT_2ND_FK1");
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

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Gender)
                    .HasColumnType("NUMBER")
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

                entity.HasOne(d => d.DoctorNavigation)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("DOCTOR_DEPARTMENT_2ND_FK1");
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
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EQUIPMENT_TYPE");

                entity.Property(e => e.EquipmentAmount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EQUIPMENT_AMOUNT");

                entity.HasOne(d => d.ConsultingRoomNameNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ConsultingRoomName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EQUIPMENT_CONSULT_ROOM_FK1");
            });

            modelBuilder.Entity<LeaveNoteApp>(entity =>
            {
                entity.HasKey(e => e.LeaveNoteId)
                    .HasName("LEAVE_NOTE_APP_PK");

                entity.ToTable("LEAVE_NOTE_APP");

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

            modelBuilder.Entity<MedicineOut>(entity =>
            {
                entity.HasKey(e => new { e.MedicineName, e.Manufacturer, e.ProductionDate })
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

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCTION_DATE");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DELIVER_DATE");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.PurchaseAmount)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.HasOne(d => d.MedicineNameNavigation)
                    .WithMany(p => p.MedicineOuts)
                    .HasForeignKey(d => d.MedicineName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
                    .HasName("MEDICINE_SALE_PK");

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

            modelBuilder.Entity<MedicineSpec>(entity =>
            {
                entity.HasKey(e => e.MedicineName)
                    .HasName("MEDICINEOUT_PK");

                entity.ToTable("MEDICINE_SPEC");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.ApplicableSymptom)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APPLICABLE_SYMPTOM");

                entity.Property(e => e.MedicineDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_DESCRIPTION");

                entity.Property(e => e.MedicineType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_TYPE");
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

                entity.HasOne(d => d.MedicineNameNavigation)
                    .WithMany(p => p.MedicineStocks)
                    .HasForeignKey(d => d.MedicineName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("PRESCRIPTION");

                entity.Property(e => e.PrescriptionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRESCRIPTION_ID");

                entity.Property(e => e.Doctor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR");

                entity.Property(e => e.MedicationInstruction)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MEDICATION_INSTRUCTION");

                entity.Property(e => e.MedicineDose)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MEDICINE_DOSE");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.MedicinePrice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("MEDICINE_PRICE");

                entity.HasOne(d => d.MedicineNameNavigation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicineName)
                    .HasConstraintName("PRESCRIPTION_MEDICINE_SPE_FK1");

                entity.HasOne(d => d.PrescriptionNavigation)
                    .WithOne(p => p.Prescription)
                    .HasForeignKey<Prescription>(d => d.PrescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESCRIPTION_DOCTOR_FK1");
            });

            modelBuilder.Entity<ReferralRecord>(entity =>
            {
                entity.HasKey(e => e.DiagnosisRecordId)
                    .HasName("REFERRAL_RECORD_PK");

                entity.ToTable("REFERRAL_RECORD");

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
                    .WithMany(p => p.ReferralRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("REFERRAL_RECORD_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ReferralRecords)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("REFERRAL_RECORD_PATIENT_FK1");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.PatientId, e.AppointmentTime })
                    .HasName("REGISTRATION_PK");

                entity.ToTable("REGISTRATION");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.AppointmentTime)
                    .HasPrecision(6)
                    .HasColumnName("APPOINTMENT_TIME");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("REGISTRATION_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("REGISTRATION_PATIENT_FK1");
            });

            modelBuilder.Entity<TransferTreatment>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.PatientId, e.Diease })
                    .HasName("TRANSFER_TREATMENT_PK");

                entity.ToTable("TRANSFER_TREATMENT");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Diease)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIEASE");

                entity.Property(e => e.ReferralHospital)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFERRAL_HOSPITAL");

                entity.Property(e => e.RferralTime)
                    .HasColumnType("DATE")
                    .HasColumnName("RFERRAL_TIME");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TransferTreatments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSFER_TREATMENT_DOCTOR_FK1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TransferTreatments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSFER_TREATMENT_PATIEN_FK1");
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

                entity.Property(e => e.CommentDetail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_DETAIL");

                entity.Property(e => e.FollowUpMatters)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FOLLOW_UP_MATTERS");

                entity.Property(e => e.TreatmentScore)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TREATMENT_SCORE");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TreatmentFeedbacks)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("TREATMENT_FEEDBACK_DOCTOR_FK1");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.TreatmentFeedbacks)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TREATMENT_FEEDBACK_PATIEN_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
