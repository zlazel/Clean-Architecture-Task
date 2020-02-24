using Clean_Architecture_Task.Application.Common.Interfaces;
using System;

namespace Clean_Architecture_Task.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
