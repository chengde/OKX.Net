using CryptoExchange.Net.Attributes;
namespace OKX.Net.Objects.BlockTrading;

/// <summary>
/// Represents the status of the RFQ 
/// </summary>
public enum RFQStatus
{
    /// <summary>
    /// The quote is active.
    /// </summary>
    [Map("active")]
    Active,

    /// <summary>
    /// The quote has been canceled.
    /// </summary>
    [Map("canceled")]
    Canceled,

    /// <summary>
    /// The quote is pending fill.
    /// </summary>
    [Map("pending_fill")]
    PendingFill,

    /// <summary>
    /// The quote has been filled.
    /// </summary>
    [Map("filled")]
    Filled,

    /// <summary>
    /// The quote has expired.
    /// </summary>
    [Map("expired")]
    Expired,

    /// <summary>
    /// The quote has traded away. traded_away only applies to Maker
    /// </summary>
    [Map("traded_away")]
    TradedAway,

    /// <summary>
    /// The quote has failed.
    /// </summary>
    [Map("failed")]
    Failed
}

/// <summary>
/// Represents the status of the RFQQuote
/// </summary>
public enum QuoteStatus
{
    /// <summary>
    /// The quote is active.
    /// </summary>
    [Map("active")]
    Active,

    /// <summary>
    /// The quote has been canceled.
    /// </summary>
    [Map("canceled")]
    Canceled,
    
    /// <summary>
    /// The quote at pending fill.
    /// </summary>
    [Map("pending_fill")]
    PendingFill,

    /// <summary>
    /// The quote has been filled.
    /// </summary>
    [Map("filled")]
    Filled,

    /// <summary>
    /// The quote has expired.
    /// </summary>
    [Map("expired")]
    Expired,

    /// <summary>
    /// The quote has failed.
    /// </summary>
    [Map("failed")]
    Failed
}