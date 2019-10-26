using System;
using System.Collections.Generic;
using System.Text;
using WebScrapingRobot.Context;
using WebScrapingRobot.Model;
using WebScrapingRobot.Repository.Interface;

namespace WebScrapingRobot.Repository
{
    public class AgencyOfficeLocationRepository : IRepository<AgencyOfficeLocation>
    {
        public void Add(AgencyOfficeLocation model)
        {
            using (var context = new FBOContext())
            {
                context.AgencyOfficeLocations.Add(model);
                context.SaveChanges();
            }
        }

        public void AddRange(List<AgencyOfficeLocation> listModel)
        {
            using (var context = new FBOContext())
            {
                context.AgencyOfficeLocations.AddRange(listModel);
                context.SaveChanges();
            }
        }
    }
}
