namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Server time
/// </summary>
public record OKXBoolean
{
    /// <summary>
    /// System time
    /// </summary>
    [JsonPropertyName("result")]
    public Boolean Result { get; set; }
}
