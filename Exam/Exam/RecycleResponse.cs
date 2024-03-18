using System.Text.Json.Serialization;

public class RecycleResponse
{
    [JsonPropertyName("help")]
    public string Help { get; set; }
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("result")]
    public RecycleResult Result { get; set; }
}