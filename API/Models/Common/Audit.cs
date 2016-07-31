using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitApp.Models
{
    public class Audit
    {
        public DateTime AuditOn { get; set; }

        public PersonBasicInfo Person { get; set; }
    }
}
