using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;
using Microsoft.AspNetCore.SignalR;
using QBU9QL_HFT_2022231.Endpoint.Services;
using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QBU9QL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        IMotoLogic logic;
        IHubContext<SignalRHub> hub;

        public MotoController(IMotoLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Moto> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Moto Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Moto value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MotoCreated", value);
        }

        
        [HttpPut]
        public void Update([FromBody] Moto value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("MotoUpdated", value);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var motoToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("MotoDeleted", motoToDelete);
        }
    }
}
