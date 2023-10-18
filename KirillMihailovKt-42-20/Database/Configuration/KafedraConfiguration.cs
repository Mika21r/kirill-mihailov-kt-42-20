using KirillMihailovKt_42_20.Database.Helpers;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KirillMihailovKt_42_20.Database.Configuration
{
    public class KafedraConfiguration : IEntityTypeConfiguration<Kafedra>
    {
        private const string TableName = "cd_kafedra";
        public void Configure(EntityTypeBuilder<Kafedra> builder)
        {
            builder
                .HasKey(p => p.KafedraId)
                .HasName($"pk_{TableName}_kafedra_id");

            builder
                .Property(p => p.KafedraId)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.KafedraId)
                .HasColumnName("kafedra_id")
                .HasComment("Идентификатор записи кафедрыы");

            builder
                .Property(p => p.KafedraName)
                .IsRequired()
                .HasColumnName("c_kafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");
            builder
                .ToTable(TableName);
        }
    }
}
