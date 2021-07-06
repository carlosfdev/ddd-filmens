using Filmens.Core.FilmAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmens.Infrastructure.Data.Config
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.Property(f => f.Title)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("title");

            builder.Property(f => f.ReleaseDate)
                .IsRequired()
                .HasColumnName("release_date");

            builder.Property(f => f.CreationDate)
                .IsRequired()
                .HasColumnName("creation_date");
        }
    }
}
