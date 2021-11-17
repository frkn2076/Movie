using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.DataAccess.Entity;

namespace Movie.DataAccess.Config
{
    public class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId)
                .IsRequired();
            builder.Property(e => e.MovieId)
                .IsRequired();
        }
    }
}
