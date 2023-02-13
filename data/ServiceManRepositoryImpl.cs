using Esevice2._0.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esevice2._0.data
{
    public class ServiceManRepositoryImpl: IServicemanRepository
    {
        List<ServiceMan> servicemanList = new List<ServiceMan>() {


            new ServiceMan { ServicemanId = 1, MobileNumber = "1234567890", City = "hyd", Category = "electrician", BasicInspection = 120.0M, Experience = 3, availailty = true },
            new ServiceMan { ServicemanId = 2, MobileNumber = "1234567890", City = "mubai", Category = "plumber", BasicInspection = 240.0M, Experience = 2, availailty = true },

        };


        public Task<bool> AddNewServiceman(ServiceMan s)
        {
            return Task.Run(() =>
            {
                if (s != null && !servicemanList.Exists(x => x.ServicemanId == s.ServicemanId))
                {
                    servicemanList.Add(s);
                    return true;
                }

                return false;
            });
        }

        public Task<bool> DeleteServiceman(ServiceMan s)
        {
            bool result = servicemanList.Remove(s);
            return Task.Run(() => result);
        }

        public Task<IEnumerable<ServiceMan>> FindByCity(string city)
        {
            return Task.Run<IEnumerable<ServiceMan>>(() => servicemanList.FindAll(x => x.City == city));
        }
        public Task<IEnumerable<ServiceMan>> FindByCategory(string category)
        {
            return Task.Run<IEnumerable<ServiceMan>>(() => servicemanList.FindAll(x => x.Category == category));
        }

        public Task<ServiceMan> FindById(int id)
        {
            return Task.Run<ServiceMan>(() => servicemanList.Find(x => x.ServicemanId == id));
        }
        public Task<IEnumerable<ServiceMan>> FindAll()
        {
            return Task.Run<IEnumerable<ServiceMan>>(() => servicemanList);
        }

        public Task<bool> UpdateServicemanDetails(ServiceMan s)
        {
            bool isFound = false;
            foreach (var item in servicemanList)
            {
                if (item.ServicemanId == s.ServicemanId)
                {
                    item.MobileNumber = s.MobileNumber;
                    item.Category = s.Category;
                    item.City = s.City;
                    item.BasicInspection = s.BasicInspection;
                    item.Experience = s.Experience;

                    break;
                }
            }
            return Task.Run(() => isFound);

        }
    
}
}
