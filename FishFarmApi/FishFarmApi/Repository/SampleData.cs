using FishFarmApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishFarmApi.Repository
{
    public static class SampleData
    {
        public static List<TankModel> GetAllTanks()
        {
            return new List<TankModel>
            {
                new TankModel { ID=1, Name = "Tank 1", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=2, Name = "Tank 2", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=3, Name = "Tank 3", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=4, Name = "Tank 4", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=5, Name = "Tank 5", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=6, Name = "Tank 6", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=7, Name = "Tank 7", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=8, Name = "Tank 8", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=9, Name = "Tank 9", DateCreated = DateTime.Now, DateModified = DateTime.Now},
                new TankModel { ID=10, Name = "Tank 10", DateCreated = DateTime.Now, DateModified = DateTime.Now}
            };
        }
        public static List<FishModel> AllFishes()
        {
            return new List<FishModel>
            {
                new FishModel { ID=1, TankID = 2, Specie = "Specie A", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=2, TankID = 4, Specie = "Specie B", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=3, TankID = 1, Specie = "Specie C", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=4, TankID = 6, Specie = "Specie D", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=5, TankID = 1, Specie = "Specie E", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=6, TankID = 8, Specie = "Specie F", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=7, TankID = 3, Specie = "Specie G", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishModel { ID=8, TankID = 3, Specie = "Specie H", DateCreated = DateTime.Now, DateModified= DateTime.Now},
            };
        }
        public static List<TankModel> GetAllTanksWithFishes()
        {
            return new List<TankModel>
            {
                new TankModel
                {
                    ID = 1, Name = "Tank 1", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>
                    {
                        new FishModel { ID=1, TankID = 1, Specie = "Specie A", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                        new FishModel { ID=4, TankID = 1, Specie = "Specie D", DateCreated = DateTime.Now, DateModified= DateTime.Now}
                    }
                },
                new TankModel
                {
                    ID = 2, Name = "Tank 2", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>
                    {
                        new FishModel { ID=3, TankID = 2, Specie = "Specie C", DateCreated = DateTime.Now, DateModified= DateTime.Now}
                    }
                },
                new TankModel
                {
                    ID = 3, Name = "Tank 3", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>()
                },
                new TankModel
                {
                    ID = 4, Name = "Tank 4", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>()
                },
                new TankModel
                {
                    ID = 5, Name = "Tank 5", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>
                    {
                        new FishModel { ID=2, TankID = 5, Specie = "Specie B", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                        new FishModel { ID=7, TankID = 5, Specie = "Specie G", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                        new FishModel { ID=5, TankID = 5, Specie = "Specie E", DateCreated = DateTime.Now, DateModified= DateTime.Now}
                    }
                },
                new TankModel
                {
                    ID = 6, Name = "Tank 6", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>
                    {
                        new FishModel { ID=9, TankID = 6, Specie = "Specie I", DateCreated = DateTime.Now, DateModified= DateTime.Now}
                    }
                },
                new TankModel
                {
                    ID = 7, Name = "Tank 7", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>
                    {
                        new FishModel { ID=6, TankID = 7, Specie = "Specie F", DateCreated = DateTime.Now, DateModified= DateTime.Now},
                        new FishModel { ID=8, TankID = 7, Specie = "Specie H", DateCreated = DateTime.Now, DateModified= DateTime.Now}
                    }
                },
                new TankModel
                {
                    ID = 8, Name = "Tank 8", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>()
                },
                new TankModel
                {
                    ID = 9, Name = "Tank 9", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>()
                },
                new TankModel
                {
                    ID = 10, Name = "Tank 10", DateCreated = DateTime.Now, DateModified = DateTime.Now, Fishes = new List<FishModel>()
                }
            };
        }

        public static List<FishMovementModel> GetAllFishMovements()
        {
            return new List<FishMovementModel>
            {
                new FishMovementModel { ID = 1, FishId = 1, MovedFromTankId = 1, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 2, FishId = 6, MovedFromTankId = 3, MovedToTankId = 7, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 3, FishId = 3, MovedFromTankId = 10, MovedToTankId = 2, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 4, FishId = 2, MovedFromTankId = 4, MovedToTankId = 5, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 5, FishId = 6, MovedFromTankId = 1, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 6, FishId = 4, MovedFromTankId = 8, MovedToTankId = 3, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 7, FishId = 7, MovedFromTankId = 2, MovedToTankId = 6, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 8, FishId = 1, MovedFromTankId = 1, MovedToTankId = 4, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 9, FishId = 4, MovedFromTankId = 9, MovedToTankId = 3, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 10, FishId = 3, MovedFromTankId = 10, MovedToTankId = 2, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 11, FishId = 1, MovedFromTankId = 2, MovedToTankId = 5, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 12, FishId = 6, MovedFromTankId = 4, MovedToTankId = 1, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 13, FishId = 1, MovedFromTankId = 6, MovedToTankId = 7, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 14, FishId = 5, MovedFromTankId = 9, MovedToTankId = 1, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 15, FishId = 10, MovedFromTankId = 9, MovedToTankId = 4, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 16, FishId = 1, MovedFromTankId = 1, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 17, FishId = 10, MovedFromTankId = 6, MovedToTankId = 8, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 18, FishId = 4, MovedFromTankId = 10, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 19, FishId = 9, MovedFromTankId = 1, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 20, FishId = 8, MovedFromTankId = 2, MovedToTankId = 5, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 21, FishId = 8, MovedFromTankId = 3, MovedToTankId = 6, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 22, FishId = 7, MovedFromTankId = 9, MovedToTankId = 8, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 23, FishId = 4, MovedFromTankId = 3, MovedToTankId = 10, DateCreated = DateTime.Now, DateModified= DateTime.Now},
                new FishMovementModel { ID = 24, FishId = 12, MovedFromTankId = 5, MovedToTankId = 9, DateCreated = DateTime.Now, DateModified= DateTime.Now},
            };
        }
    }
}