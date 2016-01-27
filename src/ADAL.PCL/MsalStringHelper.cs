﻿//----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.IdentityModel.Clients.ActiveDirectory
{
    internal static class MsalStringHelper
    {
        internal static string CreateSingleStringFromSet(this HashSet<string> setOfStrings)
        {
            if (setOfStrings == null || setOfStrings.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(setOfStrings.ElementAt(0));

            for (int i = 1; i < setOfStrings.Count; i++)
            {
                sb.Append(" ");
                sb.Append(setOfStrings.ElementAt(i));
            }

            return sb.ToString();
        }
        
        internal static HashSet<string> CreateSetFromSingleString(this string singleString)
        {
            return new HashSet<string>(singleString.Split(new[] { " " }, StringSplitOptions.None));
        }

        internal static string[] CreateArrayFromSingleString(this string singleString)
        {
            if (string.IsNullOrWhiteSpace(singleString))
            {
                return new string[] { };
            }

            return singleString.Split(new[] { " " }, StringSplitOptions.None);
        }

        internal static HashSet<string> CreateSetFromArray(this string[] arrayStrings)
        {
            HashSet<string> set = new HashSet<string>();
            if (arrayStrings == null || arrayStrings.Length == 0)
            {
                return set;
            }

            foreach (string str in arrayStrings)
            {
                set.Add(str);
            }

            return set;
        }

        internal static bool IsNullOrEmpty(string[] input)
        {
            return input == null || input.Length == 0;
        }
    }
}