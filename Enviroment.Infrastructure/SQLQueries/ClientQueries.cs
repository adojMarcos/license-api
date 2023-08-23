namespace Enviroment.Infrastructure.SQLQueries
{
    public static class ClientQueries
    {
        public static string GetAllClients => @"SELECT 
                            c.Id, 
                            c.CorporateName, 
                            c.TradeName, 
                            c.Responsible, 
                            c.Cellphone, 
                            c.Email, 
                            c.Rg, 
                            c.CNPJ,
                            a.Id,
                            a.ZipCode, 
                            a.Neighborhood, 
                            a.Street, 
                            a.Complement, 
                            a.Number, 
                            a.City, 
                            a.StateId as State
                            FROM clients c LEFT JOIN Address a ON c.Id = a.IdClient ";

        public static string GetClientById => GetAllClients + "WHERE c.Id = @IdClient";
        public static string CreateClient => @"INSERT INTO clients (
                                                CorporateName, 
                                                TradeName, 
                                                Responsible, 
                                                Cellphone, 
                                                Email, 
                                                Rg, 
                                                CNPJ) VALUES (
                                                @CorporateName, 
                                                @TradeName, 
                                                @Responsible, 
                                                @Cellphone, 
                                                @Email, 
                                                @Rg,
                                                @CNPJ
                                                );
                                                SELECT CAST(SCOPE_IDENTITY() as int);";
    }
}
