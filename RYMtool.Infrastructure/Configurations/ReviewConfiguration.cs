using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RYMtool.Core.Models;

namespace RYMtool.Infrastructure.Configurations;

public class ReviewConfiguration:IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .HasOne(x => x.Album)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.AlbumId);
    }
}