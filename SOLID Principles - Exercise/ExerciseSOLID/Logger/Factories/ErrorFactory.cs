using System;
using System.Globalization;

using Logger.Exceptions;
using Logger.Formats;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Errors;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = DateTimeFormat.Format;
        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
