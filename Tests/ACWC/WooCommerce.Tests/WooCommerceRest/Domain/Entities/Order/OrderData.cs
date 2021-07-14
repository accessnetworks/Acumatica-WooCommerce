﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using ACSC.Tests.ShopifyRest.Commerce;
using ACSC.Tests.ShopifyRest.Domain.Entities.Common;
using ACSC.Tests.ShopifyRest.Domain.Entities.Customers;
using ACSC.Tests.ShopifyRest.Domain.Entities.Enumerations;
using ACSC.Tests.ShopifyRest.Domain.Entities.Products;
using ACSC.Tests.ShopifyRest.Domain.Entities.Shipping;
using Newtonsoft.Json;

namespace ACSC.Tests.ShopifyRest.Domain.Entities.Order
{
    public class OrderResponse : IEntityResponse<OrderData>
    {
        [JsonProperty("order")]
        public OrderData Data { get; set; }
    }

    public class OrdersResponse : IEntitiesResponse<OrderData>
    {
        [JsonProperty("orders")]
        public List<OrderData> Data { get; set; }
    }

    [JsonObject(Description = "Order")]
    [Description(ShopifyCaptions.OrderData)]
    public class OrderData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Id)]
        public long? Id { get; set; }

        [JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ParentId)]
        public string ParentId { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Status)]
        public string Status { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Currency)]
        public string Currency { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Version)]
        public string Version { get; set; }

        [JsonProperty("prices_include_tax", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.PriceIncludingTax)]
        public bool PricesIncludeTax { get; set; }

        [JsonProperty("date_created", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.DateCreated)]
        public DateTime DateCreated { get; set; }

        [JsonProperty("date_modified", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.DateModified)]
        public DateTime DateModified { get; set; }

        [JsonProperty("discount_total", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalDiscount)]
        public string TotalDiscount { get; set; }

        [JsonProperty("discount_tax", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.DiscountTax)]
        public string DiscountTax { get; set; }

        [JsonProperty("shipping_total", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ShippingTotal)]
        public string ShippingTotal { get; set; }

        [JsonProperty("shipping_tax", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ShippingCostTax)]
        public string ShippingCostTax { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.OrderTotal)]
        public string OrderTotal { get; set; }

        [JsonProperty("cart_tax", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.SubtotalTax)]
        public string SubtotalTax { get; set; }

        [JsonProperty("total_tax", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalTax)]
        public decimal? TotalTax { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.CustomerId)]
        public string CustomerId { get; set; }

        [JsonProperty("order_key", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.OrderId)]
        public string OrderId { get; set; }

        [JsonProperty("billing", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.BillingAddress)]
        public OrderAddressData BillingAddress { get; set; }

        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ShippingAddress)]
        public OrderAddressData ShippingAddress { get; set; }

        [JsonProperty("coupon_lines", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.CouponLines)]
        public List<OrderDiscountCodes> CouponLines { get; set; }

        //[JsonProperty("shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.ShippingLine)]
        //public List<OrderShippingLine> ShippingLine { get; set; }

        [JsonProperty("payment_method", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.PaymentMethod)]
        public string paymentMethod { get; set; }

        [JsonProperty("payment_method_title", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.PaymenMethodTitle)]
        public string paymentMethodTitle { get; set; }

        //[JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.TaxLine)]

        //public List<OrderTaxLine> TaxLine { get; set; } = new List<OrderTaxLine>();

        //public OrderData()
        //{
        //    LineItems = new List<OrderLineItem>();
        //    ShippingLines = new List<OrderShippingLine>();
        //    DiscountApplications = new List<OrderDiscountApplications>();
        //    DiscountCodes = new List<OrderDiscountCodes>();
        //}

        // <summary>
        // The ID of the app that created the order.
        // </summary>
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? AppId { get; set; }

        ///// <summary>
        ///// The mailing address associated with the payment method. This address is an optional field that won't be available on orders that do not require a payment method.
        ///// </summary>
        //[JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.BillingAddress)]
        //public OrderAddressData BillingAddress { get; set; }

        /// <summary>
        /// [READ-ONLY] The IP address of the browser used by the customer when they placed the order.
        /// </summary>
        [JsonProperty("browser_ip")]
        [ShouldNotSerialize]
        public string BrowserIP { get; set; }

        /// <summary>
        /// Whether the customer consented to receive email updates from the shop.
        /// </summary>
        [JsonProperty("buyer_accepts_marketing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BuyerAcceptsMarketing { get; set; }

        /// <summary>
        /// The reason why the order was canceled. Valid values:
        /// customer: The customer canceled the order.
        /// fraud: The order was fraudulent.
        /// inventory: Items in the order were not in inventory.
        /// declined: The payment was declined.
        /// other: A reason not in this list.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.CancelReason)]
        public OrderCancelReason CancelReason { get; set; }

        /// <summary>
        /// [READ-ONLY] The date and time ( ISO 8601 format) when the order was canceled.
        /// </summary>
        [JsonProperty("cancelled_at")]
        [ShouldNotSerialize]
        public DateTime? CancelledAt { get; set; }

        /// <summary>
        /// [READ-ONLY] The ID of the cart that's associated with the order.
        /// </summary>
        [JsonProperty("cart_token")]
        [ShouldNotSerialize]
        public string CartToken { get; set; }

        /// <summary>
        /// [READ-ONLY] Information about the browser that the customer used when they placed their order.
        /// </summary>
        [JsonProperty("client_details")]
        [ShouldNotSerialize]
        public OrderClientDetails ClientDetails { get; set; }

        /// <summary>
        /// [READ-ONLY] The date and time (ISO 8601 format) when the order was closed.
        /// </summary>
        [JsonProperty("closed_at")]
        [ShouldNotSerialize]
        public DateTime? ClosedAt { get; set; }

        /// <summary>
        /// [READ-ONLY] The autogenerated date and time (ISO 8601 format) when the order was created in Shopify. The value for this property cannot be changed.
        /// </summary>
        [JsonProperty("created_at")]
        [Description(ShopifyCaptions.DateCreated)]
        [ShouldNotSerialize]
        public DateTime? DateCreatedAt { get; set; }

        /// <summary>
        /// The three-letter code (ISO 4217 format) for the shop currency.
        /// </summary>
        //[JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.Currency)]
        //public string Currency { get; set; }

        /// <summary>
        /// Information about the customer.
        /// The order might not have a customer and apps should not depend on the existence of a customer object.
        /// This value might be null if the order was created through Shopify POS.
        /// </summary>
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Customer)]
        public CustomerData Customer { get; set; }

        /// <summary>
        /// [READ-ONLY] The two or three-letter language code, optionally followed by a region modifier.
        /// </summary>
        [JsonProperty("customer_locale")]
        [ShouldNotSerialize]
        public string CustomerLocale { get; set; }

        /// <summary>
        /// [READ-ONLY] An ordered list of stacked discount applications.
        /// The discount_applications property includes 3 types: discount_code, manual, and script. All 3 types share a common structure and have some type specific attributes.
        /// </summary>
        //[JsonProperty("coupon_lines")]
        //[ShouldNotSerialize]
        //public List<OrderDiscountApplications> DiscountApplications { get; set; }

        /// <summary>
        /// A list of discounts applied to the order.
        /// </summary>
        [JsonProperty("codes", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Discount)]
        public List<OrderDiscountCodes> DiscountCodes { get; set; }

        /// <summary>
        /// The customer's email address.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Email)]
        public string Email { get; set; }

        /// <summary>
        /// The status of payments associated with the order. Can only be set when the order is created.
        /// </summary>
        [JsonProperty("financial_status", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.FinancialStatus)]
        public OrderFinancialStatus? FinancialStatus { get; set; }

        /// <summary>
        /// A list of fulfillments associated with the order.
        /// </summary>
        [JsonProperty("fulfillments", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Fulfillment)]
        public List<FulfillmentData> Fulfillments { get; set; }

        /// <summary>
        /// The order's status in terms of fulfilled line items.
        /// </summary>
        [JsonProperty("fulfillment_status", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.FulfillmentStatus)]
        public OrderFulfillmentStatus FulfillmentStatus { get; set; }

        /// <summary>
        /// The ID of the order, used for API purposes. This is different from the order_number property, which is the ID used by the shop owner and customer.
        /// </summary>
        //[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.OrderId)]
        //public long? Id { get; set; }

        /// <summary>
        /// The behaviour to use when updating inventory. (default: bypass)
        /// </summary>
        [JsonProperty("inventory_behaviour", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.InventoryBehaviour)]
        public OrderInventoryBehaviour? InventoryBehaviour { get; set; } = OrderInventoryBehaviour.Bypass;

        /// <summary>
        /// [READ-ONLY] The URL for the page where the buyer landed when they entered the shop.
        /// </summary>
        [JsonProperty("landing_site")]
        [Description(ShopifyCaptions.LandingSite)]
        [ShouldNotSerialize]
        public String LandingSite { get; set; }

        /// <summary>
        /// A list of line item objects, each containing information about an item in the order.
        /// </summary>
        [JsonProperty("line_items")]
        [Description(ShopifyCaptions.LineItem)]
        public List<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();

        /// <summary>
        /// The ID of the physical location where the order was processed.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LocationId { get; set; }

        /// <summary>
        /// The order name, generated by combining the order_number property with the order prefix and suffix that are set in the merchant's general settings.
        /// This is different from the id property, which is the ID of the order used by the API.
        /// This field can also be set by the API to be any string value.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Name)]
        public string Name { get; set; }

        /// <summary>
        /// An optional note that a shop owner can attach to the order.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Note)]
        public String Note { get; set; }

        /// <summary>
        /// Extra information that is added to the order. Appears in the Additional details section of an order details page.
        /// Each array entry must contain a hash with name and value keys.
        /// </summary>
        [JsonProperty("note_attributes", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.NoteAttribute)]
        public List<NoteAttribute> NoteAttributes { get; set; }

        /// <summary>
        /// [READ-ONLY] The order's position in the shop's count of orders. Numbers are sequential and start at 1.
        /// </summary>
        [JsonProperty("number")]
        [ShouldNotSerialize]
        public int? Number { get; set; }

        /// <summary>
        /// [READ-ONLY] The order 's position in the shop's count of orders starting at 1001. Order numbers are sequential and start at 1001.
        /// </summary>
        [JsonProperty("order_number")]
        [Description(ShopifyCaptions.OrderNumber)]
        [ShouldNotSerialize]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The customer's phone number for receiving SMS notifications.
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Phone)]
        public String Phone { get; set; }

        /// <summary>
        /// The list of payment gateways used for the order.
        /// </summary>
        [JsonProperty("payment_gateway_names", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Gateway)]
        [ShouldNotSerialize]
        public List<string> PaymentGatewayNames { get; set; }

        /// <summary>
        /// The presentment currency that was used to display prices to the customer.
        /// </summary>
        [JsonProperty("presentment_currency", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.PresentmentCurrency)]
        public String PresentmentCurrency { get; set; }

        /// <summary>
        /// The date and time (ISO 8601 format) when an order was processed.
        /// This value is the date that appears on your orders and that's used in the analytic reports.
        /// By default, it matches the created_at value.
        /// If you're importing orders from an app or another platform, then you can set processed_at to a date and time in the past to match when the original order was created.
        /// </summary>
        [JsonProperty("processed_at", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ProcessedAt)]
        public DateTime? ProcessedAt { get; set; }

        /// <summary>
        /// How the payment was processed.
        /// </summary>
        [JsonProperty("processing_method")]
        [Description(ShopifyCaptions.ProcessingMethod)]
        [ShouldNotSerialize]
        public OrderProcessingMethod? ProcessingMethod { get; set; }

        /// <summary>
        /// The website where the customer clicked a link to the shop.
        /// </summary>
        [JsonProperty("referring_site", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ReferringSite)]
        public String ReferringSite { get; set; }

        /// <summary>
        /// A list of refunds applied to the order.
        /// </summary>
        [JsonProperty("refunds")]
        [Description(ShopifyCaptions.Refund)]
        [ShouldNotSerialize]
        public List<OrderRefund> Refunds { get; set; }

        /// <summary>
        /// Whether to send an order confirmation to the customer.
        /// When send_receipt is set to false, then you need to disable the Storefront API from the private app's page in the Shopify admin.
        /// </summary>
        [JsonProperty("send_receipt", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.SendReceipt)]
        public bool? SendReceipt { get; set; }

        /// <summary>
        /// Whether to send a shipping confirmation to the customer.
        /// </summary>
        [JsonProperty("send_fulfillment_receipt", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.SendFulfillmentReceipt)]
        public bool? SendFulfillmentReceipt { get; set; }

        /// <summary>
        /// The mailing address to where the order will be shipped. This address is optional and will not be available on orders that do not require shipping.
        /// </summary>
        //[JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.ShippingAddress)]
        //public OrderAddressData ShippingAddress { get; set; }

        /// <summary>
        /// An array of objects, each of which details a shipping method used.
        /// </summary>
        [JsonProperty("shipping_lines")]
        [Description(ShopifyCaptions.ShippingLine)]
        public List<OrderShippingLine> ShippingLines { get; set; }

        /// <summary>
        /// Where the order originated. Can be set only during order creation, and is not writeable afterwards.
        /// Values for Shopify channels are protected and cannot be assigned by other API clients: web, pos, shopify_draft_order, iphone, and android.
        /// Orders created via the API can be assigned any other string of your choice.
        /// If unspecified, then new orders are assigned the value of your app's ID.
        /// </summary>
        [JsonProperty("source_name", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.SourceName)]
        public String SourceName { get; set; }

        /// <summary>
        /// The price of the order in the shop currency after discounts but before shipping, taxes, and tips.
        /// </summary>
        [JsonProperty("subtotal_price", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.SubTotal)]
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// The subtotal of the order in shop and presentment currencies.
        /// </summary>
        [JsonProperty("subtotal_price_set")]
        [Description(ShopifyCaptions.SubTotalSet)]
        public PriceSet SubTotalSet { get; set; }

        /// <summary>
        /// Tags attached to the order, formatted as a string of comma-separated values.
        /// Tags are additional short descriptors, commonly used for filtering and searching. Each individual tag is limited to 40 characters in length.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Tags)]
        public String Tags { get; set; }

        /// <summary>
        /// An array of tax line objects, each of which details a tax applicable to the order.
        /// </summary>
        [JsonProperty("tax_lines", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TaxLine)]
        public List<OrderTaxLine> TaxLines { get; set; }

        /// <summary>
        /// Whether taxes are included in the order subtotal.
        /// </summary>
        [JsonProperty("taxes_included", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TaxesIncluded)]
        public bool? TaxesIncluded { get; set; }

        /// <summary>
        /// Whether this is a test order.
        /// </summary>
        [JsonProperty("test", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TestCase)]
        public bool? IsTestOrder { get; set; }

        /// <summary>
        /// A unique token for the order.
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Token)]
        public String Token { get; set; }

        /// <summary>
        /// The total discounts applied to the price of the order in the shop currency.
        /// </summary>
        //[JsonProperty("total_discounts", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.TotalDiscount)]
        //public decimal? TotalDiscount { get; set; }

        /// <summary>
        /// The total discounts applied to the price of the order in shop and presentment currencies.
        /// </summary>
        [JsonProperty("total_discounts_set", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalDiscountSet)]
        public PriceSet TotalDiscountSet { get; set; }

        /// <summary>
        /// The sum of all line item prices in the shop currency.
        /// </summary>
        [JsonProperty("total_line_items_price", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ItemsTotal)]
        public decimal? ItemsTotal { get; set; }

        /// <summary>
        /// The total discounts applied to the price of the order in shop and presentment currencies.
        /// </summary>
        [JsonProperty("total_line_items_price_set", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.ItemsTotalSet)]
        public PriceSet ItemsTotalSet { get; set; }

        /// <summary>
        /// The sum of all line item prices, discounts, shipping, taxes, and tips in the shop currency. Must be positive.
        /// </summary>
        //[JsonProperty("total_price")]
        //[Description(ShopifyCaptions.OrderTotal)]
        //public decimal? OrderTotal { get; set; }

        /// <summary>
        /// The total price of the order in shop and presentment currencies.
        /// </summary>
        [JsonProperty("total_price_set")]
        [Description(ShopifyCaptions.OrderTotalSet)]
        public PriceSet OrderTotalSet { get; set; }

        /// <summary>
        /// The sum of all the taxes applied to the order in th shop currency. Must be positive.
        /// </summary>
        //[JsonProperty("total_tax", NullValueHandling = NullValueHandling.Ignore)]
        //[Description(ShopifyCaptions.TotalTax)]
        //public decimal? TotalTax { get; set; }

        /// <summary>
        /// The total tax applied to the order in shop and presentment currencies.
        /// </summary>
        [JsonProperty("total_tax_set", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalTaxSet)]
        public PriceSet TotalTaxSet { get; set; }

        /// <summary>
        /// The sum of all the tips in the order in the shop currency.
        /// </summary>
        [JsonProperty("total_tip_received", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalTips)]
        public decimal? TotalTips { get; set; }

        /// <summary>
        /// The sum of all line item weights in grams.
        /// </summary>
        [JsonProperty("total_weight", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.TotalWeight)]
        public decimal? TotalWeightInGrams { get; set; }

        /// <summary>
        /// The transactions of the order
        /// </summary>
        [Description(ShopifyCaptions.OrdersTransaction)]
        [ShouldNotSerialize]
        public List<OrderTransaction> Transactions { get; set; }

        /// <summary>
        /// The date and time (ISO 8601 format) when the order was last modified.
        /// Filtering orders by updated_at is not an effective method for fetching orders because its value can change when no visible fields of an order have been updated.
        /// Use the Webhook and Event APIs to subscribe to order events instead.
        /// </summary>
        [JsonProperty("updated_at")]
        [ShouldNotSerialize]
        public DateTime? DateModifiedAt { get; set; }

        /// <summary>
        /// The ID of the user logged into Shopify POS who processed the order, if applicable.
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.UserId)]
        public long? UserId { get; set; }

        /// <summary>
        /// The URL pointing to the order status web page, if applicable.
        /// </summary>
        [JsonProperty("order_status_url", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.OrderStatusURL)]
        [ShouldNotSerialize]
        public String OrderStatusURL { get; set; }

        /// <summary>
        /// Attaches additional metadata to a shop's resources:
        ///key(required) : An identifier for the metafield(maximum of 30 characters).
        ///namespace(required): A container for a set of metadata(maximum of 20 characters). Namespaces help distinguish between metadata that you created and metadata created by another individual with a similar namespace.
        ///value (required): Information to be stored as metadata.
        ///value_type(required): The value type.Valid values: string and integer.
        ///description(optional): Additional information about the metafield.
        /// </summary>
        [JsonProperty("metafields", NullValueHandling = NullValueHandling.Ignore)]
        [Description(ShopifyCaptions.Metafields)]
        public List<MetafieldData> Metafields { get; set; }

        /// <summary>
        /// The risks of the order
        /// </summary>
        [ShouldNotSerialize]
        [Description(ShopifyCaptions.OrderRisk)]
        public List<OrderRisk> OrderRisks { get; set; }

    }

    public class NoteAttribute
    {
        [JsonProperty("name")]
        [Description(ShopifyCaptions.Name)]
        public string Name { get; set; }

        [JsonProperty("value")]
        [Description(ShopifyCaptions.Value)]
        public string Value { get; set; }
    }
}