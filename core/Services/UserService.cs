using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using orderoni.Models;
using orderoni.Services;

namespace orderoni.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _users;

        private readonly AppSettingsService _appSettings;

        public UserService(IConfiguration config, IOptions<AppSettingsService> appSettings)
        {
            _appSettings = appSettings.Value;
            
            var client = new MongoClient(config.GetConnectionString("orderoniDB"));
            var database = client.GetDatabase("orderoniDB");

            _users = database.GetCollection<Users>("users");
        }

        public List<Users> Get()
        {
            return _users.Find(Users => true).ToList();
        }

        public Users Authenticate(string username, string password)
        {
            var user = _users.Find<Users>(Users => Users.Username == username || Users.Email == username && Users.Password == password).FirstOrDefault();


            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public Users Get(string id)
        {
            return _users.Find<Users>(Users => Users.Id == id).FirstOrDefault();
        }

        public Users Create(Users User)
        {
            _users.InsertOne(User);
            return User;
        }

        public void Update(string id, Users portIn)
        {
            _users.ReplaceOne(User => User.Id == id, portIn);
        }

        public void Remove(Users portIn)
        {
            _users.DeleteOne(user => user.Id == portIn.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

    }
}
