using KirillMihailovKt_42_20.Interfaces.PrepodInterfaces;
using KirillMihailovKt_42_20.Interfaces.KafedraInterface;

namespace KirillMihailovKt_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IKafedraService, KafedraService>();

            return services;
        }
    }
}
