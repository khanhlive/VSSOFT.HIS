namespace Vssoft.Common.Enviroment
{
    using System;
    using System.Runtime.CompilerServices;

    public class NetworkInfo
    {
        private NetConnectionStatus _mStatus;

        public string GetHelp()
        {
            if (this._mStatus == NetConnectionStatus.Connected)
            {
                return "Connect succeed.";
            }
            if (this._mStatus == NetConnectionStatus.Disconnected)
            {
                return "Your connection was disable, please check Network Setting in Console.";
            }
            if (this._mStatus == NetConnectionStatus.MediaDisconnected)
            {
                return "Cable had bad contact with Network Card! Please check it.";
            }
            if (this._mStatus == NetConnectionStatus.InvalidAddress)
            {
                return "IP address is Invalid, please check DHCP/Router or IP setting.";
            }
            return $"NetConnectionStatus is {this._mStatus}";
        }

        public string AdapterType { get; set; }

        public string ConnectionID { get; set; }

        public string DefaultGateway { get; set; }

        public string DeviceName { get; set; }

        public string Ip { get; set; }

        public string IpWan { get; set; }

        public string MacAddress { get; set; }

        public string Mask { get; set; }

        public NetConnectionStatus Status
        {
            get => 
                this._mStatus;
            set
            {
                this._mStatus = value;
            }
        }
    }
}

