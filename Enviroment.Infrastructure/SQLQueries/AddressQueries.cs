namespace Enviroment.Infrastructure.SQLQueries
{
    public static class AddressQueries
    {
        public static string CreateAddress => @"INSERT INTO address (
                                                    ZipCode, 
                                                    Neighborhood, 
                                                    Street, 
                                                    Complement, 
                                                    Number, 
                                                    City,
                                                    IdClient,
                                                    StateId) VALUES (
                                                    @ZipCode, 
                                                    @Neigborhood, 
                                                    @Street, 
                                                    @Complement, 
                                                    @Number,
                                                    @City,
                                                    @Id,
                                                    @StateId);";
        public static string UpdateAddress => @"UPDATE address SET ZipCode = @ZipCode, 
                                                            Neighborhood = @Neigborhood, 
                                                            Street = @Street, 
                                                            Complement = @Complement, 
                                                            Number = @Number, 
                                                            City = @City,
                                                            StateId = @State ";

        public static string UpdateAddressByClientId => UpdateAddress + "WHERE IdClient = @Id";
    };
}
