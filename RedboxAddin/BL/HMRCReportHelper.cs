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

        internal static List<string> WorkerDetailsHeader()
        {
            List<string> workerDetailsHeader = new List<string>();
            workerDetailsHeader.Add("Worker forename (Must be between 1 and 35 characters.)");//A
            workerDetailsHeader.Add("Worker middle name (Optional, between 1 and 35 characters.)");//B
            workerDetailsHeader.Add("Worker surname (Must be between 1 and 35 characters.)");//C
            workerDetailsHeader.Add("Worker date of birth (There must be an entry if there is no 'Worker National Insurance number'. Must be in the format of dd/mm/yyyy and be today or in the past, but within the last 130 years.)");//D
            workerDetailsHeader.Add("Worker gender (There must be an entry if there is no 'Worker National Insurance number'. Must be an 'M' for male or 'F' for female.)");//E
            workerDetailsHeader.Add("Worker National Insurance number (There must be an entry if there is no 'Worker date of birth' and 'Worker gender'. Must be in the format of 2 letters then 6 digits then A, B, C, D or a space, like QQ123456C or QQ123456 .)");//FF
            workerDetailsHeader.Add("Worker address line 1 (Must be between 1 and 35 characters.)");//G
            workerDetailsHeader.Add("Worker address line 2 (Must be between 1 and 35 characters.)");//H
            workerDetailsHeader.Add("Worker address line 3 (Optional, between 1 and 35 characters.)");//I
            workerDetailsHeader.Add("Worker address line 4 (Optional, between 1 and 35 characters.)");//J
            workerDetailsHeader.Add("Worker postcode (Must be between 1 and 10 characters.)");//K
            workerDetailsHeader.Add("Worker engagement details where intermediary didn't operate PAYE (Must be 'A' Self-employed, 'B' Partnership, 'C' Limited liability partnership, 'D' Limited company, 'E' Non-UK engagement, 'F' Another party operated PAYE on the worker's payments. If more than one option applies select the option that comes first on the list. For example, if A and E both apply, select A.)");//L
            workerDetailsHeader.Add("Worker unique taxpayer reference (UTR) (There must an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B' or 'C'. Must be 10 numbers.)");//M
            workerDetailsHeader.Add("Start date of engagement (Must be in the format of dd/mm/yyyy and be today or in the past. May be before the start of the reporting perod if the engagement has never ended.)");//N
            workerDetailsHeader.Add("End date of engagement (There must be an entry if the engagement ended. Must be in the format of dd/mm/yyyy and must be the same as or after the start date, today or in the past, and in the reporting period the report relates to.)");//O
            workerDetailsHeader.Add("Amount paid for the worker's services (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be a positive value to 2 decimal places and not include any commas. You should round to the nearest penny.)");//P
            workerDetailsHeader.Add("Currency (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be Great British pounds ('GBP') or euros ('EUR'). If the worker was paid in another currency it should be converted into Great British pounds or euros.)");//Q
            workerDetailsHeader.Add("Is this amount inclusive of VAT? (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be a 'Y' for yes or a 'N' for no.)");//R
            workerDetailsHeader.Add("Name of party paid by intermediary for worker's services (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be between 1 and 120 characters.)");//S
            workerDetailsHeader.Add("Address line 1 of party paid by intermediary for worker's services (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be between 1 and 35 characters.)");//T
            workerDetailsHeader.Add("Address line 2 of party paid by intermediary for worker's services (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'A', 'B', 'C', 'D' or 'E'. Must be between 1 and 35 characters.)");//U
            workerDetailsHeader.Add("Address line 3 of party paid by intermediary for worker's services (Optional, between 1 and 35 characters.)");//V
            workerDetailsHeader.Add("Address line 4 of party paid by intermediary for worker's services (Optional, between 1 and 35 characters.)");//W
            workerDetailsHeader.Add("Postcode of party paid by intermediary for worker's services (Optional, between 1 and 10 characters.)");//X
            workerDetailsHeader.Add("Companies House registration number of party paid by intermediary for worker's services (There must be an entry if 'Worker engagement details where intermediary didn't operate PAYE' is 'D'. Must be 8 numbers or 2 letters and 6-digit numbers.)");//Y

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
                    workersWholeDetail.Forename = dsWorkersDetail["FN"].ToString();
                    workersWholeDetail.SurName = dsWorkersDetail["LFN"].ToString();
                    workersWholeDetail.MiddleName = dsWorkersDetail["middle"].ToString();
                    workersWholeDetail.DateOfBirth = dsWorkersDetail["DOB"].ToString();
                    workersWholeDetail.NINumber = dsWorkersDetail["NI"].ToString();
                    workersWholeDetail.Gender = "";
                    workersWholeDetail.AddressLine1 = ValidateAddress1(dsWorkersDetail["Address1"].ToString());
                    workersWholeDetail.AddressLine2 = dsWorkersDetail["Address2"].ToString();
                    workersWholeDetail.AddressLine3 = dsWorkersDetail["Address3"].ToString();
                    workersWholeDetail.AddressLine4 = "";
                    workersWholeDetail.Postcode = dsWorkersDetail["PostCode"].ToString();
                    workersWholeDetail.EngagementDetails = "F";
                    workersWholeDetail.UTR = "";
                    workersWholeDetail.StartDateOfEngagement = dsWorkersDetail["start"].ToString();
                    workersWholeDetail.EndDateOfEngagement = dsWorkersDetail["finish"].ToString();
                    workersWholeDetail.AmountPaid = dsWorkersDetail["total"].ToString();
                    workersWholeDetail.Currency = "GBP";
                    workersWholeDetail.IsAmountInclusiveVAT = "No";
                    workersWholeDetail.PayDetails = "";
                    workersWholeDetail.AddressLine1OfPartyPaid = "";
                    workersWholeDetail.AddressLine2OfPartyPaid = "";
                    workersWholeDetail.AddressLine3OfPartyPaid = "";
                    workersWholeDetail.AddressLine4OfPartyPaid = "";
                    workersWholeDetail.PostCodeOfPartyPaid = "";
                    workersWholeDetail.CompaniesRegistrationOfPartyPaid = "Regi";
                    workersWholeDetails.Add(workersWholeDetail);

                }
                return workersWholeDetails;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        internal static string ValidateAddress1(string address)
        {
            string address1 = string.Empty;
            try
            {
                address1 = address1.Replace(System.Environment.NewLine, string.Empty);
                address1 = '"' + address1.Replace("\"", "\"\"") + '"';
            }
            catch (Exception ex)
            {

            }

            return address1;

        }
    }
}
