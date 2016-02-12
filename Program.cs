using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarQuickstart
{
    class Program
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";


        static void Main(string[] args)
        {
            UserCredential credential;
            var Functions = new GoogleTimeClock.Functions();
            //var service = new CalendarService(new BaseClientService.Initializer());

            //Open file IO stream.
            Functions.OpenFileStream(out credential, Scopes);
            

            // Create Google Calendar API service.
            //Functions.CreateGoogleService(credential, ApplicationName);
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //Display application menu            
            string task;

            Functions.RunAppMenu();
            task = Functions.GetTaskSelection();
            Functions.ExecuteTask(task);
            //appMenu.ValidateTask(task);           
                                    
            //Evaluate task selection


            // Define parameters of request.
            string startDate;
            string endDate;
            Functions.GetDateRange(out startDate, out endDate);            
            EventsResource.ListRequest request = service.Events.List("mba2940@gmail.com");
            request.TimeMin = DateTime.ParseExact(startDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            request.TimeMax = DateTime.ParseExact(endDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 20;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    //DateTime whenDate = Convert.ToDateTime(when);
                    //DateTime whenDate = DateTime.ParseExact(when, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string eventStart = eventItem.Start.DateTime.ToString();
                    //DateTime startTime = Convert.ToDateTime(eventStart);
                    //DateTime startTime = DateTime.ParseExact(when, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                    string eventEnd = eventItem.End.DateTime.ToString();
                    //DateTime endTime = Convert.ToDateTime(eventEnd);
                    //DateTime endTime = DateTime.ParseExact(when, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                    if (string.IsNullOrEmpty(when))
                    {
                        //when = eventItem.Start.Date;
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", eventItem.Summary + "\r\n", whenDate.ToString("MM/DD/YYYY") + "\r\n", startTime.ToString("hh:mm tt") + "\r\n", endTime.ToString("hh:mm tt"));
                    Console.WriteLine("{0} {1} {2}", eventItem.Summary + "\r\n", eventStart.ToString() + "\r\n", eventEnd.ToString() + "\r\n");
                    Console.WriteLine("Total: " + (eventItem.End.DateTime - eventItem.Start.DateTime) + "\r\n");                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();

        }
    }
}