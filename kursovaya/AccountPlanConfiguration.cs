using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kursovaya
{
	public class AccountPlanConfiguration: IEntityTypeConfiguration<AccountPlan>
	{
		public void Configure(EntityTypeBuilder<AccountPlan> builder)
		{
            //переопределение таблицы AccountPlan с помощью метода ToTable() Fluent API
            builder.ToTable("ChartOfAccount");

            //ограничение свойства с помощью метода IsRequired()
            builder.Property(ac => ac.Name).IsRequired();

            //явная типизация свойства с помощью метода HasColumnType()
            builder.Property(ac => ac.Type).HasColumnType("varchar(30)");
        }
	}
}




