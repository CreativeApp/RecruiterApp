﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitApp.Models
{
    public class PersonBasicInfo
    {
        public int UserKey { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public CodeValue Gender { get; set; }
    }
}
