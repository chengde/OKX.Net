namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Represents the details of a quote.
/// </summary>
public record OKXCreateQuoteResponse(
    [property: JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime CreationTime, // The timestamp the Quote was created, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime LastUpdatedTime, // The timestamp the Quote was last updated, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("state")]
    RFQStatus Status, // The status of the quote. Valid values can be active, canceled, pending_fill, filled, expired, or failed.

    [property: JsonPropertyName("reason")]
    string Reason, // Reasons of state. Valid values can be mmp_canceled.

    [property: JsonPropertyName("validUntil"), JsonConverter(typeof(DateTimeConverter))]
    DateTime ExpiryTime, // The timestamp the Quote expires, Unix timestamp format in milliseconds.

    [property: JsonPropertyName("rfqId")]
    string RfqId, // RFQ ID.

    [property: JsonPropertyName("clRfqId")]
    string ClientRfqId, // Client-supplied RFQ ID. Treated as client sensitive information.

    [property: JsonPropertyName("quoteId")]
    string QuoteId, // Quote ID.

    [property: JsonPropertyName("clQuoteId")]
    string ClientQuoteId, // Client-supplied Quote ID. Treated as client sensitive information.

    [property: JsonPropertyName("tag")]
    string Tag, // Quote tag.

    [property: JsonPropertyName("traderCode")]
    string TraderCode, // A unique identifier of maker.

    [property: JsonPropertyName("quoteSide")]
    string QuoteSide, // The trading direction of the Quote.

    [property: JsonPropertyName("legs")]
    List<OKXCreateQuoteLeg> Legs // The legs of the Quote.
);
