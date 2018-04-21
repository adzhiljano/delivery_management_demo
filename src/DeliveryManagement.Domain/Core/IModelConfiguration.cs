using Microsoft.EntityFrameworkCore;

namespace DeliveryManagement.Domain.Core
{
    public interface IModelConfiguration
    {
        void AddEntityTypeModel(ModelBuilder builder);
    }
}
