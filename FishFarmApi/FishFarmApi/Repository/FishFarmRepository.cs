using FishFarmApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishFarmApi.Repository
{
    public class FishFarmRepository
    {
        public List<TankModel> GetAllTanks()
        {
            return SampleData.GetAllTanks();
        }
        public List<FishModel> GetFishesByTankId(int tankId)
        {
            var allFishes = SampleData.AllFishes();
            return allFishes.Where(f => f.TankID == tankId).ToList();
        }
        public FishModel GetFishById(int id)
        {
            var theFish = SampleData.AllFishes().Where(f => f.ID == id).FirstOrDefault();
            return theFish;
        }

        public FishModel UpdateFish(int id, FishModel model, out string errorMsg)
        {
            var theFish = GetFishById(id);
            if (theFish == null)
            {
                errorMsg = "fish not found";
                throw new Exception(errorMsg);
            }
            theFish.DateModified = DateTime.Now;
            theFish.Specie = model.Specie;

            // fish is assumed to be saved at this point.

            errorMsg = "";
            return theFish;
        }
        public List<TankModel> GetAllowedDestinationTanks(int fishId)
        {
            // get the tankId of this fish
            int fishTankId = GetTankIdForFish(fishId);
            // we can't move a fish to the same tank where it is already
            var possibleTanks = SampleData.GetAllTanksWithFishes().Where(t => t.ID != fishTankId).ToList();
            if (possibleTanks.Any())
            {
                // maximum tank capacity is 3
                var allowedTanks = possibleTanks.Where(t => t.Fishes.Count < 3).ToList();
                return allowedTanks;
            }
            return new List<Models.TankModel>();
        }
        public List<FishMovementModel> GetFishMovements(int fishId)
        {
            List<FishMovementModel> allMovements = SampleData.GetAllFishMovements();
            var movtHistory = allMovements.Where(m => m.FishId == fishId).ToList();
            return movtHistory;
        }
        public FishModel MoveFish(int fishId, int toTankId)
        {
            var allowedDestinationTanks = GetAllowedDestinationTanks(fishId);
            if (allowedDestinationTanks.Any(t => t.ID == toTankId))
            {
                var theFish = GetFishById(fishId);
                theFish.TankID = toTankId;
                // save changes
                return theFish;
            }
            else
                throw new Exception("Fish cannot be moved to the specified tank!");
        }
        private int GetTankIdForFish(int fishId)
        {
            var fishTank = SampleData.GetAllTanksWithFishes().Where(t => t.Fishes.Any(f => f.ID == fishId)).FirstOrDefault();
            return fishTank.ID;
        }
    }
}