using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FoodShareAPI.DTOs;
using FoodShareAPI.Interfaces;

namespace FoodShareAPI.Servicios
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GroqService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<RespuestaIA> AnalizarDonacionAsync(
            AnalizarDonacionDto donacion)
        {
            var apiKey = _configuration["Groq:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException(
                    "No se ha configurado la API Key de Groq.");
            }

            var modelo = _configuration["Groq:Model"]
                         ?? "llama-3.1-8b-instant";

            var prompt = $@"
Eres un asistente especializado en reducción del desperdicio de alimentos para FoodShare.

Analiza la siguiente donación:

Alimento: {donacion.NombreAlimento}
Cantidad: {donacion.Cantidad}
Fecha de vencimiento: {donacion.FechaVencimiento:yyyy-MM-dd}
Descripción: {donacion.Descripcion}

Determina:

1. El nivel de riesgo de desperdicio.
2. El motivo del nivel de riesgo.
3. Una recomendación concreta para evitar el desperdicio.

El nivel de riesgo debe ser únicamente:
Bajo, Medio o Alto.

Responde exclusivamente con un JSON válido con esta estructura:

{{
    ""nivelRiesgo"": ""Alto"",
    ""motivo"": ""Explicación breve"",
    ""recomendacion"": ""Recomendación concreta""
}}
";

            var requestBody = new
            {
                model = modelo,
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content =
                            "Eres un asistente especializado " +
                            "en reducción del desperdicio alimentario."
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                temperature = 0.2
            };

            var json = JsonSerializer.Serialize(requestBody);

            using var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://api.groq.com/openai/v1/chat/completions");

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            using var response = await _httpClient.SendAsync(request);

            var responseContent =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Groq devolvió el código " +
                    $"{(int)response.StatusCode}: " +
                    $"{responseContent}");
            }

            using var document =
                JsonDocument.Parse(responseContent);

            var content =
                document.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException(
                    "Groq no devolvió contenido.");
            }

            content = LimpiarJson(content);

            var resultado =
                JsonSerializer.Deserialize<RespuestaIA>(
                    content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (resultado == null)
            {
                throw new InvalidOperationException(
                    "No fue posible interpretar la respuesta de Groq.");
            }

            return resultado;
        }

        private static string LimpiarJson(string content)
        {
            content = content.Trim();

            if (content.StartsWith("```"))
            {
                var primeraLinea =
                    content.IndexOf('\n');

                var ultimaMarca =
                    content.LastIndexOf("```");

                if (primeraLinea >= 0 && ultimaMarca > primeraLinea)
                {
                    content = content[
                        (primeraLinea + 1)..
                        ultimaMarca];
                }
            }

            return content.Trim();
        }
    }
}