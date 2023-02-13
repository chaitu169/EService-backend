using Esevice2._0.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esevice2._0.data
{
    public interface IServicemanRepository
    {
        Task<ServiceMan> FindById(int id);
        Task<IEnumerable<ServiceMan>> FindByCity(string city);
        Task<IEnumerable<ServiceMan>> FindByCategory(string category);

        Task<bool> UpdateServicemanDetails(ServiceMan s);

        Task<bool> DeleteServiceman(ServiceMan s);
        Task<bool> AddNewServiceman(ServiceMan s);
        Task<IEnumerable<ServiceMan>> FindAll();
    }
}
