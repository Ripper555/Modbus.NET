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
    /// Each of the function codes has a potentially different body payload
    /// and potentially different parameters to send.
    /// </summary>
    public sealed class FunctionCode : IEquatable<FunctionCode>, IComparable<FunctionCode>, IComparable
    {

        #region Properties

        #region Info

        private String _Info;

        /// <summary>
        /// A human readable short information on this function code.
        /// </summary>
        public String Info
        {
            get
            {
                return _Info;
            }
        }

        #endregion

        #region Value

        private Byte _Value;

        /// <summary>
        /// The numeric value of this function code.
        /// </summary>
        public Byte Value
        {
            get
            {
                return _Value;
            }
        }

        #endregion

        #region AccessRight

        private AccessRight _AccessRight;

        /// <summary>
        /// The access right (e.g. read or readwrite).
        /// </summary>
        public AccessRight AccessRight
        {
            get
            {
                return _AccessRight;
            }
        }

        #endregion

        #region AccessGroup

        private AccessGroup _AccessGroup;

        /// <summary>
        /// The access group, which could e.g. define
        /// the expected type of the return value.
        /// </summary>
        public AccessGroup AccessGroup
        {
            get
            {
                return _AccessGroup;
            }
        }

        #endregion

        #region Description

        private String _Description;

        /// <summary>
        /// A description of this function code.
        /// </summary>
        public String Description
        {
            get
            {
                return _Description;
            }
        }

        #endregion

        #endregion

        #region Constructor(s)

        #region FunctionCode(myInfo, myValue, myAccessRight, myAccessGroup, myDescription = null)

        /// <summary>
        /// Create a new ExceptionCode.
        /// </summary>
        /// <param name="myInfo">A short information on the exception code.</param>
        /// <param name="myValue">The numberic value of this exception code.</param>
        /// <param name="myAccessRight">The access right (e.g. read or readwrite).</param>
        /// <param name="myAccessGroup">The access group, which could e.g. define the expected type of the return value.</param>
        /// <param name="myDescription">A description of this exception code.</param>
        public FunctionCode(String myInfo, Byte myValue, AccessRight myAccessRight, AccessGroup myAccessGroup, String myDescription = null)
        {
            _Info        = myInfo;
            _Value       = myValue;
            _AccessRight = myAccessRight;
            _AccessGroup = myAccessGroup;
            _Description = myDescription;
        }

        #endregion

        #endregion


        public static readonly FunctionCode ReadCoils                      = new FunctionCode("Read coils",                          1, AccessRight.read,      AccessGroup.bit);
        public static readonly FunctionCode ReadDiscreteInputs             = new FunctionCode("Read discrete inputs",                2, AccessRight.read,      AccessGroup.bit,         "Single sensor bit");
        public static readonly FunctionCode ReadHoldingRegister            = new FunctionCode("Read holding register",               3, AccessRight.read,      AccessGroup.word,        "16-bit sensor word");
        public static readonly FunctionCode ReadInputRegister              = new FunctionCode("Read input register",                 4, AccessRight.read,      AccessGroup.word,        "16-bit sensor word");
        
        public static readonly FunctionCode WriteSingleCoil                = new FunctionCode("Write single coil",                   5, AccessRight.readwrite, AccessGroup.bit,         "Single actor bit");
        public static readonly FunctionCode WriteSingleRegister            = new FunctionCode("Write single register",               6, AccessRight.readwrite, AccessGroup.word);
        public static readonly FunctionCode ReadExceptionStatus            = new FunctionCode("Read Exception Status",               7, AccessRight.read,      AccessGroup.diagnostics);
        public static readonly FunctionCode Diagnostic                     = new FunctionCode("Diagnostic",                          8, AccessRight.readwrite, AccessGroup.diagnostics);

        public static readonly FunctionCode GetComEventCounter             = new FunctionCode("Get Com Event Counter",              11, AccessRight.read,      AccessGroup.diagnostics);
        public static readonly FunctionCode GetComEventLog                 = new FunctionCode("Get Com Event Log",                  12, AccessRight.read,      AccessGroup.diagnostics);

        public static readonly FunctionCode WriteMultipleCoils             = new FunctionCode("Write multiple coils",               15, AccessRight.readwrite, AccessGroup.bit);
        public static readonly FunctionCode WriteMultipleRegister          = new FunctionCode("Write multiple registers",           16, AccessRight.readwrite, AccessGroup.word);
        public static readonly FunctionCode ReportSlaveID                  = new FunctionCode("Report Slave ID",                    17, AccessRight.read,      AccessGroup.diagnostics);

        public static readonly FunctionCode ReadFileRecord                 = new FunctionCode("Read File Record",                   20, AccessRight.read,      AccessGroup.file);
        public static readonly FunctionCode WriteFileRecord                = new FunctionCode("Write File Record",                  21, AccessRight.readwrite, AccessGroup.file);
        public static readonly FunctionCode MaskWriteRegister              = new FunctionCode("Mask Write Register",                22, AccessRight.readwrite, AccessGroup.word);
        public static readonly FunctionCode ReadWriteMultipleRegister      = new FunctionCode("Write and write multiple registers", 23, AccessRight.readwrite, AccessGroup.word);
        public static readonly FunctionCode ReadFIFOQueue                  = new FunctionCode("Read FIFO Queue",                    24, AccessRight.readwrite, AccessGroup.word);

        public static readonly FunctionCode EncapsulatedInterfaceTransport = new FunctionCode("Encapsulated Interface Transport",   43, AccessRight.read,      AccessGroup.diagnostics);


        #region Operator overloading

        #region Operator == (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCall.</param>
        /// <param name="myFunctionCode2">Another FunctionCall.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(myFunctionCode1, myFunctionCode2))
                return true;

            // If one is null, but not both, return false.
            if (((Object) myFunctionCode1 == null) || ((Object) myFunctionCode2 == null))
                return false;

            return myFunctionCode1.Equals(myFunctionCode2);

        }

        #endregion

        #region Operator != (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCall.</param>
        /// <param name="myFunctionCode2">Another FunctionCall.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {
            return !(myFunctionCode1 == myFunctionCode2);
        }

        #endregion

        #region Operator <  (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCode.</param>
        /// <param name="myFunctionCode2">Another FunctionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {

            // Check if myFunctionCode1 is null
            if ((Object) myFunctionCode1 == null)
                throw new ArgumentNullException("Parameter myFunctionCode1 must not be null!");

            // Check if myFunctionCode2 is null
            if ((Object) myFunctionCode2 == null)
                throw new ArgumentNullException("Parameter myFunctionCode2 must not be null!");

            return myFunctionCode1.CompareTo(myFunctionCode2) < 0;

        }

        #endregion

        #region Operator >  (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCode.</param>
        /// <param name="myFunctionCode2">Another FunctionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {

            // Check if myFunctionCode1 is null
            if ((Object) myFunctionCode1 == null)
                throw new ArgumentNullException("Parameter myFunctionCode1 must not be null!");

            // Check if myFunctionCode2 is null
            if ((Object) myFunctionCode2 == null)
                throw new ArgumentNullException("Parameter myFunctionCode2 must not be null!");

            return myFunctionCode1.CompareTo(myFunctionCode2) > 0;

        }

        #endregion

        #region Operator <= (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCode.</param>
        /// <param name="myFunctionCode2">Another FunctionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {
            return !(myFunctionCode1 > myFunctionCode2);
        }

        #endregion

        #region Operator >= (myFunctionCode1, myFunctionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode1">A FunctionCode.</param>
        /// <param name="myFunctionCode2">Another FunctionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (FunctionCode myFunctionCode1, FunctionCode myFunctionCode2)
        {
            return !(myFunctionCode1 < myFunctionCode2);
        }

        #endregion

        #endregion


        #region IComparable<FunctionCall> Members

        #region CompareTo(myObject)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myObject">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(Object myObject)
        {

            // Check if myObject is null
            if (myObject == null)
                throw new ArgumentNullException("myObject must not be null!");

            // Check if myObject can be casted to an ElementId object
            var _FunctionCall = myObject as FunctionCode;
            if ((Object) _FunctionCall == null)
                throw new ArgumentException("myObject is not of type FunctionCall!");

            return CompareTo(_FunctionCall);

        }

        #endregion

        #region CompareTo(myFunctionCode)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(FunctionCode myFunctionCode)
        {

            // Check if myFunctionCode is null
            if (myFunctionCode == null)
                throw new ArgumentNullException("myFunctionCode must not be null!");

            return Value.CompareTo(myFunctionCode.Value);

        }

        #endregion

        #endregion

        #region IEquatable<FunctionCall> Members

        #region Equals(myObject)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myObject">An object to compare with.</param>
        /// <returns>true|false</returns>
        public override Boolean Equals(Object myObject)
        {

            // Check if myObject is null
            if (myObject == null)
                throw new ArgumentNullException("Parameter myObject must not be null!");

            // Check if myObject can be cast to FunctionCall
            var _FunctionCall = myObject as FunctionCode;
            if ((Object) _FunctionCall == null)
                throw new ArgumentException("Parameter myObject could not be casted to type FunctionCall!");

            return this.Equals(_FunctionCall);

        }

        #endregion

        #region Equals(myFunctionCode)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myFunctionCode">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Boolean Equals(FunctionCode myFunctionCode)
        {

            // Check if myIPAddress is null
            if ((Object) myFunctionCode == null)
                throw new ArgumentNullException("Parameter myFunctionCode must not be null!");

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(this, myFunctionCode))
                return true;

            return Value.Equals(myFunctionCode.Value);

        }

        #endregion

        #endregion

        #region GetHashCode()

        /// <summary>
        /// Return the HashCode of this object.
        /// </summary>
        /// <returns>The HashCode of this object.</returns>
        public override Int32 GetHashCode()
        {
            return _Value.GetHashCode();
        }

        #endregion

        #region ToString()

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override String ToString()
        {
            return String.Format("{0} [{1}]", _Info, _Value);
        }

        #endregion


    }

}
