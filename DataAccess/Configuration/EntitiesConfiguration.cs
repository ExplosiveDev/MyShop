using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property configurations
            builder.Property(x => x.Name)
                   .HasMaxLength(180)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(1024);

            //Set Relationship configurations
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);

        }
		public void Configure(EntityTypeBuilder<User> builder)
		{

			//Set Primary Key
			builder.HasKey(x => x.Id);

			//Set Property configurations
			builder.Property(x => x.FirstName)
				   .HasMaxLength(180)
				   .IsRequired();

			builder.Property(x => x.LastName)
				   .HasMaxLength(1024);


		}
	}
}
