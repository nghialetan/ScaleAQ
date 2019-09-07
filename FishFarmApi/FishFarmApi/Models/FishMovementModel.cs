using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishFarmApi.Models
{
    public class FishMovementModel
    {
        public int ID { get; set; }
        public int FishId { get; set; }
        public int MovedFromTankId { get; set; }
        public int MovedToTankId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}