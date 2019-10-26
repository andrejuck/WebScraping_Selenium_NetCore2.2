using System;
using System.Collections.Generic;
using System.Text;
using WebScrapingRobot.Context;
using WebScrapingRobot.Model;
using WebScrapingRobot.Repository.Interface;

namespace WebScrapingRobot.Repository
{
    public class PostRepository : IRepository<Post>
    {
        public void Add(Post model)
        {
            using (var context = new FBOContext())
            {
                context.Posts.Add(model);
                context.SaveChanges();
            }
        }

        public void AddRange(List<Post> listModel)
        {
            using (var context = new FBOContext())
            {
                context.Posts.AddRange(listModel);
                context.SaveChanges();
            }
        }
    }
}
