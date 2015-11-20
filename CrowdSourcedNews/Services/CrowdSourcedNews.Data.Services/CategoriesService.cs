using CrowdSourcedNews.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSourcedNews.Models;

namespace CrowdSourcedNews.Data.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> All()
        {
            var result = this.categories.All();

            return result;
        }
    }
}
