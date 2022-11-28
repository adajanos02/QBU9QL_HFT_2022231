using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QBU9QL_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        IMotoLogic logic;

        public MotoController(IMotoLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Motorcycle> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Motorcycle Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Motorcycle value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut]
        public void Update([FromBody] Motorcycle value)
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
