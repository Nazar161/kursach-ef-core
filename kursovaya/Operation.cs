using System;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace kursovaya
{
	public class Operation
	{
		//переопределение столбца Id с помощью атрибута Column
		[Column("operation_id")]
		public int Id { get; set; }
		public int Number { get; set; }
		public Instant Date { get; set; }
		public string Type { get; set; }
		public double Sum { get; set; }
		public double SaldoInput { get; set; }
		public double SaldoOutput { get; set; }

		[ForeignKey("DealId")]
		public int DealId { get; set; }
		public virtual Deal Deal { get; set; }

		public int SubAccountId { get; set; }
        public virtual SubAccount SubAccount { get; set; }
	}
}

