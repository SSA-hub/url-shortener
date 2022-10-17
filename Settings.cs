namespace url_shortener;

public class Settings
{
    public string? ConnectionString { get; set; }
    public bool ForRobot { get; set; }
    public string? RedirectUrl { get; set; }
}