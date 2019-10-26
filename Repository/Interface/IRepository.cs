using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapingRobot.Repository.Interface
{
    public interface IRepository<T>
    {
        void Add(T model);
        void AddRange(List<T> listModel);
    }
}
