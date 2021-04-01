using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Taki.Common.Communication
{
    public static class PacketLostHandel
    {
        public static byte[] GetDataFromSocket(Socket TheSocket, int RecvicedLength)
        {
            byte[] ReturnData = new byte[RecvicedLength];

            int TempRecvicedLength = 0;
            byte[] TempData = new byte[RecvicedLength];

            TheSocket.ReceiveBufferSize = RecvicedLength;

            while (TempRecvicedLength < RecvicedLength)
            {
                int TempDataRecvicedLength = TheSocket.Receive(TempData);
                Buffer.BlockCopy(TempData, 0, ReturnData, TempRecvicedLength, TempDataRecvicedLength);
                TempData = new byte[RecvicedLength];
                TempRecvicedLength += TempDataRecvicedLength;
            }
            return ReturnData;
        }

        public static byte[] GetDataFroStream(NetworkStream mStreamFromServer, int recvicedLength)
        {
            byte[] ReturnData = new byte[recvicedLength];

            int TempRecvicedLength = 0;
            byte[] TempData = new byte[recvicedLength];

            while (TempRecvicedLength < recvicedLength)
            {
                int TempDataRecvicedLength = mStreamFromServer.Read(TempData, 0, recvicedLength);
                Buffer.BlockCopy(TempData, 0, ReturnData, TempRecvicedLength, TempDataRecvicedLength);
                TempData = new byte[recvicedLength];
                TempRecvicedLength += TempDataRecvicedLength;
            }
            return ReturnData;
        }
    }
}
