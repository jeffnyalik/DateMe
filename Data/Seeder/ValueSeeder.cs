using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingAPI.Data.Seeder
{
    public class ValueSeeder : IEntityTypeConfiguration<Value>
    {
        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.HasData(
                new Value
                {
                    Id = 1,
                    Name = "Value1"
                },
                new Value
                {
                    Id = 2,
                    Name = "Value2"
                },
                new Value
                {
                    Id = 3,
                    Name = "Value4"
                },
                new Value
                {
                    Id = 4,
                    Name = "Value5"
                },
                new Value
                {
                    Id = 5,
                    Name = "Value6"
                }
            );
        }
    }
}
