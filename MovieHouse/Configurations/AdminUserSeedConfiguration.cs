namespace MovieHouse.Configurations
{
    public class AdminUserSeedConfiguration
    {
        public const string SECTION_NAME = "identity:adminUser";


        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public int Age { get; set; }
    }
}
