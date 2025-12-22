using CryptoExchange.Net.RateLimiting.Guards;
using OKX.Net.Enums;
using OKX.Net.Interfaces.Clients.UnifiedApi;
using OKX.Net.Objects.BlockTrading;
using OKX.Net.Objects.Public;

namespace OKX.Net.Clients.UnifiedApi;
internal class OKXRestClientUnifiedApiBlockTrading : IOKXRestClientUnifiedApiBlockTrading
{
    private static readonly RequestDefinitionCache _definitions = new();
    private readonly OKXRestClientUnifiedApi _baseClient;

    internal OKXRestClientUnifiedApiBlockTrading(OKXRestClientUnifiedApi baseClient)
    {
        _baseClient = baseClient;
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXCounterparty[]>> GetCounterpartiesAsync(CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v5/rfq/counterparties", OKXExchange.RateLimiter.EndpointGate, 1, authenticated :true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        var result = await _baseClient.SendAsync<OKXCounterparty[]>(request, parameters, ct).ConfigureAwait(false);
        return result;
    }
    /// <inheritdoc />
    public async Task<WebCallResult<OKXRfq>> CreateRFQAsync(List<string> counterparties, List<OKXRfqLeg> legs, bool? anonymous = null, string? clientRfqId = null, string? tag = null, bool? allowPartialExecution = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection() 
        {
            {"counterparties",counterparties},
            {"legs",legs }
        };
        parameters.AddOptional("anonymous", anonymous);
        parameters.AddOptional("clRfqId", clientRfqId);
        parameters.AddOptional("tag", tag);
        parameters.AddOptional("allowPartialExecution", allowPartialExecution);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/create-rfq", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXRfq>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXCancelRFQResponse>> CancelRFQAsync(string? rfqId = null, string? clientRfqId = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", rfqId);
        parameters.AddOptional("clRfqId", clientRfqId);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-rfq", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXCancelRFQResponse>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXCancelRFQResponse[]>> CancelMultipleRFQAsync(List<string>? rfqIds = null, List<string>? clientRfqIds = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqIds", rfqIds);
        parameters.AddOptional("clRfqIds", clientRfqIds);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-batch-rfqs", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXCancelRFQResponse[]>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXTime>> CancelAllRFQAsync(CancellationToken ct = default)
    {
        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-all-rfqs", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXTime>(request, null, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXBlockTrade>> ExecuteQuoteAsync(string rfqId, string quoteId, List<OKXExecuteQuoteLeg> legs, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "rfqIds", rfqId},
            { "quoteId",quoteId}
        };
        parameters.AddOptional("legs", legs);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/execute-quote", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(3), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXBlockTrade>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXQuoteProduct[]>> GetQuoteProductsAsync(CancellationToken ct = default)
    {
        var request = _definitions.GetOrCreate(HttpMethod.Get, $"/api/v5/rfq/maker-instrument-settings", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXQuoteProduct[]>(request, null, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXBoolean>> SetQuoteProductsAsync(List<OKXQuoteProduct> quoteProducts, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "quoteProducts", quoteProducts}
        };

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"maker-instrument-settings", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(3), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXBoolean>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXTime>> ResetMMPStatusAsync(CancellationToken ct = default)
    {
        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/mmp-reset", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXTime>(request, null, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<MMPConfigResponse>> SetMMPConfigAsync(string timeInterval, string frozenInterval, string countLimit, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "timeInterval", timeInterval},
            { "frozenInterval",frozenInterval},
            { "countLimit",countLimit}
        };

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/mmp-config", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(10), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<MMPConfigResponse>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXQuote>> CreateQuoteAsync(string rfqId, string? clientQuoteId, OrderSide quoteSide, List<OKXQuoteLeg> legs, string? tag = null, bool? anonymous = null, string? expiresIn = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "rfqId", rfqId}
        };
        parameters.AddOptional("clQuoteId", clientQuoteId);
        parameters.AddOptional("quoteSide", quoteSide);
        parameters.AddOptional("legs", legs);
        parameters.AddOptional("tag", tag);
        parameters.AddOptional("anonymous", anonymous);
        parameters.AddOptional("expiresIn", expiresIn);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/create-quote", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(50, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXQuote>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXCancelQuoteResponse>> CancelQuoteAsync(string? quoteId = null, string? clientQuoteId = null, string? rfqId = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("quoteId", quoteId);
        parameters.AddOptional("clQuoteId", clientQuoteId);
        parameters.AddOptional("rfqId", rfqId);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-quote", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(50, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXCancelQuoteResponse>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXCancelQuoteResponse[]>> CancelMultipleQuotesAsync(List<string>? quoteIds = null, List<string>? clientQuoteIds = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("quoteIds", quoteIds);
        parameters.AddOptional("clQuoteIds", clientQuoteIds);

        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-batch-quotes", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXCancelQuoteResponse[]>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXTime>> CancelAllQuotesAsync(CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        var request = _definitions.GetOrCreate(HttpMethod.Post, $"/api/v5/rfq/cancel-all-quotes", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendGetSingleAsync<OKXTime>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXRfq[]>> GetRFQsAsync(string? rfqId = null, string? clientRfqId = null, RFQStatus? state = null, string? beginId = null, string? endId = null, string? limit = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", rfqId);
        parameters.AddOptional("clRfqId", clientRfqId);
        parameters.AddOptional("state", state);
        parameters.AddOptional("beginId", beginId);
        parameters.AddOptional("endId", endId);
        parameters.AddOptional("limit", limit);

        var request = _definitions.GetOrCreate(HttpMethod.Get, $"/api/v5/rfq/rfqs", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXRfq[]>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXQuote[]>> GetQuotesAsync(string? rfqId = null, string? clientRfqId = null, string? quoteId = null, string? clientQuoteId = null, QuoteStatus? state = null, string? beginId = null, string? endId = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", rfqId);
        parameters.AddOptional("clRfqId", clientRfqId);
        parameters.AddOptional("quoteId", quoteId);
        parameters.AddOptional("clQuoteId", clientQuoteId);
        parameters.AddOptional("state", state);
        parameters.AddOptional("beginId", beginId);
        parameters.AddOptional("endId", endId);
        parameters.AddOptional("limit", limit);

        var request = _definitions.GetOrCreate(HttpMethod.Get, $"/api/v5/rfq/quotes", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(2, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXQuote[]>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<WebCallResult<OKXBlockTrade[]>> GetTradesAsync(string? rfqId = null, string? clientRfqId = null, string? quoteId = null, 
        string? blockTdId = null, string? clientQuoteId = null, string? beginId = null, string? endId = null,
        long? beginTs = null, long? endTs = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", rfqId);
        parameters.AddOptional("clRfqId", clientRfqId);
        parameters.AddOptional("quoteId", quoteId);
        parameters.AddOptional("blockTdId", blockTdId);
        parameters.AddOptional("clQuoteId", clientQuoteId);
        parameters.AddOptional("beginId", beginId);
        parameters.AddOptional("endId", endId);
        parameters.AddOptional("beginTs", beginTs);
        parameters.AddOptional("endTs", endTs);
        parameters.AddOptional("limit", limit);

        var request = _definitions.GetOrCreate(HttpMethod.Get, $"/api/v5/rfq/trades", OKXExchange.RateLimiter.EndpointGate, 1, true,
            limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(2), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
        return await _baseClient.SendAsync<OKXBlockTrade[]>(request, parameters, ct).ConfigureAwait(false);
    }
}
