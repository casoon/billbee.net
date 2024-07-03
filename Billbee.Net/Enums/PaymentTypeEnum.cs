namespace Billbee.Net.Enums;

/// <summary>
///     Represents the possible payment types.
/// </summary>
public enum PaymentTypeEnum
{
    /// <summary>
    ///     Bank transfer payment.
    /// </summary>
    Bankueberweisung = 1,

    /// <summary>
    ///     Cash on delivery payment.
    /// </summary>
    Nachnahme = 2,

    /// <summary>
    ///     PayPal payment.
    /// </summary>
    PayPal = 3,

    /// <summary>
    ///     Cash payment.
    /// </summary>
    Barzahlung = 4,

    /// <summary>
    ///     Voucher payment.
    /// </summary>
    Gutschein = 6,

    /// <summary>
    ///     Sofortüberweisung payment.
    /// </summary>
    Sofortueberweisung = 19,

    /// <summary>
    ///     Etsy Money Order payment.
    /// </summary>
    MoneyOrder = 20,

    /// <summary>
    ///     Etsy Check payment.
    /// </summary>
    Check = 21,

    /// <summary>
    ///     Other payment method.
    /// </summary>
    Andere = 22,

    /// <summary>
    ///     Direct debit payment.
    /// </summary>
    Lastschrift = 23,

    /// <summary>
    ///     Moneybookers payment.
    /// </summary>
    Moneybookers = 24,

    /// <summary>
    ///     KLARNA Invoice payment.
    /// </summary>
    KLARNA_Invoice = 25,

    /// <summary>
    ///     Invoice payment.
    /// </summary>
    Rechnung = 26,

    /// <summary>
    ///     Moneybookers credit card payment.
    /// </summary>
    Moneybookers_Kreditkarte = 27,

    /// <summary>
    ///     Moneybookers direct debit payment.
    /// </summary>
    Moneybookers_Lastschrift = 28,

    /// <summary>
    ///     BILLPAY Invoice payment.
    /// </summary>
    BILLPAY_Rechnung = 29,

    /// <summary>
    ///     BILLPAY direct debit payment.
    /// </summary>
    BILLPAY_Lastschrift = 30,

    /// <summary>
    ///     Credit card payment.
    /// </summary>
    Kreditkarte = 31,

    /// <summary>
    ///     Maestro payment.
    /// </summary>
    Maestro = 32,

    /// <summary>
    ///     iDEAL payment.
    /// </summary>
    iDEAL = 33,

    /// <summary>
    ///     EPS payment.
    /// </summary>
    EPS = 34,

    /// <summary>
    ///     P24 payment.
    /// </summary>
    P24 = 35,

    /// <summary>
    ///     ClickAndBuy payment.
    /// </summary>
    ClickAndBuy = 36,

    /// <summary>
    ///     GiroPay payment.
    /// </summary>
    GiroPay = 37,

    /// <summary>
    ///     Novalnet direct debit payment.
    /// </summary>
    Novalnet_Lastschrift = 38,

    /// <summary>
    ///     KLARNA Part Payment.
    /// </summary>
    KLARNA_PartPayment = 39,

    /// <summary>
    ///     iPayment credit card payment.
    /// </summary>
    iPayment_CC = 40,

    /// <summary>
    ///     Billsafe payment.
    /// </summary>
    Billsafe = 41,

    /// <summary>
    ///     Test order payment.
    /// </summary>
    Testbestellung = 42,

    /// <summary>
    ///     WireCard credit card payment.
    /// </summary>
    WireCard_Kreditkarte = 43,

    /// <summary>
    ///     Amazon Payments.
    /// </summary>
    AmazonPayments = 44,

    /// <summary>
    ///     Secupay credit card payment.
    /// </summary>
    Secupay_Kreditkarte = 45,

    /// <summary>
    ///     Secupay direct debit payment.
    /// </summary>
    Secupay_Lastschrift = 46,

    /// <summary>
    ///     WireCard direct debit payment.
    /// </summary>
    WireCard_Lastschrift = 47,

    /// <summary>
    ///     EC payment.
    /// </summary>
    EC = 48,

    /// <summary>
    ///     Paymill credit card payment.
    /// </summary>
    Paymill_Kreditkarte = 49,

