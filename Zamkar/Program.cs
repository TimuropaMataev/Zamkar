using Microsoft.EntityFrameworkCore;
using Zamkar.Models;

namespace Zamkar;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? str = builder.Configuration.GetConnectionString("ZamkarConnection");

        builder.Services.AddMvc();
        builder.Services.AddDbContext<ZamkarContext>(x => x.UseSqlServer(str));

        var app = builder.Build();

        app.MapDefaultControllerRoute();
        app.Run();
    }
}