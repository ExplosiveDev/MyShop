using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class ProductConfiguration
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(180)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(1024);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Comments)
                    .WithMany(x => x.Products);

        }
		public void Configure(EntityTypeBuilder<User> builder)
		{

			builder.HasKey(x => x.Id);

			builder.Property(x => x.FirstName)
				   .HasMaxLength(180)
				   .IsRequired();

			builder.Property(x => x.LastName)
				   .HasMaxLength(1024);

		}
        public void Configure(EntityTypeBuilder<Basket> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Basket);

        }
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Basket)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.BasketId);

        }
        public void Configure(EntityTypeBuilder<Comments> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId);
            

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Comments);

        }
    }
}
