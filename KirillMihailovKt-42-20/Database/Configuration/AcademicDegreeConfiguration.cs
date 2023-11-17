using KirillMihailovKt_42_20.Database.Helpers;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KirillMihailovKt_42_20.Database.Configuration
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academicdegree";
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{TableName}_academicdegree_id");

            builder
                .Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.AcademicDegreeId)
                .HasColumnName("academicdegree_id")
                .HasComment("Идентификатор записи ученной степени");

            builder
                .Property(p => p.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_academicdegreeName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Ученная степень");
            builder
                .ToTable(TableName);
        }
    }
}
