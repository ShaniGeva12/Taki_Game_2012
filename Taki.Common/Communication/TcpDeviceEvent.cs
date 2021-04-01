using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes;

namespace Taki.Common.Communication
{
    public class TcpDeviceEvent
    {
        private static Array MessgeTypesArray = Enum.GetValues(typeof(MessageTypes));
        
        public TcpDeviceEvent(byte[] data, byte byteMessageType)
            : this(data)
        {
            MessageType = GetTypeFromByte(byteMessageType);
        }

        public TcpDeviceEvent(byte[] data, MessageTypes messageType)
            : this(data)
        {
            MessageType = messageType;
        }

        private TcpDeviceEvent(byte[] data)
        {
            Data = data;
        }

        public static MessageTypes GetTypeFromByte(byte Byte)
        {
            try
            {
                return (MessageTypes)MessgeTypesArray.GetValue((int)Byte);
            }
            catch
            {
                return MessageTypes.ERROR;
            }
        }

        public byte[] Data
        {
            get;
            private set;
        }

        public byte ByteMessageType
        {
            get;
            private set;
        }

        private MessageTypes mMessageType;

        public MessageTypes MessageType
        {
            get { return mMessageType; }
            set
            {
                mMessageType = value;

                for (int i = 1; i < MessgeTypesArray.Length; i++)
                {
                    if ((MessageTypes)MessgeTypesArray.GetValue(i) == value)
                    {
                        ByteMessageType = (byte)i;
                        break;
                    }
                }

            }
        }


    }
}
