//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerSideWithDataTableJS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public System.Guid ID { get; set; }
        public System.Guid HeroOrderID { get; set; }
        public Nullable<int> AmountPaidCurrencyID { get; set; }
        public Nullable<double> AmountPaidValue { get; set; }
        public string Email { get; set; }
        public Nullable<int> Status { get; set; }
        public string UserID { get; set; }
        public string AddressID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string CityName { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public Nullable<float> SalesTaxPercent { get; set; }
        public Nullable<bool> ShippingIncludedInTax { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CheckoutStatus { get; set; }
        public System.DateTime LastTimeModified { get; set; }
        public Nullable<int> PaymentMethodUsed { get; set; }
        public Nullable<int> CompleteStatus { get; set; }
        public string PlatformTransactionID { get; set; }
        public Nullable<int> TransactionPriceCurrencyID { get; set; }
        public Nullable<double> TransactionPriceValue { get; set; }
        public Nullable<bool> BestOfferSale { get; set; }
        public Nullable<int> ShippingInsuranceCostCurrencyID { get; set; }
        public Nullable<double> ShippingInsuranceCostPriceValue { get; set; }
        public string ShippingService { get; set; }
        public Nullable<int> ShippingServiceCostCurrencyID { get; set; }
        public Nullable<double> ShippingServiceCostValue { get; set; }
        public string ContainingOrderID { get; set; }
        public Nullable<int> QuantityPurchased { get; set; }
        public string PlatformItemID { get; set; }
        public string ItemTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressName { get; set; }
    }
}
