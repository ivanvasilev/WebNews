using CrowdSourcedNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcedNews.Data.Services.Contracts
{
    public interface ICommentsService
    {
        IQueryable<Comment> All();

        int Add(Comment model, string username);

        int SaveChanges();
    }
}
