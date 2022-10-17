namespace url_shortener.Entities;

public class Settings
{
    public string? ConnectionString { get; set; }
    public bool ForRobot { get; set; }
    public string? RedirectUrl { get; set; }
}