using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCore.Testing.Data.ValueConverters;

public class DateTimeToChar8Converter : ValueConverter<DateTime, string>
{
    public DateTimeToChar8Converter() : base(
        dateTime => dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
        stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd", CultureInfo.InvariantCulture)
        )
    { }
}