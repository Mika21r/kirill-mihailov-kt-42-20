using KirillMihailovKt_42_20.Database.Helpers;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KirillMihailovKt_42_20.Database.Configuration
{
    public class PrepodConfiguration : IEntityTypeConfiguration<Prepod>
    {
        private const string TableName = "cd_prepod";
        public void Configure(EntityTypeBuilder<Prepod> builder) 
        {
            builder
                .HasKey(p => p.PrepodId)
                .HasName($"pk_{TableName}_prepod_id");

            builder.Property(p => p.PrepodId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PrepodId)
                .HasColumnName("prepod_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_prepod_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_prepod_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_prepod_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.KafedraId)
                .HasColumnName("c_kafedra_id")
                .HasComment("Идентификатор кафедры");

            builder.ToTable(TableName)
                .HasOne(p => p.Kafedra)
                .WithMany(t => t.Prepod)
                .HasForeignKey(p => p.KafedraId)
                .HasConstraintName("fk_f_kafedra_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.KafedraId);
            builder.Navigation(p => p.Kafedra);

            builder.Property(p => p.AcademicDegreeId)
               .HasColumnName("c_prepod_academicdegreeId")
               .HasComment("Идентификатор ученой степени");

            builder.ToTable(TableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany(t => t.Prepod)
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_f_academicdegree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId);
            builder.Navigation(p => p.AcademicDegree);
        }
    }
}
