namespace Billbee.Net.Enums;

/// <summary>
///     Represents the possible event types.
/// </summary>
public enum EventTypeEnum
{
    /// <summary>
    ///     Event when an order is imported.
    /// </summary>
    OrderImported,

    /// <summary>
    ///     Event when a bill is printed.
    /// </summary>
    BillPrinted,

    /// <summary>
    ///     Event when a label is printed.
    /// </summary>
    LabelPrinted,

    /// <summary>
    ///     Event when an account is created.
    /// </summary>
    AccountCreated,

    /// <summary>
    ///     Event when an account is deleted.
    /// </summary>
    AccountDeleted,

    /// <summary>
    ///     Event when an order is deleted.
    /// </summary>
    OrderDeleted,

    /// <summary>
    ///     Event when an order detail is deleted.
    /// </summary>
    OrderDetailDeleted,

    /// <summary>
    ///     Event when an order detail is added.
    /// </summary>
    OrderDetailAdded,

    /// <summary>
    ///     Event when an account is synced.
    /// </summary>
    AccountSynced,

    /// <summary>
    ///     Event when an order state is synced.
    /// </summary>
    OrderStateSynced,

    /// <summary>
    ///     Event when an order is exported.
    /// </summary>
    OrderExported,

    /// <summary>
    ///     Event when a delivery note is printed.
    /// </summary>
    DeliveryNotePrinted,

    /// <summary>
    ///     Event when an order is shipped.
    /// </summary>
    OrderShipped,

    /// <summary>
    ///     Event when an order is paid.
    /// </summary>
    OrderPaid,

    /// <summary>
    ///     Event when a user is assigned to an order.
    /// </summary>
    UserAssignedToOrder,

    /// <summary>
    ///     Event when an order state is changed.
    /// </summary>
    OrderStateChanged,

    /// <summary>
    ///     Event when customers are joined.
    /// </summary>
    CustomersJoined,

    /// <summary>
    ///     Event when an email address is changed.
    /// </summary>
    EMailChanged,

    /// <summary>
    ///     Event when a shipment is created.
    /// </summary>
    ShipmentCreated,

    /// <summary>
    ///     Event when an order commit is printed.
    /// </summary>
    OrderCommitPrinted,

    /// <summary>
    ///     Event when an order is forwarded.
    /// </summary>
    OrderForwarded,

    /// <summary>
    ///     Event when there is an account sync error.
    /// </summary>
    AccountSyncError,

    /// <summary>
    ///     Event when a customer downloads an invoice.
    /// </summary>
    CustomerInvoiceDownload,

    /// <summary>
    ///     Event when a customer is notified.
    /// </summary>
    CustomerNotified,

    /// <summary>
    ///     Event when an order is canceled.
    /// </summary>
    OrderCanceled,

    /// <summary>
    ///     Event when there is a shipment status update.
    /// </summary>
    ShipmentStatus,

    /// <summary>
    ///     Event when a customer file is downloaded.
    /// </summary>
    CustomerFileDownload,

    /// <summary>
    ///     Event when a payment is imported.
    /// </summary>
    PaymentImported,

    /// <summary>
    ///     Event when a rule is executed.
    /// </summary>
    RuleExecuted,

    /// <summary>
    ///     Event when an order is created by the API.
    /// </summary>
    CreatedByApi,

    /// <summary>
    ///     Event when an offer is printed.
    /// </summary>
    OfferPrinted,

    /// <summary>
    ///     Event when an email is sent.
    /// </summary>
    EmailSent,

    /// <summary>
    ///     Event when an email fails to send.
    /// </summary>
    EmailFailed,

    /// <summary>
    ///     Event when forwarding an order fails.
    /// </summary>
    OrderForwardFailed,

    /// <summary>
    ///     Event when forwarding order data fails.
    /// </summary>
    OrderDataForwardFailed,

    /// <summary>
    ///     Event when sending a file to a cloud device fails.
    /// </summary>
    SendFileToCloudDeviceFailed,

    /// <summary>
    ///     Event when a user logs in.
    /// </summary>
    LogIn,

    /// <summary>
    ///     Event when a user logs out.
    /// </summary>
    LogOut,

    /// <summary>
    ///     Event when a service is booked.
    /// </summary>
    BookService,

    /// <summary>
    ///     Event when a service is canceled.
    /// </summary>
    CancelService,

    /// <summary>
    ///     Event when a user is impersonated.
    /// </summary>
    Impersonated,

    /// <summary>
    ///     Event when stock is synced.
    /// </summary>
    StockSynced,

    /// <summary>
    ///     Event when stock sync fails.
    /// </summary>
    StockSyncFailed,

    /// <summary>
    ///     Event when a file is uploaded.
    /// </summary>
    UploadedFile,

    /// <summary>
    ///     Event when a payment batch is read.
    /// </summary>
    PaymentBatchRead,

    /// <summary>
    ///     Event when a payment batch fails.
    /// </summary>
    PaymentBatchFailed,

    /// <summary>
    ///     Event when user account payment details are changed.
    /// </summary>
    UserAcountPayDetailsChanged,

    /// <summary>
    ///     Event when a translation occurs.
    /// </summary>
    Translate,

    /// <summary>
    ///     Event when a product is uploaded.
    /// </summary>
    ProductUploaded,

    /// <summary>
    ///     Event when an order is exported to bookkeeping.
    /// </summary>
    OrderExportedToBookkeeping,

    /// <summary>
    ///     Event when exporting an order to bookkeeping fails.
    /// </summary>
    OrderExportToBookkeepingFailed,

    /// <summary>
    ///     Event when a payment is exported to bookkeeping.
    /// </summary>
    PaymentExportedToBookkeeping,

    /// <summary>
    ///     Event when exporting a payment to bookkeeping fails.
    /// </summary>
    PaymentExportToBookkeepingFailed,

    /// <summary>
    ///     Event when the account payment type is changed.
    /// </summary>
    AccountPaymentTypeChanged,

    /// <summary>
    ///     Event when the account test phase is changed.
    /// </summary>
    AccountTestPhaseChanged,

    /// <summary>
    ///     Event for API usage.
    /// </summary>
    ApiUsage,

    /// <summary>
    ///     Event when uploading a product fails.
    /// </summary>
    ProductUploadFailed,

    /// <summary>
    ///     Event when the stock minimum is recalculated.
    /// </summary>
    RecalculatedStockMin,

    /// <summary>
    ///     Event when the desired stock level is recalculated.
    /// </summary>
    RecalculatedStockDesired,

    /// <summary>
    ///     Event when a shipment fails.
    /// </summary>
    ShipmentFailed,

    /// <summary>
    ///     Event when a customer file is downloaded from DaWanda.
    /// </summary>
    CustomerFileDownloadDaWanda,

    /// <summary>
    ///     Event when an order detail is modified.
    /// </summary>
    OrderDetailModified,

    /// <summary>
    ///     Event when an order is modified.
    /// </summary>
    OrderModified,

    /// <summary>
    ///     Event when an order state is transferred.
    /// </summary>
    OrderStateTransfered,

    /// <summary>
    ///     Event when transferring an order state fails.
    /// </summary>
    OrderStateTransferFailed,

    /// <summary>
    ///     Event when a payment is created.
    /// </summary>
    PaymentCreated
}