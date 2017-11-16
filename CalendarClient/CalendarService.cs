using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.IO;
using System.Reflection;

namespace CalendarClient
{
    public class CalendarServiceClient
    {
        private static string[] Scopes = { CalendarService.Scope.Calendar };
        private const string ApplicationName = "Google Calendar API .NET Quickstart";
        private const string AndromedaCalendarId = "055nh3thpc5chlp3t65l5s1458@group.calendar.google.com";
        private const string ErisCalendarId = "bg4bnva1ek06eff2t8lf3mb1nc@group.calendar.google.com";

        private string CurrentAssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public void GetMeetings()
        {
            var service = GetCalendarService();

            ListCalendarMeetings(service, AndromedaCalendarId);
            ListCalendarMeetings(service, ErisCalendarId);
        }

        public void AddMeeting()
        {
            var service = GetCalendarService();
            
            var addedMeeting = service.Events.Insert(new Event()
            {
                Summary = "Test meeting",
                Start = new EventDateTime { DateTime = GetCurrentHour().AddHours(1), TimeZone = "Europe/Warsaw" },
                End = new EventDateTime { DateTime = GetCurrentHour().AddHours(2), TimeZone = "Europe/Warsaw" }
            }, AndromedaCalendarId).Execute();
            Console.WriteLine("Event created: {0}", addedMeeting.HtmlLink);
        }

        private static DateTime GetCurrentHour()
        {
            var now = DateTime.Now;
            return new DateTime(now.Ticks - now.Ticks % TimeSpan.TicksPerHour);
        }

        private static void ListCalendarMeetings(CalendarService service, string calendarId)
        {
            // Define parameters of request.
            var request = service.Events.List(calendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            var events = request.Execute();
            Console.WriteLine(string.Concat(events.Summary, " -  upcoming events:"));
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
        }

        private CalendarService GetCalendarService()
        {
            GoogleCredential credential;

            using (var stream =
                new FileStream(Path.Combine(CurrentAssemblyDirectory, "client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            // Create Google Calendar API service.
            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
    }
}
