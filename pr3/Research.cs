﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    class Research
    {
        public List<ByInterestArea> byInterestArea { get; set; }
        public List<ByFaculty> byFaculty { get; set; }
    }

    public class ByInterestArea
    {
        public string areaName { get; set; }
        public List<string> citations { get; set; }
    }

    public class ByFaculty
    {
        public string facultyName { get; set; }
        public string username { get; set; }
        public List<string> citations { get; set; }
    }
}
