using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasks.Domain.Entity;

namespace Tasks.Infrastructure.Persistence.Contexts.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasIndex(x => x.UserId);

            builder.HasIndex(x => x.Status);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MetadataJson);

            builder.HasOne(x => x.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Task_Status", "[Status] IN ('Pending', 'InProgress', 'Completed')");
                t.HasCheckConstraint("CK_Task_Metadata", "MetadataJson IS NULL OR ISJSON(MetadataJson) = 1");
            });
        }
    }
}
