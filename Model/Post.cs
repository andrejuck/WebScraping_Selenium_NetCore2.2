using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapingRobot.Model
{
    public class Post
    {
        public int Id { get; set; }
        public Opportunity Opportunity { get; set; }
        public AgencyOfficeLocation AgencyOfficeLocation { get; set; }
        public string Type { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
