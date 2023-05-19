using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;
using Microsoft.AspNetCore.SignalR;
using QBU9QL_HFT_2022231.Endpoint.Services;

namespace QBU9QL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {

        IRiderLogic logic;
        IHubContext<SignalRHub> hub;
        public RiderController(IRiderLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Rider> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Rider Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Rider value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RiderCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Rider value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RiderUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var riderToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RiderDeleted", riderToDelete);
        }
    }
}
