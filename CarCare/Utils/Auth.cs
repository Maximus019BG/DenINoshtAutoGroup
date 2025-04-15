using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CarCare
{
    public static class Auth
    {
        private const string AdminFile = "admin.json";

        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public static void SaveAdmin(string username, string password)
        {
            var admin = new { username, passwordHash = HashPassword(password) };
            var json = JsonSerializer.Serialize(admin, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(AdminFile, json);
        }

        public static bool IsAdminSetUp() => File.Exists(AdminFile);

        public static bool ValidateLogin(string username, string password)
        {
            if (!IsAdminSetUp()) return false;

            var json = File.ReadAllText(AdminFile);
            var admin = JsonSerializer.Deserialize<AdminData>(json);
            return admin != null &&
                   admin.username == username &&
                   admin.passwordHash == HashPassword(password);
        }

        private class AdminData
        {
            public string username { get; set; }
            public string passwordHash { get; set; }
        }
    }
}