// Models/Responses/ApiResponses.cs
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace template_dotnet.Models.Responses
{
    /// <summary>
    /// Respuesta API estándar
    /// </summary>
    public class Responses
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public Responses()
        {
            Success = true;
        }

        public Responses(string message)
        {
            Success = false;
            Message = message;
        }

        public Responses(IEnumerable<string> errors)
        {
            Success = false;
            Errors = errors;
        }

        public Responses(ModelStateDictionary modelState)
        {
            Success = false;
            Errors = modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }

    /// <summary>
    /// Respuesta API estándar con datos
    /// </summary>
    /// <typeparam name="T">Tipo de los datos incluidos en la respuesta</typeparam>
    public class ApiResponse<T> : Responses
    {
        public T Results { get; set; }

        public ApiResponse(T data)
        {
            Success = true;
            Results = data;
        }
    }
}