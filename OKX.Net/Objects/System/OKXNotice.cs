namespace OKX.Net.Objects.System;
/// <summary>
/// Represents a notice message from OKX.
/// </summary>
/// [SerializationModel]
public class OKXNotice
{
    /// <summary> event </summary>
    [JsonPropertyName("event")]
    public string? Event{ get; set; }
    /// <summary> code </summary>
    [JsonPropertyName("code")]
    public int? Code { get; set; }
    /// <summary> message</summary>
    [JsonPropertyName("msg")]
    public string? Message { get; set; }
    /// <summary> channel </summary>
    [JsonPropertyName("channel")]
    public string? Channel{ get; set; }
    /// <summary> Connection Count</summary>
    [JsonPropertyName("connCount")]
    public int? ConnectionCount{ get; set; }
    /// <summary> Connection Id</summary>
    [JsonPropertyName("connId")]
    public string? ConnectionId { get; set; }
}
