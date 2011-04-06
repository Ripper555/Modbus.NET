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

namespace com.aperis.Modbus
{

    /// <summary>
    /// A modbus access group, which could e.g. define
    /// the expected type of the return value.
    /// </summary>
    public enum AccessGroup
    {
        bit,
        word,
        file,
        diagnostics
    }

}
