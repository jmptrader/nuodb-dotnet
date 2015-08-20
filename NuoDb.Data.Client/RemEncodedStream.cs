/****************************************************************************
* Copyright (c) 2012-2013, NuoDB, Inc.
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*
*   * Redistributions of source code must retain the above copyright
*     notice, this list of conditions and the following disclaimer.
*   * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*   * Neither the name of NuoDB, Inc. nor the names of its contributors may
*     be used to endorse or promote products derived from this software
*     without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
* ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL NUODB, INC. BE LIABLE FOR ANY DIRECT, INDIRECT,
* INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
* LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
* OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
* LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
* OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
* ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
****************************************************************************/

using System;
namespace NuoDb.Data.Client
{

    /// <summary>
    /// RemEncodedStream  - EncodedDataStream class that can encodes types  based on connection protocol version
    /// 
    /// 
    /// </summary>
    internal class RemEncodedStream : EncodedDataStream
    {

        internal int protocolVersion;

        public RemEncodedStream(int protocolVersion)
            : base()
        {
            this.protocolVersion = protocolVersion;
        }

        public override void encodeDate(DateTime date)
        {
            if (protocolVersion >= Protocol.PROTOCOL_VERSION9)
            {
                base.encodeScaledDate(date);
            }
            else
            {
                base.encodeDate(date);
            }
        }

        public override void encodeTime(DateTime time)
        {
            if (protocolVersion >= Protocol.PROTOCOL_VERSION9)
            {
                base.encodeScaledTime(time);
            }
            else
            {
                base.encodeTime(time);
            }
        }

        public override void encodeTime(TimeSpan time)
        {
            if (protocolVersion >= Protocol.PROTOCOL_VERSION9)
            {
                base.encodeScaledTime(time);
            }
            else
            {
                base.encodeTime(time);
            }
        }

        public override void encodeTimestamp(DateTime timestamp)
        {
            if (protocolVersion >= Protocol.PROTOCOL_VERSION9)
            {
                base.encodeScaledTimestamp(timestamp);
            }
            else
            {
                base.encodeTimestamp(timestamp);
            }
        }

        public override void encodeBigDecimal(Decimal bd)
        {
            if (protocolVersion >= Protocol.PROTOCOL_VERSION11)
                base.encodeBigDecimal(bd);
            else
                base.encodeOldBigDecimal(bd);
        }

    }

}