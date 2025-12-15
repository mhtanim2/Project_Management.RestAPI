using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectManagement.RestAPI.Middleware;

public class ApiResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result == null)
        {
            await next();
            return;
        }

        if (context.Result is ObjectResult objectResult && objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
        {
            var value = objectResult.Value;
            object data = value ?? new { };

            object? pagination = null;

            if (value is System.Collections.IEnumerable enumerable && !(value is string))
            {
                var list = enumerable.Cast<object?>().ToList();
                var total = list.Count;

                var http = context.HttpContext.Request;
                int page = 1;
                int limit = 20;
                if (int.TryParse(http.Query["page"].FirstOrDefault(), out var p)) page = Math.Max(1, p);
                if (int.TryParse(http.Query["limit"].FirstOrDefault(), out var l)) limit = Math.Max(1, l);

                var totalPages = limit > 0 ? (int)Math.Ceiling(total / (double)limit) : 1;

                pagination = new
                {
                    page,
                    limit,
                    total,
                    totalPages
                };

                data = list; 
            }

            var response = new
            {
                success = true,
                data,
                message = "Success",
                pagination,
                timestamp = DateTime.UtcNow.ToString("o")
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = objectResult.StatusCode
            };
        }
        else if (context.Result is EmptyResult)
        {
            var response = new
            {
                success = true,
                data = new { },
                message = "Success",
                pagination = (object?)null,
                timestamp = DateTime.UtcNow.ToString("o")
            };
            context.Result = new JsonResult(response) { StatusCode = 200 };
        }

        await next();
    }
}

