namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents a response for executing a quote on OKX.
/// </summary>
public record OKXExecuteQuoteResponse(
    [property: JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime ExecutionTime, // The execution time for the trade. Unix timestamp in milliseconds.

    [property: JsonPropertyName("rfqId")]
    string RfqId, // RFQ ID.

    [property: JsonPropertyName("clRfqId")]
    string ClientRfqId, // Client-supplied RFQ ID. Treated as client sensitive information.

    [property: JsonPropertyName("quoteId")]
    string QuoteId, // Quote ID.

    [property: JsonPropertyName("clQuoteId")]
    string ClientQuoteId, // Client-supplied Quote ID. Treated as client sensitive information.

    [property: JsonPropertyName("blockTdId")]
    string BlockTradeId, // Block trade ID.

    [property: JsonPropertyName("tag")]
    string RfqTag, // RFQ tag.

    [property: JsonPropertyName("tTraderCode")]
    string TakerTraderCode, // A unique identifier of the taker.

    [property: JsonPropertyName("mTraderCode")]
    string MakerTraderCode, // A unique identifier of the maker.

    [property: JsonPropertyName("legs")]
    List<OKXBlockTradeLeg> Legs // Legs of the trade.
);
