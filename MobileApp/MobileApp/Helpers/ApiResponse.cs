using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Helpers
{
    internal static class ApiResponse
    {
        internal static string GetErrorMessage(ApiException exception)
        {
            switch (exception.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return "Przesłane dane są nieprawidłowe.";
                case System.Net.HttpStatusCode.Unauthorized:
                    return "Nieprawidłowa autoryzacja";
                case System.Net.HttpStatusCode.InternalServerError:
                    return "Wewnętrzny błąd serwera";
                case System.Net.HttpStatusCode.NotFound:
                    return "Nie odnaleziono zasobu";
                case System.Net.HttpStatusCode.Forbidden:
                    return "Brak dostępu do tego zasobu";
                case System.Net.HttpStatusCode.RequestTimeout:
                    return "Upłynął czas na relizację zapytania";
                default:
                    return "Błąd połącznenia";
            }
        }
        internal static string GetTimeout()
        {
            return "Upłynął czas na relizację zapytania";
        }
        internal static string GetCompleted()
        {
            return "Operacja zakończona pomyślnie";
        }
    }
}
