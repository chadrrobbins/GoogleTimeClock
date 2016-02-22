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

namespace GoogleTimeClock
{
    class Functions
    {
        //static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        //static string ApplicationName = "Google Calendar API .NET Quickstart";

        public void OpenFileStream(out UserCredential credential, string[] Scopes)
        {            
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        //public void CreateGoogleService(UserCredential credential, string ApplicationName)
        //{
        //    var service = new CalendarService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = ApplicationName,
        //    });
        //}        

        public void RunAppMenu()
        {
            
            Console.WriteLine("Select task to perform.");
            Console.WriteLine("1. Calculate employee hours.");
            Console.WriteLine("2. Exit.");
        }    

        public string GetTaskSelection()
        {
            string task;

            task = Console.ReadLine();
            ValidateTask(task);

            return task;
        }

        public int ValidateTask(string Task)
        {
            int isValid = 0;
            int value;

            while (isValid == 0)
            {
                if (int.TryParse(Task, out value) && value >= 1 && value <= 2)
                {
                    isValid = 1;
                }
                else
                {                    
                    Console.Clear();
                    Console.WriteLine("Please enter a number between 0 and 2.");
                    RunAppMenu();
                    GetTaskSelection();
                }
            }

            return isValid;
        }

        public void GetDateRange(out string startDate, out string endDate)
        {            
            Console.WriteLine("Please enter the starting date to use to calculate employee hours in the format YYYY-MM-DD.");
            startDate = Console.ReadLine();
            Console.WriteLine("Please enter the end date to use to calculate employee hours in the format YYYY-MM-DD.");
            endDate = Console.ReadLine();
        }        

        public void ExecuteTask(string Task)
        {
            switch (Convert.ToInt32(Task))
            {
                case 1:
                    //Display hours for all employees for two week time period.
                    
                    return;
                case 2:
                    Environment.Exit(0);
                    return;
            }
        }

        public DateTime CreateDateTime(string when)
        {
            string date;
            string time;
            string ampm;
            string chunk;

            if (when.Length != 0)
            {
                date = when.Substring(0, when.IndexOf(" ")).Trim();
                chunk = when.Substring(when.IndexOf(" ") + 1).Trim();
                time = chunk.Substring(0, chunk.IndexOf(" ")).Trim();
                ampm = chunk.Substring(chunk.IndexOf(" ") + 1).Trim();

                string[] dat = date.Split('/');

                string[] tim = time.Split(':');

                int d = Convert.ToInt32(dat[1]);
                int mon = Convert.ToInt32(dat[0]);
                int y = Convert.ToInt32(dat[2]);
                int h = Convert.ToInt32(tim[0]);
                int min = Convert.ToInt32(tim[1]);
                int s = Convert.ToInt32(tim[2]);

                if (ampm.Equals("PM") && h != 12)
                {
                    h += 12;
                }

                return new DateTime(y, mon, d, h, min, s);
            }

            return new DateTime(1, 1, 1, 0, 0, 0);
        }

        
    }
}
