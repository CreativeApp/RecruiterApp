using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitApp.Models
{
    public class Address
    {
        public int? AddressKey { get; set; }

        public string AddressLine1 { get; set; }

        public string LandMark { get; set; }

        public CodeValue City { get; set; }

        public CodeValue State { get; set; }

        public CodeValue Country { get; set; }


    }
}
