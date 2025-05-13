namespace Sefer.Backed.Pdf.Api;

public class ApiKeyValidator(IConfiguration configuration)
{
    public static ApiKeyValidator Create(IConfiguration configuration) => new(configuration);

    public bool IsValid(string? apiKey)
    {
        if(string.IsNullOrEmpty(apiKey)) return false;
        var configured = GetConfiguredKey();
        if (string.IsNullOrEmpty(configured)) return false;
        return apiKey == configured;
    }

    private string? GetConfiguredKey()
    {
        return
            EnvVar.GetEnvironmentVariable("PDF_API_KEY") ??
            configuration.GetSection("Pdf").GetValue<string>("ApiKey");
    }
}
