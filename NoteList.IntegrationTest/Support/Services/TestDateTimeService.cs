using NoteList.Service.Impl;
using System;

namespace NoteList.IntegrationTest.Support.Services
{
    public class TestDateTimeService : DateTimeService
    {
        protected TimeHelperService dateTimeService;

        public TestDateTimeService(TimeHelperService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        public override DateTime GetUtcNow()
        {
            return this.dateTimeService.GetUtcNow() ?? DateTime.UtcNow;
        }
    }
}
