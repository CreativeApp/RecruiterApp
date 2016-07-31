using RecruitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitApp.StubHrlper
{
    public class StubHelper
    {
        public static List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>()
            {
                new Applicant()
                {
                    ApplicantId = 1,
                    Address = new Address()
                    {
        
                    },
                    Email = "manju@gmail.com",
                    ExpMonths=7,
                    ExpYears=5,
                    FirstName="Manju",
                    LastName="Jeorge",
                    PhoneNumber=1234567890,
                    Role=new CodeValue()
                    {

                    },
                    Technology=new CodeValue()
                    {

                    },
                    Created = new Audit()
                    {

                    },
                    Updated= new Audit()
                    {

                    }
                }
            };

            return applicants;
        }
    }
}