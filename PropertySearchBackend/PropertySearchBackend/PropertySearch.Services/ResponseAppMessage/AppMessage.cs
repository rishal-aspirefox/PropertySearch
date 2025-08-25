namespace PropertySearch.Application.ResponseAppMessage
{
    public static class AppMessage
    {
        public const string AllFieldsRequired = "All Fields all required";

        public static class Auth
        {
            public const string EmailPassword = "Email and password are required.";
            public const string InvalidEmail = "Invalid email";
            public const string InvalidPassword = "Invalid Password";

        }

        public static class Property
        {
            public const string PropertiesNotFound = "No properties found matching the criteria.";
            public const string NotFound = "Property not found";
            public const string FailedToCreate = "Failed to create property. Please check the input data.";
        }

        public static class Spaces
        {
            public const string SpacesNotFound = "No spaces found matching the criteria.";
            public const string AverageSpaceSizeNotFound = "Average space size not found";
            public const string PropertySpacesNotFound = "No spaces found for this property.";

        }

        public static class Country
        {
            public const string CountriesNotFound = "No countries found.";
            public const string StatesNotFound = "No states found for the specified country.";
        }
    }
}
