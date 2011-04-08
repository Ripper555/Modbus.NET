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
using System.Threading;

#endregion

namespace com.aperis.Modbus
{

    /// <summary>
    /// A Modbus Master (Client)
    /// </summary>
    public class ModbusMaster : IModbusMaster
    {

        private Int32 _InvocationId;

        public UInt16 NextInvocationId
        {
            get
            {
                Interlocked.Increment(ref _InvocationId);
                Interlocked.CompareExchange(ref _InvocationId, 0, UInt16.MaxValue);
                return (UInt16) _InvocationId;
            }
        }



        public ModbusMaster()
        {
            _InvocationId = 0;
        }



        // ------------------------------------------------------------------------
        /// <summary>Read coils from slave asynchronous. The result is given in the response function.</summary>
        /// <param name="myInvocationId">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="myStartAddress">Address from where the data read begins.</param>
        /// <param name="myNumberOfCoils">Length of data.</param>
        public void ReadCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 myNumberOfCoils)
        {
            WriteAsyncData(ModbusProtocol.CreateReadHeader(myInvocationId, myStartAddress, myNumberOfCoils, FunctionCode.ReadCoils), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read coils from slave synchronous.</summary>
        /// <param name="myInvocationId">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="myStartAddress">Address from where the data read begins.</param>
        /// <param name="myNumberOfCoils">Length of data.</param>
        /// <param name="values">Contains the result of function.</param>
        public void ReadCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 myNumberOfCoils, ref Byte[] values)
        {
            values = WriteSyncData(ModbusProtocol.CreateReadHeader(myInvocationId, myStartAddress, myNumberOfCoils, FunctionCode.ReadCoils), myInvocationId);
        }












        // ------------------------------------------------------------------------
        /// <summary>Read discrete inputs from slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        public void ReadDiscreteInputs(UInt16 myInvocationId, UInt16 startAddress, UInt16 numInputs)
        {
            WriteAsyncData(ModbusProtocol.CreateReadHeader(myInvocationId, startAddress, numInputs, FunctionCode.ReadDiscreteInputs), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read discrete inputs from slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        /// <param name="values">Contains the result of function.</param>
        public void ReadDiscreteInputs(UInt16 myInvocationId, UInt16 startAddress, UInt16 numInputs, ref Byte[] values)
        {
            values = WriteSyncData(ModbusProtocol.CreateReadHeader(myInvocationId, startAddress, numInputs, FunctionCode.ReadDiscreteInputs), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read holding registers from slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        public void ReadHoldingRegister(UInt16 myInvocationId, UInt16 startAddress, UInt16 numInputs)
        {
            WriteAsyncData(ModbusProtocol.CreateReadHeader(myInvocationId, startAddress, numInputs, FunctionCode.ReadHoldingRegister), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read holding registers from slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        /// <param name="values">Contains the result of function.</param>
        public void ReadHoldingRegister(UInt16 myInvocationId, UInt16 startAddress, UInt16 numInputs, ref Byte[] values)
        {
            values = WriteSyncData(ModbusProtocol.CreateReadHeader(myInvocationId, startAddress, numInputs, FunctionCode.ReadHoldingRegister), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read input registers from slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        public void ReadInputRegister(UInt16 myReqestNumber, UInt16 myStartAddress, UInt16 myNumberOfInputs)
        {
            WriteAsyncData(ModbusProtocol.CreateReadHeader(myReqestNumber, myStartAddress, myNumberOfInputs, FunctionCode.ReadInputRegister),
                myReqestNumber);
        }

        // ------------------------------------------------------------------------
        /// <summary>Read input registers from slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        /// <param name="values">Contains the result of function.</param>
        public void ReadInputRegister(UInt16 myInvocationId, UInt16 startAddress, UInt16 numInputs, ref Byte[] values)
        {
            values = WriteSyncData(ModbusProtocol.CreateReadHeader(myInvocationId, startAddress, numInputs, FunctionCode.ReadInputRegister), myInvocationId);
        }

        // ------------------------------------------------------------------------
        /// <summary>Write single coil in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="OnOff">Specifys if the coil should be switched on or off.</param>
        public void WriteSingleCoils(UInt16 myInvocationId, UInt16 startAddress, bool OnOff)
        {

            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, 1, 1, FunctionCode.WriteSingleCoil);
            
            if (OnOff == true)
            {
                _ModbusPDU.Seek(10, SeekOrigin.Begin);
                _ModbusPDU.WriteByte(255);
            }

            WriteAsyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write single coil in slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="OnOff">Specifys if the coil should be switched on or off.</param>
        /// <param name="result">Contains the result of the synchronous write.</param>
        public void WriteSingleCoils(UInt16 myInvocationId, UInt16 startAddress, bool OnOff, ref Byte[] result)
        {

            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, 1, 1, FunctionCode.WriteSingleCoil);
            
            if (OnOff == true)
            {
                _ModbusPDU.Seek(10, SeekOrigin.Begin);
                _ModbusPDU.WriteByte(255);
            }

            result = WriteSyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write multiple coils in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numBits">Specifys number of bits.</param>
        /// <param name="values">Contains the bit information in byte format.</param>
        public void WriteMultipleCoils(UInt16 myInvocationId, UInt16 startAddress, UInt16 numBits, Byte[] values)
        {

            var _NumBytes = Convert.ToByte(values.Length);
            var _ModbusPDU   = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, numBits, (byte)(_NumBytes + 2), FunctionCode.WriteMultipleCoils);

            _ModbusPDU.Write(values, 13, _NumBytes);

            WriteAsyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write multiple coils in slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numBits">Specifys number of bits.</param>
        /// <param name="values">Contains the bit information in byte format.</param>
        /// <param name="result">Contains the result of the synchronous write.</param>
        public void WriteMultipleCoils(UInt16 myInvocationId, UInt16 startAddress, UInt16 numBits, Byte[] values, ref Byte[] result)
        {
            
            var _NumBytes = Convert.ToByte(values.Length);
            var _ModbusPDU   = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, numBits, (byte)(_NumBytes + 2), FunctionCode.WriteMultipleCoils);

            _ModbusPDU.Write(values, 13, _NumBytes);

            result = WriteSyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write single register in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        public void WriteSingleRegister(UInt16 myInvocationId, UInt16 startAddress, Byte[] values)
        {
            
            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, 1, 1, FunctionCode.WriteSingleRegister);

            _ModbusPDU.Write(values, 10, 2);
            
            WriteAsyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write single register in slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        /// <param name="result">Contains the result of the synchronous write.</param>
        public void WriteSingleRegister(UInt16 myInvocationId, UInt16 startAddress, Byte[] values, ref Byte[] result)
        {
            
            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, 1, 1, FunctionCode.WriteSingleRegister);
            
            _ModbusPDU.Write(values, 10, 2);

            result = WriteSyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write multiple registers in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        public void WriteMultipleRegister(UInt16 myInvocationId, UInt16 startAddress, Byte[] values)
        {
            
            var _NumBytes = Convert.ToUInt16(values.Length);
            if (_NumBytes % 2 > 0) _NumBytes++;

            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, Convert.ToUInt16(_NumBytes / 2), Convert.ToByte(_NumBytes + 2), FunctionCode.WriteMultipleRegister);

            _ModbusPDU.Write(values, 13);

            WriteAsyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Write multiple registers in slave synchronous.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        /// <param name="result">Contains the result of the synchronous write.</param>
        public void WriteMultipleRegister(UInt16 myInvocationId, UInt16 startAddress, Byte[] values, ref Byte[] result)
        {

            UInt16 numBytes = Convert.ToUInt16(values.Length);
            if (numBytes % 2 > 0) numBytes++;
            
            var _ModbusPDU = ModbusProtocol.CreateWriteHeader(myInvocationId, startAddress, Convert.ToUInt16(numBytes / 2), Convert.ToByte(numBytes + 2), FunctionCode.WriteMultipleRegister);

            _ModbusPDU.Write(values, 13);

            result = WriteSyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Read/Write multiple registers in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startReadAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        /// <param name="startWriteAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        public void ReadWriteMultipleRegister(UInt16 myInvocationId, UInt16 startReadAddress, UInt16 numInputs, UInt16 startWriteAddress, Byte[] values)
        {
            
            UInt16 numBytes = Convert.ToUInt16(values.Length);
            if (numBytes % 2 > 0) numBytes++;
            
            var _ModbusPDU = ModbusProtocol.CreateReadWriteHeader(myInvocationId, startReadAddress, numInputs, startWriteAddress, Convert.ToUInt16(numBytes / 2));

            _ModbusPDU.Write(values, 17);

            WriteAsyncData(_ModbusPDU, myInvocationId);

        }

        // ------------------------------------------------------------------------
        /// <summary>Read/Write multiple registers in slave synchronous. The result is given in the response function.</summary>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="startReadAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        /// <param name="startWriteAddress">Address to where the data is written.</param>
        /// <param name="values">Contains the register information.</param>
        /// <param name="result">Contains the result of the synchronous command.</param>
        public void ReadWriteMultipleRegister(UInt16 myInvocationId, UInt16 startReadAddress, UInt16 numInputs, UInt16 startWriteAddress, Byte[] values, ref Byte[] result)
        {
            
            UInt16 numBytes = Convert.ToUInt16(values.Length);
            if (numBytes % 2 > 0) numBytes++;
            
            var _ModbusPDU = ModbusProtocol.CreateReadWriteHeader(myInvocationId, startReadAddress, numInputs, startWriteAddress, Convert.ToUInt16(numBytes / 2));

            _ModbusPDU.Write(values, 17);
            
            result = WriteSyncData(_ModbusPDU, myInvocationId);

        }
















        


        // Write asynchronous data
        private void WriteAsyncData(MemoryStream write_data, UInt16 id)
        {
            //if ((tcpAsyCl != null) && (tcpAsyCl.Connected))
            //{
            //    try
            //    {
            //        tcpAsyCl.BeginSend(write_data, 0, write_data.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            //        tcpAsyCl.BeginReceive(tcpAsyClBuffer, 0, tcpAsyClBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), tcpAsyCl);
            //    }
            //    catch (SystemException)
            //    {
            //        CallException(id, write_data[7], excExceptionConnectionLost);
            //    }
            //}
            //else CallException(id, write_data[7], excExceptionConnectionLost);
        }


        // Write data and and wait for response
        private byte[] WriteSyncData(MemoryStream write_data, ushort id)
        {

            //if (tcpSynCl.Connected)
            //{
            //    try
            //    {
            //        tcpSynCl.Send(write_data, 0, write_data.Length, SocketFlags.None);
            //        int result = tcpSynCl.Receive(tcpSynClBuffer, 0, tcpSynClBuffer.Length, SocketFlags.None);

            //        byte function = tcpSynClBuffer[7];
            //        byte[] data;

            //        if (result == 0) CallException(id, write_data[7], excExceptionConnectionLost);

            //        // ------------------------------------------------------------
            //        // Response data is slave exception
            //        if (function > excExceptionOffset)
            //        {
            //            function -= excExceptionOffset;
            //            CallException(id, function, tcpSynClBuffer[8]);
            //            return null;
            //        }
            //        // ------------------------------------------------------------
            //        // Write response data
            //        else if ((function >= fctWriteSingleCoil) && (function != fctReadWriteMultipleRegister))
            //        {
            //            data = new byte[2];
            //            Array.Copy(tcpSynClBuffer, 10, data, 0, 2);
            //        }
            //        // ------------------------------------------------------------
            //        // Read response data
            //        else
            //        {
            //            data = new byte[tcpSynClBuffer[8]];
            //            Array.Copy(tcpSynClBuffer, 9, data, 0, tcpSynClBuffer[8]);
            //        }
            //        return data;
            //    }
            //    catch (SystemException)
            //    {
            //        CallException(id, write_data[7], excExceptionConnectionLost);
            //    }
            //}
            //else CallException(id, write_data[7], excExceptionConnectionLost);
            return null;
        }

/*

        // 'req' is an instance of the low-level `ModbusRequestStack` class
        var req = client.request(FunctionCode.ReadInputRegister, // Function Code: 4
                                 0,    // Start at address 0
                                 50);  // Read 50 contiguous registers from 0

        
        req.on('response', function(registers) {
            // An Array of length 50 filled with Numbers of the current registers.
            Console.WriteLine(registers);
            client.end();
        });

*/


        
    }

}
