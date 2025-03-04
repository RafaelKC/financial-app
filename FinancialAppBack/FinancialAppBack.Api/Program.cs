using FinancialAppBack.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDatabase(configuration)
        .AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        })
        .AddEndpointsApiExplorer()
        .AddControllers();
    
    services.AddSwaggerGen();
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();
    app.MapControllers();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<FinancialAppDbContext>();
        dbContext.Database.Migrate();
    }
    
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseAuthentication();
    app.UseAuthorization();
}

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
ConfigureMiddleware(app);

app.Run();