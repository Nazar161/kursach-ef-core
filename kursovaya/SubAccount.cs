using System;
using System.ComponentModel.DataAnnotations;

namespace kursovaya
{
	public class SubAccount
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public int Number { get; set; }

		public int AccountPlanId { get; set; }
		public virtual AccountPlan AccountPlan { get; set; }

		public virtual List<Operation> Operations { get; set; }

	}
}

