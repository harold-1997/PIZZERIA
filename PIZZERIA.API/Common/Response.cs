

// Clase que guarda las respuestas para los endpoints
namespace PIZZERIA.API.Common
{
    public class Response<T>
    {
        public bool IsSucces { get; set; } = false;
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}
