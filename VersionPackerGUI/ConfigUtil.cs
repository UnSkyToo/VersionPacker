using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace VersionPackerGUI
{
    public static class ConfigUtil
    {
        private static string m_configPath = System.Windows.Forms.Application.StartupPath + "\\Config.dat";
        private static Dictionary<string, string> m_config = new Dictionary<string, string>();

        private static string GetValue(string key)
        {
            if (m_config.ContainsKey(key))
            {
                return m_config[key];
            }
            return string.Empty;
        }

        private static void SetValue(string key, string value)
        {
            if (m_config.ContainsKey(key))
            {
                m_config[key] = value;
            }
            else
            {
                m_config.Add(key, value);
            }
        }

        public static void SaveConfig()
        {
            StreamWriter fp = null;

            try
            {
                fp = new StreamWriter(m_configPath, false, Encoding.Default);

                foreach (KeyValuePair<string, string> pair in m_config)
                {
                    fp.WriteLine("{0},{1}", pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FileUtil.SafeRelease(fp);
            }
        }

        public static void LoadConfig()
        {
            StreamReader fp = null;

            try
            {
                if (!File.Exists(m_configPath))
                {
                    return;
                }

                m_config.Clear();

                fp = new StreamReader(m_configPath, Encoding.Default);

                while (!fp.EndOfStream)
                {
                    string line = fp.ReadLine();
                    string[] keyValue = line.Split(',');

                    if (keyValue.Length != 2)
                    {
                        throw new Exception("Config data format error!");
                    }

                    m_config.Add(keyValue[0], keyValue[1]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FileUtil.SafeRelease(fp);
            }
        }

        public static string GetVersionPath()
        {
            return GetValue("VersionPath");
        }

        public static void SetVersionPath(string value)
        {
            SetValue("VersionPath", value);
        }

        public static string GetPatchPath()
        {
            return GetValue("PatchPath");
        }

        public static void SetPatchPath(string value)
        {
            SetValue("PatchPath", value);
        }

        public static string GetResourcePath()
        {
            return GetValue("ResourcePath");
        }

        public static void SetResourcePath(string value)
        {
            SetValue("ResourcePath", value);
        }

        public static VersionData GetOldVersion()
        {
            try
            {
                string version = GetValue("OldVersion");
                string[] numbers = version.Split(new char[] { '_' });

                return new VersionData(int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]), int.Parse(numbers[3]));
            }
            catch
            {
                return VersionData.Empty;
            }
        }

        public static void SetOldVersion(VersionData value)
        {
            string version = string.Format("{0}_{1}_{2}_{3}", value.MajorNumber, value.MinorNumber, value.RevisionNumber, value.BuildNumber);
            SetValue("OldVersion", version);
        }

        public static VersionData GetNewVersion()
        {
            try
            {
                string version = GetValue("NewVersion");
                string[] numbers = version.Split(new char[] { '_' });

                return new VersionData(int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]), int.Parse(numbers[3]));
            }
            catch
            {
                return VersionData.Empty;
            }
        }

        public static void SetNewVersion(VersionData value)
        {
            string version = string.Format("{0}_{1}_{2}_{3}", value.MajorNumber, value.MinorNumber, value.RevisionNumber, value.BuildNumber);
            SetValue("NewVersion", version);
        }

        public static string GetUpdaterUrl()
        {
            try
            {
                string updaterUrl = GetValue("UpdaterUrl");
                return updaterUrl;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void SetUpdaterUrl(string value)
        {
            SetValue("UpdaterUrl", value);
        }

        public static List<string> GetIgnoreFileList()
        {
            try
            {
                string ignoreData = GetValue("IgnoreFileList");
                if (ignoreData == string.Empty)
                {
                    return new List<string>();
                }
                string[] ignoreDataList = ignoreData.Split(new char[] { '|' });
                return new List<string>(ignoreDataList);
            }
            catch
            {
                return new List<string>();
            }
        }

        public static void SetIgnoreFileList(List<string> ignoreFileList)
        {
            if (ignoreFileList.Count == 0)
            {
                return;
            }

            string ignoreData = ignoreFileList[0];

            for (int i = 1; i < ignoreFileList.Count; ++i)
            {
                ignoreData = string.Format("{0}|{1}", ignoreData, ignoreFileList[i]);
            }

            SetValue("IgnoreFileList", ignoreData);
        }

        public static List<string> GetIgnoreFolderList()
        {
            try
            {
                string ignoreData = GetValue("IgnoreFolderList");
                if (ignoreData == string.Empty)
                {
                    return new List<string>();
                }
                string[] ignoreDataList = ignoreData.Split(new char[] { '|' });
                return new List<string>(ignoreDataList);
            }
            catch
            {
                return new List<string>();
            }
        }

        public static void SetIgnoreFolderList(List<string> ignoreFolderList)
        {
            if (ignoreFolderList.Count == 0)
            {
                return;
            }

            string ignoreData = ignoreFolderList[0];

            for (int i = 1; i < ignoreFolderList.Count; ++i)
            {
                ignoreData = string.Format("{0}|{1}", ignoreData, ignoreFolderList[i]);
            }

            SetValue("IgnoreFolderList", ignoreData);
        }
    }
}
