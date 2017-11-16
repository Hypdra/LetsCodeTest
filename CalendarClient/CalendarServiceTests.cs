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
        [Ignore("This test will add a new meeting every time, so it is ignored. Unignore it if you want to create a meeting")]
        public void AddMeeting_CheckConsole()
        {
            var calendarService = new CalendarServiceClient();
            calendarService.AddMeeting();
        }
    }
}
