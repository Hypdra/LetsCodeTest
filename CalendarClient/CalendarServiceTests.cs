using NUnit.Framework;
using System;

namespace CalendarClient
{
    [TestFixture]
    public class CalendarServiceTests
    {
        [Test]
        public void ReadMeetings_CheckConsole()
        {
            var calendarService = new CalendarServiceClient();
            calendarService.GetMeetings();
        }

        [Test]
        public void AddMeeting_CheckConsole()
        {
            var calendarService = new CalendarServiceClient();
            calendarService.AddMeeting();
        }

        [Test]
        public void GetWholeHour()
        {
            var now = DateTime.Now;
            Console.WriteLine(new DateTime(now.Ticks - now.Ticks % TimeSpan.TicksPerHour));
        }
    }
}
