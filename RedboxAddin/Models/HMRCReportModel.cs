using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedboxAddin.Models
{
    class HMRCReportModel
    {
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string NINumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Postcode { get; set; }
        public string EngagementDetails { get; set; }
        public string UTR { get; set; }
        public string StartDateOfEngagement { get; set; }
        public string EndDateOfEngagement { get; set; }
        public string AmountPaid { get; set; }
        public string Currency { get; set; }
        public string IsAmountInclusiveVAT { get; set; }
        public string PayDetails { get; set; }
        public string AddressLine1OfPartyPaid { get; set; }
        public string AddressLine2OfPartyPaid { get; set; }
        public string AddressLine3OfPartyPaid { get; set; }
        public string AddressLine4OfPartyPaid { get; set; }
        public string PostCodeOfPartyPaid { get; set; }
        public string CompaniesRegistrationOfPartyPaid { get; set; }
    }
}
