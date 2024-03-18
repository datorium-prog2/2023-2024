using System.Text.Json.Serialization;

public class RecycleResult
{
    [JsonPropertyName("records")]

    public List<Recycle> Records { get; set; }
}