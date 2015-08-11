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

using System.Data.Common;
using System.Collections.Generic;
using System;

namespace NuoDb.Data.Client
{
    class NuoDbDataParameterCollection : DbParameterCollection
    {
        private List<NuoDbParameter> collection = new List<NuoDbParameter>();

        public override int Add(object value)
        {
            if (value is DbParameter)
            {
                collection.Add(ImportParameter(value as DbParameter));
            }
            else
            {
                NuoDbParameter param = new NuoDbParameter();
                param.Value = value;
                collection.Add(param);
            }
            return collection.Count - 1;
        }

        private static NuoDbParameter ImportParameter(DbParameter value)
        {
            if (value is NuoDbParameter)
                return value as NuoDbParameter;
            NuoDbParameter param = new NuoDbParameter();
            param.ParameterName = value.ParameterName;
            param.Value = value.Value;
            param.DbType = value.DbType;
            param.Direction = value.Direction;
            param.Size = value.Size;
            param.SourceColumn = value.SourceColumn;
            param.SourceColumnNullMapping = value.SourceColumnNullMapping;
            param.SourceVersion = value.SourceVersion;
            return param;
        }

        public override void AddRange(Array values)
        {
            foreach (object value in values)
            {
                Add(value);
            }
        }

        public override void Clear()
        {
            collection.Clear();
        }

        public override bool Contains(string value)
        {
            foreach (NuoDbParameter p in collection)
                if (String.Equals(p.ParameterName, value, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public override bool Contains(object value)
        {
            return collection.Contains((NuoDbParameter)value);
        }

        public override void CopyTo(Array array, int index)
        {
            for (int i = 0; i < collection.Count; i++)
                array.SetValue(collection[i], index + i);
        }

        public override int Count
        {
            get { return collection.Count; }
        }

        public override System.Collections.IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        protected override DbParameter GetParameter(string parameterName)
        {
            foreach (NuoDbParameter p in collection)
                if (String.Equals(p.ParameterName, parameterName, StringComparison.OrdinalIgnoreCase))
                    return p;
            return null;
        }

        protected override DbParameter GetParameter(int index)
        {
            return collection[index];
        }

        public override int IndexOf(string parameterName)
        {
            for (int i = 0; i < collection.Count; i++)
                if (String.Equals(collection[i].ParameterName, parameterName, StringComparison.OrdinalIgnoreCase))
                    return i;
            return -1;
        }

        public override int IndexOf(object value)
        {
            for (int i = 0; i < collection.Count; i++)
                if (collection[i] == value)
                    return i;
            return -1;
        }

        public override void Insert(int index, object value)
        {
            if (!(value is DbParameter))
                throw new ArgumentException("Parameter is not a DbParameter", "value");
            collection.Insert(index, ImportParameter(value as DbParameter));
        }

        public override bool IsFixedSize
        {
            get { return false; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override bool IsSynchronized
        {
            get { return false; }
        }

        public override void Remove(object value)
        {
            if (!(value is NuoDbParameter))
                throw new ArgumentException("Parameter is not a NuoDB parameter", "value");

            collection.Remove(value as NuoDbParameter);
        }

        public override void RemoveAt(string parameterName)
        {
            for (int i = 0; i < collection.Count; i++)
                if (String.Equals(collection[i].ParameterName, parameterName, StringComparison.OrdinalIgnoreCase))
                {
                    collection.RemoveAt(i);
                    break;
                }
        }

        public override void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            NuoDbParameter param = ImportParameter(value);
            int index = IndexOf(parameterName);
            if (index == -1)
                collection.Add(param);
            else
                collection[index] = param;
        }

        protected override void SetParameter(int index, DbParameter value)
        {
            if (index < 0 || index > collection.Count)
                throw new IndexOutOfRangeException();
            collection[index] = ImportParameter(value);
        }

        public override object SyncRoot
        {
            get { return this; }
        }
    }
}
