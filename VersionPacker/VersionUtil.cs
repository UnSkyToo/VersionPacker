using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace VersionPacker
{
    public static class VersionUtil
    {
        private static readonly string TempOldPath = "OldVersion";
        private static readonly string TempDiffPath = "DiffPath";
        private static readonly string TempFileList = "res_list";
        private static readonly string TempInfo = "info.txt";

        private static string oldVersion = string.Empty;
        private static string newVersion = string.Empty;
        private static string newVersionZipName = string.Empty;
        private static string updaterUrl = string.Empty;

        /// <summary>
        /// 比较指定目录和指定版本的差异，并打包成zip文件
        /// </summary>
        /// <param name="newResourcePath">新资源路径</param>
        /// <param name="oldVersion">老版本号</param>
        /// <param name="versionFilePath">存储老版本的根目录</param>
        /// <param name="newVersion">新版本号</param>
        /// <param name="newVersionZipName">新版本号名称（未指定则默认为新版本号）</param>
        /// <param name="newVersionFilePath">新版本存放目录</param>
        /// <param name="password">压缩包密码</param>
        /// <param name="zipLevel">压缩等级（0-9）</param>
        /// <param name="updaterUrl">更新服务器地址</param>
        /// <param name="ignoreFileList">忽略的文件列表</param>
        /// <param name="ignoreFolderList">忽略的目录列表</param>
        public static void Packer(string newResourcePath, string oldVersion, string versionFilePath, string newVersion, string newVersionZipName, string newVersionFilePath, string password, int zipLevel, string updaterUrl, List<string> ignoreFileList, List<string> ignoreFolderList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newResourcePath))
                {
                    throw new Exception("必须指定资源目录");
                }

                newResourcePath = DirectoryUtil.FixedDirectoryPostfix(newResourcePath);

                if (!Directory.Exists(newResourcePath))
                {
                    throw new Exception("找不到资源目录" + newResourcePath);
                }

                if (string.IsNullOrWhiteSpace(newVersionZipName))
                {
                    newVersionZipName = newVersion + ".zip";
                }

                if (!newVersionZipName.EndsWith(".zip"))
                {
                    newVersionZipName += ".zip";
                }

                VersionUtil.oldVersion = oldVersion;
                VersionUtil.newVersion = newVersion;
                VersionUtil.updaterUrl = updaterUrl;
                VersionUtil.newVersionZipName = newVersionZipName;

                if (newVersionFilePath == string.Empty)
                {
                    newVersionFilePath = Directory.GetCurrentDirectory();
                }

                versionFilePath = DirectoryUtil.FixedDirectoryPostfix(versionFilePath);
                newVersionFilePath = DirectoryUtil.FixedDirectoryPostfix(newVersionFilePath);

                string zipFilePath = newVersionFilePath + newVersionZipName;
                string verPath = versionFilePath + oldVersion + ".zip"; // 老版本zip文件路径
                string oldVersionPath = Directory.GetCurrentDirectory() + "\\" + TempOldPath; // 老版本zip解压的临时路径
                string[] diffFiles; // 差异文件

                oldVersionPath = DirectoryUtil.FixedDirectoryPostfix(oldVersionPath);
                
                if (Directory.Exists(oldVersionPath))
                {
                    Directory.Delete(oldVersionPath, true);
                    Directory.CreateDirectory(oldVersionPath);
                }

                if (!File.Exists(verPath)) // 老版本不存在则直接打包新资源
                {
                    diffFiles = DirectoryUtil.GetAllDirectoryAndFile(newResourcePath, ignoreFileList, ignoreFolderList);

                    for (int i = 0; i < diffFiles.Length; i++)
                    {
                        diffFiles[i] = diffFiles[i].Substring(newResourcePath.Length, diffFiles[i].Length - newResourcePath.Length);
                    }
                }
                else
                {
                    // 解压缩老版本文件
                    ZipUtil.UnZipFile(verPath, oldVersionPath, string.Empty, true);
                    // 比较新目录和老目录之间的差异文件
                    diffFiles = DirectoryUtil.GetDifferentDirectory(oldVersionPath, newResourcePath, ignoreFileList, ignoreFolderList);
                }

                // 差异列表为空
                if (diffFiles.Length == 0)
                {
                    Console.WriteLine("版本对比结果一致，无需生成差异包");
                    return;
                }
                
                // 创建临时的老版本文件目录
                string diffPath = Directory.GetCurrentDirectory() + "\\" + TempDiffPath; // 差异文件临时存放路径
                diffPath = DirectoryUtil.FixedDirectoryPostfix(diffPath);
                
                if (Directory.Exists(diffPath))
                {
                    Directory.Delete(diffPath, true);
                    Directory.CreateDirectory(diffPath);
                }
                // 拷贝差异资源，准备压缩
                DirectoryUtil.CopyFiles(diffFiles, newResourcePath, diffPath);
                // 压缩差异包
                ZipUtil.ZipDirectory(zipFilePath, diffPath, password, zipLevel, true);
                // 生成文件列表
                CreateFileList(diffFiles, Directory.GetCurrentDirectory() + "\\" + TempFileList);
                // 生成信息文件
                CreateInfo(zipFilePath, Directory.GetCurrentDirectory() + "\\" + TempInfo);
                
                // 删除临时文件
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + TempOldPath))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + "\\" + TempOldPath, true);
                }
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + TempDiffPath))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + "\\" + TempDiffPath, true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 生成文件列表
        /// </summary>
        /// <param name="fileList">文件列表</param>
        /// <param name="filePath">文件列表保存路径</param>
        private static void CreateFileList(string[] fileList, string filePath)
        {
            try
            {
                using (StreamWriter outStream = new StreamWriter(filePath, false, Encoding.ASCII))
                {
                    foreach (string file in fileList)
                    {
                        outStream.WriteLine(file);
                    }
                    outStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 生成信息文件
        /// </summary>
        /// <param name="zipFilePath">需要生成的Zip压缩包</param>
        /// <param name="filePath">保存配置的文件</param>
        private static void CreateInfo(string zipFilePath, string filePath)
        {
            try
            {
                using (StreamWriter outStream = new StreamWriter(filePath, false, Encoding.ASCII))
                {
                    string md5 = MD5.Get(zipFilePath);
                    FileInfo info = new FileInfo(zipFilePath);
                    outStream.WriteLine("<res_patch_ver>");
                    outStream.WriteLine("\t<from>" + VersionUtil.oldVersion + "</from>");
                    outStream.WriteLine("\t<to>" + VersionUtil.newVersion + "</to>");
                    outStream.WriteLine("\t<patch>" + VersionUtil.updaterUrl + VersionUtil.newVersionZipName + "</patch>");
                    outStream.WriteLine("\t<md5>" + md5 + "</md5>");
                    outStream.WriteLine("\t<size>" + info.Length.ToString() + "</size>");
                    outStream.WriteLine("</res_patch_ver>");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
