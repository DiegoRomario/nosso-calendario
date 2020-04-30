using NossoCalendario.WebApi.Helpers;

namespace NossoCalendario.WebApi.Entensions
{
    public static class StringExtensions
    {
        public static string ToHash(this string text)
        {
            return PasswordEncryptorHelper.Hash(text);
        }
    }
}
