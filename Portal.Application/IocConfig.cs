using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class IocConfig
{
    public static void AddJwtSettings(this IServiceCollection services)
    {
        services.AddTransient<IJwtSettings,JwtSettings>(opts =>
        {
            var conf = opts.GetService<IConfiguration>();
            string accessToken = conf.GetSection("JwtSettings:AccessTokenSecret").Value;
            string refreshToken = conf.GetSection("JwtSettings:RefreshTokenSecret").Value;
            double accessTokenExpiration = conf.GetSection("JwtSettings:AccessTokenExpirationMinutes").Value.ToDouble();
            double refreshTokenExpiration = conf.GetSection("JwtSettings:RefreshTokenExpirationMinutes").Value.ToDouble();
            string issuer = conf.GetSection("JwtSettings:Issuer").Value;
            string audience = conf.GetSection("JwtSettings:Audience").Value;
            return new(accessToken, refreshToken, accessTokenExpiration, refreshTokenExpiration, issuer, audience);
        });
    }
}