    /// <summary>
    ///     Novalnet credit card payment.
    /// </summary>
    Novalnet_Kreditkarte = 50,

    /// <summary>
    ///     Novalnet invoice payment.
    /// </summary>
    Novalnet_Rechnung = 51,

    /// <summary>
    ///     Novalnet PayPal payment.
    /// </summary>
    Novalnet_PayPal = 52,

    /// <summary>
    ///     Paymill payment.
    /// </summary>
    Paymill = 53,

    /// <summary>
    ///     PayPal invoice payment.
    /// </summary>
    Rechnung_PayPal = 54,

    /// <summary>
    ///     Selekkt payment.
    /// </summary>
    Selekkt = 55,

    /// <summary>
    ///     Avocadostore payment.
    /// </summary>
    Avocadostore = 56,

    /// <summary>
    ///     Direct checkout payment.
    /// </summary>
    DirectCheckout = 57,

    /// <summary>
    ///     Rakuten payment.
    /// </summary>
    Rakuten = 58,

    /// <summary>
    ///     Prepayment.
    /// </summary>
    Vorkasse = 59,

    /// <summary>
    ///     Commission settlement payment.
    /// </summary>
    Kommissionsabrechnung = 60,

    /// <summary>
    ///     Amazon Marketplace payment.
    /// </summary>
    Amazon_Marketplace = 61,

    /// <summary>
    ///     Amazon Payments Advanced.
    /// </summary>
    Amazon_Payments_Advanced = 62,

    /// <summary>
    ///     Stripe payment.
    /// </summary>
    Stripe = 63,

    /// <summary>
    ///     BILLPAY Pay Later payment.
    /// </summary>
    BILLPAY_PayLater = 64,

    /// <summary>
    ///     PostFinance payment.
    /// </summary>
    PostFinance = 65,

    /// <summary>
    ///     iZettle payment.
    /// </summary>
    iZettle = 66,

    /// <summary>
    ///     SumUp payment.
    /// </summary>
    SumUp = 67,

    /// <summary>
    ///     Payleven payment.
    /// </summary>
    payleven = 68,

    /// <summary>
    ///     Atalanda payment.
    /// </summary>
    atalanda = 69,

    /// <summary>
    ///     Saferpay credit card payment.
    /// </summary>
    Saferpay_Kreditkarte = 70,

    /// <summary>
    ///     WireCard PayPal payment.
    /// </summary>
    WireCard_PayPal = 71,

    /// <summary>
    ///     Micropayment.
    /// </summary>
    Micropayment = 72,

    /// <summary>
    ///     Installment purchase payment.
    /// </summary>
    Ratenkauf = 73,

    /// <summary>
    ///     Wayfair payment.
    /// </summary>
    Wayfair = 74,

    /// <summary>
    ///     MangoPay PayPal payment.
    /// </summary>
    MangoPay_PayPal = 75,

    /// <summary>
    ///     MangoPay Sofortüberweisung payment.
    /// </summary>
    MangoPay_Sofortueberweisung = 76,

    /// <summary>
    ///     MangoPay credit card payment.
    /// </summary>
    MangoPay_Kreditkarte = 77,

    /// <summary>
    ///     MangoPay iDeal payment.
    /// </summary>
    MangoPay_iDeal = 78,

    /// <summary>
    ///     PayPal Express payment.
    /// </summary>
    PayPal_Express = 79,

    /// <summary>
    ///     PayPal direct debit payment.
    /// </summary>
    PayPal_Lastschrift = 80,

    /// <summary>
    ///     PayPal credit card payment.
    /// </summary>
    PayPal_Kreditkarte = 81,

    /// <summary>
    ///     Wish payment.
    /// </summary>
    Wish = 82,

    /// <summary>
    ///     Bancontact/Mister Cash payment.
    /// </summary>
    Bancontact_Mister_Cash = 83,

    /// <summary>
    ///     Belfius Direct Net payment.
    /// </summary>
    Belfius_Direct_Net = 84,

    /// <summary>
    ///     KBC/CBC Betaalknop payment.
    /// </summary>
    KBC_CBC_Betaalknop = 85,

    /// <summary>
    ///     Novalnet Przelewy24 payment.
    /// </summary>
    Novalnet_Przelewy24 = 86,

    /// <summary>
    ///     Novalnet prepayment.
    /// </summary>
    Novalnet_Vorkasse = 87,

