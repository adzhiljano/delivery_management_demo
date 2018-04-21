using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DeliveryManagement.Domain.Core
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
