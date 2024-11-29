namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents a response for canceling an RFQ on OKX.
/// </summary>
public record OKXCancelRFQResponse(
    [property: JsonPropertyName("rfqId")]
    string RfqId, // RFQ ID.

    [property: JsonPropertyName("clRfqId")]
    string ClientRfqId, // Client-supplied RFQ ID.

    [property: JsonPropertyName("sCode")]
    string StatusCode, // The code of the event execution result, 0 means success.

    [property: JsonPropertyName("sMsg")]
    string StatusMessage // Rejection message if the request is unsuccessful.
);
