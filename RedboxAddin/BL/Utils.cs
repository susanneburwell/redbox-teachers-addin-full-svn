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
