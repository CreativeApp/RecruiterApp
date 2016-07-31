using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitApp.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CodeValue Technology { get; set; }

        public CodeValue Role { get; set; }

        public int ExpYears { get; set; }

        public int ExpMonths { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public Audit Created { get; set; }

        public Audit Updated { get; set; }
    }
}