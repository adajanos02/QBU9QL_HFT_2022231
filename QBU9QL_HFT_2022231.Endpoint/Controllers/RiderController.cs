using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;


namespace QBU9QL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {

        IRiderLogic logic;
        public RiderController(IRiderLogic logic)
        {
                this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Riders> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Riders Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Riders value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Riders value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
