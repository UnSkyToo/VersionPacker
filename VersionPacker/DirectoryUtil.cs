using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VersionPacker
{
    public static class DirectoryUtil
    {
        /// <summary>
        /// 判断两个文件是否相等（MD5）
        /// </summary>
        /// <param name="filePath1">文件1</param>
        /// <param name="filePath2">文件2</param>
        /// <returns>返回true表示相等</returns>
        public static bool FileEqual(string filePath1, string filePath2)
        {
            try
            {
                if (!File.Exists(filePath1) || !File.Exists(filePath2))
                {
                    return false;
                }

                string md51 = MD5.Get(filePath1);
                string md52 = MD5.Get(filePath2);

                if (md51 == md52)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 尝试修复一个文件夹路径名称（结尾没有\则加上）
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>返回修改后的值</returns>
        public static string FixedDirectoryPostfix(string path)
        {
            if (path.EndsWith("\\"))
            {
                return path;
            }
            return path + "\\";
        }

        /// <summary>
        /// 返回一个目录下所有的目录和文件（包括所有子目录）
        /// </summary>
        /// <param name="directoryPath">根目录</param>
        /// <param name="ignoreFileList">忽略的文件列表</param>
        /// <param name="ignoreFolderList">忽略的目录列表</param>
        /// <returns>返回文件列表</returns>
        public static string[] GetAllDirectoryAndFile(string directoryPath, List<string> ignoreFileList, List<string> ignoreFolderList)
        {
            try
            {
                List<string> result = new List<string>();
                // 获取路径下的所有文件
                string[] files = Directory.GetFiles(directoryPath);
                // 获取路径下的所有目录
                string[] directorys = Directory.GetDirectories(directoryPath);
                // 递归保存所有子目录以及文件
                foreach (string directory in directorys)
                {
                    if (ignoreFolderList.Contains(directory))
                    {
                        continue;
                    }
                    result.AddRange(GetAllDirectoryAndFile(directory, ignoreFileList, ignoreFolderList));
                }
                // 保存所有文件
                foreach (string file in files)
                {
                    if (ignoreFileList.Contains(file))
                    {
                        continue;
                    }
                    result.Add(file);
                }

                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 对比一个目录下不同的文件
        /// </summary>
        /// <param name="oldDirectoryPath">老版本文件目录</param>
        /// <param name="newDirectoryPath">新版本文件目录</param>
        /// <param name="ignoreFileList">忽略的文件列表</param>
        /// <returns>返回不同的文件列表</returns>
        public static string[] GetDifferentFile(string oldDirectoryPath, string newDirectoryPath, List<string> ignoreFileList)
        {
            try
            {
                oldDirectoryPath = FixedDirectoryPostfix(oldDirectoryPath);
                newDirectoryPath = FixedDirectoryPostfix(newDirectoryPath);

                List<string> result = new List<string>();
                // 获取指定目录新老版本文件列表
                string[] oldFileList = Directory.GetFiles(oldDirectoryPath);
                string[] newFileList = Directory.GetFiles(newDirectoryPath);

                // 处理文件列表，使其由绝对路径变为相对路径
                for (int i = 0; i < oldFileList.Length; i++)
                {
                    oldFileList[i] = oldFileList[i].Substring(oldDirectoryPath.Length, oldFileList[i].Length - oldDirectoryPath.Length);
                }
                for (int i = 0; i < newFileList.Length; i++)
                {
                    if (ignoreFileList.Contains(newFileList[i]))
                    {
                        newFileList[i] = string.Empty;
                        continue;
                    }
                    newFileList[i] = newFileList[i].Substring(newDirectoryPath.Length, newFileList[i].Length - newDirectoryPath.Length);
                }

                // 遍历新文件列表，和老版本文件比较差异
                foreach (string filePath in newFileList)
                {
                    if (filePath == string.Empty)
                    {
                        continue;
                    }

                    bool isExist = false;
                    foreach (string existPath in oldFileList)
                    {
                        if (filePath == existPath)
                        {
                            if (FileEqual(oldDirectoryPath + existPath, newDirectoryPath + filePath))
                            {
                                isExist = true;
                                break;
                            }
                        }
                    }

                    // 在老版本中不存在的文件，或者有修改的文件，则保存
                    if (!isExist)
                    {
                        result.Add(filePath);
                    }
                }

                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 对比一个目录下不同的文件和目录（包括所有子目录）
        /// </summary>
        /// <param name="oldDirectoryPath">老版本文件目录</param>
        /// <param name="newDirectoryPath">新版本文件目录</param>
        /// <param name="ignoreFileList">忽略的文件列表</param>
        /// <param name="ignoreFolderList">忽略的目录列表</param>
        /// <returns>返回不同的文件列表</returns>
        public static string[] GetDifferentDirectory(string oldDirectoryPath, string newDirectoryPath, List<string> ignoreFileList, List<string> ignoreFolderList)
        {
            try
            {
                oldDirectoryPath = FixedDirectoryPostfix(oldDirectoryPath);
                newDirectoryPath = FixedDirectoryPostfix(newDirectoryPath);

                List<string> result = new List<string>();
                // 获取指定目录下的新老版本目录列表
                string[] oldSubDirectory = Directory.GetDirectories(oldDirectoryPath);
                string[] newSubDirectory = Directory.GetDirectories(newDirectoryPath);

                // 处理目录列表，使其由绝对路径变为相对路径
                for (int i = 0; i < oldSubDirectory.Length; i++)
                {
                    oldSubDirectory[i] = oldSubDirectory[i].Substring(oldDirectoryPath.Length, oldSubDirectory[i].Length - oldDirectoryPath.Length);
                }
                for (int i = 0; i < newSubDirectory.Length; i++)
                {
                    if (ignoreFolderList.Contains(newSubDirectory[i]))
                    {
                        newSubDirectory[i] = string.Empty;
                        continue;
                    }
                    newSubDirectory[i] = newSubDirectory[i].Substring(newDirectoryPath.Length, newSubDirectory[i].Length - newDirectoryPath.Length);
                }

                // 遍历新路径列表，和老版本文件比较差异
                foreach (string newDir in newSubDirectory)
                {
                    if (newDir == string.Empty)
                    {
                        continue;
                    }

                    bool isExist = false;
                    foreach (string oldDir in oldSubDirectory)
                    {
                        if (newDir == oldDir)
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (isExist) // 目录存在，则递归比较子目录
                    {
                        string[] diffFile = GetDifferentDirectory(oldDirectoryPath + newDir, newDirectoryPath + newDir, ignoreFileList, ignoreFolderList);

                        foreach (string file in diffFile)
                        {
                            result.Add(newDir + "\\" + file);
                        }
                    }
                    else // 目录不存在则直接添加目录已经目录中的所有文件
                    {
                        result.Add(newDir); // 保存新目录本身
                        string[] diffFile = GetAllDirectoryAndFile(newDirectoryPath + newDir, ignoreFileList, ignoreFolderList);
                        // 保存所有子目录和文件（目录在前，因为需要先创建目录在创建文件）
                        foreach(string file in diffFile)
                        {
                            if (ignoreFileList.Contains(file))
                            {
                                continue;
                            }
                            result.Add(file.Substring(newDirectoryPath.Length, file.Length - newDirectoryPath.Length));
                        }
                    }
                }

                // 保存目录下的差异文件
                string[] diff = GetDifferentFile(oldDirectoryPath, newDirectoryPath, ignoreFileList);
                result.AddRange(diff);

                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 拷贝文件到指定目录
        /// </summary>
        /// <param name="files">需要拷贝文件列表（文件必须是相对路径）</param>
        /// <param name="directoryPath">目录路径</param>
        public static void CopyFiles(string[] files, string sourceDirectoryPath, string directoryPath)
        {
            try
            {
                sourceDirectoryPath = FixedDirectoryPostfix(sourceDirectoryPath);
                directoryPath = FixedDirectoryPostfix(directoryPath);

                // 创建目标目录
                Directory.CreateDirectory(directoryPath);

                // 遍历文件列表
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(sourceDirectoryPath + file);

                    if (!info.Exists) // 目录
                    {
                        Directory.CreateDirectory(directoryPath + file);
                    }
                    else // 文件
                    {
                        string path = Path.GetDirectoryName(directoryPath + file);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        File.Copy(sourceDirectoryPath + file, directoryPath + file, true);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
