using System.Globalization;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.API.Data.ValueConverters;

public class DateTimeToChar8Converter() : ValueConverter<DateTime, string>(dateTime => dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
    stringValue => DateTime.ParseExact(stringValue, "yyyyMMdd", CultureInfo.InvariantCulture));