using OKX.Net.Enums;

namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Represents a leg in the trade, which is a subclass of QuoteLeg.
/// </summary>
public record OKXBlockTradeLeg(
    [property: JsonPropertyName("instId")]
    string InstrumentId, // Instrument ID, e.g., BTC-USDT-SWAP.

    [property: JsonPropertyName("px")]
    decimal Price, // The price the leg executed.

    [property: JsonPropertyName("sz")]
    decimal Size, // Size of the leg.

    [property: JsonPropertyName("side")]
    OrderSide Side, // The direction of the leg. Valid value can be buy or sell.

    [property: JsonPropertyName("tgtCcy")]
    string TargetCurrency, // Defines the unit of the size attribute.

    [property: JsonPropertyName("fee")]
    decimal Fee, // Fee. Negative number represents the transaction fee charged by the platform. Positive fee represents rebate.

    [property: JsonPropertyName("feeCcy")]
    string FeeCurrency, // Fee currency.

    [property: JsonPropertyName("tradeId")]
    string TradeId // Last traded ID.
) ;
