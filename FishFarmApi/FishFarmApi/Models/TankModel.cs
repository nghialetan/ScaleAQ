using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishFarmApi.Models
{
    public class TankModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<FishModel> Fishes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}