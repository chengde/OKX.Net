using CryptoExchange.Net.Objects.Sockets;
using OKX.Net.Objects.BlockTrading;
namespace OKX.Net.Interfaces.Clients.UnifiedApi;

/// <summary>
/// Unified API
/// </summary>
public interface IOKXSocketClientUnifiedApiBlockTrading
{
    /// <summary>
    /// Retrieve the RFQs sent or received by the user. Data will be pushed whenever the user sends or receives an RFQ.
    /// <para><a href="https://www.okx.com/docs-v5/en/?shell#block-trading-websocket-private-channel-rfqs-channel" /></para>
    /// </summary>
    /// <param name="onData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CallResult<UpdateSubscription>> SubscribeToRFQsAsync(Action<DataEvent<OKXRFQUpdate>> onData, CancellationToken ct = default);

    /// <summary>
    /// Retrieve the Quotes sent or received by the user. Data will be pushed whenever the user sends or receives a Quote.
    /// <para><a href="https://www.okx.com/docs-v5/en/?shell#block-trading-websocket-private-channel-quotes-channel" /></para>
    /// </summary>
    /// <param name="onData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CallResult<UpdateSubscription>> SubscribeToQuotesAsync(Action<DataEvent<OKXQuoteUpdate>> onData, CancellationToken ct = default);

    /// <summary>
    /// Retrieve user's block trades data. All the legs in the same block trade are included in the same update. Data will be pushed whenever there is a block trade that the user is a counterparty for.
    /// <para><a href="https://www.okx.com/docs-v5/en/?shell#block-trading-websocket-private-channel-structure-block-trades-channel" /></para>
    /// </summary>
    /// <param name="onData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CallResult<UpdateSubscription>> SubscribeToStructureBlockTradesAsync(Action<DataEvent<OKXBlockTrade>> onData, CancellationToken ct = default);

}