namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// An Array of objects containing the execution size of each leg of the RFQ.
/// The ratio of the leg sizes needs to be the same as the RFQ.
/// *Note: tgtCcy and side of each leg will be same as ones in the RFQ. px will be the same as the ones in the Quote
/// </summary>
/// <param name="InstrumentId"></param>
/// <param name="Size"></param>
public record OKXExecuteQuoteLeg
(
    [property: JsonPropertyName("instId")]
    string InstrumentId, // Instrument ID, e.g., BTC-USDT-SWAP.

    [property: JsonPropertyName("sz")]
    string Size // Size of the leg.
);
