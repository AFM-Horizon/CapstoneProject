using CapstoneProject.DataAccess.Subject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapstoneProject.Service_Extensions
{
    public static class RepositoryServiceRegistration
    {
        /// <summary>
        /// This is an Extension method on the <see cref="IServiceCollection"/> class.
        /// It allows us to encapsulate the logic which checks which subject repository we require to be registered
        /// for injection in the startup class
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var isScraper = configuration.GetSection("WebScraper").Value;

            if (isScraper == "true")
            {
                services.AddScoped<ISubjectRepository, SubjectWebscraperRepository>();
            }
            else
            {
                services.AddScoped<ISubjectRepository, SubjectJsonRepository>();
            }

            return services;
        }
    }
}