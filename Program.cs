var builder = WebApplication.CreateBuilder(args);
var app = builder.WithSharedConfig().Build();

app.MapPost("/generate", (PostModel body, IConfiguration configuration) =>
{
    // Check if the user that used to correct api key to talk with the pdf service
    if(!ApiKeyValidator.Create(configuration).IsValid(body.ApiKey)) return Results.Unauthorized();

    // Check if the correct information is submitted
    if (string.IsNullOrEmpty(body.Html) || string.IsNullOrEmpty(body.FileName)) return Results.BadRequest();

    // Prepare all pdf documents streams. The pdf is written to a file to prevent all kind of stream issues
    var pdfFile = Path.GetTempFileName() + ".pdf";
    using var pdfDest = File.OpenWrite(pdfFile);

    // Convert the html to a pdf
    var converterProperties = new ConverterProperties();
    HtmlConverter.ConvertToPdf(body.Html, pdfDest, converterProperties);

    // Return the result
    return Results.File(pdfFile, "application/pdf", body.FileName);
});

app.MapGet("/test", ([FromQuery] string apiKey, IConfiguration configuration) =>
{
    // Check if the user that used to correct api key to talk with the pdf service
    if(!ApiKeyValidator.Create(configuration).IsValid(apiKey)) return Results.Unauthorized();

    // Prepare all pdf documents streams. The pdf is written to a file to prevent all kind of stream issues
    var pdfFile = Path.GetTempFileName() + ".pdf";
    using var pdfDest = File.OpenWrite(pdfFile);

    // Convert the html to a pdf
    const string html = "<html><boyd><h1>Test Page</h1><p>If you can read this page, the pdf conversion is working correctly.</html>";
    var converterProperties = new ConverterProperties();
    HtmlConverter.ConvertToPdf(html, pdfDest, converterProperties);

    // Return the result
    return Results.File(pdfFile, "application/pdf", "test.pdf");
});

app.Run();
