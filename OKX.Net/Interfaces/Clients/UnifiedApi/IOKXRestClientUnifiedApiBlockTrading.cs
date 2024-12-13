using OKX.Net.Objects.BlockTrading;
using OKX.Net.Objects.Public;
using OKX.Net.Objects.Trade;

namespace OKX.Net.Interfaces.Clients.UnifiedApi;

/// <summary>
/// Unified API trading endpoints
/// </summary>
public interface IOKXRestClientUnifiedApiBlockTrading
{
    /// <summary>
    /// Retrieves the list of counterparties that the user is permitted to trade with.
    /// <para><a href="https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-get-counterparties" /></para>
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<WebCallResult<IEnumerable<OKXCounterparty>>> GetCounterpartiesAsync(CancellationToken ct = default);


    /// <summary>
    /// Creates a Request For Quote (RFQ) asynchronously.
    /// </summary>
    /// <param name="counterparties">The trader code(s) of the counterparties who receive the RFQ. Can be found via /api/v5/rfq/counterparties/. This parameter is required.</param>
    /// <param name="legs">An array of objects containing each leg of the RFQ. Maximum 15 legs can be placed per request. This parameter is required.</param>
    /// <param name="anonymous">Submit RFQ on a disclosed or anonymous basis. Valid values are true or false. If not specified, the default value is false. When anonymous = true, the taker’s identity is not disclosed to the maker even after trade execution.</param>
    /// <param name="clientRfqId">Client-supplied RFQ ID. A combination of case-sensitive alpha-numeric, all numbers, or all letters of up to 32 characters.</param>
    /// <param name="tag">RFQ tag. The block trade associated with the RFQ will have the same tag. A combination of case-sensitive alphanumerics, all numbers, or all letters of up to 16 characters.</param>
    /// <param name="allowPartialExecution">Whether the RFQ can be partially filled provided that the shape of legs stays the same. Valid values are true or false. Default is false.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{OKXOrderAmendResponse}"/>.</returns>
    Task<WebCallResult<OKXCreateRFQResponse>> CreateRFQAsync(
        List<string> counterparties,
        List<OKXRFQLeg> legs,
        bool? anonymous = null,
        string? clientRfqId = null,
        string? tag = null,
        bool? allowPartialExecution = null,
        CancellationToken ct = default);


    /// <summary>
    /// Cancels an existing active RFQ that you have created previously.
    /// <para> <a href ="https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-rfq"/></para>
    /// </summary>
    /// <param name="rfqId">RFQ ID created. This parameter is conditional. Either rfqId or clRfqId is required. If both are passed, rfqId will be used.</param>
    /// <param name="clientRfqId">Client-supplied RFQ ID. A combination of case-sensitive alphanumerics, all numbers, or all letters of up to 32 characters. This parameter is conditional. Either rfqId or clRfqId is required. If both are passed, rfqId will be used.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 5 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-rfq
    /// </remarks>
    Task<WebCallResult<OKXCancelRFQResponse>> CancelRFQAsync(string? rfqId = null, string? clientRfqId = null, CancellationToken ct = default);


    /// <summary>
    /// Cancel one or multiple active RFQ(s) in a single batch. Maximum 100 RFQ orders can be canceled per request.
    /// <para> <a href ="https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-multiple-rfqs"/></para>
    /// </summary>
    /// <param name="rfqIds">RFQ IDs created. This parameter is conditional. Either rfqIds or clRfqIds is required. If both are passed, rfqIds will be used.</param>
    /// <param name="clientRfqIds">Client-supplied RFQ IDs. This parameter is conditional.  Either rfqIds or clRfqIds is required. If both are passed, rfqIds will be used.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-rfq
    /// </remarks>
    Task<WebCallResult<IEnumerable<OKXCancelRFQResponse>>> CancelMultipleRFQAsync(List<string>? rfqIds = null, List<string>? clientRfqIds = null, CancellationToken ct = default);


    /// <summary>
    /// Cancels all active RFQs
    /// <para> <a href ="https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-all-rfqs"/></para>
    /// </summary>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-all-rfq
    /// </remarks>
    Task<WebCallResult<OKXTime>> CancelAllRFQAsync(CancellationToken ct = default);


    /// <summary>
    /// Executes a Quote. This operation is only used by the creator of the RFQ.
    /// <para> <a href ="https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-execute-quote"/></para>
    /// </summary>
    /// <param name="rfqId">RFQ ID. This parameter is required.</param>
    /// <param name="quoteId">Quote ID. This parameter is required.</param>
    /// <param name="legs">An array of objects containing the execution size of each leg of the RFQ. The ratio of the leg sizes needs to be the same as the RFQ. Note: tgtCcy and side of each leg will be same as ones in the RFQ. px will be the same as the ones in the Quote.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 3 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/execute-quote
    /// </remarks>
    Task<WebCallResult<OKXBlockTrade>> ExecuteQuoteAsync(string rfqId, string quoteId, List<OKXExecuteQuoteLeg> legs = null, CancellationToken ct = default);


