using Keep_Note4.Context;
using Keep_Note4.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Serilog;



var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

    builder.Services.AddScoped<INoteRepo, NoteRepo>();

    builder.Services.AddScoped<IReminderRepo, ReminderRepo>();

    builder.Services.AddScoped<IUserRepo, UserRepo>();



    builder.Services.AddControllers();
    builder.Services.AddDbContext<KeepDbContext>(op =>
    {
        op.UseSqlServer(builder.Configuration["ConnectionStrings:MyConnection"]);
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
