using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NodaTime;

namespace kursovaya
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseNpgsql(connectionString).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                AccountPlan ap1 = new AccountPlan { Name = "клиентский счет", Type = "расчетный", Number = 121231 };
                AccountPlan ap2 = new AccountPlan { Name = "контрагентский счет", Type = "валютный", Number = 324255 };
                AccountPlan ap3 = new AccountPlan { Name = "клиентский счет", Type = "касса", Number = 987389 };
                AccountPlan ap4 = new AccountPlan { Name = "комиссионный счет", Type = "валютный", Number = 892131 };
                AccountPlan ap5 = new AccountPlan { Name = "контрагентский счет", Type = "касса", Number = 923193 };
                db.AccountPlans.AddRange(ap1, ap2, ap3, ap4, ap5);

                SubAccount sa1 = new SubAccount { Name = "дилерские операции", Number = 444222, AccountPlan = ap1 };
                SubAccount sa2 = new SubAccount { Name = "брокерские операции", Number = 776442, AccountPlan = ap2 };
                SubAccount sa3 = new SubAccount { Name = "операции доверительного управления", Number = 906678, AccountPlan = ap4 };
                SubAccount sa4 = new SubAccount { Name = "брокерские операции", Number = 364872, AccountPlan = ap5 };
                SubAccount sa5 = new SubAccount { Name = "дилерские операции", Number = 093248, AccountPlan = ap4 };
                SubAccount sa6 = new SubAccount { Name = "брокерские операции", Number = 781623, AccountPlan = ap3 };
                SubAccount sa7 = new SubAccount { Name = "операции доверительного управления", Number = 382229, AccountPlan = ap1 };
                SubAccount sa8 = new SubAccount { Name = "дилерские операции", Number = 829374, AccountPlan = ap1 };
                SubAccount sa9 = new SubAccount { Name = "брокерские операции", Number = 983457, AccountPlan = ap5 };
                SubAccount sa10 = new SubAccount { Name = "операции доверительного управления", Number = 824233, AccountPlan = ap3 };
                db.SubAccounts.AddRange(sa1, sa2, sa3, sa4, sa5, sa6, sa7, sa8, sa9, sa10);

                Deal d1 = new Deal { Agreement = 668, Tiker = "AAPL", Order = 7812, Number = 981279,
                    Date = SystemClock.Instance.GetCurrentInstant(), Quantity = 4, Price = 160,
                    TotalCost = 640, Trader = "aw3781x", Commission = 24};
                Deal d2 = new Deal { Agreement = 910, Tiker = "BA", Order = 8921, Number = 172312,
                    Date = SystemClock.Instance.GetCurrentInstant(), Quantity = 19, Price = 180,
                    TotalCost = 3420, Trader = "pa4301d", Commission = 58};
                Deal d3 = new Deal { Agreement = 811, Tiker = "GE", Order = 5212, Number = 129733,
                    Date = SystemClock.Instance.GetCurrentInstant(), Quantity = 1, Price = 90,
                    TotalCost = 90, Trader = "ul9773k", Commission = 2};
                Deal d4 = new Deal { Agreement = 923, Tiker = "NIKE", Order = 8522, Number = 781232,
                    Date = SystemClock.Instance.GetCurrentInstant(), Quantity = 5, Price = 130,
                    TotalCost = 650, Trader = "wi3561o", Commission = 15};
                Deal d5 = new Deal { Agreement = 561, Tiker = "SBUX", Order = 3568, Number = 873241,
                    Date = SystemClock.Instance.GetCurrentInstant(), Quantity = 10, Price = 80,
                    TotalCost = 800, Trader = "te9244h", Commission = 9};
                db.Deals.AddRange(d1, d2, d3, d4, d5);

                Operation op1 = new Operation{Number = 234234,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 2500, SaldoInput = 450, SaldoOutput = 890, SubAccount = sa2, Deal = d1
                };
                Operation op2 = new Operation{Number = 88888,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 1200,SaldoInput = 500,SaldoOutput = 340,SubAccount = sa3, Deal = d3
                };
                Operation op3 = new Operation{Number = 0102399,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "продажа", Sum = 8700,SaldoInput = 3000,SaldoOutput = 4200,SubAccount = sa5, Deal = d3
                };
                Operation op4 = new Operation{Number = 289374,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 6300,SaldoInput = 3400,SaldoOutput = 5200,SubAccount = sa7, Deal = d2
                };
                Operation op5 = new Operation{Number = 936274,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "продажа", Sum = 7800,SaldoInput = 2800,SaldoOutput = 3500,SubAccount = sa2, Deal = d2
                };
                Operation op6 = new Operation{Number = 127683,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 9450,SaldoInput = 3250,SaldoOutput = 4250,SubAccount = sa8, Deal = d4
                };
                Operation op7 = new Operation{Number = 276382,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "продажа", Sum = 4300,SaldoInput = 1300,SaldoOutput = 1800,SubAccount = sa9, Deal = d5
                };
                Operation op8 = new Operation{Number = 987213,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 4500,SaldoInput = 1700,SaldoOutput = 2300,SubAccount = sa9, Deal = d5
                };
                Operation op9 = new Operation{Number = 623171,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "продажа", Sum = 3800,SaldoInput = 1300,SaldoOutput = 2100,SubAccount = sa10, Deal = d4
                };
                Operation op10 = new Operation{Number = 732831,Date = SystemClock.Instance.GetCurrentInstant(),
                    Type = "покупка", Sum = 550,SaldoInput = 110,SaldoOutput = 230,SubAccount = sa1, Deal = d4
                };

                db.Operations.AddRange(op1, op2, op3, op4, op5, op6, op7, op8, op9, op10);

                db.SaveChanges();
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var operations = db.Operations
                    .Include(o => o.Deal)
                    .Include(o => o.SubAccount)
                        .ThenInclude(sa => sa.AccountPlan)
                    .ToList();

                Console.WriteLine("***** Жадная загрузка *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                foreach (var op in operations)
                {
                    Console.WriteLine($"Операция номер {op.Number}");
                    Console.WriteLine($"Номер договора сделки и тикер {op.Deal?.Agreement}, {op.Deal?.Tiker}");
                    Console.WriteLine($"Название и номер субсчета - {op.SubAccount?.Name}, {op.SubAccount?.Number}");
                    Console.WriteLine($"Название и номер плана счетов - " +
                        $"{op.SubAccount?.AccountPlan?.Name}, {op.SubAccount?.AccountPlan?.Number}");
                    Console.WriteLine("-----------------------------");
                }
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                AccountPlan accountPlan = db.AccountPlans.FirstOrDefault();
                db.SubAccounts.Where(sa => sa.AccountPlanId == accountPlan.Id).Load();


                Console.WriteLine("***** Явная загрузка *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");

                Console.WriteLine($"Название и номер плана счетов - {accountPlan.Name}, {accountPlan.Number}");
                Console.WriteLine("-----------------------------");
                foreach (var subAcc in accountPlan.SubAccounts)
                    Console.WriteLine($"Названия и номера субсчетов - {subAcc.Name}, {subAcc.Number}");

            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var subAccounts = db.SubAccounts.ToList();

                Console.WriteLine("***** Ленивая загрузка *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");

                foreach (var sa in subAccounts)
                {
                    Console.WriteLine($"Названия и номера субсчета - {sa.Name}, {sa.Number}");
                    Console.WriteLine($"Название и номер плана счетов - " +
                        $"{sa.AccountPlan?.Name}, {sa.AccountPlan?.Number}");
                    Console.WriteLine("-----------------------------");
                }

            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var operations = db.Operations
                    .Include(o => o.Deal)
                    .Where(o => o.DealId == 4)
                    .OrderBy(o => o.Number)
                    .ToList();

                Console.WriteLine("***** LINQ запрос *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                foreach (var op in operations)
                    Console.WriteLine($"Номер операции - {op.Number}, тикер сделки - {op.Deal?.Tiker}");

            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var operations = from operation in db.Operations
                                 join subAccount in db.SubAccounts on operation.SubAccountId equals subAccount.Id
                                 join accountPlan in db.AccountPlans on subAccount.AccountPlanId equals accountPlan.Id
                                 select new
                                 {
                                     opNumber = operation.Number,
                                     subAccountNumber = subAccount.Name,
                                     accountPlanType = accountPlan.Type
                                 };
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** Соединение трех таблиц *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                foreach (var op in operations)
                    Console.WriteLine($"номер опреации:{op.opNumber} - " +
                        $"номер субсчета:{op.subAccountNumber} - тип плана счетов:{op.accountPlanType}");
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var subAccounts = db.SubAccounts.Where(sa => sa.Number > 430000)
                    .Union(db.SubAccounts.Where(sa => sa.Name.Contains("дилерские")));

                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** объединение метод Union *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");

                foreach (var subAccount in subAccounts)
                    Console.WriteLine($"{subAccount.Number} - {subAccount.Name}");
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var subAccounts = db.SubAccounts.Where(sa => sa.Number > 430000)
                    .Intersect(db.SubAccounts.Where(sa => sa.Name.Contains("брокерские")));

                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** пересечение метод Intersect *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");

                foreach (var subAccount in subAccounts)
                    Console.WriteLine($"{subAccount.Name} - {subAccount.Number}");
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {

                var selector1 = db.SubAccounts.Where(sa => sa.Number > 430000);
                var selector2 = db.SubAccounts.Where(sa => sa.Name.Contains("брокерские"));

                var subAccounts = selector1.Except(selector2);

                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** разность метод Except *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");

                foreach (var subAccount in subAccounts)
                    Console.WriteLine($"{subAccount.Name} - {subAccount.Number}");
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                int operations = db.Operations.Count(op => op.Sum < 5000);

                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** агрегирование Count *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine($"количество операций {operations}");
            }
            using (ApplicationContext db = new ApplicationContext(options))
            {
                double operationsSum = db.Operations
                    .Where(op => op.Sum < 5000)
                    .Sum(op => op.Sum);

                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine("***** агрегирование Sum *****");
                Console.WriteLine("••••••••••••••••••••••••••••••••••••••");
                Console.WriteLine($"Сумма всех операций где сумма " +
                    $"операции не превышает 5000: {operationsSum}");
            }
            Console.Read();
        }
    }
}
