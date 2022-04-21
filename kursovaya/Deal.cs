using System;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace kursovaya
{
	[Table("Distribute")]
	public class Deal
	{
		public int Id { get; set; }
		public int Agreement { get; set; }
		public string Tiker { get; set; }
		public int Order { get; set; }
		public int Number { get; set; }
		public Instant Date { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public double TotalCost { get; set; }
		[Column(TypeName = "varchar(30)")]
		public string Trader { get; set; }
		public double Commission { get; set; }

		public virtual List<Operation> Operations { get; set; }

	}
}

