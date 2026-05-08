namespace OKX.Net.Objects.Trade;

/// <summary>
/// Cancel request
/// </summary>
[SerializationModel]
public record OKXOrderCancelRequest
{
    /// <summary>
    /// ["<c>instId</c>"] Symbol name
    /// </summary>
    [JsonPropertyName("instId")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// ["<c>ordId</c>"] Order id
    /// </summary>
    [JsonPropertyName("ordId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? OrderId { get; set; }

    /// <summary>
    /// ["<c>clOrdId</c>"] Client order id
    /// </summary>
    [JsonPropertyName("clOrdId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ClientOrderId { get; set; }
}
