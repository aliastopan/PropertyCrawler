using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Models;
using PropertyCrawler;

namespace ConsoleApp.Services;

public class ConsoleService : IConsoleService
{
    private readonly ILogger<ConsoleService> _logger;
    private readonly IConfiguration _config;

    public ConsoleService(ILogger<ConsoleService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var bookshelf = new BookShelf(id: 5);

        Property.Crawler(bookshelf);

    }
}