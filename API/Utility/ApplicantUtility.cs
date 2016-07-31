using RecruitApp.Models;
using RecruitApp.StubHrlper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitApp.Utility
{
    public class ApplicantUtility
    {
        public static IEnumerable<Applicant> GetApplicants()
        {
            return StubHelper.GetApplicants();
        }
    }
}