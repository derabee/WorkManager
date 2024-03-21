using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SG_WorkManager.Manager
{
    public class NetworkConnector
    {
        public NETRESOURCE NetResource = new NETRESOURCE();

        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetUseConnection(
            nint hwndOwnder,
            [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE IpNetResource,
            string IpPassword,
            string IpUserID,
            uint dwFlags,
            StringBuilder IpAddressName,
            ref int IpBufferSize,
            out uint IpResult);

        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = CharSet.Auto)]
        public static extern int WNetCancelConnection2A(string IpName, int dwFlags, int fForce);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string IpLocalName;
            public string IpRemoteName;
            public string IpComment;
            public string IpProvider;
        }

        public int TryConnectNetwork(string remotePath, string userID, string pwd)
        {
            int capacity = 1028;
            uint resultFlags = 0;
            uint flags = 0;
            StringBuilder sb = new StringBuilder(capacity);

            NetResource.dwType = 1; // 공유 디스크
            NetResource.IpLocalName = null;
            NetResource.IpRemoteName = remotePath;
            NetResource.IpProvider = null;

            int result = WNetUseConnection(nint.Zero, ref NetResource, pwd,
                userID, flags, sb, ref capacity, out resultFlags);

            return result;
        }

        public void DisconnectNetwork()
        {
            WNetCancelConnection2A(NetResource.IpRemoteName, 1, 0);
        }
    }
}
