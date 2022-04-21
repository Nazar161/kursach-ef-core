using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace kursovaya
{
	public class DealConfiguration: IEntityTypeConfiguration<Deal>
	{
		public void Configure(EntityTypeBuilder<Deal> builder)
		{
			//конфигурация ключа с Fluent API метод HasKey()
			builder.HasKey(d => d.Id);
		}
	}
}

