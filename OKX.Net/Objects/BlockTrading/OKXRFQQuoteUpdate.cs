using OKX.Net.Enums;

namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents an OKX quote update.
/// </summary>
public record OKXQuoteUpdate(
    [property: JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime CreationTime, // The timestamp the Quote was created, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime LastUpdatedTime, // The timestamp the Quote was updated latest, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("state")]
    QuoteStatus Status, // The status of the quote. Valid values can be active, canceled, filled, expired or failed.

    [property: JsonPropertyName("reason")]
    string Reason, // Reasons of state. Valid values can be mmp_canceled.

    [property: JsonPropertyName("validUntil"), JsonConverter(typeof(DateTimeConverter))]
    DateTime ExpiryTime, // The timestamp the Quote expires. Unix timestamp format in milliseconds.

    [property: JsonPropertyName("rfqId")]
    string RfqId, // RFQ ID.

    [property: JsonPropertyName("clRfqId")]
    string ClientRfqId, // Client-supplied RFQ ID. This attribute is treated as client sensitive information.

    [property: JsonPropertyName("quoteId")]
    string QuoteId, // Quote ID.

    [property: JsonPropertyName("clQuoteId")]
    string ClientQuoteId, // Client-supplied Quote ID. This attribute is treated as client sensitive information.

    [property: JsonPropertyName("tag")]
    string Tag, // Quote tag. The block trade associated with the Quote will have the same tag.

    [property: JsonPropertyName("traderCode")]
    string MakerTraderCode, // A unique identifier of maker. Empty if anonymous mode of Quote is True.

    [property: JsonPropertyName("quoteSide")]
    OrderSide QuoteSide, // Top level side of Quote. Its value can be buy or sell.

    [property: JsonPropertyName("legs")]
    List<OKXCreateQuoteLeg> Legs // An array of objects containing each leg of the Quote.
);
