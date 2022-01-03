using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using OSBB.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}