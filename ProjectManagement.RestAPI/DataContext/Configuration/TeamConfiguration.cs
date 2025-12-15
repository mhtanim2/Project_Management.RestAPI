using Microsoft.EntityFrameworkCore;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.DataContext.Configuration;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired();

        builder.HasMany(t => t.Tasks)
            .WithOne(wt => wt.Team)
            .HasForeignKey(wt => wt.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.TeamMembers)
            .WithOne(tm => tm.Team)
            .HasForeignKey(tm => tm.TeamId);
    }
}