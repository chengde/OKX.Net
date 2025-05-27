using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace OKX.Net.Objects.System;
/// <summary>
/// Subscription for OKX notice messages.
/// </summary>
public class OKXNoticeSubscription : SystemSubscription<OKXNotice>
{
    private Action<OKXNotice>? _onNotice;
    /// <summary>
    /// Identifiers for the listeners that this subscription will handle.
    /// </summary>
    public override HashSet<string> ListenerIdentifiers { get; set; } = new HashSet<string>() { "notice", "channel-conn-count", "channel-conn-count-error" };
    /// <summary>
    /// ctor
    /// </summary>
    public OKXNoticeSubscription(ILogger logger,Action<OKXNotice>? OnNotice) : base(logger, false)
    {
        _onNotice = OnNotice;
    }
    /// <summary>
    /// Handles a message received from the socket connection.
    /// </summary>
    public override CallResult HandleMessage(SocketConnection connection, DataEvent<OKXNotice> message)
    {
        var notice = message.Data;
        if ( _onNotice == null)
        {
            _logger.LogWarning($"Received notice message {notice.Code} {notice.Message}");
        }
        else
            _onNotice.Invoke(message.Data);
        return new CallResult(null);
    }
}
