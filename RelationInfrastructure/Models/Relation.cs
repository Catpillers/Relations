using System;
using System.Collections.Generic;
using System.Linq;

namespace Relations.Dal.Models
{
    public class Relation : EntityWithId
    {
        public Relation()
        {
            Id = new Guid();
            CreatedAt = DateTime.Now;
            CreatedBy = "Evangelion";
            IsDisabled = false;
            IsTemporary = false;
            IsMe = false;
        }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDisabled { get; set; }
        public Guid? ParentRelationId { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsMe { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }
        public string DefaultStreet { get; set; }
        public string DefaultPostalCode { get; set; }
        public string DefaultCity { get; set; }
        public string DefaultCountry { get; set; }
        public string EmailAddress { get; set; }
        public string Url { get; set; }
        public string Imaddress { get; set; }
        public string SkypeAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public DateTime? DepartureBetween { get; set; }
        public DateTime? DepartureBetweenAnd { get; set; }
        public DateTime? ArrivalBetween { get; set; }
        public DateTime? ArrivalBetweenAnd { get; set; }
        public string Remarks { get; set; }
        public string CustomerCode { get; set; }
        public string DebtorNumber { get; set; }
        public string VendorNumber { get; set; }
        public string InvoiceTo { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public bool? SendInvoiceDigital { get; set; }
        public Guid? VatId { get; set; }
        public string VatName { get; set; }
        public double? PaymentTerm { get; set; }
        public bool PaymentViaAutomaticDebit { get; set; }
        public string VatNumber { get; set; }
        public string ChamberOfCommerce { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankBic { get; set; }
        public double? CalculateMinimalPrice { get; set; }
        public bool? CalculatePriceManually { get; set; }
        public bool? CalculatePriceByPriceList { get; set; }
        public Guid? PriceListId { get; set; }
        public string PriceListName { get; set; }
        public bool? CalculatePriceBasedOnPositions { get; set; }
        public bool? CalculatePriceBasedOnAmount { get; set; }
        public bool? CalculatePriceBasedOnWeight { get; set; }
        public bool? CalculatePriceBasedOnDistance { get; set; }
        public bool? CalculatePriceBasedOnTonne { get; set; }
        public bool? CalculatePriceByFixed { get; set; }
        public bool? CalculatePriceByDistance { get; set; }
        public bool? CalculatePriceBasedOnEpq { get; set; }
        public bool? CalculatePriceBasedOnLoadingMeters { get; set; }
        public bool? CalculatePriceBasedOnVolume { get; set; }
        public double? CalculatePriceByFixedPrice { get; set; }
        public double? CalculateMinimalPriceForCollecting { get; set; }
        public bool? CalculatePriceManuallyForCollecting { get; set; }
        public bool? CalculatePriceByPriceListForCollecting { get; set; }
        public Guid? PriceListIdForCollecting { get; set; }
        public string PriceListNameForCollecting { get; set; }
        public bool? CalculatePriceBasedOnPositionsForCollecting { get; set; }
        public bool? CalculatePriceBasedOnAmountForCollecting { get; set; }
        public bool? CalculatePriceBasedOnWeightForCollecting { get; set; }
        public bool? CalculatePriceBasedOnDistanceForCollecting { get; set; }
        public bool? CalculatePriceBasedOnTonneForCollecting { get; set; }
        public bool? CalculatePriceByFixedForCollecting { get; set; }
        public bool? CalculatePriceByDistanceForCollecting { get; set; }
        public bool? CalculatePriceBasedOnEpqForCollecting { get; set; }
        public bool? CalculatePriceBasedOnLoadingMetersForCollecting { get; set; }
        public bool? CalculatePriceBasedOnVolumeForCollecting { get; set; }
        public double? CalculatePriceByFixedPriceForCollecting { get; set; }
        public string GeographicalRegions { get; set; }
        public bool? SendDigitalFreightDocumentsByEmail { get; set; }
        public Guid? DigitalFreightDocumentEmailTemplateId { get; set; }
        public bool? SendFreightStatusUpdateByEmail { get; set; }
        public bool? DepartureTimeSlotsAreAllEqual { get; set; }
        public Guid? DepartureTimeSlotIdOnSundays { get; set; }
        public Guid? DepartureTimeSlotIdOnMondays { get; set; }
        public Guid? DepartureTimeSlotIdOnTuesdays { get; set; }
        public Guid? DepartureTimeSlotIdOnWednesdays { get; set; }
        public Guid? DepartureTimeSlotIdOnThursdays { get; set; }
        public Guid? DepartureTimeSlotIdOnFridays { get; set; }
        public Guid? DepartureTimeSlotIdOnSaturdays { get; set; }
        public bool? ArrivalTimeSlotsAreAllEqual { get; set; }
        public Guid? ArrivalTimeSlotIdOnSundays { get; set; }
        public Guid? ArrivalTimeSlotIdOnMondays { get; set; }
        public Guid? ArrivalTimeSlotIdOnTuesdays { get; set; }
        public Guid? ArrivalTimeSlotIdOnWednesdays { get; set; }
        public Guid? ArrivalTimeSlotIdOnThursdays { get; set; }
        public Guid? ArrivalTimeSlotIdOnFridays { get; set; }
        public Guid? ArrivalTimeSlotIdOnSaturdays { get; set; }
        public int InvoiceDateGenerationOptions { get; set; }
        public int InvoiceGroupByOptions { get; set; }
        public string InvoiceGroupByTransportOrderColumnName { get; set; }
        public string GeneralLedgerAccount { get; set; }
        public Guid? TransportUnitTransactionOverviewTextTemplateId { get; set; }
        public bool? SendFreightDocumentsAlongWithInvoice { get; set; }
        public string CarrierCode { get; set; }
        public string SupplyNumber { get; set; }
        public Guid? ThirdPartyToUseForInvoicing { get; set; }
        public int? Flags { get; set; }
        public ICollection<RelationCategory> RelationCategories { get; set; }
        public ICollection<RelationAddress> RelationAddresses { get; set; }
    }
}