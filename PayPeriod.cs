using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTimeClock
{
    class PayPeriod
    {
        private string firstName;
        private string lastName;
        private string email;
        private double totalHours;

        public PayPeriod(string _firstName, string _lastName, string _email, double _totalHours)
        {
            firstName = _firstName;
            lastName = _lastName;
            email = _email;
            totalHours = _totalHours;
        }

        public string FirstName
        {
            get 
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
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

    }
}
