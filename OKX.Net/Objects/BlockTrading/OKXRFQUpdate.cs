using OKX.Net.Enums;
namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Represents an RFQ (Request For Quote) update.
/// </summary>
public record OKXRFQUpdate(
    [property: JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime CreationTime, // The timestamp the RFQ was created, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime LastUpdatedTime, // The timestamp the RFQ was updated latest, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("state")]
    RFQStatus Status, // The status of the RFQ. Valid values can be active, canceled, filled, expired or failed.

    [property: JsonPropertyName("counterparties")]
    List<string> CounterpartiesTraderCodes, // The list of counterparties traderCode the RFQ was broadcasted to.

    [property: JsonPropertyName("validUntil"), JsonConverter(typeof(DateTimeConverter))]
    DateTime ExpiryTime, // The timestamp the RFQ expires. Unix timestamp format in milliseconds.

    [property: JsonPropertyName("clRfqId")]
    string ClientRfqId, // Client-supplied RFQ ID. This attribute is treated as client sensitive information.

    [property: JsonPropertyName("tag")]
    string Tag, // RFQ tag. The block trade associated with the RFQ will have the same tag.

    [property: JsonPropertyName("flowType")]
    string FlowType, // Identify the type of the RFQ.

    [property: JsonPropertyName("traderCode")]
    string TakerTraderCode, // A unique identifier of the taker. Empty if anonymous mode is True.

    [property: JsonPropertyName("rfqId")]
    string RfqId, // RFQ ID.

    [property: JsonPropertyName("allowPartialExecution")]
    bool AllowPartialExecution, // Whether the RFQ can be partially filled provided that the shape of legs stays the same.

    [property: JsonPropertyName("legs")]
    List<OKXCreateQuoteLeg> Legs // An array of objects containing each leg of the RFQ.
);

