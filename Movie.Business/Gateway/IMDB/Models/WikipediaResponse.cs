namespace Movie.Business.Gateway.IMDB.Models;
public class WikipediaResponse
{
    public string ImDbId { get; set; }
    public string Title { get; set; }
    public string FullTitle { get; set; }
    public string Type { get; set; }
    public string Year { get; set; }
    public string Language { get; set; }
    public string TitleInLanguage { get; set; }
    public string Url { get; set; }
    public PlotResponse PlotShort { get; set; }
    public PlotResponse PlotFull { get; set; }
    public string ErrorMessage { get; set; }
}
