using Newtonsoft.Json;
namespace ApiWeb.Services;

public class UtilService
{
    private readonly IConfiguration _configuration;

    public UtilService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? SeviceConn()
    {
        var ambiente = _configuration["Ambiente"];
        var conn = ambiente == "P"
            ? _configuration["ServiceConn_P"]
            : _configuration["ServiceConn_H"];

        Console.WriteLine($"Ambiente: {ambiente}");
        Console.WriteLine($"ConnectionString: {conn}");

        return conn;
    }
}