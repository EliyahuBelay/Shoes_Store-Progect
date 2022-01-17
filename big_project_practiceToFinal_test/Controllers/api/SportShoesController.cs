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
    public class SportShoesController : ApiController
    {
        string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=ShoesShopDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        //private SqlConnection Some()//helping function to to save code writing;
        //{
        //   using (SqlConnection connection = new SqlConnection(stringConnection))
        //    {
        //        return connection;
        //    }
        //}
        // GET: api/SportShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<SportShoes> listOfShoes = new List<SportShoes>();
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = @"SELECT * FROM SportShoes";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dataFromDb = cmd.ExecuteReader();
                    if (dataFromDb.HasRows)
                    {
                        while (dataFromDb.Read())
                        {
                            listOfShoes.Add(new SportShoes(dataFromDb.GetInt32(0), dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetInt32(3), dataFromDb.GetInt32(4)));
                        }
                        connection.Close();
                        return Ok(new { listOfShoes });
                    }
                    return NotFound();
                }
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

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM SportShoes WHERE {id} = Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dataFromDb = cmd.ExecuteReader();
                    if (dataFromDb.HasRows)
                    {
                        SportShoes shoes = new SportShoes(dataFromDb.GetInt32(0), dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetInt32(3), dataFromDb.GetInt32(4));
                        connection.Close();
                        return Ok(new { shoes });
                    }
                    return NotFound();
                }
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

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody] SportShoes shoes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $@"INSERT INTO SportShoes (CompanyName,ModelShoes,Size,Price) VALUES ('{shoes.CompanyName}','{shoes.ModelShoes}',{shoes.Size},{shoes.Price})";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rowsEffected = cmd.ExecuteNonQuery();
                    if(rowsEffected > 0)
                    {
                        return Ok($"{rowsEffected} rows effected");
                    }
                    else if(rowsEffected == 0)
                    {
                        return BadRequest("the action falid to add");
                    }
                    return BadRequest("there is a problem with the action");
                }
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

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody] SportShoes shoes)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $@"UPDATE SportShoes SET CompanyName = '{shoes.CompanyName}',CompanyName = '{shoes.ModelShoes}',CompanyName = {shoes.Size},CompanyName = {shoes.Price}";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    int rowEffected = cmd.ExecuteNonQuery();
                    if (rowEffected > 0)
                    {
                        return Ok($"{rowEffected} rows effected");
                    }
                    else if (rowEffected == 0)
                    {
                        return BadRequest("the action falid to add");
                    }
                    return BadRequest("there is a problem with the action");
                }
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

        // DELETE: api/SportShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $@"DELETE FROM SportShoes WHERE Id = {id}";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    int rowsEffected = cmd.ExecuteNonQuery();
                    if(rowsEffected > 0)
                    {
                        return Ok($"{rowsEffected} rows effected");
                    }
                    else if (rowsEffected == 0)
                    {
                        return BadRequest("the action falid to add");
                    }
                    return BadRequest("there is a problem with the action");
                }
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
