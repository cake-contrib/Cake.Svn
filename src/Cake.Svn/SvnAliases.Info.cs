using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Info;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Check if the <paramref name="directoryPath"/> was added to the Subversion working copy.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <returns>
        /// <c>true</c> if the directory <paramref name="directoryPath"/> was added to the 
        /// Subversion working copy, even it doesn't exist on the remote repository.
        /// <c>false</c> if the directory exist but the directory was not added to the working copy.
        /// </returns>
        /// <example>
        /// Check if the <paramref name="directoryPath"/> was added to the Subversion working copy.
        /// <code>
        /// <![CDATA[
        ///     var isWorkingCopy = IsDirectoryInSvnWorkingCopy (@"C:\project\src\newfolder\");
        ///
        ///     Verbose("The directory is a working copy: {0}", isWorkingCopy);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static bool IsDirectoryInSvnWorkingCopy(this ICakeContext context, DirectoryPath directoryPath)
        {
            var svnInformation = new SvnInfo(context.Environment, SvnClientFactoryMethod);

            return svnInformation.IsDirectoryInSvnWorkingCopy(directoryPath);
        }

        /// <summary>
        /// Check if the <paramref name="filePath"/> was added to the Subversion working copy.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <returns>
        /// <c>true</c> if the file <paramref name="filePath"/> was added to the 
        /// Subversion working copy, even it doesn't exist on the remote repository.
        /// <c>false</c> if the file exist but the file was not added to the working copy.
        /// </returns>
        /// <example>
        /// Check if the <paramref name="filePath"/> was added to the Subversion working copy.
        /// <code>
        /// <![CDATA[
        ///     var isWorkingCopy = IsFileInSvnWorkingCopy(@"C:\project\src\newfolder\newfile.cs");
        ///
        ///     Verbose("The file is a working copy: {0}", IsWorkingCopy);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static bool IsFileInSvnWorkingCopy(this ICakeContext context, FilePath filePath)
        {
            var svnInformation = new SvnInfo(context.Environment, SvnClientFactoryMethod);

            return svnInformation.IsFileInSvnWorkingCopy(filePath);
        }

        /// <summary>
        /// Gets Subversion information about the directory at <paramref name="directoryPath"/>.
        /// The result list contains recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <returns>A result list containing recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter.</returns>
        /// <example>
        /// <para>
        /// Gets Subversion information about the directory at <paramref name="directoryPath"/>.
        /// The result list contains recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var localDirectoryInfo = GetSvnDirectoryInfo(@"C:\project\src\");
        ///
        ///     foreach(var svnInfoResult in localDirectoryInfo)
        ///     {
        ///         Verbose("Path: {0}", svnInfoResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static IEnumerable<SvnInfoResult> GetSvnDirectoryInfo(this ICakeContext context, DirectoryPath directoryPath)
        {
            return GetSvnDirectoryInfo(context, directoryPath, null);
        }

        /// <summary>
        /// Gets Subversion information about the directory at <paramref name="directoryPath"/> with specific settings.
        /// The result list contains recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>A result list containing recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/></returns>
        /// <example>
        /// <para>
        /// Gets Subversion information about the directory at <paramref name="directoryPath"/> with specific settings.
        /// The result list contains recursive information about the <paramref name="directoryPath"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var svnInfoSettings = new SvnInfoSettings
        ///     {
        ///         Depth = SvnDepth.Unknown;
        ///     };
        ///
        ///     var localDirectoryInfo = GetSvnDirectoryInfo(@"C:\project\src\", svnInfoSettings);
        ///
        ///     foreach(var svnInfoResult in localDirectoryInfo)
        ///     {
        ///         Verbose("Path: {0}", svnInfoResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static IEnumerable<SvnInfoResult> GetSvnDirectoryInfo(
            this ICakeContext context, 
            DirectoryPath directoryPath, 
            SvnInfoSettings settings)
        {
            var svnInformation = new SvnInfo(context.Environment, SvnClientFactoryMethod);

            return svnInformation.GetInfo(directoryPath, settings ?? new SvnInfoSettings());
        }

        /// <summary>
        /// Gets Subversion information about the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <returns>The Subversion information.</returns>
        /// <example>
        /// <para>Gets Subversion information about the file at <paramref name="filePath"/>.</para>
        /// <code>
        /// <![CDATA[
        ///     var localFileInfo = GetSvnFileInfo(@"C:\project\src\file.cs");
        ///
        ///     Verbose("Path: {0}", localFileInfo.Path);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static SvnInfoResult GetSvnFileInfo(this ICakeContext context, FilePath filePath)
        {
            return GetSvnFileInfo(context, filePath, null);
        }

        /// <summary>
        /// Gets Subversion information about file at <paramref name="filePath"/> with specific settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion information.</returns>
        /// <example>
        /// <para>Gets Subversion information about file at <paramref name="filePath"/> with specific settings.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnInfoSettings = new SvnInfoSettings
        ///     {
        ///         Depth = SvnDepth.Unknown;
        ///     };
        ///
        ///     var localFileInfo = GetSvnFileInfo(@"C:\project\src\", svnInfoSettings);
        ///
        ///     Verbose("Path: {0}", localFileInfo.Path);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static SvnInfoResult GetSvnFileInfo(this ICakeContext context, FilePath filePath, SvnInfoSettings settings)
        {
            var svnInformation = new SvnInfo(context.Environment, SvnClientFactoryMethod);

            // A file returns only one SvnInfoResult.
            return svnInformation.GetInfo(filePath, settings ?? new SvnInfoSettings()).Single();
        }

        /// <summary>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/>.
        /// The result list contains recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The Uri.</param>
        /// <returns>A result list containing recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter</returns>
        /// <example>
        /// <para>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/>.
        /// The result list contains recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// the overload <see cref="GetSvnDirectoryInfo(ICakeContext, DirectoryPath, SvnInfoSettings)"/> 
        /// can be used with changing the settings parameter.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var remoteInfo = GetSvnRemoteInfo(new Uri("https://svn.example.com/"));
        ///
        ///     foreach(var svnInfoResult in remoteInfo)
        ///     {
        ///         Verbose("Path: {0}", svnInfoResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static IEnumerable<SvnInfoResult> GetSvnRemoteInfo(this ICakeContext context, Uri repositoryUrl)
        {
            return GetSvnRemoteInfo(context, repositoryUrl, null);
        }

        /// <summary>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/> with specific settings.
        /// The result list contains recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The Uri.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>A result list containing recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.</returns>
        /// <example>
        /// <para>
        /// Gets Subversion information about the file or directory at <paramref name="repositoryUrl"/> with specific settings.
        /// The result list contains recursive information about the <paramref name="repositoryUrl"/> 
        /// (<see cref="SvnDepth.Infinity"/>). To get information with another <see cref="SvnDepth"/> 
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var svnInfoSettings = new SvnInfoSettings
        ///     {
        ///         Depth = SvnDepth.Unknown;
        ///     };
        ///
        ///     var remoteInfo = GetSvnRemoteInfo(new Uri("https://svn.example.com/"), svnInfoSettings);
        ///
        ///     foreach(var svnInfoResult in remoteInfo)
        ///     {
        ///         Verbose("Path: {0}", svnInfoResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Info")]
        [CakeNamespaceImport("Cake.Svn.Info")]
        public static IEnumerable<SvnInfoResult> GetSvnRemoteInfo(this ICakeContext context, Uri repositoryUrl, SvnInfoSettings settings)
        {
            var svnInformation = new SvnInfo(context.Environment, SvnClientFactoryMethod);

            return svnInformation.GetInfo(repositoryUrl, settings ?? new SvnInfoSettings());
        }
    }
}
