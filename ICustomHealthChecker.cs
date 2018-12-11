using System;

namespace Core2_2HealthCheckDI
{
    public interface ICustomHealthChecker
    {
        bool CheckHealth();
    }


    public class CustomHealthChecker : ICustomHealthChecker
    {
        public bool CheckHealth()
        {
            DateTime dt = DateTime.Now;

            if(dt.Ticks % 2 == 0) return true;

            return false; 
        }
    }
}