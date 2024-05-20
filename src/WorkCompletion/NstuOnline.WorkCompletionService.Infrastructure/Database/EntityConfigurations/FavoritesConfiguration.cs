using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Enums;
using FavoritesDb = NstuOnline.WorkCompletion.Domain.Entity.Favorites;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class FavoritesConfiguration : IEntityTypeConfiguration<FavoritesDb>
{
    public void Configure(EntityTypeBuilder<FavoritesDb> builder)
    {
        builder.ToTable("favorites");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        
        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultFavorites());
    }

    private List<FavoritesDb> GetDefaultFavorites()
    {
        return new List<FavoritesDb>
        {
            new((byte)Favorites.DoItLater, "do_it_later", "Сделать позже"),
            new((byte)Favorites.CheckLater, "check_later", "Проверить позже"),
            new((byte)Favorites.Specify, "specify", "Уточнить"),
            new((byte)Favorites.Agree, "agree", "Соглосовать")
        };
    }
}