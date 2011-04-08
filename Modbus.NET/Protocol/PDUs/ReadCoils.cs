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
    /// This class is a Modbus PDU for the Read Coils function code (0x01).
    /// It is used to read from 1 to 2000 contiguous status coils (bits)
    /// in a remote device starting at the given address and for the given
    /// number of coils (bits).
    /// </summary>
    public class ReadCoils : AModbusPDU
    {

        #region Properties

        #region StartAddress

        /// <summary>
        /// The starting address.
        /// </summary>
        public UInt16 StartAddress  { get; private set; }

        #endregion

        #region NumberOfCoils

        /// <summary>
        /// The number of coils (bits) to read.
        /// </summary>
        public UInt16 NumberOfCoils { get; private set; }

        #endregion

        #region Serialized

        /// <summary>
        /// A serialized representation of this PDU.
        /// </summary>
        public override Byte[] Serialized
        {
            get
            {
                return ModbusProtocol.CreateReadHeader(
                                        this.InvocationId,
                                        this.StartAddress,
                                        this.NumberOfCoils,
                                        this.FunctionCode).ToArray();
            }
        }

        #endregion

        #endregion

        #region Constructor(s)

        #region ReadCoils(myModbusDevice, myStartAddress, myNumberOfCoils)

        /// <summary>
        /// This creates a new Modbus PDU for the Read Coils function code (0x01).
        /// It is used to read from 1 to 2000 contiguous status coils (bits)
        /// in a remote device starting at the given address and for the given
        /// number of coils (bits).
        /// </summary>
        /// <param name="myModbusDevice">The Modbus device.</param>
        /// <param name="myStartAddress">The starting address.</param>
        /// <param name="myNumberOfCoils">The number of coils to read.</param>
        public ReadCoils(IModbusDevice myModbusDevice, UInt16 myStartAddress, UInt16 myNumberOfCoils)
            : base(myModbusDevice, FunctionCode.ReadCoils)
        {
            StartAddress  = myStartAddress;
            NumberOfCoils = myNumberOfCoils;
        }

        #endregion

        #endregion

    }

}