    /// <summary>
    /// Retrieves the products which makers want to quote and receive RFQs for, and the corresponding price and size limit.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-get-quote-products
    /// </summary>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="IEnumerable<OKXQuoteProduct>"/>.</returns>
    /// <remarks>
    /// Rate Limit: 5 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: GET /api/v5/rfq/maker-instrument-settings
    /// </remarks>
    Task<WebCallResult<IEnumerable<OKXQuoteProduct>>> GetQuoteProductsAsync(CancellationToken ct = default);

    /// <summary>
    /// Customizes the products which makers want to quote and receive RFQs for, and the corresponding price and size limit.
    /// </summary>
    /// <param name="quoteProducts">A list of products which makers want to quote and receive RFQs for, including the corresponding price and size limit.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 5 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/maker-instrument-settings
    /// </remarks>
    Task<WebCallResult<OKXBoolean>> SetQuoteProductsAsync(List<OKXQuoteProduct> quoteProducts, CancellationToken ct = default);


    /// <summary>
    /// Resets the MMP (Market Maker Protection) status to be inactive.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-reset-mmp-status
    /// </summary>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{T}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 5 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/mmp-reset
    /// </remarks>
    Task<WebCallResult<OKXTime>> ResetMMPStatusAsync(CancellationToken ct = default);

    /// <summary>
    /// Sets the MMP (Market Maker Protection) configuration. Only applicable to block trading makers.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-set-mmp
    /// </summary>
    /// <param name="timeInterval">Time window (ms). MMP interval where monitoring is done. "0" means disable MMP. Maximum time interval is 600,000. This parameter is required.</param>
    /// <param name="frozenInterval">Frozen period (ms). "0" means the trade will remain frozen until you request "Reset MMP Status" to unfreeze. This parameter is required.</param>
    /// <param name="countLimit">Limit in number of execution attempts. This parameter is required.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{MMPConfigResponse}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 1 request per 10 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/mmp-config
    /// </remarks>
    Task<WebCallResult<MMPConfigResponse>> SetMMPConfigAsync(string timeInterval, string frozenInterval, string countLimit, CancellationToken ct = default);

    /// <summary>
    /// Allows the user to quote an RFQ that they are a counterparty to. The user MUST quote the entire RFQ and not part of the legs or part of the quantity. Partial quoting is not allowed.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-create-quote
    /// </summary>
    /// <param name="rfqId">RFQ ID. This parameter is required.</param>
    /// <param name="clientQuoteId">Client-supplied Quote ID. A combination of case-sensitive alphanumerics, all numbers, or all letters of up to 32 characters.</param>
    /// <param name="quoteSide">The trading direction of the Quote. Its value can be buy or sell. For example, if quoteSide is buy, all the legs are executed in their leg sides; otherwise, all the legs are executed in the opposite of their leg sides. This parameter is required.</param>
    /// <param name="legs">The legs of the Quote. This parameter is required.</param>
    /// <param name="tag">Quote tag. The block trade associated with the Quote will have the same tag. A combination of case-sensitive alphanumerics, all numbers, or all letters of up to 16 characters.</param>
    /// <param name="anonymous">Submit Quote on a disclosed or anonymous basis. Valid value is true or false. False by default.</param>
    /// <param name="expiresIn">Seconds that a quote expires in. Must be an integer between 10-120. Default is 60.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{OKXOrderAmendResponse}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 50 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/create-quote
    /// </remarks>
    Task<WebCallResult<OKXCreateQuoteResponse>> CreateQuoteAsync(
        string rfqId,
        string? clientQuoteId,
        Enums.OrderSide quoteSide,
        List<OKXCreateQuoteLeg> legs,
        string? tag = null,
        bool? anonymous = null,
        string? expiresIn = null,
        CancellationToken ct = default);

    /// <summary>
    /// Cancels an existing active Quote you have created in response to an RFQ.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-quote
    /// </summary>
    /// <param name="quoteId">Quote ID. This parameter is conditional.</param>
    /// <param name="clientQuoteId">Client-supplied Quote ID. Either quoteId or clientQuoteId is required. If both clientQuoteId and quoteId are passed, quoteId will be treated as the primary identifier. This parameter is conditional.</param>
    /// <param name="rfqId">RFQ ID. This parameter is optional.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{CancelQuoteResponse}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 50 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-quote
    /// </remarks>
    Task<WebCallResult<OKXCancelQuoteResponse>> CancelQuoteAsync(
        string? quoteId = null,
        string? clientQuoteId = null,
        string? rfqId = null,
        CancellationToken ct = default);

    /// <summary>
    /// Cancels one or multiple active Quote(s) in a single batch. Maximum 100 quote orders can be canceled per request.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-multiple-quotes
    /// </summary>
    /// <param name="quoteIds">List of Quote IDs. This parameter is conditional.</param>
    /// <param name="clientQuoteIds">List of client-supplied Quote IDs. This parameter is conditional. Either quoteIds or clientQuoteIds is required. If both are sent, quoteIds will be used as the primary identifier.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult<List{CancelQuoteResponse}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-batch-quotes
    /// </remarks>
    Task<WebCallResult<IEnumerable<OKXCancelQuoteResponse>>> CancelMultipleQuotesAsync(
        List<string>? quoteIds = null,
        List<string>? clientQuoteIds = null,
        CancellationToken ct = default);

