namespace BlazorApp.Models
{
    public static class CitiesRepository
    {
        private static List<string> cities = new List<string>()
        {
            "Los Angeles",
            "New York City",
            "Charlotte"
        };

        public static List<string> GetCities() => cities;
    }
}
