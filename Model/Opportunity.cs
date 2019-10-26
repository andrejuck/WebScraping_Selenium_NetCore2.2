using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapingRobot.Model
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SolicitationNumber { get; set; }
        public string Category { get; set; }
    }
}
