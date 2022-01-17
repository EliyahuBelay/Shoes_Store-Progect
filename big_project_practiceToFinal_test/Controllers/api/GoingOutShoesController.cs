using big_project_practiceToFinal_test.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace big_project_practiceToFinal_test.Controllers.api
{
    public class GoingOutShoesController : ApiController
    {
        ShoesShopDB dbContex = new ShoesShopDB();
        // GET: api/GoingOutShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<GoingOutShoes> ListOfShoes = dbContex.GoingOutShoeses.ToList();
                if (ListOfShoes == null) return Ok("data base is empty");
                return Ok(new { ListOfShoes });
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/GoingOutShoes/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                GoingOutShoes oneShoes = await dbContex.GoingOutShoeses.FindAsync(id);
                if (oneShoes == null) return NotFound();
                return Ok(new {oneShoes});
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/GoingOutShoes
        public async Task<IHttpActionResult> Post([FromBody]GoingOutShoes someShoes)
        {
            try
            {
                dbContex.GoingOutShoeses.Add(someShoes);
                await dbContex.SaveChangesAsync();
                return Get();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/GoingOutShoes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]GoingOutShoes updateShoes)
        {
            try
            {
                GoingOutShoes shoesToFind = await dbContex.GoingOutShoeses.FindAsync(id);
                shoesToFind.CompanyName = updateShoes.CompanyName;
                shoesToFind.Gender = updateShoes.Gender;
                shoesToFind.HeelOn = updateShoes.HeelOn;
                shoesToFind.IfExist = updateShoes.IfExist;
                shoesToFind.Size = updateShoes.Size;
                shoesToFind.Price = updateShoes.Price;
                if(updateShoes != null)
                {
                await dbContex.SaveChangesAsync();
                    return Get();
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/GoingOutShoes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                GoingOutShoes shoesToDelete =  await dbContex.GoingOutShoeses.FindAsync(id);
                if(shoesToDelete != null)
                {
                    dbContex.GoingOutShoeses.Remove(shoesToDelete);
                    await dbContex.SaveChangesAsync();
                    return Get();
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
