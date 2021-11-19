using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yixuan.ApplicationCore.Models
{
    public class ServiceCreateModel
    {
        public ServiceCreateModel()
        {
            ServiceDate = DateTime.Now;
        }
        public int RoomNo { get; set; }
        public string SDesc { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
