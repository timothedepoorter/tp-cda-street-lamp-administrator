using BCrypt.Net;
using lampadaire.Models;
using lampadaire.MongoDBConnection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lampadaire.Service
{
    public class AuthService
    {
        private readonly IMongoCollection<Utilisateur> _utilisateurs;
        private readonly IConfiguration _configuration;

        public AuthService(IOptions<MongoDbSetting> settings, IMongoDatabase database, IConfiguration configuration)
        {
            _utilisateurs = database.GetCollection<Utilisateur>(settings.Value.UtilisateurCollectionName);
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(string identifiant, string motDePasse)
        {
            var existingUser = await _utilisateurs.Find(u => u.Identifiant == identifiant).FirstOrDefaultAsync();
            if (existingUser != null)
                return "L'utilisateur existe déjà.";

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(motDePasse);

 
            string role = "user";
            
            if (identifiant == "admin@example.com")  
            {
                role = "admin";
            }

            var utilisateur = new Utilisateur
            {
                Identifiant = identifiant,
                MotDePasse = hashedPassword,
                Role = role
            };

            await _utilisateurs.InsertOneAsync(utilisateur);
            return "Inscription réussie.";
        }

        public async Task<string> LoginAsync(string identifiant, string motDePasse)
        {
            var utilisateur = await _utilisateurs.Find(u => u.Identifiant == identifiant).FirstOrDefaultAsync();
            if (utilisateur == null || !BCrypt.Net.BCrypt.Verify(motDePasse, utilisateur.MotDePasse))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, utilisateur.Id),
                    new Claim(ClaimTypes.Email, utilisateur.Identifiant),
                    new Claim(ClaimTypes.Role, utilisateur.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
