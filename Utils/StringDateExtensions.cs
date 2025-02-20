using System.Globalization;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Utils;

public static class StringDateExtensions
{
    private const string DateFormat = "dd/MM/yyyy";

    public static DateOnly ParseDate(this string date)
    {
        if (DateTime.TryParseExact(date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
        {
            return DateOnly.FromDateTime(parsedDateTime);
        }

        throw new FormatException($"Formato de fecha inválido. Se espera {DateFormat}");
    }

    public static string ToFormattedString(this DateOnly date)
    {
        return date.ToString(DateFormat);
    }
}