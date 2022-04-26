using Microsoft.Extensions.DependencyInjection;
using MediatR;
using TheShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TheShop.Infrastructure.Persistence.Repositories;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Suppliers;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Application.Services.External;
using TheShop.Infrastructure.External.Services;
using TheShop.Core.Application.Services.Factory;
using TheShop.Core.Application.Services;
using TheShop.Core.Application.Behavior;
using Serilog;
using TheShop.Infrastructure.Logging;
using FluentValidation;

namespace TheShop.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApplicationServices();
            serviceCollection.AddInfrastructureServices();
        }

        private static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(TheShop.Core.Application.Module).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(TheShop.Core.Application.Module).Assembly);
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            serviceCollection.AddScoped<IExternalSupplierServiceFactory, ExternalSupplierServiceFactory>();
            serviceCollection.AddScoped<ISupplierArticleService, SupplierArticleService>();
        }

        private static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("TheShopDb").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            serviceCollection.AddAutoMapper(typeof(TheShop.Infrastructure.Persistence.Module).Assembly);
            serviceCollection.AddAutoMapper(typeof(TheShop.Infrastructure.External.Module).Assembly);

            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IOrderReadOnlyRepository, OrderReadOnlyRepository>();
            serviceCollection.AddScoped<ISupplierRepository, SupplierRepository>();
            serviceCollection.AddScoped<IArticleRepository, ArticleRepository>();

            serviceCollection.AddScoped<IExternalSupplierTest1Service, ExternalSupplierTest1Service>();
            serviceCollection.AddScoped<IExternalSupplierTest2Service, ExternalSupplierTest2Service>();
            serviceCollection.AddScoped<IExternalSupplierTest3Service, ExternalSupplierTest3Service>();

            serviceCollection.AddSerilog();
        }

        private static void AddSerilog(this IServiceCollection serviceCollection)
        {
            Log.Logger = SerilogConfig.ConfigureLogging();
            serviceCollection.AddLogging(e => e.AddSerilog());
        }
    }
}
