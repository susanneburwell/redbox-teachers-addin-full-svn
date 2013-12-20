﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RedboxAddin.Models
{
    class RContact
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string JobTitle { get; set; }
        [Key]
        public long contactID { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPostcode { get; set; }
        public string AddressCountry { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneBusiness { get; set; }
        public string PhoneFax { get; set; }
        public string CategoryStr { get; set; }
        public bool _1stRefChecked { get; set; }
        public bool _2ndRefChecked { get; set; }
        public bool _3rdRefChecked { get; set; }
        public string AccountName { get; set; }
        public bool AdditionalInfoOnCRB { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankSortCode { get; set; }
        public string BankStatementLocation { get; set; }
        public string BirthDate { get; set; }
        public string Consultant { get; set; }
        public bool CRBandAddressProofMatch { get; set; }
        public DateTime CRBDateSent { get; set; }
        public DateTime CRBExpiryDate { get; set; }
        public string CRBFormRef { get; set; }
        public string CRBNumber { get; set; }
        public DateTime CRBValidFrom { get; set; }
        public string CurrentPayScale { get; set; }
        public bool CVReceived { get; set; }
        public bool DBSDirectPayment { get; set; }
        public DateTime DateOfSupply { get; set; }
        public DateTime FirstDayTeachingUK { get; set; }
        public DateTime GTCCheckDate { get; set; }
        public string GTCNumber { get; set; }
        public bool IDChecked { get; set; }
        public bool Instructor { get; set; }
        public string InterviewNotes { get; set; }
        public string LateRecord { get; set; }
        public bool List99 { get; set; }
        public DateTime LTStartDate { get; set; }
        public bool MedicalChecklist { get; set; }
        public string NINumber { get; set; }
        public string Notes { get; set; }
        public bool NQT { get; set; }
        public bool OtherCRBNumber { get; set; }
        public DateTime OTTEndDate { get; set; }
        public bool OverseasPoliceCheck { get; set; }
        public bool OverseasTrainedTeacher { get; set; }
        public string PassportNo { get; set; }
        public string PassportLocation { get; set; }
        public string PayDetails { get; set; }
        public bool PAYETeacherContractSigned { get; set; }
        public string PhotoLocation { get; set; }
        public DateTime GraduationDate { get; set; }
        public DateTime ProtabilityCheckSent { get; set; }
        public DateTime ProtabilityReceivedDate { get; set; }
        public bool ProofOfAddress { get; set; }
        public string ProofOfID { get; set; }
        public string ProofOfID2 { get; set; }
        public bool QTS { get; set; }
        public string Qualification { get; set; }
        public DateTime RedboxLeaveDate { get; set; }
        public DateTime RedboxStartDate { get; set; }
        public bool RedboxCRB { get; set; }
        public string ReferredBy { get; set; }
        public string Referee1Address { get; set; }
        public string Referee1Email { get; set; }
        public string Referee1Fax { get; set; }
        public string Referee1Mobile { get; set; }
        public string Referee1Name { get; set; }
        public string Referee1Notes { get; set; }
        public string Referee1Phone { get; set; }
        public string Referee2Address { get; set; }
        public string Referee2Email { get; set; }
        public string Referee2Fax { get; set; }
        public string Referee2Mobile { get; set; }
        public string Referee2Name { get; set; }
        public string Referee2Notes { get; set; }
        public string Referee2Phone { get; set; }
        public string Referee3Address { get; set; }
        public string Referee3Email { get; set; }
        public string Referee3Fax { get; set; }
        public string Referee3Mobile { get; set; }
        public string Referee3Name { get; set; }
        public string Referee3Notes { get; set; }
        public string Referee3Phone { get; set; }
        public bool ReferencesChecked { get; set; }
        public bool RegistrationComplete { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool SendBankStatement { get; set; }
        public bool SendPassport { get; set; }
        public bool SendVisa { get; set; }
        public string SicknessRecord { get; set; }
        public string TeacherStatus { get; set; }
        public DateTime UKArrivalDate { get; set; }
        public bool UpdateService { get; set; }
        public DateTime UpdateServiceRegisteredDate { get; set; }
        public DateTime VisaExpiryDate { get; set; }
        public string VisaType { get; set; }
        public string VisaLocation { get; set; }
        public string YearGroup { get; set; }

    }
}
