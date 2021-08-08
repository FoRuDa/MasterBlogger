using System;
using System.Configuration;
using DB.Aplication.contracts;
using FluentAssertions.Common;
using MB.Application;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class BootStrap
    {

        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient< IArticleCategoryApplication, ArticleCategoryApplication > ();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddDbContext<MasterBloggerContext>(option
                => option.UseSqlServer(connectionString));
         
        }

    }
}
