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
                            (SELECT State FROM States s WHERE s.UFCode = a.Id) as State
                            FROM clients c INNER JOIN Address a ON c.Id = a.IdClient ";
    }
}
