namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents the response for canceling a quote on OKX.
/// </summary>
public record OKXCancelQuoteResponse(
    [property: JsonPropertyName("quoteId")]
    string QuoteId, // Quote ID.

    [property: JsonPropertyName("clQuoteId")]
    string ClientQuoteId, // Client-supplied Quote ID.

    [property: JsonPropertyName("sCode")]
    string StatusCode, // The code of the event execution result, 0 means success.

    [property: JsonPropertyName("sMsg")]
    string StatusMessage // Rejection message if the request is unsuccessful.
);
