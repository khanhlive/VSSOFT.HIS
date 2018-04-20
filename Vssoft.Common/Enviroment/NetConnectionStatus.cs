namespace Vssoft.Common.Enviroment
{
    using System;

    public enum NetConnectionStatus
    {
        Disconnected,
        Connecting,
        Connected,
        Disconnecting,
        HardwareNotPresent,
        HardwareDisabled,
        HardwareMalfunction,
        MediaDisconnected,
        Authenticating,
        AuthenticationSucceeded,
        AuthenticationFailed,
        InvalidAddress,
        CredentialsRequired
    }
}