    /// <summary>
    ///     Novalnet instant bank payment.
    /// </summary>
    Novalnet_Instantbank = 88,

    /// <summary>
    ///     Novalnet iDEAL payment.
    /// </summary>
    Novalnet_IDEAL = 89,

    /// <summary>
    ///     Novalnet EPS payment.
    /// </summary>
    Novalnet_EPS = 90,

    /// <summary>
    ///     Novalnet GiroPay payment.
    /// </summary>
    Novalnet_GiroPay = 91,

    /// <summary>
    ///     Novalnet Barzahlen payment.
    /// </summary>
    Novalnet_Barzahlen = 92,

    /// <summary>
    ///     Real payment.
    /// </summary>
    Real = 93,

    /// <summary>
    ///     Fruugo payment.
    /// </summary>
    Fruugo = 94,

    /// <summary>
    ///     Cdiscount payment.
    /// </summary>
    Cdiscount = 95,

    /// <summary>
    ///     PayDirekt payment.
    /// </summary>
    PayDirekt = 96,

    /// <summary>
    ///     Etsy Payments.
    /// </summary>
    EtsyPayments = 97,

    /// <summary>
    ///     KLARNA payment.
    /// </summary>
    KLARNA = 98,

    /// <summary>
    ///     Limango payment.
    /// </summary>
    limango = 99,

    /// <summary>
    ///     Santander installment purchase payment.
    /// </summary>
    SantanderRatenkauf = 100,

    /// <summary>
    ///     Santander invoice payment.
    /// </summary>
    SantanderRechnungskauf = 101,

    /// <summary>
    ///     Cashpresso payment.
    /// </summary>
    Cashpresso = 102,

    /// <summary>
    ///     Tipser payment.
    /// </summary>
    Tipser = 103,

    /// <summary>
    ///     eBay payment.
    /// </summary>
    Ebay = 104,

    /// <summary>
    ///     Mollie payment.
    /// </summary>
    Mollie = 105,

    /// <summary>
    ///     Mollie invoice payment.
    /// </summary>
    MollieInvoice = 106,

    /// <summary>
    ///     Mollie credit card payment.
    /// </summary>
    MollieCreditCard = 107,

    /// <summary>
    ///     Mollie Sofort payment.
    /// </summary>
    MollieSofort = 108,

    /// <summary>
    ///     Mollie GiroPay payment.
    /// </summary>
    MollieGiroPay = 109,

    /// <summary>
    ///     Mollie Maestro payment.
    /// </summary>
    MollieMaestro = 110,

    /// <summary>
    ///     Mollie KLARNA Pay Later payment.
    /// </summary>
    MollieKlarnaPayLater = 111,

    /// <summary>
    ///     Mollie PayPal payment.
    /// </summary>
    MolliePayPal = 112,

    /// <summary>
    ///     Apple Pay payment.
    /// </summary>
    ApplePay = 113,

    /// <summary>
    ///     Braintree payment.
    /// </summary>
    Braintree = 114,

    /// <summary>
    ///     Braintree credit card payment.
    /// </summary>
    BraintreeCreditCard = 115,

    /// <summary>
    ///     Braintree PayPal payment.
    /// </summary>
    BraintreePayPal = 116,

    /// <summary>
    ///     Mollie iDEAL payment.
    /// </summary>
    MollieIdeal = 117,

    /// <summary>
    ///     Scalapay payment.
    /// </summary>
    Scalapay = 118,

    /// <summary>
    ///     Otto Payments.
    /// </summary>
    OttoPayments = 119,

    /// <summary>
    ///     Idealo Direktkauf Payments.
    /// </summary>
    IdealoDirektkaufPayments = 120,

    /// <summary>
    ///     EasyCredit payment.
    /// </summary>
    EasyCredit = 121,

    /// <summary>
    ///     Mollie Apple Pay payment.
    /// </summary>
    MollieApplePay = 122,

    /// <summary>
    ///     Mollie EPS payment.
    /// </summary>
    MollieEPS = 123,

    /// <summary>
    ///     CrefoPay Prepaid payment.
    /// </summary>
    CrefoPayPrepaid = 124,

    /// <summary>
    ///     Mollie Bancontact payment.
    /// </summary>
    MollieBancontact = 125
}