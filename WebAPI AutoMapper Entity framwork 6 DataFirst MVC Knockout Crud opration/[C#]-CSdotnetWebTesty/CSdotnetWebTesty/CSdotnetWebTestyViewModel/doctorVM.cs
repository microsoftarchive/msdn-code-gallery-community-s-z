using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSdotnetWebTestyViewModel
{
    public class doctorVM
    {
        public int id { get; set; }


        public int? user_id { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
       // public DateTime? created_date { get; set; }
       // public DateTime? update_date { get; set; }
        // public virtual user user { get; set; }
    }
}
