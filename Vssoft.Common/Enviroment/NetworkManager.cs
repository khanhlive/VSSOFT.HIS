namespace Vssoft.Common.Enviroment
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Management;
    using System.Net;

    public static class NetworkManager
    {
        private static Dictionary<string, Vssoft.Common.Enviroment.NetworkInfo> _mInformations;
        private static Vssoft.Common.Enviroment.NetworkInfo _networkInfo;

        public static void Extract()
        {
            Vssoft.Common.Enviroment.NetworkInfo info = null;
            if (_mInformations.Count > 0)
            {
                foreach (Vssoft.Common.Enviroment.NetworkInfo info2 in _mInformations.Values)
                {
                    if (info2.Status == NetConnectionStatus.Connected)
                    {
                        info = info2;
                        break;
                    }
                    info = info2;
                }
            }
            if (info == null)
            {
                info = new Vssoft.Common.Enviroment.NetworkInfo {
                    DeviceName = "",
                    MacAddress = "",
                    AdapterType = "",
                    Ip = "0.0.0.0",
                    IpWan = "0.0.0.0",
                    Mask = "0.0.0.0",
                    DefaultGateway = "0.0.0.0",
                    ConnectionID = ""
                };
            }
            info.IpWan = GetIpWan();
            _networkInfo = info;
        }

        private static string GetIpWan()
        {
            try
            {
                WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                Console.WriteLine(response.StatusDescription);
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string str = reader.ReadToEnd();
                int index = str.IndexOf(":");
                str = str.Remove(0, index + 1);
                int startIndex = str.LastIndexOf("</body>");
                str = str.Remove(startIndex, 14);
                reader.Close();
                responseStream.Close();
                response.Close();
                return str.Trim();
            }
            catch (Exception)
            {
                return "0.0.0.0";
            }
        }

        private static string ParseProperty(object data)
        {
            if (data != null)
            {
                return data.ToString();
            }
            return "";
        }

        public static void ReadSysInfo()
        {
            Vssoft.Common.Enviroment.NetworkInfo info;
            _mInformations = new Dictionary<string, Vssoft.Common.Enviroment.NetworkInfo>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL");
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    info = null;
                    try
                    {
                        info = new Vssoft.Common.Enviroment.NetworkInfo {
                            DeviceName = ParseProperty(obj2["Description"]),
                            AdapterType = ParseProperty(obj2["AdapterType"]),
                            MacAddress = ParseProperty(obj2["MACAddress"]),
                            ConnectionID = ParseProperty(obj2["NetConnectionID"]),
                            Status = (NetConnectionStatus) Convert.ToInt32(obj2["NetConnectionStatus"])
                        };
                    }
                    catch
                    {
                        info = null;
                    }
                    if (info != null)
                    {
                        SetIp(info);
                        _mInformations.Add(info.ConnectionID, info);
                    }
                }
            }
            catch
            {
                info = new Vssoft.Common.Enviroment.NetworkInfo {
                    DeviceName = "",
                    MacAddress = "",
                    AdapterType = "",
                    Ip = "0.0.0.0",
                    IpWan = "0.0.0.0",
                    Mask = "0.0.0.0",
                    DefaultGateway = "0.0.0.0",
                    ConnectionID = ""
                };
                _mInformations.Add(info.ConnectionID, info);
            }
        }

        private static void SetIp(Vssoft.Common.Enviroment.NetworkInfo info)
        {
            ManagementClass class2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                try
                {
                    if (info.Status != NetConnectionStatus.Connected)
                    {
                        info.Ip = "0.0.0.0";
                        info.Mask = "0.0.0.0";
                        info.DefaultGateway = "0.0.0.0";
                    }
                    if (((bool) obj2["ipEnabled"]) && obj2["MACAddress"].ToString().Equals(info.MacAddress))
                    {
                        string[] strArray = (string[]) obj2["IPAddress"];
                        info.Ip = strArray[0];
                        string[] strArray2 = (string[]) obj2["IPSubnet"];
                        info.Mask = strArray2[0];
                        string[] strArray3 = (string[]) obj2["DefaultIPGateway"];
                        info.DefaultGateway = strArray3[0];
                        break;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine("[SetIP]:" + exception.Message);
                }
            }
        }

        public static Vssoft.Common.Enviroment.NetworkInfo NetworkInfo =>
            _networkInfo;
    }
}

