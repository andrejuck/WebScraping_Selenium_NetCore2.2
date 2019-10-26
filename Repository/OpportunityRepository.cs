using System;
using System.Collections.Generic;
using System.Text;
using WebScrapingRobot.Context;
using WebScrapingRobot.Model;
using WebScrapingRobot.Repository.Interface;

namespace WebScrapingRobot.Repository
{
    public class OpportunityRepository : IRepository<Opportunity>
    {
        public void Add(Opportunity model)
        {
            using (var context = new FBOContext())
            {
                context.Opportunities.Add(model);
                context.SaveChanges();
            }
        }

        public void AddRange(List<Opportunity> listModel)
        {
            using (var context = new FBOContext())
            {
                context.Opportunities.AddRange(listModel);
                context.SaveChanges();
            }
        }
    }
}
