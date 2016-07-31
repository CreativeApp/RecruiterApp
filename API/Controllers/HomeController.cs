using RecruitApp.Models;
using RecruitApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RecruitApp.Controllers
{
   // [Authorize]
    [RoutePrefix("dashboard")]
    public class HomeController : ApiController
    {
        [Route("{userKey}/GetApplicants")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Applicant>))]
        public async Task<IHttpActionResult> GetApplicants(int userKey)
        {
            var applicants = ApplicantUtility.GetApplicants();
            return this.Ok(applicants);
        }
    }
}
