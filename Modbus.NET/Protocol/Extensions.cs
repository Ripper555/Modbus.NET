/*
 * Copyright (c) 2011, Aperis GmbH, http://www.aperis.com
 * Autor: Achim 'ahzf' Friedland <achim.friedland@aperis.com>
 * This file is part of Modbus.NET
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.IO;
using System.Net;

#endregion

namespace com.aperis.Modbus
{

    public enum ByteOrder
    {
        Unmodified,
        HostToNetwork,
        NetworkToHost
    }

    public static class Extensions
    {

        #region WriteWord(this myMemoryStream, myWord, myByteOrder = ByteOrder.Unmodified)

        public static void WriteWord(this MemoryStream myMemoryStream, Int16 myWord, ByteOrder myByteOrder = ByteOrder.Unmodified)
        {
            
            Byte[] _Bytes = null;
            
            switch (myByteOrder)
            {

                case ByteOrder.Unmodified :
                    _Bytes = BitConverter.GetBytes(myWord);
                    break;

                case ByteOrder.HostToNetwork :
                    _Bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(myWord));
                    break;
                
                case ByteOrder.NetworkToHost :
                    _Bytes = BitConverter.GetBytes(IPAddress.NetworkToHostOrder(myWord));
                    break;

            }

            myMemoryStream.WriteByte(_Bytes[0]);  // high byte
            myMemoryStream.WriteByte(_Bytes[1]);  // low  byte

        }

        #endregion

        #region WriteWord(this myMemoryStream, myWord, myByteOrder = ByteOrder.Unmodified)

        public static void WriteWord(this MemoryStream myMemoryStream, UInt16 myWord, ByteOrder myByteOrder = ByteOrder.Unmodified)
        {

            Byte[] _Bytes = null;

            switch (myByteOrder)
            {

                case ByteOrder.Unmodified:
                    _Bytes = BitConverter.GetBytes(myWord);
                    break;

                case ByteOrder.HostToNetwork:
                    _Bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(myWord));
                    break;

                case ByteOrder.NetworkToHost:
                    _Bytes = BitConverter.GetBytes(IPAddress.NetworkToHostOrder(myWord));
                    break;

            }

            myMemoryStream.WriteByte(_Bytes[0]);  // high byte
            myMemoryStream.WriteByte(_Bytes[1]);  // low  byte

        }

        #endregion

        #region Write(this myMemoryStream, myBytes, myOffset)

        public static void Write(this MemoryStream myMemoryStream, Byte[] myBytes, Int32 myOffset)
        {
            myMemoryStream.Write(myBytes, myOffset, myBytes.Length);
        }

        #endregion

    }

}
