using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace NossoCalendario.WebApi.Controllers.Base
{
    public static class ResponseBase
    {
        public static object Response(object result = null)
        {
            return new
            {
                success = true,
                data = result
            };

        }

        public static object Response(ModelStateDictionary ModelState)
        {
            IEnumerable<ModelError> modelErros = ModelState.Values.SelectMany(e => e.Errors);

            List<string> errors = new List<string>();

            foreach (var item in modelErros)
            {
                errors.Add(item.Exception == null ? item.ErrorMessage : item.Exception.Message);
            }

            return new
            {
                success = false,
                errors
            };
        }

    }
}

