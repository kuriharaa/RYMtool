using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RYMtool.Core.Models;

namespace RYMtool.Infrastructure.Configurations;

public class AlbumConfiguration:IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder
            .HasKey(x => x.Id);
    }
}