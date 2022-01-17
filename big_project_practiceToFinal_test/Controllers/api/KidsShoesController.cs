using big_project_practiceToFinal_test.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace big_project_practiceToFinal_test.Controllers.api
{
    public class KidsShoesController : ApiController
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=ShoesShopDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        ShoesShopDBDataContext dataContex = new ShoesShopDBDataContext(stringConnection);
        // GET: api/KidsShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<KidsShoe> listOfShoes = dataContex.KidsShoes.ToList();
                return Ok(new { listOfShoes });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/KidsShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                KidsShoe shoes = dataContex.KidsShoes.First(item => item.Id == id);
                return Ok(new {shoes});
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/KidsShoes
        public IHttpActionResult Post([FromBody]KidsShoe shoes)
        {
            try
            {
                dataContex.KidsShoes.InsertOnSubmit(shoes);
                dataContex.SubmitChanges();
                return Get();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/KidsShoes/5
        public IHttpActionResult Put(int id, [FromBody]KidsShoe shoesToUpdate)
        {
            try
            {
                KidsShoe shoes =  dataContex.KidsShoes.First(item => item.Id == id);
                if (shoes == null) { return Ok("there is a no such as id"); }
                shoes.CompanyName = shoesToUpdate.CompanyName;
                shoes.Material = shoesToUpdate.Material;
                shoes.IfExeist = shoesToUpdate.IfExeist;
                shoes.Size = shoesToUpdate.Size;
                shoes.Price = shoesToUpdate.Price;
                dataContex.SubmitChanges();
                return Get();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/KidsShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                KidsShoe shoes = dataContex.KidsShoes.First(item => item.Id == id);
                if(shoes == null) { return Ok("there is no such as id"); }
                dataContex.KidsShoes.DeleteOnSubmit(shoes);
                dataContex.SubmitChanges();
                return Get();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
