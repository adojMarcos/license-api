
namespace Enviroment.Infrastructure.SQLQueries
{
    public static class LicenseQueries
    {
        public static string GetAllLicenses => "SELECT Id, LicenseName FROM licenses ";
        public static string GetLicenseById => GetAllLicenses + "WHERE Id = @Id";
        public static string GetLicenseByName => GetAllLicenses + "WHERE LicenseName = @Name";
        public static string CreateLicense => @"INSERT INTO licenses(LicenseName) values(@LicenseName);
                                                SELECT CAST(SCOPE_IDENTITY() as int)";
        public static string DeleteLicense => "DELETE FROM licenses WHERE Id = @id";
        public static string UpdateLicense => "UPDATE licenses SET LicenseName = @LicenseName WHERE Id = @id;";


    }
}
