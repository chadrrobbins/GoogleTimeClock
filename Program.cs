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
using Excel = Microsoft.Office.Interop.Excel;

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
            string curFile = @"c:\Libraries\Documents\EmployeeHours.xls";
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

            Excel.Application xlApp = new Excel.Application();            
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
                    string email = eventItem.Creator.Email.ToString();
                    string start = eventItem.Start.DateTime.ToString();
                    string end = eventItem.End.DateTime.ToString();
                    string summary = eventItem.Summary.ToString();

                    DateTime start_date = Functions.CreateDateTime(start);
                    DateTime end_date = Functions.CreateDateTime(end);

                    string startDateString = start_date.ToShortDateString();
                    string startTimeString = start_date.ToShortTimeString();
                    string endTimeString = end_date.ToShortTimeString();

                    Console.WriteLine("{0} {1} {2} {3} {4}", summary + "\r\nDate: ", startDateString + "\r\nStart time: ", startTimeString + "\r\nEnd time: ", endTimeString + "\r\nEmail:", email);
                    Console.WriteLine("Total: " + (eventItem.End.DateTime - eventItem.Start.DateTime) + "\r\n");                    
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();

        }
    }
}