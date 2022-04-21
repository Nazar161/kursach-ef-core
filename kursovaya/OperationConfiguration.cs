using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace kursovaya
{
	public class OperationConfiguration: IEntityTypeConfiguration<Operation>
	{
		public void Configure(EntityTypeBuilder<Operation> builder)
        {
			//переопределение столбца Number с помощью метода HasColumnName() Fluent API
			builder.Property(u => u.Number).HasColumnName("operation_number");

			//конфигурация внешнего ключа с Fluent API метод HasForeignKey()
			builder
				.HasOne(p => p.SubAccount)
				.WithMany(t => t.Operations)
				.HasForeignKey(p => p.SubAccountId);

			//ограничение длины символьного свойства с помощью метода HasMaxLength()
            builder.Property(op => op.Type).HasMaxLength(25);
		}
	}
}

