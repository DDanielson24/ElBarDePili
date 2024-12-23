namespace ElBarDePili.API.Middleware
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SecurityMiddleware(IConfiguration iconfiguration, RequestDelegate next)
        {
            _configuration = iconfiguration;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_configuration is null) return;

            string? apiKey = _configuration["APIKey"];
            if (apiKey is null) return;

            if (context.Request.Headers.TryGetValue("APIKey", out var extractedApiKey))
            {
                if (!extractedApiKey.Equals(apiKey))
                {
                    context.Response.StatusCode = 401; //Unathorized
                    await context.Response.WriteAsync("APIKey incorrecta");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401; //Unathorized
                await context.Response.WriteAsync("APIKey incorrecta");
                return;
            }
        }
    }
}
