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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

#endregion

namespace com.aperis.Modbus
{

    public class ModbusProtocol
    {

        // The byte length of the "MODBUS Application Protocol" header.
        const Byte MBAP_LENGTH = 7;

        // The byte length of the "MODBUS Function Code".
        const Byte FUNCTIONCODE_LENGTH = 1;
        
        // An exception response from a MODBUS slave (server) will have
        // the high-bit (0x80) set on it's function code.
        const Byte EXCEPTION_BIT = 1 << 7;


        #region CreateGenericHeader(myInvocationId, myMessageSize, myFunctionCode)

        public static MemoryStream CreateGenericHeader(UInt16 myInvocationId, UInt16 myMessageSize, FunctionCode myFunctionCode)
        {

            var _MemoryStream = new MemoryStream(20);

            _MemoryStream.WriteWord(myInvocationId);                         // Invocation/Transaction Identifier
            _MemoryStream.WriteWord(0);                                      // Protocol Identifier (Zero for Modbus/TCP)
            _MemoryStream.WriteWord(myMessageSize, ByteOrder.HostToNetwork); // Length Field/Message size
            _MemoryStream.WriteByte(0);                                      // Unit Identifier/Slave address (255 if not used)
            _MemoryStream.WriteByte(myFunctionCode.Value);                   // Function code

            return _MemoryStream;

        }

        #endregion


        /// <summary>
        /// Create modbus header for reading.
        /// </summary>
        /// <param name="myInvocationId"></param>
        /// <param name="myStartAddress"></param>
        /// <param name="myLength"></param>
        /// <param name="myFunctionCode"></param>
        /// <returns></returns>
        public static MemoryStream CreateReadHeader(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 myLength, FunctionCode myFunctionCode)
        {

            var _Header = CreateGenericHeader(myInvocationId, 6, myFunctionCode);

            // Start address
            var _adr = BitConverter.GetBytes((Int16) IPAddress.HostToNetworkOrder((Int16) myStartAddress));
            _Header.WriteByte(_adr[0]);             // high byte
            _Header.WriteByte(_adr[1]);				// low  byte

            // Number of data to read
            var _length = BitConverter.GetBytes((Int16) IPAddress.HostToNetworkOrder((Int16) myLength));
            _Header.WriteByte(_length[0]);			// high byte
            _Header.WriteByte(_length[1]);			// low  byte

            return _Header;

        }

        // Create modbus header for write action
        public static MemoryStream CreateWriteHeader(UInt16 myInvocationId, UInt16 startAddress, UInt16 numData, Byte numBytes, FunctionCode myFunctionCode)
        {

            var _Header = CreateGenericHeader(myInvocationId, (UInt16) (numBytes + 5) , myFunctionCode);

            _Header.WriteWord(startAddress, ByteOrder.HostToNetwork);

            if (myFunctionCode >= FunctionCode.WriteMultipleCoils)
            {
                _Header.WriteWord(numData, ByteOrder.HostToNetwork);
                _Header.WriteByte((Byte) (numBytes - 2));
            }

            return _Header;

        }

        // Create modbus header for write action
        public static MemoryStream CreateReadWriteHeader(UInt16 myInvocationId, UInt16 startReadAddress, UInt16 numRead, UInt16 startWriteAddress, UInt16 numWrite)
        {

            var _Header = CreateGenericHeader(myInvocationId, (UInt16)(11 + numWrite * 2), FunctionCode.ReadWriteMultipleRegister);

            _Header.WriteWord(startReadAddress,  ByteOrder.HostToNetwork);
            _Header.WriteWord(numRead,           ByteOrder.HostToNetwork);
            _Header.WriteWord(startWriteAddress, ByteOrder.HostToNetwork);
            _Header.WriteWord(numWrite,          ByteOrder.HostToNetwork);
            _Header.WriteByte((Byte)(numWrite * 2));

            return _Header;

        }

    }

}
