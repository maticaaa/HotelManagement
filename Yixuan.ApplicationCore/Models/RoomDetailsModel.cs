using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yixuan.ApplicationCore.Models
{
    public class RoomDetailsModel
    {
        
        public int Id { get; set; }
        public int RTCode { get; set; }
        public bool Status { get; set; }
        public List<ServiceResponseModel> Services { get; set; }

        public RoomDetailsModel()
        {
            Services = new List<ServiceResponseModel>();
        }
    }
}
