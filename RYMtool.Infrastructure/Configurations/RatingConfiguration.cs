using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RYMtool.Core.Models;

namespace RYMtool.Infrastructure.Configurations;

public class RatingConfiguration:IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .HasOne(x => x.Album)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.AlbumId);
    }
}