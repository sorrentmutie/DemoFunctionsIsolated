using System;
using DemoFunctionsIsolated.Library;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoFunctionsIsolated
{
    public class GetStudentsCount
    {
        private readonly ILogger _logger;
        private readonly IStudentsData studentsData;

        public GetStudentsCount(ILoggerFactory loggerFactory, IStudentsData studentsData)
        {
            _logger = loggerFactory.CreateLogger<GetStudentsCount>();
            this.studentsData = studentsData;
        }

        [Function("GetStudentsCount")]
        public async Task Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var students = await studentsData.GetStudents();
            _logger.LogInformation($"{students.Count()}: GetStudentsCount function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
