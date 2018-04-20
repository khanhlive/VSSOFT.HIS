namespace Vssoft.Common.Enviroment
{
    using System;
    using System.Runtime.InteropServices;

    public class WinInet
    {
        [DllImport("wininet.dll", CharSet=CharSet.Auto)]
        private static extern bool InternetGetConnectedState(ref ConnectionState lpdwFlags, int dwReserved);
        public static bool IsConnectedToInternet()
        {
            bool flag;
            ConnectionState lpdwFlags = 0;
            try
            {
                flag = InternetGetConnectedState(ref lpdwFlags, 0);
            }
            catch (Exception)
            {
                return false;
            }
            return flag;
        }

        [Flags]
        private enum ConnectionState
        {
            InternetConnectionConfigured = 0x40,
            InternetConnectionLan = 2,
            InternetConnectionModem = 1,
            InternetConnectionOffline = 0x20,
            InternetConnectionProxy = 4,
            InternetRasInstalled = 0x10
        }
    }
}

