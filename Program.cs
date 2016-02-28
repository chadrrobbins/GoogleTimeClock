//This program uses code pulled from https://developers.google.com/google-apps/calendar/quickstart/dotnet

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
            //string task;

            //Functions.RunAppMenu();
            //task = Functions.GetTaskSelection();
            //Functions.ExecuteTask(task);
            //appMenu.ValidateTask(task);           
                                    
            //Evaluate task selection


            // Define parameters of request.
            //string startDate;
            //string endDate;
            //Functions.GetDateRange(out startDate, out endDate);            
            EventsResource.ListRequest request = service.Events.List("mba2940@gmail.com");
            //request.TimeMin = DateTime.ParseExact(startDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //request.TimeMax = DateTime.ParseExact(endDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            request.TimeMin = Convert.ToDateTime("2016-01-18");
            request.TimeMax = Convert.ToDateTime("2016-01-25");
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
                    // 1/15/2016 7:30:00 AM
                    string start = eventItem.Start.DateTime.ToString();
                    string end = eventItem.End.DateTime.ToString();                  

                    DateTime start_date = Functions.CreateDateTime(start);
                    DateTime end_date = Functions.CreateDateTime(end);                    

                    Console.WriteLine("{0} {1} {2} {3} {4}", eventItem.Summary + "\r\nDate: ", start_date.ToShortDateString() + "\r\nStart time: ", start_date.ToShortTimeString() + "\r\nEnd time: ", end_date.ToShortTimeString() + "\r\nEmail:", eventItem.Creator.Email.ToString());
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