namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// RFQ Counterparty
/// </summary>
public record OKXCounterparty(
    // The long formative username of trader or entity on the platform.
    [property: JsonPropertyName("traderName")]
    string TraderName,

    // A unique identifier of the maker, which will be publicly visible on the platform. All RFQ and Quote endpoints will use this as the unique counterparty identifier.
    [property: JsonPropertyName("traderCode")]
    string TraderCode,

    // The counterparty type. LP refers to API connected auto market makers.
    [property: JsonPropertyName("type")]
    string CounterpartyType);
