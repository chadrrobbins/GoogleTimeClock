using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTimeClock
{
    class Job
    {
        private string contractorName;
        private string jobTitle;
        private string jobLocation;
        private double totalHours;
        private DateTime jobWorkDailyStart;  // Date and time the job is started on a particular day
        private DateTime jobWorkDailyEnd;    // Date and time the job is ended on a particular day

        // Constructor
        public Job(string _contractorName, string _jobTitle, string _jobLocation, DateTime start, DateTime end)
        {
            contractorName = _contractorName;
            jobTitle = _jobTitle;
            jobLocation = _jobLocation;
            jobWorkDailyStart = start;
            jobWorkDailyEnd = end;
        }

        // Property Declarations
        public String ContractorName
        {
            get
            {
                return this.contractorName;
            }
            set
            {
                this.contractorName = value;
            }
        }

        public String JobTitle
        {
            get
            {
                return this.jobTitle;
            }
            set
            {
                this.jobTitle = value;
            }
        }

        public String JobLocation
        {
            get
            {
                return this.jobLocation;
            }
            set
            {
                this.jobLocation = value;
            }
        }

        public double TotalHours
        {
            get
            {
                return this.totalHours;
            }
            set
            {
                this.totalHours = value;
            }
        }

        public DateTime JobWorkDayStart
        {
            get
            {
                return jobWorkDailyStart;
            }

            set
            {
                jobWorkDailyStart = value;
            }
        }

        public DateTime JobWorkDayEnd
        {
            get
            {
                return jobWorkDailyEnd;
            }

            set
            {
                jobWorkDailyEnd = value ;
            }
        }

        // Public Method Declarations

        // Private Method Declarations
        private void CalcTotalHours()
        {
            totalHours = (jobWorkDailyEnd - jobWorkDailyStart).TotalDays;
        }
    }
}
