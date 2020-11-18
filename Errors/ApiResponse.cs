using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "შენნ შეგეშალა რაღაც",
                401 => "ავტორიზებული არ ხარ",
                404 => "ვერ მოიძებნა ვერაფერი.",
                500 => "სერვერის შეცდომა",
                _ => null
            };
        }
    }
}
