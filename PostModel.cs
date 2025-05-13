// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Sefer.Backed.Pdf.Api;

/// <summary>
/// Hold the information that should be posted to generate the pdf
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PostModel
{
    /// <summary>
    /// The api key to give authorized access
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// The html that should be converted into HTML
    /// </summary>
    public string? Html { get; set; }

    /// <summary>
    /// The filename of the resulting pdf
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// The paper size to be just, default a4
    /// </summary>
    public string PaperSize { get; set; } = "a4";
}