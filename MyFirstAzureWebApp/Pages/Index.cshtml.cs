using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstAzureWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;

    public IndexModel(ILogger<IndexModel> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }


    public void OnGet()
    {
        var environment = _configuration["BuildEnvironment:Name"];
        ViewData["environment"] = environment;
    }

    private readonly IDictionary<string, string> Users = new Dictionary<string, string>()
    {
        { "test", "passcode"}
    };

    public string Authenticate(string userName, string password)
    {
        if (!Users.Any(t => t.Key == userName && t.Value == password))
            return null;

        return $"Login succeeded for user {userName}";
    }

    public int Add(int a, int b)
    {
        int c = a + b;
        return c;
    }


}
