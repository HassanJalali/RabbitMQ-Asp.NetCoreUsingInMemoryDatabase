using Microsoft.EntityFrameworkCore;
using ProducerApplication.Models;

namespace ProducerApplication.Data
{
    public interface IOrderDbContext
    {
        DbSet<Order> Order { get; set; }

        Task<int> SaveChangesAsync();
    }
}
