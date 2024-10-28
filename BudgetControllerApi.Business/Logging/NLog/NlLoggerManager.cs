using BudgetControllerApi.Business.Logging.Contracts;
using NLog;

namespace BudgetControllerApi.Business.Logging.NLog
{
    public class NlLoggerManager : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => _logger.Debug(message);

        public void LogError(string message) => _logger.Error(message);

        public void LogInfo(string message) => _logger.Info(message);

        public void LogWarning(string message) => _logger.Debug(message);
    }
}
