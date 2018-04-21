using System.Collections.Generic;

namespace DeliveryManagement.Domain.Core
{
    public class PagingDO<T> where T: class
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
