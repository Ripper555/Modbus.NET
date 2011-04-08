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
    /// An abstract Modbus PDU for the given function code.
    /// </summary>
    public abstract class AModbusPDU
    {

        #region Properties

        #region ModbusDevice

        /// <summary>
        /// The Modbus device.
        /// </summary>
        public IModbusDevice ModbusDevice { get; private set; }

        #endregion

        #region FunctionCode

        /// <summary>
        /// The function code of this PDU.
        /// </summary>
        public FunctionCode FunctionCode { get; private set; }

        #endregion

        #region InvocationId

        /// <summary>
        /// The Modbus InvocationId.
        /// </summary>
        public UInt16 InvocationId { get; private set; }

        #endregion

        #region Serialized

        /// <summary>
        /// A serialized representation of this PDU.
        /// </summary>
        public abstract Byte[] Serialized { get; }

        #endregion

        #endregion

        #region Constructor(s)

        #region AModbusPDU(myModbusDevice, myFunctionCode)

        /// <summary>
        /// Creates an abstract Modbus PDU for the given function code.
        /// </summary>
        /// <param name="myModbusDevice">The Modbus device.</param>
        /// <param name="myFunctionCode">The function code.</param>
        protected AModbusPDU(IModbusDevice myModbusDevice, FunctionCode myFunctionCode)
        {
            
            ModbusDevice = myModbusDevice;
            FunctionCode = myFunctionCode;

            InvocationId = this.ModbusDevice.NextInvocationId;

        }

        #endregion

        #endregion

    }

}
