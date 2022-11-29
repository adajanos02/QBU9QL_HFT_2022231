using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Logic.Classes;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMotoLogic logic;
        IRiderLogic rLogic;

        public StatController(IMotoLogic logic, IRiderLogic rLogic)
        {
            this.logic = logic; 
            this.rLogic = rLogic;
        }
        [HttpGet]
        public IEnumerable<object> GetMaxSoldCompany()
        {
            return this.logic.ThisModelHasTheBestBrand();
        }
        [HttpGet]
        public IEnumerable<object> GetCompanyOlderThan70()
        {
            return this.logic.CompanyOlderThan70();
        }
        [HttpGet]
        public IEnumerable<object> GetHasMoreThan800ccmMoto()
        {
            return this.rLogic.HasMoreThan800ccmMoto();
        }
        [HttpGet]
        public IEnumerable<object> HasAprilia()
        {
            return this.rLogic.HasAprilia();
        }
        [HttpGet]
        public IEnumerable<object> HasETZModel()
        {
            return this.rLogic.HasETZModel();
        }

    }
}
