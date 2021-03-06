using System;
using System.Globalization;
using TestLibrary;

/// <summary>
///GetHashCode
/// </summary>
public class CultureInfoGetHashCode
{
    public static int Main()
    {
        CultureInfoGetHashCode CultureInfoGetHashCode = new CultureInfoGetHashCode();

        TestLibrary.TestFramework.BeginTestCase("CultureInfoGetHashCode");
        if (CultureInfoGetHashCode.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        if (!Utilities.IsWindows)
        {
            // Neutral cultures not supported on Windows
            retVal = PosTest2() && retVal;
        }
        retVal = PosTest3() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: CultureTypes.SpecificCultures");
        try
        {

            CultureInfo myCultureInfo = new CultureInfo("en-US");
            // the only guarantee that can be made about HashCodes is that they will be non-zero 
            //  and unique across calls
            int actualValue   = myCultureInfo.GetHashCode();
            int expectedValue = myCultureInfo.GetHashCode();
            if (actualValue != expectedValue)
            {
                TestLibrary.TestFramework.LogError("001", "myCultureInfo.GetHashCode() " + actualValue + "  should return " + expectedValue);
                retVal = false;
            }
            if (0 == actualValue)
            {
                TestLibrary.TestFramework.LogError("101", "myCultureInfo.GetHashCode() " + actualValue + "  should not return 0");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: CultureTypes.NeutralCultures");
        try
        {
            CultureInfo myCultureInfo = new CultureInfo("en");
            // the only guarantee that can be made about HashCodes is that they will be non-zero 
            //  and unique across calls
            int actualValue   = myCultureInfo.GetHashCode();
            int expectedValue = myCultureInfo.GetHashCode();
            if (actualValue != expectedValue)
            {
                TestLibrary.TestFramework.LogError("003", "myCultureInfo.GetHashCode() " + actualValue + " should return " + expectedValue);
                retVal = false;
            }
            if (0 == actualValue)
            {
                TestLibrary.TestFramework.LogError("103", "myCultureInfo.GetHashCode() " + actualValue + "  should not return 0");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: invariant culture");
        try
        {

            CultureInfo myCultureInfo = CultureInfo.InvariantCulture;
            // the only guarantee that can be made about HashCodes is that they will be non-zero 
            //  and unique across calls
            int actualValue   = myCultureInfo.GetHashCode();
            int expectedValue = myCultureInfo.GetHashCode();
            if (myCultureInfo.GetHashCode() != expectedValue)
            {
                TestLibrary.TestFramework.LogError("005", "myCultureInfo.GetHashCode() " + actualValue + " should return " + expectedValue);
                retVal = false;
            }
            if (0 == actualValue)
            {
                TestLibrary.TestFramework.LogError("105", "myCultureInfo.GetHashCode() " + actualValue + "  should not return 0");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
}

