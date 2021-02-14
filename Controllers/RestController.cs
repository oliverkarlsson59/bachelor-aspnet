using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bachelorproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
    public class RestController : ControllerBase
    {
        private DbHandler dbHandler;
        public RestController() {
        }


        [HttpGet]
        [Route("user/{id}/comment")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
        //Usedfor fetching a single row with SQL JOIN
        public async Task<IActionResult> firstCommentByUser(int id){
            dbHandler = new DbHandler();
            Comment result = await dbHandler.getCommentByJoinUserId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("user/{id}/comments/{limit}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
        //Used for fetching multiple rows with SQL JOIN
        public async Task<IActionResult> commentsByUser(int id, int limit){
            dbHandler = new DbHandler();
            List<Comment> result = await dbHandler.getCommentsByJoinUserId(id, limit);
            return Ok(result);
        }

        [HttpGet]
        [Route("comment/{id}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
        //Usedfor fetching a single row without any SQL JOIN
        public async Task<IActionResult> commentById(int id){
            dbHandler = new DbHandler();
            Comment result = await dbHandler.getCommentById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("comments/{limit}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
        //Used for fetching multiple rows without any SQL JOIN
        public async Task<IActionResult> commentsByLimit(int limit){
            dbHandler = new DbHandler();
            List<Comment> result = await dbHandler.getComments(limit);
            return Ok(result);
        }

        
    }
}