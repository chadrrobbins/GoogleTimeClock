using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTimeClock
{
    class Job
    {
        private String contractorName;
        private String jobTitle;
        private String jobLocation;
        private int totalHours;

        public Job(String _contractorName, String _jobTitle, String _jobLocation, int _totalHours)
        {
            this.contractorName = _contractorName;
            this.jobTitle = _jobTitle;
            this.jobLocation = _jobLocation;
            this.totalHours = _totalHours;
        }

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

        public int TotalHours
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
    }
}
