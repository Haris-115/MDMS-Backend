using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystemAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ManagementSystemAPI.Helpers;
using Microsoft.Extensions.Options;

namespace ManagementSystemAPI.DataAccess.Implementation
{
    public class UsersProvider : IUsersProvider
    {
        private readonly AppSettings _appSettings;

        public PostgreSqlContext _context;

        public UsersProvider(PostgreSqlContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public int AddUsersRecord(Users users)
        {
            users.password = BCrypt.Net.BCrypt.HashPassword(users.password, _appSettings.Salt);
            _context.users.Add(users);
            _context.SaveChanges();
            return users.users_id;
        }

        public void UpdateUsersRecord(Users users)
        {
            _context.users.Update(users);
            _context.SaveChanges();
        }

        public void DeleteUsersRecord(int id)
        {
            var entity = _context.users.FirstOrDefault(t => t.users_id == id);
            _context.users.Remove(entity);
            _context.SaveChanges();
        }
        public Users Authenticate(Users users)
        {
            /*var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
             * string myPassword = "password";
string mySalt = BCrypt.GenerateSalt();
//mySalt == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO"
string myHash = BCrypt.HashPassword(myPassword, mySalt);
//myHash == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO4777l4bVeQgDL6VIkxqlzQ7TCalQvla"
bool doesPasswordMatch = BCrypt.CheckPassword(myPassword, myHash);
             */
            // get account from database
            var matchedUser = _context.users.FirstOrDefault(x => x.username == users.username || x.email == users.email);
            //string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(users.password, _appSettings.Salt);
            bool valid = BCrypt.Net.BCrypt.Equals(matchedUser.password, passwordHash);
            // check account found and verify password
            if (matchedUser == null || !valid)
            {
                // authentication failed
                return null;
            }
            else
            {
                var token = generateJwtToken(matchedUser);

                // authentication successful
                return new Users(matchedUser, token);
            }
        }
        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.users_id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Users GetUsersSingleRecord(int id)
        {
            return _context.users.FirstOrDefault(t => t.users_id == id);
        }

        public List<Users> GetUsersRecords()
        {
            return _context.users.ToList();
        }
        public List<Users> GetAll()
        {
            return _context.users.ToList();
        }
    }
}
