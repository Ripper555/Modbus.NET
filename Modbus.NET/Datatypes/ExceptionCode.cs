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
    /// If it's an exception response, then the next byte will be one
    /// these exception codes, indicating the reason for the failure.
    /// </summary>
    public sealed class ExceptionCode : IEquatable<ExceptionCode>, IComparable<ExceptionCode>, IComparable
    {

        #region Properties

        #region Info

        private String _Info;

        /// <summary>
        /// A human readable short information on this exception code.
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

        #region ExceptionCode(myInfo, myValue)

        /// <summary>
        /// Create a new ExceptionCode.
        /// </summary>
        /// <param name="myInfo">A short information on the exception code.</param>
        /// <param name="myValue">The numberic value of this exception code.</param>
        /// <param name="myDescription">A description of this exception code.</param>
        public ExceptionCode(String myInfo, Byte myValue, String myDescription = null)
        {
            _Info        = myInfo;
            _Value       = myValue;
            _Description = myDescription;
        }

        #endregion

        #endregion


        public static readonly ExceptionCode IllegalFunction                  = new ExceptionCode("Illegal Function",                        1);
        public static readonly ExceptionCode IllegalDataAddress               = new ExceptionCode("Illegal Data Address",                    2);
        public static readonly ExceptionCode IllegalDataValue                 = new ExceptionCode("Illegal Data Value",                      3);
        public static readonly ExceptionCode SlaveDeviceFailure               = new ExceptionCode("Slave Device Failure",                    4);

        public static readonly ExceptionCode Acknowledge                      = new ExceptionCode("Acknowledge",                             5);
        public static readonly ExceptionCode SlaveDeviceBusy                  = new ExceptionCode("Slave Device Busy",                       6);
        public static readonly ExceptionCode MemoryParityError                = new ExceptionCode("Memory Parity Error",                     8);
        public static readonly ExceptionCode GatewayPathUnavailable           = new ExceptionCode("Gateway Path Unavailable",               10);

        public static readonly ExceptionCode GatewayTargetPathFailedToRespond = new ExceptionCode("Gateway Target Path Failed to Respond",  11);

        public static readonly ExceptionCode SentFailed                       = new ExceptionCode("Sent failed",                           100);
        public static readonly ExceptionCode NotConnected                     = new ExceptionCode("Not Connected",                         253);
        public static readonly ExceptionCode ConnectionLost                   = new ExceptionCode("Connection Lost",                       254);
        public static readonly ExceptionCode Timeout                          = new ExceptionCode("Timeout",                               255);


        #region Operator overloading

        #region Operator == (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A FunctionCall.</param>
        /// <param name="myExceptionCode2">Another FunctionCall.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(myExceptionCode1, myExceptionCode2))
                return true;

            // If one is null, but not both, return false.
            if (((Object) myExceptionCode1 == null) || ((Object) myExceptionCode2 == null))
                return false;

            return myExceptionCode1.Equals(myExceptionCode2);

        }

        #endregion

        #region Operator != (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A FunctionCall.</param>
        /// <param name="myExceptionCode2">Another FunctionCall.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {
            return !(myExceptionCode1 == myExceptionCode2);
        }

        #endregion

        #region Operator <  (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A ExceptionCode.</param>
        /// <param name="myExceptionCode2">Another ExceptionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {

            // Check if myExceptionCode1 is null
            if ((Object) myExceptionCode1 == null)
                throw new ArgumentNullException("Parameter myExceptionCode1 must not be null!");

            // Check if myExceptionCode2 is null
            if ((Object) myExceptionCode2 == null)
                throw new ArgumentNullException("Parameter myExceptionCode2 must not be null!");

            return myExceptionCode1.CompareTo(myExceptionCode2) < 0;

        }

        #endregion

        #region Operator >  (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A ExceptionCode.</param>
        /// <param name="myExceptionCode2">Another ExceptionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {

            // Check if myExceptionCode1 is null
            if ((Object) myExceptionCode1 == null)
                throw new ArgumentNullException("Parameter myExceptionCode1 must not be null!");

            // Check if myExceptionCode2 is null
            if ((Object) myExceptionCode2 == null)
                throw new ArgumentNullException("Parameter myExceptionCode2 must not be null!");

            return myExceptionCode1.CompareTo(myExceptionCode2) > 0;

        }

        #endregion

        #region Operator <= (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A ExceptionCode.</param>
        /// <param name="myExceptionCode2">Another ExceptionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {
            return !(myExceptionCode1 > myExceptionCode2);
        }

        #endregion

        #region Operator >= (myExceptionCode1, myExceptionCode2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode1">A ExceptionCode.</param>
        /// <param name="myExceptionCode2">Another ExceptionCode.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (ExceptionCode myExceptionCode1, ExceptionCode myExceptionCode2)
        {
            return !(myExceptionCode1 < myExceptionCode2);
        }

        #endregion

        #endregion


        #region IComparable<ExceptionCode> Members

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

            // Check if myObject can be casted to an ExceptionCode object
            var _ExceptionCode = myObject as ExceptionCode;
            if ((Object) _ExceptionCode == null)
                throw new ArgumentException("myObject is not of type ExceptionCode!");

            return CompareTo(_ExceptionCode);

        }

        #endregion

        #region CompareTo(myExceptionCode)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(ExceptionCode myExceptionCode)
        {

            // Check if myExceptionCode is null
            if (myExceptionCode == null)
                throw new ArgumentNullException("myExceptionCode must not be null!");

            return Value.CompareTo(myExceptionCode.Value);

        }

        #endregion

        #endregion

        #region IEquatable<ExceptionCode> Members

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

            // Check if myObject can be cast to ExceptionCode
            var _ExceptionCode = myObject as ExceptionCode;
            if ((Object) _ExceptionCode == null)
                throw new ArgumentException("Parameter myObject could not be casted to type ExceptionCode!");

            return this.Equals(_ExceptionCode);

        }

        #endregion

        #region Equals(myExceptionCode)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myExceptionCode">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Boolean Equals(ExceptionCode myExceptionCode)
        {

            // Check if myIPAddress is null
            if ((Object) myExceptionCode == null)
                throw new ArgumentNullException("Parameter myExceptionCode must not be null!");

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(this, myExceptionCode))
                return true;

            return Value.Equals(myExceptionCode.Value);

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
