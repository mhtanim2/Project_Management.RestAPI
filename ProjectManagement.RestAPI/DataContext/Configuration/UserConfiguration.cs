using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.DataContext.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FullName)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();

        builder.HasMany(u => u.AssignedTasks)
            .WithOne(wt => wt.AssignedToUser)
            .HasForeignKey(wt => wt.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.TeamMembers)
            .WithOne(tm => tm.User)
            .HasForeignKey(tm => tm.UserId);

    }
}
