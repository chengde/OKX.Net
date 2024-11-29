namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Quote Product.
/// </summary>
public record OKXQuoteProduct(
    [property: JsonPropertyName("instType")]
    string InstrumentType, // Type of instrument. Valid value can be FUTURES, OPTION, SWAP or SPOT.

    [property: JsonPropertyName("includeAll")]
    bool IncludeAll, // Receive all instruments or not under specific instType setting.

    [property: JsonPropertyName("data")]
    List<OKXQuoteProductDetail> Instruments // Elements of the instType.
);

/// <summary>
/// Elements of the InstrumentType
/// </summary>
public record OKXQuoteProductDetail(
    [property: JsonPropertyName("instFamily")]
    string InstrumentFamily, // Instrument family. Required for FUTURES, OPTION and SWAP only.

    [property: JsonPropertyName("instId")]
    string InstrumentId, // Instrument ID. Required for SPOT only.

    [property: JsonPropertyName("maxBlockSz")]
    string MaxBlockSize, // Max trade quantity for the product(s).

    [property: JsonPropertyName("makerPxBand")]
    string MakerPriceBand // Price bands in unit of ticks, measured against mark price.
);
