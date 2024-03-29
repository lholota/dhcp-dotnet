﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Options;

namespace LH.Dhcp
{
    public class DhcpPacket
    {
        private readonly IReadOnlyList<IDhcpOption> _options;

        internal DhcpPacket(
            uint transactionId, 
            DhcpOperation operation, 
            ClientHardwareAddress clientHardwareAddress,
            uint hops,
            ushort secs,
            bool isBroadcast,
            IPAddress clientIp,
            IPAddress yourIp,
            IPAddress serverIp,
            IPAddress gatewayIp,
            string serverName,
            string bootFile,
            IReadOnlyList<IDhcpOption> options)
        {
            _options = options;
            Secs = secs;
            IsBroadcast = isBroadcast;
            ClientIp = clientIp;
            YourIp = yourIp;
            ServerIp = serverIp;
            GatewayIp = gatewayIp;
            ServerName = serverName;
            BootFile = bootFile;
            TransactionId = transactionId;
            Operation = operation;
            ClientHardwareAddress = clientHardwareAddress;
            Hops = hops;
        }

        public uint TransactionId { get; }

        public DhcpOperation Operation { get; }

        public ClientHardwareAddress ClientHardwareAddress { get; }

        public uint Hops { get; }

        public ushort Secs { get; }

        public bool IsBroadcast { get; }

        public IPAddress ClientIp { get; }

        public IPAddress YourIp { get; }

        public IPAddress ServerIp { get; }

        public IPAddress GatewayIp { get; }

        public string ServerName { get; }

        public string BootFile { get; }

        public bool HasOption<TOption>() where TOption : IDhcpOption
        {
            return _options.Any(x => x is TOption);
        }

        public TOption GetOption<TOption>() where TOption : IDhcpOption
        {
            var result = _options.OfType<TOption>().SingleOrDefault();

            if (result == null)
            {
                throw new InvalidOperationException($"The DHCP Packet does not contain the option of type {typeof(TOption)}.");
            }

            return result;
        }
    }
}