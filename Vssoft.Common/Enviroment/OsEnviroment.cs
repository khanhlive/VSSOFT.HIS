namespace Vssoft.Common.Enviroment
{
    using System;

    public class OsEnviroment
    {
        private static int GetOsArchitecture()
        {
            string environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((string.IsNullOrEmpty(environmentVariable) || (string.Compare(environmentVariable, 0, "x86", 0, 3, true) == 0)) ? 0x20 : 0x40);
        }

        public static string GetOsInfo()
        {
            OperatingSystem oSVersion = Environment.OSVersion;
            Version version = oSVersion.Version;
            string str = "";
            if (oSVersion.Platform == PlatformID.Win32Windows)
            {
                switch (version.Minor)
                {
                    case 0:
                        return "95";

                    case 10:
                        if (version.Revision.ToString() == "2222A")
                        {
                            return "98SE";
                        }
                        return "98";

                    case 90:
                        return "Me";
                }
                return str;
            }
            if (oSVersion.Platform == PlatformID.Win32NT)
            {
                switch (version.Major)
                {
                    case 3:
                        return "NT 3.51";

                    case 4:
                        return "NT 4.0";

                    case 5:
                        if (version.Minor != 0)
                        {
                            return "XP";
                        }
                        return "2000";

                    case 6:
                        if (version.Minor != 0)
                        {
                            return "7";
                        }
                        return "Vista";
                }
            }
            return str;
        }
    }
}

