using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.DataContext.Configuration;


public class WorkTaskConfiguration : IEntityTypeConfiguration<WorkTask>
{
    public void Configure(EntityTypeBuilder<WorkTask> builder)
    {
        builder.ToTable("WorkTasks");

        builder.HasKey(wt => wt.Id);

        builder.Property(wt => wt.Title)
            .IsRequired();

        
        builder.HasOne(wt => wt.AssignedToUser)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(wt => wt.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(wt => wt.Team)
            .WithMany(t => t.Tasks)
            .HasForeignKey(wt => wt.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(wt => wt.TeamId);
        builder.HasIndex(wt => wt.AssignedToUserId);

    }
}

