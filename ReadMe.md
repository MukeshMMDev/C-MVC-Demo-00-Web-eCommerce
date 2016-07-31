##ASP Web

NUGet Package:

1.  Unity Framework(by Microsoft)
2.  Unity.MVC (MVC Bootstrap by Microsoft)


1.  Using Entity Framework Migrations(After creating repo and model)

  1.  Open Package Manger Console (Select DAL Project)
  2.  CMD: enable-migrations
  3.  CMD: add-migration Initial
  4.  CMD: update-database

2.Unity.MVC 

	1.  In AppStart Folder-->UnityConfig.cs

			container.RegisterType<IRepositoryBase < Customer >, CustomerRepository>();