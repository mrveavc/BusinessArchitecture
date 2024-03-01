using System;
using Core.Repository;
using Entities.Models;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}

