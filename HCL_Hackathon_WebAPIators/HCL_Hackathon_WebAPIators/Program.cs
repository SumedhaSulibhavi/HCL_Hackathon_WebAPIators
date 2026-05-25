////using HCL_Hackathon_WebAPIators.Helpers;
////using HCL_Hackathon_WebAPlators.Data;

////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.IdentityModel.Tokens;
////using Microsoft.OpenApi.Models;
////using System.Text;
////using System.Text.Json.Serialization;

////var builder = WebApplication.CreateBuilder(args);

////// 0. Register Database Engine with Connection Properties
////builder.Services.AddDbContext<AppDbContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////// 1. Configure JSON serialization settings to ignore circular references globally
////builder.Services.AddControllers().AddJsonOptions(options => {
////    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
////});

////// 2. Wire up the JWT Token Authentication Pipeline
////var jwtKey = builder.Configuration["Jwt:Key"] ?? "SuperSecretHCLHackathonLongKey2026";
////var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

////builder.Services.AddAuthentication(options => {
////    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
////}).AddJwtBearer(options => {
////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuerSigningKey = true,
////        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
////        ValidateIssuer = false,
////        ValidateAudience = false,
////        ClockSkew = TimeSpan.Zero // Enforces session token expiration immediately
////    };
////});

////// 3. Register your utility helper dependencies
////builder.Services.AddScoped<JwtHelper>();
////builder.Services.AddEndpointsApiExplorer();

////// 4. Configure Swagger with a global JWT 'Authorize' lock button
////builder.Services.AddSwaggerGen(c => {
////    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HCL Pizza Retail Portal API", Version = "v1" });
////    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
////    {
////        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer 12345abcdef'",
////        Name = "Authorization",
////        In = ParameterLocation.Header,
////        Type = SecuritySchemeType.ApiKey,
////        Scheme = "Bearer"
////    });
////    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
////        {
////            new OpenApiSecurityScheme {
////                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
////            },
////            Array.Empty<string>()
////        }
////    });
////});

////// 5. Enforce Cross-Origin Resource Sharing (CORS) explicitly for Angular
////builder.Services.AddCors(options => {
////    options.AddPolicy("AllowAngular", policy =>
////        policy.WithOrigins("http://localhost:4200")
////              .AllowAnyMethod()
////              .AllowAnyHeader());
////});

////var app = builder.Build();



////// --- STRICT MIDDLEWARE LIFECYCLE ORDERING MATRIX ---
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseCors("AllowAngular");      // 1. CORS runs first to handle preflight headers
////app.UseAuthentication();        // 2. Authentication extracts token claims
////app.UseAuthorization();         // 3. Authorization validates system role bounds

////app.MapControllers();

////app.Run();



//using HCL_Hackathon_WebAPIators.Data;
//using HCL_Hackathon_WebAPIators.Helpers;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore; // Needed for AddDbContext
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
// // Needed to find your JwtHelper

//var builder = WebApplication.CreateBuilder(args);

//// =========================================================================
//// 🗄️ DATABASE CONNECTION REGISTRATION (FIXES APPDBCONTEXT EXCEPTION)
//// =========================================================================
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// =========================================================================
//// 🔑 UTILITY UTILS REGISTRATION (FIXES JWTHELPER EXCEPTION)
//// =========================================================================
//builder.Services.AddScoped<JwtHelper>();

//// =========================================================================
//// 🛠️ .NET 8 COMPATIBLE JWT AUTHENTICATION SERVICES CONFIGURATION
//// =========================================================================
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(
//        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "SuperSecretHackathonKeyThatIsLongEnoughToMeetTheRequirements123!"))
//    };
//});

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TicketManagement.API", Version = "v1" });

//    // Define the Bearer security scheme setup
//    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer 12345abcdef\"",
//        Name = "Authorization",
//        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
//        Scheme = "Bearer"
//    });

//    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//    {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//            {
//                Reference = new Microsoft.OpenApi.Models.OpenApiReference
//                {
//                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                },
//                Scheme = "oauth2",
//                Name = "Bearer",
//                In = Microsoft.OpenApi.Models.ParameterLocation.Header
//            },
//            new List<string>()
//        }
//    });
//});

//// Configure CORS for your Angular local development environment hosting ports
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular", policy =>
//    {
//        policy.WithOrigins("http://localhost:57093", "http://localhost:4200")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//var app = builder.Build();

//// =========================================================================
//// 🚀 MIDDLEWARE EXECUTION PIPELINE ORDER (CRITICAL FOR .NET 8)
//// =========================================================================
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors("AllowAngular"); // 1. Check permissions first

//app.UseAuthentication();    // 2. Read the encrypted token incoming string header
//app.UseAuthorization();     // 3. Block or allow the request based on roles/attributes

//app.MapControllers();

//app.Run();


using HCL_Hackathon_WebAPIators.Data;
using HCL_Hackathon_WebAPIators.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// =========================================================================
// 🗄️ DATABASE CONNECTION REGISTRATION
// =========================================================================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =========================================================================
// 🔄 FIXES CIRCULAR REFERENCE CRASHES FOR 3NF RELATIONAL MODELS
// =========================================================================
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// =========================================================================
// 🔑 UTILITY DEPENDENCY REGISTRATION
// =========================================================================
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddEndpointsApiExplorer();

// =========================================================================
// 🛠️ JWT AUTHENTICATION SERVICES CONFIGURATION (KEY SYNCHRONIZED)
// =========================================================================
// 🎯 CRITICAL MATCH: Uses the exact fallback key from your appsettings matrix
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SuperSecretHCLHackathonLongKey2026";
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ClockSkew = TimeSpan.Zero // Enforces immediate expiration tracking
    };
});

// =========================================================================
// 🎨 SWAGGER SECURITY CONFIGURATION MATRIX
// =========================================================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HCL Pizza Retail Portal API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// =========================================================================
// 🌐 CORS POLICY SETUP FOR ANGULAR INTEGRATION
// =========================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:57093", "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// =========================================================================
// 🚀 MIDDLEWARE EXECUTION PIPELINE ORDER 
// =========================================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular"); // 1. Preflight CORS check runs first

app.UseAuthentication();    // 2. Extracts and validates incoming Bearer signature claims
app.UseAuthorization();     // 3. Evaluates Roles bounds (e.g., [Authorize(Roles = "Manager")])

app.MapControllers();

app.Run();