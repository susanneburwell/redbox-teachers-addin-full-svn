using RedboxAddin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RedboxAddin.BL
{
    static class HMRCReportHelper
    {
        static string dateFormat = "dd/MM/yyyy";
        static string amountFormat = "0.00";

        internal static List<string> EmploymentDetails()
        {
            List<string> employmentDetails = new List<string>();
            employmentDetails.Add("Employment intermediary name (Must be between 1 and 120 characters.)");
            employmentDetails.Add("Employment intermediary address line 1 (Must be between 1 and 35 characters.)");
            employmentDetails.Add("Employment intermediary address line 2 (Must be between 1 and 35 characters.)");
            employmentDetails.Add("Employment intermediary address line 3 (Optional, between 1 and 35 characters.)");
            employmentDetails.Add("Employment intermediary address line 4 (Optional, between 1 and 35 characters.)");
            employmentDetails.Add("Employment intermediary postcode (Must be between 1 and 10 characters.)");
            employmentDetails.Add("");

            return employmentDetails;
        }

        internal static List<string> EmploymentIntermediaryDetails()
        {
            List<string> employmentIntermediaryDetails = new List<string>();
            employmentIntermediaryDetails.Add("Redbox Teacher Recruitment Ltd");
            employmentIntermediaryDetails.Add("4-5, Halliford Studios, Scene Dock");
            employmentIntermediaryDetails.Add("Manygate Ln");
            employmentIntermediaryDetails.Add("Shepperton");
            employmentIntermediaryDetails.Add("Middlesex");
            employmentIntermediaryDetails.Add("TW17 9EG");
            employmentIntermediaryDetails.Add("");

            return employmentIntermediaryDetails;
        }

        internal static List<string> WorkerDetailsHeader()
        {
            List<string> workerDetailsHeader = new List<string>();
            workerDetailsHeader.Add("Worker forename");//A
            workerDetailsHeader.Add("Worker middle name");//B
            workerDetailsHeader.Add("Worker surname");//C
            workerDetailsHeader.Add("Worker date of birth");//D
            workerDetailsHeader.Add("Worker gender");//E
            workerDetailsHeader.Add("Worker National Insurance number");//FF
            workerDetailsHeader.Add("Worker address line 1 ");//G
            workerDetailsHeader.Add("Worker address line 2 ");//H
            workerDetailsHeader.Add("Worker address line 3 ");//I
            workerDetailsHeader.Add("Worker address line 4 ");//J
            workerDetailsHeader.Add("Worker postcode ");//K
            workerDetailsHeader.Add("Worker engagement details where intermediary didn't operate PAYE");//L
            workerDetailsHeader.Add("Worker unique taxpayer reference (UTR)");//M
            workerDetailsHeader.Add("Start date of engagement");//N
            workerDetailsHeader.Add("End date of engagement");//O
            workerDetailsHeader.Add("Amount paid for the worker's services");//P
            workerDetailsHeader.Add("Currency");//Q
            workerDetailsHeader.Add("Is this amount inclusive of VAT? ");//R
            workerDetailsHeader.Add("Name of party paid by intermediary for worker's services");//S
            workerDetailsHeader.Add("Address line 1 of party paid by intermediary for worker's services");//T
            workerDetailsHeader.Add("Address line 2 of party paid by intermediary for worker's services");//U
            workerDetailsHeader.Add("Address line 3 of party paid by intermediary for worker's services");//V
            workerDetailsHeader.Add("Address line 4 of party paid by intermediary for worker's services");//W
            workerDetailsHeader.Add("Postcode of party paid by intermediary for worker's services");//X
            workerDetailsHeader.Add("Companies House registration number of party paid by intermediary for worker's services");//Y

            return workerDetailsHeader;
        }

        internal static List<HMRCReportModel> GetWorkersDetails(DataSet dsWorkersDetails)
        {
            List<HMRCReportModel> workersWholeDetails = new List<HMRCReportModel>();
            try
            {
                foreach (DataRow dsWorkersDetail in dsWorkersDetails.Tables[0].Rows)
                {
                    HMRCReportModel workersWholeDetail = new HMRCReportModel();
                    workersWholeDetail.Forename = CheckNameFormat(dsWorkersDetail["FN"].ToString());
                    workersWholeDetail.SurName = CheckNameFormat(dsWorkersDetail["LFN"].ToString());
                    workersWholeDetail.MiddleName = CheckNameFormat(dsWorkersDetail["middle"].ToString());
                    workersWholeDetail.DateOfBirth = CheckDOBFormat(dsWorkersDetail["DOB"].ToString());
                    workersWholeDetail.NINumber = CheckNINumber(dsWorkersDetail["NI"].ToString());
                    workersWholeDetail.Gender = "";
                    workersWholeDetail.AddressLine1 = CheckAddress(dsWorkersDetail["Address1"].ToString());
                    workersWholeDetail.AddressLine2 = CheckAddress(dsWorkersDetail["Address2"].ToString());
                    workersWholeDetail.AddressLine3 = CheckAddress(dsWorkersDetail["Address3"].ToString());
                    workersWholeDetail.AddressLine4 = "";
                    workersWholeDetail.Postcode = dsWorkersDetail["PostCode"].ToString();
                    workersWholeDetail.EngagementDetails = "F";
                    workersWholeDetail.UTR = "";
                    workersWholeDetail.StartDateOfEngagement = CheckEngagementStartDate(dsWorkersDetail["start"].ToString());
                    workersWholeDetail.EndDateOfEngagement = CheckEngagementEndDate(dsWorkersDetail["start"].ToString(), dsWorkersDetail["finish"].ToString());
                    workersWholeDetail.AmountPaid = CheckPayAmountFormat(dsWorkersDetail["total"].ToString());
                    workersWholeDetail.Currency = "GBP";
                    workersWholeDetail.IsAmountInclusiveVAT = "No";
                    workersWholeDetail.PayDetails = "";
                    workersWholeDetail.AddressLine1OfPartyPaid = "";
                    workersWholeDetail.AddressLine2OfPartyPaid = "";
                    workersWholeDetail.AddressLine3OfPartyPaid = "";
                    workersWholeDetail.AddressLine4OfPartyPaid = "";
                    workersWholeDetail.PostCodeOfPartyPaid = "";
                    workersWholeDetail.CompaniesRegistrationOfPartyPaid = "";
                    workersWholeDetails.Add(workersWholeDetail);

                }
                return workersWholeDetails;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetWorkersDetails: " + ex.Message);
                return null;
            }

        }

        internal static string CheckAddress(string address)
        {
            string filterAddress = string.Empty;
            try
            {
                filterAddress = RemoveUnwantedCharacters(address);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckAddress: " + ex.Message);
            }

            return filterAddress;

        }

        private static string RemoveUnwantedCharacters(string value)
        {
            string filterValue = string.Empty;
            try
            {
                filterValue = value.Replace(System.Environment.NewLine, string.Empty);
                filterValue = '"' + filterValue.Replace("\"", "\"\"") + '"';
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in RemoveUnwantedCharacters: " + ex.Message);
            }

            return filterValue;
        }

        private static string CheckNameFormat(string name)
        {
            string filterName = string.Empty;
            try
            {
                filterName = RemoveUnwantedCharacters(name);
                if (filterName.Length > 35) { filterName = filterName.Substring(0, 35); }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckNameFormat: " + ex.Message);
            }

            return filterName;
        }

        private static string CheckDOBFormat(string date)
        {
            string checkDate = string.Empty;
            try
            {
                if (!(string.IsNullOrEmpty(date)))
                {
                    int age = 0;
                    DateTime dt = DateTime.ParseExact(date, dateFormat, null);
                    age = DateTime.Today.Year - dt.Year;
                    if (dt < DateTime.Today && age < 130)
                    {
                        checkDate = dt.ToString(dateFormat);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDOBFormat: " + ex.Message);
            }

            return checkDate;
        }

        private static string CheckNINumber(string niNumber)
        {
            string checkNINumber = string.Empty;
            string expresion;
            expresion = "^\\s*([a-zA-Z]){2}\\s*([0-9]){1}\\s*([0-9]){1}\\s*([0-9]){1}\\s*([0-9]){1}\\s*([0-9]){1}\\s*([0-9]){1}\\s*([a-zA-Z]){1}?$";
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(niNumber.Trim(), expresion))
                {
                    checkNINumber = niNumber;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckNINumber: " + ex.Message);

            }

            return checkNINumber;

        }

        private static string CheckEngagementStartDate(string engaementDate)
        {
            string checkEngagementDate = string.Empty;

            try
            {
                DateTime dt = DateTime.Parse(engaementDate);
                if (dt <= DateTime.Today)
                {
                    checkEngagementDate = dt.ToString(dateFormat);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in engaementDate: " + ex.Message);
            }

            return checkEngagementDate;

        }

        private static string CheckEngagementEndDate(string engaementStartDate, string engaementEndDate)
        {
            string checkEngagementDate = string.Empty;

            try
            {
                DateTime dtStart = DateTime.Parse(engaementStartDate);
                DateTime dtEnd = DateTime.Parse(engaementEndDate);

                if (dtEnd <= DateTime.Today && dtEnd >= dtStart)
                {
                    checkEngagementDate = dtEnd.ToString(dateFormat);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckEngagementEndDate: " + ex.Message);
            }

            return checkEngagementDate;

        }

        private static string CheckPayAmountFormat(string payAmount)
        {
            string checkpayAmount = string.Empty;
            try
            {
                decimal payamount = decimal.Parse(payAmount);
                checkpayAmount = payamount.ToString(amountFormat);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckPayAmountFormat: " + ex.Message);
            }

            return checkpayAmount;
        }

    }
}
