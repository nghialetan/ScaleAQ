using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishFarmApi.Models
{
    public class FishModel
    {
        public int ID { get; set; }
        public int TankID { get; set; }
        public string Specie { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}