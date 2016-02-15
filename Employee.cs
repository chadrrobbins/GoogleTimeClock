using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTimeClock
{
    class Employee
    {
        private String firstName;
        private String lastName;
        private int totalHours;

        public Employee(String _firstName, String _lastName, int _totalHours)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.totalHours = _totalHours;
        }

        public String FirstName
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

        public String LastName
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
