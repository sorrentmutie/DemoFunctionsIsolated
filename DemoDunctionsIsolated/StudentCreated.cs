using System;
using System.Text.Json;
using DemoFunctionsIsolated.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoFunctionsIsolated
{
    public class StudentCreated
    {
        private readonly ILogger _logger;
        private readonly IStudentsData studentsData;
        private readonly IClock clock;

        public StudentCreated(ILoggerFactory loggerFactory, IStudentsData studentsData, IClock clock)
        {
            _logger = loggerFactory.CreateLogger<StudentCreated>();
            this.studentsData = studentsData;
            this.clock = clock;
        }

        [Function("StudentCreated")]
        [QueueOutput("studenti-immatricolati")]
        public string Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
            var nuovoStudente = new Student
            {
                Id = 1,
                Name = "Mario Rossi",
                Email = "rossi@gmail.com",
                Matricola = "789",
                RegistrationDate = clock.GetNow()
            };
            return JsonSerializer.Serialize(nuovoStudente);
        }
    }
}