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

#endregion

namespace com.aperis.Modbus
{

    /// <summary>
    /// The interface for a Modbus master (client).
    /// </summary>
    public interface IModbusMaster : IModbusDevice
    {

        void ReadCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 myNumberOfCoils);
        void ReadCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 myNumberOfCoils, ref Byte[] values);

        void ReadDiscreteInputs(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numInputs);
        void ReadDiscreteInputs(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numInputs, ref Byte[] values);

        void ReadHoldingRegister(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numInputs);
        void ReadHoldingRegister(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numInputs, ref Byte[] values);

        void ReadInputRegister(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numInputs, ref Byte[] values);
        void ReadInputRegister(UInt16 myReqestNumber, UInt16 mymyStartAddress, UInt16 myNumberOfInputs);

        void ReadWriteMultipleRegister(UInt16 myInvocationId, UInt16 startReadAddress, UInt16 numInputs, UInt16 startWriteAddress, Byte[] values);
        void ReadWriteMultipleRegister(UInt16 myInvocationId, UInt16 startReadAddress, UInt16 numInputs, UInt16 startWriteAddress, Byte[] values, ref Byte[] result);

        void WriteMultipleCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numBits, Byte[] values);
        void WriteMultipleCoils(UInt16 myInvocationId, UInt16 myStartAddress, UInt16 numBits, Byte[] values, ref Byte[] result);

        void WriteMultipleRegister(UInt16 myInvocationId, UInt16 myStartAddress, Byte[] values);
        void WriteMultipleRegister(UInt16 myInvocationId, UInt16 myStartAddress, Byte[] values, ref Byte[] result);

        void WriteSingleCoils(UInt16 myInvocationId, UInt16 myStartAddress, Boolean OnOff);
        void WriteSingleCoils(UInt16 myInvocationId, UInt16 myStartAddress, Boolean OnOff, ref Byte[] result);

        void WriteSingleRegister(UInt16 myInvocationId, UInt16 myStartAddress, Byte[] values);
        void WriteSingleRegister(UInt16 myInvocationId, UInt16 myStartAddress, Byte[] values, ref Byte[] result);

    }

}
