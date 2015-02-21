﻿//-----------------------------------------------------------------------
// <copyright file="ProjectInfo.cs" company="SonarSource SA and Microsoft Corporation">
//   (c) SonarSource SA and Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace SonarMSBuild.Tasks
{
    /// <summary>
    /// Possible types of project
    /// </summary>
    public enum ProjectType
    {
        Product = 0,
        Test
    }

    /// <summary>
    /// Data class to describe a single project
    /// </summary>
    /// <remarks>The class is XML-serializable</remarks>
    [XmlRoot(Namespace=XmlNamespace)]
    public class ProjectInfo
    {
        public const string XmlNamespace = "http://www.sonarsource.com/msbuild/integration/2015/1";

        #region Public properties

        /// <summary>
        /// The project file name
        /// </summary>
        public string ProjectName
        {
            get;
            set;
        }

        /// <summary>
        /// The kind of the project
        /// </summary>
        public ProjectType ProjectType
        {
            get;
            set;
        }

        /// <summary>
        /// Unique identifier for the project
        /// </summary>
        public Guid ProjectGuid
        {
            get;
            set;
        }

        /// <summary>
        /// The full name and path of the project file
        /// </summary>
        public string FullPath
        {
            get;
            set;
        }

        #endregion

        #region Serialization

        /// <summary>
        /// Saves the project to the specified file as XML
        /// </summary>
        public void Save(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            Serializer.SaveModel(this, fileName);
        }


        /// <summary>
        /// Loads and returns project info from the specified XML file
        /// </summary>
        public static ProjectInfo Load(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            ProjectInfo model = Serializer.LoadModel<ProjectInfo>(fileName);
            return model;
        }

        #endregion

    }
}