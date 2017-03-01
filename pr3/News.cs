using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    class News
    {
        public List<Year> year { get; set; }
        public List<Quarter> quarter { get; set; }
        public List<Month> month { get; set; }
        public List<Older> older { get; set; }
    }

    public class Year
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Quarter
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Month
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}

