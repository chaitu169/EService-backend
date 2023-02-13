using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esevice2._0.dtos
{
    public class ServicemanUpdateDto
    {
        public string MobileNumber { get; set; }
        public string City { get; set; }

        public string Category { get; set; }

        public decimal BasicInspection { get; set; }
        public DateTime Experience { get; set; }

        public bool availailty { get; set; }
    }
}
