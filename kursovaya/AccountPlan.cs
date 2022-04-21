using System;
using System.ComponentModel.DataAnnotations;
namespace kursovaya
{
	public class AccountPlan
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		public string Type { get; set; }
		public int Number { get; set; }

		public virtual List<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();
	}
}

