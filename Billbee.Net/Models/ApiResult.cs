namespace Billbee.Net.Models;

/// <summary>
///     Single entry result set for API requests.
/// </summary>
/// <typeparam name="T">Type of content as part of the result.</typeparam>
public class ApiResult<T>
{
    /// <summary>
    ///     Enumeration of possible error codes.
    /// </summary>
    public enum ErrorCodeEnum
    {
        NoError = 0,
        ApiNotActivated,
        OrderNotFound,
        InvoiceNotCreated,
        CantCreateInvoice,
        OrderCanceled,
        OrderDeleted,
        OrderNotPaid,
        InternalError,
        OrderExists,
        WrongShopId,
        InvalidData,
        CreateUser_DuplicateEmail,
        CreateUser_InvalidEmail,
        CreateUser_UserRejected,
        CreateUser_TermsNotAccepted,
        NoPaidAccount,
        APIServiceNotBooked,
        CantCreateDeliveryNote
    }

    /// <summary>
    ///     Gets a value indicating whether the request was successful.
    /// </summary>
    public bool Success => ErrorMessage == null && ErrorCode == ErrorCodeEnum.NoError;

    /// <summary>
    ///     Gets or sets the detailed error message if the request failed.
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    ///     Gets or sets the error code if the request failed.
    /// </summary>
    /// <remarks>
    ///     See <see cref="ErrorCodeEnum" /> for possible values.
    /// </remarks>
    public ErrorCodeEnum ErrorCode { get; set; }

    /// <summary>
    ///     Gets or sets the response content of the request.
    /// </summary>
    public T Data { get; set; }
}

/// <summary>
///     Multi-entry result set for API requests with paging behavior.
/// </summary>
/// <typeparam name="T">Type of content as part of the result, typically of type IEnumerable.</typeparam>
public class ApiPagedResult<T> : ApiResult<T>
{
    /// <summary>
    ///     Gets or sets the paging information for the result set.
    /// </summary>
    public PagingInformation Paging { get; set; }

    /// <summary>
    ///     Information about the paging.
    /// </summary>
    public class PagingInformation
    {
        /// <summary>
        ///     Gets or sets the currently delivered page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        ///     Gets or sets the total count of pages available with the given <see cref="PageSize" />.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Gets or sets the total count of available datasets.
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        ///     Gets or sets the number of entries each page should contain.
        /// </summary>
        public int PageSize { get; set; }
    }
}