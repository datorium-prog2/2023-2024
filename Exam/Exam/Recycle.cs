using System.Text.Json.Serialization;

public class Recycle
{
    [JsonPropertyName("pilsetanovads")]
    public string City { get; set; }

    [JsonPropertyName("adrese")]
    public string Address { get; set; }

    [JsonPropertyName("map")]
    public string Coordinates { get; set; }

    [JsonPropertyName("0 : Papīrs")]
    public string Paper { get; set; }

    [JsonPropertyName("1 : Plastmasa")]
    public string Plastic { get; set; }

    [JsonPropertyName("2 : Stikls")]
    public string Glass { get; set; }

    [JsonPropertyName("3 : Metāls")]
    public string Metal { get; set; }

    [JsonPropertyName("4 : Bioloģiski noārdāmie atkritumi")]
    public string Bio { get; set; }
    [JsonPropertyName("5 : Tekstilmateriāli")]
    public string Textile { get; set; }
    [JsonPropertyName("6 : Elektriskās un elektroniskās iekārtas")]
    public string Electronics { get; set; }
    [JsonPropertyName("7 : Apgaismes iekārtas un spuldzes")]
    public string Lightbulbs { get; set; }
    [JsonPropertyName("8 : Baterijas un akumulatori")]
    public string Batteries { get; set; }
    [JsonPropertyName("9 : Sadzīvē radušies bīstamie atkritumi")]
    public string Dangerous { get; set; }
    [JsonPropertyName("10 : Nolietotās riepas")]
    public string Tires { get; set; }
}