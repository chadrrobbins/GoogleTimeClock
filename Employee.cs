using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTimeClock
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private ArrayList jobs;
        private string email;
        private double totalHours;
        
        public Employee(string _email, double _totalHours)
        {
            email = _email;
            totalHours = _totalHours;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public double TotalHours
        {
            get
            {
                return totalHours;
            }

            set
            {
                totalHours = value;
            }

        }

        public void AddJob(Job job)
        {
            jobs.Add(job);
        }

        public double GetTotalDailyHours(DateTime start, DateTime end)
        {
            double jobHours = 0;

            foreach (Job job in jobs) 
            {
                if (!(job.JobWorkDayStart < start) && !(job.JobWorkDayEnd > end))
                {
                    jobHours += job.TotalHours;
                }
            }

            return jobHours;
        }
    }
}
