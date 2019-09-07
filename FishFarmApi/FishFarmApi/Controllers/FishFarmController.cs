using FishFarmApi.Models;
using FishFarmApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FishFarmApi.Controllers
{
    /// <summary>
    /// Endpoints to manage Fish and tanks of a fish farm
    /// </summary>
    [RoutePrefix("api/v1/fishfarm")]
    public class FishFarmController : ApiController
    {
        FishFarmRepository repo = null;
        public FishFarmController()
        {
            repo = new FishFarmRepository();
        }

        // GET: api/v1/fishfarm/tanks
        /// <summary>
        /// Get all tanks
        /// </summary>
        /// <returns></returns>
        [Route("tanks")]
        [HttpGet]
        public IHttpActionResult GetTanks()
        {
            List<TankModel> allTanks = repo.GetAllTanks();
            return Ok(allTanks);
        }

        // GET: api/v1/fishfarm/tanks/3/fishes
        /// <summary>
        /// Get fishes by tankId
        /// </summary>
        /// <param name="tankId"></param>
        /// <returns></returns>
        [Route("tank/{tankId}/fishes")]
        [HttpGet]
        public IHttpActionResult GetFishesForTank([FromUri] int tankId)
        {
            return Ok(repo.GetFishesByTankId(tankId));
        }

        // GET: api/v1/fishfarm/fishes/7
        /// <summary>
        /// Get fish by fishId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("fishes/{id}")]
        [HttpGet]
        public IHttpActionResult GetFishById([FromUri] int id)
        {
            FishModel fish = repo.GetFishById(id);
            return Ok(fish);
        }

        // PUT: api/v1/fishfarm/fish/update/5
        /// <summary>
        /// Update a fish
        /// For testing purpose, ONLY the specie and dateModified will be updated
        /// </summary>
        /// <param name="fish"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("fish/update/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateFish([FromBody] FishModel fish, int id)
        {
            var fishToUpdate = repo.GetFishById(id);
            if (fish == null)
            {
                return NotFound();
            }

            string errorMsg = string.Empty;
            try
            {
                var updatedFish = repo.UpdateFish(id, fish, out errorMsg);
                return Ok(updatedFish);
            }
            catch (Exception)
            {
                return BadRequest(errorMsg);
            }
        }

        // GET: api/v1/fishfarm/destination-tanks/4
        /// <summary>
        /// Get all allowed destination tanks for a fish
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        [Route("destination-tanks/{fishId}")]
        [HttpGet]
        public IHttpActionResult GetAllowedDestinationTanks([FromUri] int fishId)
        {
            var fishToCheck = repo.GetFishById(fishId);
            if (fishToCheck == null)
            {
                return NotFound();
            }
            List<TankModel> destinations = repo.GetAllowedDestinationTanks(fishId);
            return Ok(destinations);
        }

        // GET: api/v1/fishfarm/movements/3
        /// <summary>
        /// Get all movements a fish has gone through in its lifetime
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        [Route("movements/{fishId}")]
        [HttpGet]
        public IHttpActionResult GetMovementHistory([FromUri] int fishId)
        {
            List<FishMovementModel> movementHistory = repo.GetFishMovements(fishId);
            return Ok(movementHistory);
        }

        // GET: api/v1/fishfarm/fish/move/4/9
        /// <summary>
        /// Move a fish from its tank to another tank
        /// </summary>
        /// <param name="fishId"></param>
        /// <param name="toTankId"></param>
        /// <returns></returns>
        [Route("fish/move/{fishId}/{toTankId}")]
        [HttpGet]
        public IHttpActionResult MoveFIsh([FromUri] int fishId, int toTankId)
        {
            try
            {
                var response = repo.MoveFish(fishId, toTankId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

