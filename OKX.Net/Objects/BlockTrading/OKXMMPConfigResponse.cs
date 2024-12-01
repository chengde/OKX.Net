namespace OKX.Net.Objects.BlockTrading;
/// <summary>
/// Represents the response for setting MMP configuration on OKX.
/// </summary>
public record MMPConfigResponse(
    [property: JsonPropertyName("timeInterval")]
string TimeInterval, // Time window (ms). MMP interval where monitoring is done.

    [property: JsonPropertyName("frozenInterval")]
string FrozenInterval, // Frozen period (ms).

    [property: JsonPropertyName("countLimit")]
string CountLimit // Limit in number of execution attempts.
);
