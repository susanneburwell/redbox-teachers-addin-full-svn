using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedboxAddin.BL
{
    static class Utils
    {
        internal static string GetFullName(string prefix, string firstName, string middleName, string lastName, string suffix)
        {
            string fullname = "";
            if (!string.IsNullOrEmpty(prefix)) fullname = fullname + prefix + " ";
            if (!string.IsNullOrEmpty(firstName)) fullname = fullname + firstName + " ";
            if (!string.IsNullOrEmpty(middleName)) fullname = fullname + middleName + " ";
            if (!string.IsNullOrEmpty(lastName)) fullname = fullname + lastName + " ";
            if (!string.IsNullOrEmpty(suffix)) fullname = fullname + suffix + " ";
            return fullname;
        }

        internal static string GetAddress(string street, string city, string state, string postcode, string country)
        {
            string fullAddress = "";
            if (!string.IsNullOrEmpty(street)) fullAddress = fullAddress + street + "\n";
            if (!string.IsNullOrEmpty(city)) fullAddress = fullAddress + city + "\n";
            if (!string.IsNullOrEmpty(state)) fullAddress = fullAddress + state + "\n";
            if (!string.IsNullOrEmpty(postcode)) fullAddress = fullAddress + postcode + "\n";
            if (!string.IsNullOrEmpty(country)) fullAddress = fullAddress + country + "\n";
            return fullAddress;
        }

        public static string CheckString(object myObject)
        {
            try
            {
                if (System.DBNull.Value == myObject)
                {
                    return "";
                }
                else if (myObject == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(myObject);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "CheckString Failed :- " + ex.Message);
                return "";
            }
        }

        public static bool CheckBool(object myObject)
        {
            try
            {
                if (System.DBNull.Value == myObject)
                {
                    return false;
                }
                else if (myObject == null)
                {
                    return false;
                }
                else if (myObject.ToString().ToLower() == "yes")
                {
                    return true;
                }
                else if (myObject.ToString().Trim() == "1")
                {
                    return true;
                }

                else
                {
                    return Convert.ToBoolean(myObject);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "CheckBool Failed :- " + ex.Message);
                return false;
            }
        }

        public static decimal CheckDecimal(object myObject)
        {
           
            try
            {
                Decimal dec = Convert.ToDecimal(myObject);
                return dec;
            }
            catch
            {
                return Convert.ToDecimal("00.0");
            }
        }

        public static bool validateDecimal(string text)
        {
            try
            {
                Decimal dec = Convert.ToDecimal(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Dictionary<int, string> ExtractAppointmentData(string data)
        {
            Dictionary<int, string> datastring = new Dictionary<int, string>();
            try
            {
                string school = data.Substring(0, data.IndexOf(' ')).Trim();
                string other = data.Substring(data.IndexOf(' ')).Trim();
                datastring.Add(1, school);
                datastring.Add(2, other);
                return datastring;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in ExtractAppointmentData: " + ex.Message);
                return null;
            }
        }

        //internal static bool CheckForRedboxFolder()
        //{
        //    try
        //    {
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in CheckForRedboxFolder() :- " + ex.Message);
        //    }
        //}

        public static string TeacherQuals(bool TA, bool QTS, bool NQT, bool OTT, bool QNN, bool NN, bool SEN)
        {
            string Quals = "";
            if (TA) Quals += "/TA";
            if (QTS) Quals += "/QTS";
            if (NQT) Quals += "/NQT";
            if (OTT) Quals += "/OTT";
            if (QNN) Quals += "/QNN";
            if (NN) Quals += "/NN";
            if (SEN) Quals += "/SEN";

            if (Quals != "") Quals = Quals.Substring(1);
            return Quals;
        }

        public static string YearGroup(bool Nur, bool Rec, bool Yr1, bool Yr2, bool Yr3, bool Yr4, bool Yr5, bool Yr6)
        {
            string agegroup = "";
            if (Nur) agegroup += "Nur/";
            if (Rec) agegroup += "Rec/";
            if (Yr1) agegroup += "Yr1/";
            if (Yr2) agegroup += "Yr2/";
            if (Yr3) agegroup += "Yr3/";
            if (Yr4) agegroup += "Yr4/";
            if (Yr5) agegroup += "Yr5/";
            if (Yr6) agegroup += "Yr6";

            agegroup = agegroup.Replace("Nur/Rec", "Nur-Rec");
            agegroup = agegroup.Replace("Rec/Yr1", "Rec-Yr1");
            agegroup = agegroup.Replace("Yr1/Yr2", "Yr1-Yr2");
            agegroup = agegroup.Replace("Yr2/Yr3", "Yr2-Yr3");
            agegroup = agegroup.Replace("Yr3/Yr4", "Yr3-Yr4");
            agegroup = agegroup.Replace("Yr4/Yr5", "Yr4-Yr5");
            agegroup = agegroup.Replace("Yr5/Yr6", "Yr5-Yr6");

            agegroup = agegroup.Replace("-Rec-", "-");
            agegroup = agegroup.Replace("-Yr1-", "-");
            agegroup = agegroup.Replace("-Yr2-", "-");
            agegroup = agegroup.Replace("-Yr3-", "-");
            agegroup = agegroup.Replace("-Yr4-", "-");
            agegroup = agegroup.Replace("-Yr5-", "-");

            if (agegroup.Length > 0)
            {
                if (agegroup.Substring(agegroup.Length - 1) == "/") agegroup = agegroup.Substring(0, agegroup.Length - 1);
            }

            return agegroup;
        }
    }
}
