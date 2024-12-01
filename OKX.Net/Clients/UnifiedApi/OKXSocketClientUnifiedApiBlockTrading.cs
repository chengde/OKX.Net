using CryptoExchange.Net.Objects.Sockets;
using OKX.Net.Interfaces.Clients.UnifiedApi;
using OKX.Net.Objects.BlockTrading;
using OKX.Net.Objects.Sockets.Subscriptions;

namespace OKX.Net.Clients.UnifiedApi;

/// <inheritdoc />
internal class OKXSocketClientUnifiedApiBlockTrading : IOKXSocketClientUnifiedApiBlockTrading
{
    private readonly OKXSocketClientUnifiedApi _client;

    private readonly ILogger _logger;

    #region ctor

    internal OKXSocketClientUnifiedApiBlockTrading(ILogger logger, OKXSocketClientUnifiedApi client)
    {
        _client = client;
        _logger = logger;
    }
    #endregion
    public async Task<CallResult<UpdateSubscription>> SubscribeToRFQsAsync(Action<DataEvent<OKXRFQUpdate>> onData, CancellationToken ct = default)
    {
        var subscription = new OKXSubscription<OKXRFQUpdate>(_logger, new List<Objects.Sockets.Models.OKXSocketArgs>
            {
                new Objects.Sockets.Models.OKXSocketArgs
                {
                    Channel = "rfqs"
                }
            }, onData, null, true);

        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToQuotesAsync(Action<DataEvent<OKXQuoteUpdate>> onData, CancellationToken ct = default)
    {
        var subscription = new OKXSubscription<OKXQuoteUpdate>(_logger, new List<Objects.Sockets.Models.OKXSocketArgs>
            {
                new Objects.Sockets.Models.OKXSocketArgs
                {
                    Channel = "quotes"
                }
            }, onData, null, true);

        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToStructureBlockTradesAsync(Action<DataEvent<OKXBlockTrade>> onData, CancellationToken ct = default)
    {
        var subscription = new OKXSubscription<OKXBlockTrade>(_logger, new List<Objects.Sockets.Models.OKXSocketArgs>
            {
                new Objects.Sockets.Models.OKXSocketArgs
                {
                    Channel = "struc-block-trades"
                }
            }, onData, null, true);

        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }
}
