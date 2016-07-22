using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_class_library;
using teste_web_api.DataAccess;
using teste_web_api.Models;

namespace teste_web_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<ValuesModel> Get()
        {
            var valuesDAO = new ValuesDAO();
            return valuesDAO.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ValuesModel Get(int id)
        {
            var valuesDAO = new ValuesDAO();
            return valuesDAO.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ValuesModel value)
        {
            var valuesDAO = new ValuesDAO();
            valuesDAO.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ValuesModel value, [FromQueryAttribute]string queryid)
        {
            //teste de import de class library
            var a = new Class1();
            var valuesDAO = new ValuesDAO();
            value.Id = id;
            valuesDAO.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var valuesDAO = new ValuesDAO();
            valuesDAO.Delete(new ValuesModel{Id = id});
        }
    }
}