    /// <summary>
    /// Cancels all active Quotes.
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-cancel-all-quotes
    /// </summary>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{CancelAllQuotesResponse}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: POST /api/v5/rfq/cancel-all-quotes
    /// </remarks>
    Task<WebCallResult<OKXTime>> CancelAllQuotesAsync(CancellationToken ct = default);

    /// <summary>
    /// Retrieves details of RFQs that the user is a counterparty to (either as the creator or the receiver of the RFQ).
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-get-rfqs
    /// </summary>
    /// <param name="rfqId">RFQ ID. This parameter is optional.</param>
    /// <param name="clientRfqId">Client-supplied RFQ ID. If both clientRfqId and rfqId are passed, rfqId will be treated as the primary identifier. This parameter is optional.</param>
    /// <param name="state">The status of the RFQ. Valid values can be active, canceled, pending_fill, filled, expired, failed, traded_away. This parameter is optional.</param>
    /// <param name="beginId">Start RFQ ID the request to begin with. Pagination of data to return records newer than the requested RFQ ID, not including beginId. This parameter is optional.</param>
    /// <param name="endId">End RFQ ID the request to end with. Pagination of data to return records earlier than the requested RFQ ID, not including endId. This parameter is optional.</param>
    /// <param name="limit">Number of results per request. The maximum is 100, which is also the default value. This parameter is optional.</param>
    /// <param name="ct">Cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task representing the asynchronous operation, with a result of type <see cref="WebCallResult{IEnumerable{RFQDetails}}"/>.</returns>
    /// <remarks>
    /// Rate Limit: 2 requests per 2 seconds
    /// Rate limit rule: UserID
    /// HTTP Request: GET /api/v5/rfq/rfqs
    /// </remarks>
    Task<WebCallResult<IEnumerable<OKXRFQUpdate>>> GetRFQsAsync(
        string? rfqId = null,
        string? clientRfqId = null,
        RFQStatus? state = null,
        string? beginId = null,
        string? endId = null,
        string? limit = null,
        CancellationToken ct = default);

    /// <summary>
    /// Retrieves all quotes that the user is a counterparty to (either as the creator or the receiver).
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-get-quotes
    /// </summary>
    /// <param name="rfqId">RFQ ID.</param>
    /// <param name="clientRfqId">Client-supplied RFQ ID. If both clientRfqId and rfqId are passed, rfqId will be treated as primary identifier.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="clientQuoteId">Client-supplied Quote ID. If both clientQuoteId and quoteId are passed, quoteId will be treated as primary identifier.</param>
    /// <param name="state">The status of the quote (e.g., active, canceled, pending_fill, filled, expired, failed).</param>
    /// <param name="beginId">Start quote ID for pagination.</param>
    /// <param name="endId">End quote ID for pagination.</param>
    /// <param name="limit">Number of results per request (default is 100, maximum is 100).</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Task representing the asynchronous operation, containing a list of quotes.</returns>
    public Task<WebCallResult<IEnumerable<OKXQuoteUpdate>>> GetQuotesAsync(
        string? rfqId = null,
        string? clientRfqId = null,
        string? quoteId = null,
        string? clientQuoteId = null,
        QuoteStatus? state = null,
        string? beginId = null,
        string? endId = null,
        int? limit = null,
        CancellationToken ct = default);

    /// <summary>
    /// Retrieves the executed trades that the user is a counterparty to (either as the creator or the receiver).
    /// https://www.okx.com/docs-v5/en/?shell#block-trading-rest-api-get-trades
    /// </summary>
    /// <param name="rfqId">RFQ ID.</param>
    /// <param name="clientRfqId">Client-supplied RFQ ID. If both clientRfqId and rfqId are passed, rfqId will be treated as primary identifier.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="blockTdId">Block trade ID.</param>
    /// <param name="clientQuoteId">Client-supplied Quote ID. If both clientQuoteId and quoteId are passed, quoteId will be treated as primary identifier.</param>
    /// <param name="beginId">The starting RFQ ID for pagination.</param>
    /// <param name="endId">The last RFQ ID for pagination.</param>
    /// <param name="beginTs">Filter trade execution time with a begin timestamp (UTC timezone). Unix timestamp format in milliseconds.</param>
    /// <param name="endTs">Filter trade execution time with an end timestamp (UTC timezone). Unix timestamp format in milliseconds.</param>
    /// <param name="limit">Number of results per request. The maximum is 100, which is also the default value.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Task representing the asynchronous operation, containing a list of trades.</returns>
    Task<WebCallResult<IEnumerable<OKXBlockTrade>>> GetTradesAsync(
            string? rfqId = null,
            string? clientRfqId = null,
            string? quoteId = null,
            string? blockTdId = null,
            string? clientQuoteId = null,
            string? beginId = null,
            string? endId = null,
            long? beginTs = null,
            long? endTs = null,
            int? limit = null,
            CancellationToken ct = default);

}