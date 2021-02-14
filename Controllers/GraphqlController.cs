using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using System.Collections.Generic;
using GraphQL.Types;
using System;

namespace bachelorproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
    public class GraphqlController : ControllerBase
    {
        public GraphqlController() { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
        
            var schema = new Schema{ Query = new Query() };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
            });

            if(result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
          
        }
    }
}