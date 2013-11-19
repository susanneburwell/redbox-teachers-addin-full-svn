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
    }
}
