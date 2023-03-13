using Amazon.S3;
using Diplomna.DbContexts;
using Diplomna.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var Origins = "_Origins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersInfoContext>(dbContextOptions => dbContextOptions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IdentityInterface, IdentityService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.Cookie.Name = ("Cookie");
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
    );
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(Origins,
                          policy =>
                          {
                              policy.WithOrigins("https://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowCredentials();
                                               

                          });
});



/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme ).AddCookie(o => 
{
    o.Cookie.Name = "__Host-spa";
    //Kakvo e SameSite i SameSite Strict
    o.Cookie.SameSite = SameSiteMode.Strict;
    o.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthorization(o =>
o.AddPolicy("admin",o=> o.RequireClaim("role","admin"))
);*/
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(Origins);
app.UseAuthorization();
app.UseSession();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
