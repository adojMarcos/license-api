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
                                                    @IdClient,
                                                    @StateId);";
    };
}
