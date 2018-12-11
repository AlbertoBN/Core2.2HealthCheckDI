using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Core2_2HealthCheckDI
{
    public class DIhealthCheckClass : IHealthCheck
    {
        private readonly ICustomHealthChecker _healthChecker;
        public DIhealthCheckClass(ICustomHealthChecker checker)
        {
            _healthChecker = checker;   
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            bool isHealthy = _healthChecker.CheckHealth();
            if(!isHealthy)
            {
                return Task.FromResult(new HealthCheckResult(
                    status: context.Registration.FailureStatus,
                    description: "He is dead Jim"));
            }

            return Task.FromResult(HealthCheckResult.Healthy("Healthy as a horse"));
        }
    }
}