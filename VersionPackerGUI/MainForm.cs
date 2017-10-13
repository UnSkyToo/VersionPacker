using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VersionPackerGUI
{
    public struct VersionData
    {
        public static readonly VersionData Empty = new VersionData(0, 0, 0, 0);

        public int MajorNumber; // 主版本号(1)
        public int MinorNumber; // 次版本号(2)
        public int RevisionNumber; // 修正版本号(3)
        public int BuildNumber; // 编译版本号(4)

        public VersionData(int major, int minor, int revision, int build)
        {
            MajorNumber = major;
            MinorNumber = minor;
            RevisionNumber = revision;
            BuildNumber = build;
        }

        public string ToVersionString()
        {
            return string.Format("{0}.{1}.{2}.{3}", MajorNumber, MinorNumber, RevisionNumber, BuildNumber);
        }

        public override int GetHashCode()
        {
            return MajorNumber.GetHashCode() + MinorNumber.GetHashCode() + RevisionNumber.GetHashCode() + BuildNumber.GetHashCode() + base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(VersionData))
            {
                return false;
            }

            if (obj is VersionData)
            {
                VersionData vd = (VersionData)obj;

                return this.GetHashCode() == vd.GetHashCode();
            }
            return false;
        }

        public static bool operator ==(VersionData lhs, VersionData rhs)
        {
            if (lhs.MajorNumber == rhs.MajorNumber && lhs.MinorNumber == rhs.MinorNumber && lhs.RevisionNumber == rhs.RevisionNumber && lhs.BuildNumber == rhs.BuildNumber)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(VersionData lhs, VersionData rhs)
        {
            if (lhs.MajorNumber != rhs.MajorNumber || lhs.MinorNumber != rhs.MinorNumber || lhs.RevisionNumber != rhs.RevisionNumber || lhs.BuildNumber != rhs.BuildNumber)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(VersionData lhs, VersionData rhs)
        {
            if (lhs.MajorNumber > rhs.MajorNumber)
            {
                return true;
            }

            if (lhs.MajorNumber < rhs.MajorNumber)
            {
                return false;
            }

            if (lhs.MinorNumber > rhs.MinorNumber)
            {
                return true;
            }

            if (lhs.MajorNumber < rhs.MajorNumber)
            {
                return false;
            }

            if (lhs.RevisionNumber > rhs.RevisionNumber)
            {
                return true;
            }

            if (lhs.RevisionNumber < rhs.RevisionNumber)
            {
                return false;
            }

            if (lhs.BuildNumber > rhs.BuildNumber)
            {
                return true;
            }

            if (lhs.BuildNumber < rhs.BuildNumber)
            {
                return false;
            }

            return false;
        }

        public static bool operator <(VersionData lhs, VersionData rhs)
        {
            if (lhs.MajorNumber < rhs.MajorNumber)
            {
                return true;
            }

            if (lhs.MajorNumber > rhs.MajorNumber)
            {
                return false;
            }

            if (lhs.MinorNumber < rhs.MinorNumber)
            {
                return true;
            }

            if (lhs.MajorNumber > rhs.MajorNumber)
            {
                return false;
            }

            if (lhs.RevisionNumber < rhs.RevisionNumber)
            {
                return true;
            }

            if (lhs.RevisionNumber > rhs.RevisionNumber)
            {
                return false;
            }

            if (lhs.BuildNumber < rhs.BuildNumber)
            {
                return true;
            }

            if (lhs.BuildNumber > rhs.BuildNumber)
            {
                return false;
            }

            return false;
        }
    }

    public partial class MainForm : Form
    {
        private string m_VersionPath = string.Empty;
        private string m_PatchPath = string.Empty;
        private string m_ResourcePath = string.Empty;
        private string m_UpdaterUrl = string.Empty;
        private VersionData m_OldVersion = VersionData.Empty;
        private VersionData m_NewVersion = VersionData.Empty;
        private List<string> m_IgnoreFileList = new List<string>();
        private List<string> m_IgnoreFolderList = new List<string>();

        private Process m_packer = null;

        private string IgnoreListToString(List<string> ignoreList)
        {
            if (ignoreList.Count == 0)
            {
                return "0";
            }

            string ignoreData = ignoreList[0];

            for (int i = 1; i < ignoreList.Count; ++i)
            {
                ignoreData = string.Format("{0}|{1}", ignoreData, ignoreList[i]);
            }

            return ignoreData;
        }

        private void InitFormData()
        {
            if (m_VersionPath != string.Empty)
            {
                linkVersionPath.Text = m_VersionPath;
            }
            if (m_PatchPath != string.Empty)
            {
                linkPatchPath.Text = m_PatchPath;
            }
            if (m_ResourcePath != string.Empty)
            {
                linkResourcePath.Text = m_ResourcePath;
            }
            if (m_UpdaterUrl != string.Empty)
            {
                txtUpdaterUrl.Text = m_UpdaterUrl;
            }
            if (m_OldVersion != VersionData.Empty)
            {
                numericOldVersion1.Value = m_OldVersion.MajorNumber;
                numericOldVersion2.Value = m_OldVersion.MinorNumber;
                numericOldVersion3.Value = m_OldVersion.RevisionNumber;
                numericOldVersion4.Value = m_OldVersion.BuildNumber;
            }
            if (m_NewVersion != VersionData.Empty)
            {
                numericNewVersion1.Value = m_NewVersion.MajorNumber;
                numericNewVersion2.Value = m_NewVersion.MinorNumber;
                numericNewVersion3.Value = m_NewVersion.RevisionNumber;
                numericNewVersion4.Value = m_NewVersion.BuildNumber;
            }
            foreach (string folder in m_IgnoreFolderList)
            {
                listIgnore.Items.Add(folder);
            }
            foreach (string file in m_IgnoreFileList)
            {
                listIgnore.Items.Add(file);
            }
        }

        private bool CheckDataValid()
        {
            if (m_VersionPath == string.Empty || m_PatchPath == string.Empty || m_ResourcePath == string.Empty)
            {
                return false;
            }

            if (m_OldVersion == VersionData.Empty || m_NewVersion == VersionData.Empty)
            {
                return false;
            }

            if (m_UpdaterUrl == string.Empty)
            {
                return false;
            }

            return true;
        }

        private bool CreateInfo(string infoPath)
        {
            if (!infoPath.EndsWith("\\"))
            {
                infoPath += "\\";
            }

            if (!Directory.Exists(infoPath))
            {
                Directory.CreateDirectory(infoPath);
            }

            if (File.Exists(infoPath + "info.txt"))
            {
                File.Delete(infoPath + "info.txt");
            }

            File.Copy(Application.StartupPath + "\\info.txt", infoPath + "info.txt");

            if (File.Exists(infoPath + "res_list"))
            {
                File.Delete(infoPath + "res_list");
            }

            File.Copy(Application.StartupPath + "\\res_list", infoPath + "res_list");

            return true;
        }

        private bool PackerPatch() // 生成补丁
        {
            if (CheckDataValid() == false)
            {
                MessageBox.Show("部分打包参数错误");
                return false;
            }
            
            if (m_OldVersion == m_NewVersion)
            {
                MessageBox.Show("版本号相同");
                return false;
            }

            if (m_NewVersion < m_OldVersion)
            {
                MessageBox.Show("新版本不能小于老版本");
                return false;
            }

            try
            {
                if (m_packer.HasExited == false)
                {
                    MessageBox.Show("打包进行中...");
                    return false;
                }
            }
            catch
            {
            }

            string ignoreFileList = IgnoreListToString(m_IgnoreFileList);
            string ignoreFolderList = IgnoreListToString(m_IgnoreFolderList);

            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = Application.StartupPath;
            info.FileName = "VersionPacker.exe";
            info.Arguments = string.Format("-v {0} -x {1} -z {2} -n {0}-{2} -s {3} -u {4} -i {5} -f {6} -l 9 {7}", m_OldVersion.ToVersionString(), m_VersionPath, m_NewVersion.ToVersionString(), m_PatchPath, m_UpdaterUrl, ignoreFileList, ignoreFolderList, m_ResourcePath);

            try
            {
                m_packer.StartInfo = info;
                m_packer.Start();
                m_packer.WaitForExit();

                string infoPath = string.Format("{0}\\{1}-{2}", m_PatchPath, m_OldVersion.ToVersionString(), m_NewVersion.ToVersionString());
                if (!CreateInfo(infoPath))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("打包程序运行错误\r\n{0}", ex.ToString()));
                return false;
            }

            return true;
        }

        private bool PackerVersion() // 生成版本包
        {
            if (CheckDataValid() == false)
            {
                MessageBox.Show("部分打包参数错误");
                return false;
            }

            try
            {
                if (m_packer.HasExited == false)
                {
                    MessageBox.Show("打包进行中...");
                    return false;
                }
            }
            catch
            {
            }

            string ignoreFileList = IgnoreListToString(m_IgnoreFileList);
            string ignoreFolderList = IgnoreListToString(m_IgnoreFolderList);

            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = Application.StartupPath;
            info.FileName = "VersionPacker.exe";
            info.Arguments = string.Format("-x {0} -z {1} -s {2} -u {3} -i {4} -f {5} -l 9 {6}", m_VersionPath, m_NewVersion.ToVersionString(), m_PatchPath, m_UpdaterUrl, ignoreFileList, ignoreFolderList, m_ResourcePath);

            try
            {
                m_packer.StartInfo = info;
                m_packer.Start();
                m_packer.WaitForExit();

                string sourceFilePath = string.Format("{0}\\{1}.zip", m_PatchPath, m_NewVersion.ToVersionString());
                string destFilePath = string.Format("{0}\\{1}.zip", m_VersionPath, m_NewVersion.ToVersionString());

                if (File.Exists(destFilePath))
                {
                    File.Delete(destFilePath);
                }

                File.Move(sourceFilePath, destFilePath);

                string infoPath = string.Format("{0}\\{1}", m_VersionPath, m_NewVersion.ToVersionString());
                if (!CreateInfo(infoPath))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("打包程序运行错误\r\n{0}", ex.ToString()));
                return false;
            }

            return true;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigUtil.LoadConfig();

            m_VersionPath = ConfigUtil.GetVersionPath();
            m_PatchPath = ConfigUtil.GetPatchPath();
            m_ResourcePath = ConfigUtil.GetResourcePath();
            m_OldVersion = ConfigUtil.GetOldVersion();
            m_NewVersion = ConfigUtil.GetNewVersion();
            m_UpdaterUrl = ConfigUtil.GetUpdaterUrl();
            m_IgnoreFileList = ConfigUtil.GetIgnoreFileList();
            m_IgnoreFolderList = ConfigUtil.GetIgnoreFolderList();

            m_packer = new Process();

            InitFormData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigUtil.SetVersionPath(m_VersionPath);
            ConfigUtil.SetPatchPath(m_PatchPath);
            ConfigUtil.SetResourcePath(m_ResourcePath);
            ConfigUtil.SetOldVersion(m_OldVersion);
            ConfigUtil.SetNewVersion(m_NewVersion);
            ConfigUtil.SetUpdaterUrl(m_UpdaterUrl);
            ConfigUtil.SetIgnoreFileList(m_IgnoreFileList);
            ConfigUtil.SetIgnoreFolderList(m_IgnoreFolderList);

            ConfigUtil.SaveConfig();

            try
            {
                if (m_packer.HasExited == false)
                {
                    m_packer.Kill();
                }
            }
            catch
            {
            }
        }

        private void linkVersionPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "选择版本库文件所在目录";
            dialog.SelectedPath = m_VersionPath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_VersionPath = dialog.SelectedPath;
                linkVersionPath.Text = m_VersionPath;
            }
        }

        private void linkPatchPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "选择更新包文件存放目录";
            dialog.SelectedPath = m_PatchPath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_PatchPath = dialog.SelectedPath;
                linkPatchPath.Text = m_PatchPath;
            }
        }
        private void linkResourcePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "选择资源包文件所在目录";
            dialog.SelectedPath = m_ResourcePath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_ResourcePath = dialog.SelectedPath;
                linkResourcePath.Text = m_ResourcePath;

                if (listIgnore.Items.Count > 0 && listIgnore.Items[0].ToString().EndsWith(".svn"))
                {
                    listIgnore.Items.RemoveAt(0);
                    m_IgnoreFolderList.RemoveAt(0);
                }

                listIgnore.Items.Insert(0, string.Format(@"{0}\{1}", m_ResourcePath, ".svn"));
                m_IgnoreFolderList.Insert(0, listIgnore.Items[0].ToString());
            }
        }

        private void numericOldVersion_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown control = sender as NumericUpDown;

            if (control != null)
            {
                string name = control.Name;
                int value = (int)control.Value;

                switch (name)
                {
                    case "numericOldVersion1":
                        m_OldVersion.MajorNumber = value;
                        break;
                    case "numericOldVersion2":
                        m_OldVersion.MinorNumber = value;
                        break;
                    case "numericOldVersion3":
                        m_OldVersion.RevisionNumber = value;
                        break;
                    case "numericOldVersion4":
                        m_OldVersion.BuildNumber = value;
                        break;
                    case "numericNewVersion1":
                        m_NewVersion.MajorNumber = value;
                        break;
                    case "numericNewVersion2":
                        m_NewVersion.MinorNumber = value;
                        break;
                    case "numericNewVersion3":
                        m_NewVersion.RevisionNumber = value;
                        break;
                    case "numericNewVersion4":
                        m_NewVersion.BuildNumber = value;
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtUpdaterUrl_TextChanged(object sender, EventArgs e)
        {
            m_UpdaterUrl = txtUpdaterUrl.Text;
        }

        private void btnCreatePatch_Click(object sender, EventArgs e)
        {
            if (PackerPatch() == false)
            {
                return;
            }

            if (PackerVersion() == false)
            {
                return;
            }

            MessageBox.Show("打包完成");
        }

        private void btnCreateWholePack_Click(object sender, EventArgs e)
        {
            if (PackerVersion() == false)
            {
                return;
            }

            MessageBox.Show("打包完成");
        }

        private void btnAddIgnoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.InitialDirectory = m_ResourcePath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach(string filePath in dialog.FileNames)
                {
                    if (listIgnore.Items.Contains(filePath) == false)
                    {
                        listIgnore.Items.Add(filePath);
                        m_IgnoreFileList.Add(filePath);
                    }
                }
            }
        }

        private void btnAddIgnoreFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = "选择要忽略的目录";
            dialog.SelectedPath = m_ResourcePath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string realData = dialog.SelectedPath;
                if (listIgnore.Items.Contains(realData) == false)
                {
                    listIgnore.Items.Add(realData);
                    m_IgnoreFolderList.Add(realData);
                }
            }
        }

        private void btnDeleteIgnoreItem_Click(object sender, EventArgs e)
        {
            if (listIgnore.SelectedIndex != -1)
            {
                if (listIgnore.SelectedItem.ToString().EndsWith(".svn"))
                {
                    return;
                }
                m_IgnoreFileList.Remove(listIgnore.SelectedItem.ToString());
                m_IgnoreFolderList.Remove(listIgnore.SelectedItem.ToString());
                listIgnore.Items.RemoveAt(listIgnore.SelectedIndex);
            }
        }

        private void btnClearIgnoreList_Click(object sender, EventArgs e)
        {
            m_IgnoreFileList.Clear();
            m_IgnoreFolderList.Clear();
            listIgnore.Items.Clear();

            if (m_ResourcePath != string.Empty)
            {
                m_IgnoreFolderList.Add(string.Format(@"{0}\{1}", m_ResourcePath, ".svn"));
                listIgnore.Items.Add(m_IgnoreFolderList[0]);
            }
        }
    }
}
