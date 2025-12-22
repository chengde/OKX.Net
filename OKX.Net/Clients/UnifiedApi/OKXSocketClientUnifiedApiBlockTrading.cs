using CryptoExchange.Net.Objects.Sockets;
using OKX.Net.Interfaces.Clients.UnifiedApi;
using OKX.Net.Objects.BlockTrading;
using OKX.Net.Objects.Funding;
using OKX.Net.Objects.Sockets.Models;
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
    public async Task<CallResult<UpdateSubscription>> SubscribeToRFQsAsync(Action<DataEvent<OKXRfq>> onData, CancellationToken ct = default)
    {
        var internalHandler = new Action<DateTime, string?, OKXSocketUpdate<OKXRfq[]>>((receiveTime, originalData, data) =>
        {
            onData(
                new DataEvent<OKXRfq>(OKXExchange.ExchangeName, data.Data.First(), receiveTime, originalData)
                    .WithUpdateType(data.EventType?.Equals("snapshot", StringComparison.Ordinal) == true ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(data.Data.First().LastUpdatedTime)
                    .WithStreamId(data.Arg.Channel)
                    .WithSymbol(data.Arg.Symbol)
                );
        });

        var subscription = new OKXSubscription<OKXRfq[]>(_logger, _client, new List<OKXSocketArgs>
            {
                new OKXSocketArgs
                {
                    Channel = "rfqs"
                }
            }, internalHandler, true);

        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToQuotesAsync(Action<DataEvent<OKXQuote>> onData, CancellationToken ct = default)
    {
        var internalHandler = new Action<DateTime, string?, OKXSocketUpdate<OKXQuote[]>>((receiveTime, originalData, data) =>
        {
            onData(
                new DataEvent<OKXQuote>(OKXExchange.ExchangeName, data.Data.First(), receiveTime, originalData)
                    .WithUpdateType(data.EventType?.Equals("snapshot", StringComparison.Ordinal) == true ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(data.Data.First().LastUpdatedTime)
                    .WithStreamId(data.Arg.Channel)
                    .WithSymbol(data.Arg.Symbol)
                );
        });

        var subscription = new OKXSubscription<OKXQuote[]>(_logger, _client, new List<OKXSocketArgs>
            {
                new OKXSocketArgs
                {
                    Channel = "quotes"
                }
            }, internalHandler, true);
        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToStructureBlockTradesAsync(Action<DataEvent<OKXBlockTrade>> onData, CancellationToken ct = default)
    {
        var internalHandler = new Action<DateTime, string?, OKXSocketUpdate<OKXBlockTrade[]>>((receiveTime, originalData, data) =>
        {
            onData(
                new DataEvent<OKXBlockTrade>(OKXExchange.ExchangeName, data.Data.First(), receiveTime, originalData)
                    .WithUpdateType(data.EventType?.Equals("snapshot", StringComparison.Ordinal) == true ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(data.Data.First().ExecutionTime)
                    .WithStreamId(data.Arg.Channel)
                    .WithSymbol(data.Arg.Symbol)
                );
        });

        var subscription = new OKXSubscription<OKXBlockTrade[]>(_logger, _client, new List<OKXSocketArgs>
            {
                new OKXSocketArgs
                {
                    Channel = "struc-block-trades"
                }
            }, internalHandler, true);
        return await _client.SubscribeInternalAsync(_client.GetUri("/ws/v5/business"), subscription, ct).ConfigureAwait(false);
    }
}
