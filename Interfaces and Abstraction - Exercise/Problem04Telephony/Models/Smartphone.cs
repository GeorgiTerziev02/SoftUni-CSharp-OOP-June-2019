using Problem04Telephony.Contracts;
using Problem04Telephony.Exceptions;
using System.Linq;

namespace Problem04Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }
        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
