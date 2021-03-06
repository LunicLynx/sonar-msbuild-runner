﻿//-----------------------------------------------------------------------
// <copyright file="AnalysisSetting.cs" company="SonarSource SA and Microsoft Corporation">
//   Copyright (c) SonarSource SA and Microsoft Corporation.  All rights reserved.
//   Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SonarQube.Common
{
    /// <summary>
    /// Data class to describe an additional analysis configuration setting
    /// /// </summary>
    /// <remarks>The class is XML-serializable.
    public class AnalysisSetting
    {
        #region Data

        /// <summary>
        /// The identifier for the setting
        /// </summary>
        /// <remarks>Each type </remarks>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// The value of the setting
        /// </summary>
        [XmlAttribute]
        public string Value { get; set; }

        #endregion

        #region Static helper methods

        /// <summary>
        /// Regular expression to validate setting ids.
        /// </summary>
        /// <remarks>
        /// Validation rules:
        /// Must start with an alpanumeric character.
        /// Can be followed by any number of alphanumeric characters or .
        /// Whitespace is not allowed
        /// </remarks>
        private static readonly Regex ValidSettingKeyRegEx = new Regex(@"^\w[\w\d\.-]*$", RegexOptions.Compiled);

        /// <summary>
        /// Returns true if the supplied string is a valid key for a sonar-XXX.properties file, otherwise false
        /// </summary>
        public static bool IsValidKey(string key)
        {
            bool isValid = ValidSettingKeyRegEx.IsMatch(key);
            return isValid;
        }

        /// <summary>
        /// Comparer to use when comparing keys of analysis settings
        /// </summary>
        public static IEqualityComparer<string> SettingKeyComparer = StringComparer.Ordinal;

        /// <summary>
        /// Comparer to use when comparing keys of analysis settings
        /// </summary>
        public static IEqualityComparer<string> SettingValueComparer = StringComparer.Ordinal;

        #endregion
    }
}
