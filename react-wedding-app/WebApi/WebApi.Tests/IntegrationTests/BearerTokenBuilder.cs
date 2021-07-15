using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationTests
{
    public class BearerTokenBuilder
    {
        private readonly SymmetricSecurityKey _key;
        private string _issuer;
        private string _audience;
        private TimeSpan _life = TimeSpan.FromHours(1);
        private DateTime _notBefore = DateTime.UtcNow;        
        private readonly List<Claim> _claims;
        private readonly JwtSecurityTokenHandler _securityTokenHandler = new JwtSecurityTokenHandler();

        private static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }

        public BearerTokenBuilder()
        {
            var config = InitConfiguration();

            _issuer = config["Jwt:Issuer"];
            _audience = config["Jwt:Audience"];
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            _claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
            };
        }
        
        
        public BearerTokenBuilder IssuedBy(string issuer)
        {
            if (string.IsNullOrEmpty(issuer))
            {
                throw new ArgumentException("Issued by cannot be null or empty", nameof(issuer));
            }

            _issuer = issuer;

            return this;
        }

        public BearerTokenBuilder ForAudience(string audience)
        {
            if (string.IsNullOrEmpty(audience))
            {
                throw new ArgumentException("Audience cannot be null or empty", nameof(audience));
            }

            _audience = audience;

            return this;
        }

        public BearerTokenBuilder ForSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Subject cannot be null or empty", nameof(subject));
            }

            if (_claims.FirstOrDefault(claim => claim.Type == "sub") == null)
            {
                _claims.Add(new Claim("sub", subject));
            }

            return this;
        }
        

        public BearerTokenBuilder WithClaim(string claimType, string value)
        {
            if (string.IsNullOrEmpty(claimType))
            {
                throw new ArgumentException("Claim type cannot be null or empty", nameof(claimType));
            }

            if (value == null)
            {
                value = string.Empty;
            }

            _claims.Add(new Claim(claimType, value));

            return this;
        }

        public BearerTokenBuilder WithLifetime(TimeSpan life)
        {
            if (life == new TimeSpan(0, 0, 0, 0, 0))
            {
                throw new ArgumentException("Lifetime cannot be null", nameof(life));
            }

            _life = life;

            return this;
        }

        public BearerTokenBuilder NotBefore(DateTime notBefore)
        {
            if (notBefore == DateTime.MinValue)
            {
                throw new ArgumentException("Not before cannot be null", nameof(notBefore));
            }

            _notBefore = notBefore;

            return this;
        }
    
        public string BuildToken()
        {
            if (_key == null)
            {
                throw new InvalidOperationException(
                    "You must specify a key to use for signing the JWT Token");
            }
            

            var signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var notBefore = _notBefore;
            var expires = notBefore.Add(_life);
           
            var identity = new ClaimsIdentity(_claims);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                NotBefore = notBefore,
                Expires = expires,
                SigningCredentials = signingCredentials,
                Subject = identity
            };

            var token = _securityTokenHandler.CreateToken(securityTokenDescriptor);

            var encodedAccessToken = _securityTokenHandler.WriteToken(token);

            return encodedAccessToken;
        }
        
        
    }
}