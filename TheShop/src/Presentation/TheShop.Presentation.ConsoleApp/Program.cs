using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheShop.DependencyInjection;
using TheShop.Infrastructure.Persistence;
using TheShop.Infrastructure.Persistence.Extensions;
using TheShop.Presentation.ConsoleApp;

var serviceCollection = new ServiceCollection();
serviceCollection.AddModules();
serviceCollection.AddTransient<EntryPoint>();
var serviceProvider = serviceCollection.BuildServiceProvider();

serviceProvider.GetService<DatabaseContext>().AddTestData();
var logger = serviceProvider.GetService<ILogger<Program>>();
AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((sender, args) => ExceptionHandler.HandleExceptions(sender, args, logger));

await serviceProvider.GetService<EntryPoint>().Run();

