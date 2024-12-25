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
            if (_configuration is null)
            {
                await ReturnMethod(context, "No se dispone del archivo de configuración");
                return;
            }

            string? apiKey = _configuration["APIKey"];
            if (apiKey is null)
            {
                await ReturnMethod(context, "No se ha configurado la APIKey");
                return;
            }

            if (context.Request.Headers.TryGetValue("APIKey", out var extractedApiKey))
            {
                if (!extractedApiKey.Equals(apiKey))
                {
                    await ReturnMethod(context, "La APIKey proporcionada no es correcta");
                    return;
                }
            }
            else
            {
                await ReturnMethod(context, "No se ha proporcionado ninguna APIKey");
                    return;
            }
                

            await _next(context);
        }

        public async Task ReturnMethod(HttpContext context, string response)
        {
            context.Response.StatusCode = 401; //Unathorized
            await context.Response.WriteAsync(response);
        }
    }
}
