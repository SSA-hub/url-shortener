using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace url_shortener.Entities;

[Table("urls")]
public class Url
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("fullurl")] public string FullUrl { get; set; }
    [Column("shorturl")] public int ShortUrl { get; set; }
}