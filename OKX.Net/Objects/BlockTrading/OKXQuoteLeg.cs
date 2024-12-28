using OKX.Net.Enums;

namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Represents a leg in the Quote, which is a subclass of RFQLeg.
/// </summary>
public record OKXQuoteLeg(
    [property: JsonPropertyName("instId")]
    string InstrumentId, // Instrument ID, e.g., BTC-USDT-SWAP.

    [property: JsonPropertyName("tdMode")]
    TradeMode? TradeMode, // Trade mode. Margin mode: cross isolated. Non-Margin mode: cash.

    [property: JsonPropertyName("ccy")]
    string Currency, // Margin currency. Only applicable to cross MARGIN orders in Spot and futures mode.

    [property: JsonPropertyName("sz")]
    decimal Size, // The size of the quoted leg in contracts or spot.

    [property: JsonPropertyName("px")]
    decimal Price, // The price of the leg. 

    [property: JsonPropertyName("side")]
    OrderSide Side, // The direction of the leg. Valid values can be buy or sell.

    [property: JsonPropertyName("posSide")]
    PositionSide? PositionSide, // Position side. Default is net in the net mode. Only applicable to FUTURES/SWAP.

    [property: JsonPropertyName("tgtCcy")]
    string TargetCurrency // Defines the unit of the size attribute. Only applicable to instType = SPOT.
);