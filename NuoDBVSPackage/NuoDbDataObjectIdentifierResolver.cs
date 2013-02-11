﻿/****************************************************************************
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Data;

namespace NuoDb.VisualStudio.DataTools
{
    public class NuoDbDataObjectIdentifierResolver : DataObjectIdentifierResolver
    {
        private DataConnection dataConnection;

        public NuoDbDataObjectIdentifierResolver()
        {
            System.Diagnostics.Trace.WriteLine("NuoDbDataObjectIdentifierResolver()");
        }

        public NuoDbDataObjectIdentifierResolver(DataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public override object[] ContractIdentifier(string typeName, object[] fullIdentifier, bool refresh)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("NuoDbDataObjectIdentifierResolver::ContractIdentifier({0})", typeName));
            return base.ContractIdentifier(typeName, fullIdentifier, refresh);
        }
        public override object[] ExpandIdentifier(string typeName, object[] partialIdentifier, bool refresh)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("NuoDbDataObjectIdentifierResolver::ExpandIdentifier({0})", typeName));
            return base.ExpandIdentifier(typeName, partialIdentifier, refresh);
        }

    }
}
