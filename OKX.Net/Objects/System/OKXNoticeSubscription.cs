using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets;
namespace OKX.Net.Objects.System;
/// <summary>
/// Subscription for OKX notice messages.
/// </summary>
public class OKXNoticeSubscription : SystemSubscription
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OKXNoticeSubscription"/> class.
    /// </summary>
    /// <param name="logger">The logger instance to use for logging.</param>
    /// <param name="OnNotice">The action to invoke when a notice message is received.</param>
    public OKXNoticeSubscription(ILogger logger, Action<OKXNotice>? OnNotice) : base(logger, false)
    {
        base.MessageRouter = MessageRouter.CreateWithoutTopicFilter<OKXNotice>("notice", (sc, dt, st, notice) => { OnNotice?.Invoke(notice); return CallResult.SuccessResult; });
    }
}
