using System.IO;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace GraphQLDemo.Models
{
    public class GraphQlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;
        public GraphQlMiddleware(RequestDelegate next, IPersonRepository personRepository)
        {
            _next = next;
            _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema
                        {
                            Query = new PersonQuery(_personRepository)
                        };
                        var result = await new DocumentExecuter()
                        .ExecuteAsync(options =>
                        {
                            options.Schema = schema;
                            options.Query = query;
                        });
                        await WriteResult(httpContext, result);
                    }
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}
