using Clean_Architecture_Task.Application.Common.Interfaces;
using System;

namespace Clean_Architecture_Task.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
