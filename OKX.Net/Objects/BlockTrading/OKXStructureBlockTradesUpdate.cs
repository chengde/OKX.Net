namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents an OKX structure block trade update.
/// </summary>
public record OKXStructureBlockTradesUpdate(
    [property: JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
    DateTime ExecutionTime, // The time the trade was executed. Unix timestamp in milliseconds.

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
    string TradeTag, // Trade tag. The block trade will have the tag of the RFQ or Quote it corresponds to.

    [property: JsonPropertyName("tTraderCode")]
    string TakerTraderCode, // A unique identifier of the Taker. Empty if anonymous mode of RFQ is True.

    [property: JsonPropertyName("mTraderCode")]
    string MakerTraderCode, // A unique identifier of the Maker. Empty if anonymous mode of Quote is True.

    [property: JsonPropertyName("legs")]
    List<OKXBlockTradeLeg> Legs // Legs of the trade.
);
