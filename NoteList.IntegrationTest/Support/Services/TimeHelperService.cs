using System;

namespace NoteList.IntegrationTest.Support.Services
{
    public class TimeHelperService
    {
        protected DateTime? dateTime = null;

        public TimeHelperService()
        {
        }

        public void SetCurrentDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public void SetCurrentDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            this.dateTime = new DateTime(year, month, day, hour, minute, second);
        }

        public DateTime? GetUtcNow()
        {
            return this.dateTime;
        }
    }
}
