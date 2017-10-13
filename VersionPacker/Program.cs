using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VersionPacker
{
    class Program
    {
        // 资源路径
        private static string resourcePath = string.Empty;
        // 新版本号
        private static string newVersion = "Resource";
        // 新版本压缩包名称（未指定默认为新版本号）
        private static string newVersionZipName = string.Empty;
        // 老版本号
        private static string oldVersion = string.Empty;
        // 老本版本存放路径
        private static string versionPath = string.Empty;
        // 打包的补丁存放路径
        private static string newVersionPath = string.Empty;
        // 压缩密码
        private static string password = string.Empty;
        // 压缩等级
        private static int zipLevel = 0;
        // 更新服务器地址
        private static string updaterUrl = string.Empty;
        // 忽略文件列表
        private static List<string> ignoreFileList = new List<string>();
        // 忽略目录列表
        private static List<string> ignoreFolderList = new List<string>();

        private static void Usage()
        {
            Console.WriteLine("Version Packer v1.0.0");
            Console.WriteLine("用法：VersionPacker [-option] resourcePath");
            Console.WriteLine("");
            Console.WriteLine("其中选项包括：");
            Console.WriteLine("  -v\t指定参与比较的版本号（如果未指定，则打包所有资源）");
            Console.WriteLine("  -x\t指定版本Zip包所在的目录");
            Console.WriteLine("  -z\t指定压缩后的版本号");
            Console.WriteLine("  -n\t指定压缩后的文件名（如果未指定，则默认为版本号）");
            Console.WriteLine("  -s\t指定压缩后的版本存放目录");
            Console.WriteLine("  -l\t指定压缩等级（0-9）");
            Console.WriteLine("  -p\t指定压缩包密码");
            Console.WriteLine("  -u\t指定更新服务器地址");
            Console.WriteLine("  -i\t指定忽略的文件列表");
            Console.WriteLine("  -f\t指定忽略的目录列表");
            Console.WriteLine("  -h\t帮助");
        }

        private static void ParseArgs(string[] args)
        {
            try
            {
                for (int i = 0; i < args.Length; )
                {
                    if (args[i].StartsWith("-"))
                    {
                        switch (args[i])
                        {
                            case "-v":
                                oldVersion = args[i + 1];
                                i += 2;
                                break;
                            case "-x":
                                versionPath = args[i + 1];
                                i += 2;
                                break;
                            case "-z":
                                newVersion = args[i + 1];
                                i += 2;
                                break;
                            case "-n":
                                newVersionZipName = args[i + 1];
                                i += 2;
                                break;
                            case "-s":
                                newVersionPath = args[i + 1];
                                i += 2;
                                break;
                            case "-l":
                                zipLevel = int.Parse(args[i + 1]);
                                i += 2;
                                break;
                            case "-p":
                                password = args[i + 1];
                                i += 2;
                                break;
                            case "-u":
                                updaterUrl = args[i + 1];
                                i += 2;
                                break;
                            case "-i":
                                string ignoreFile = args[i + 1];
                                if (ignoreFile != "0")
                                {
                                    string[] ignoreFiles = ignoreFile.Split(new char[] { '|' });
                                    ignoreFileList.AddRange(ignoreFiles);
                                }
                                i += 2;
                                break;
                            case "-f":
                                string ignoreFolder = args[i + 1];
                                if (ignoreFolder != "0")
                                {
                                    string[] ignoreFolders = ignoreFolder.Split(new char[] { '|' });
                                    ignoreFolderList.AddRange(ignoreFolders);
                                }
                                i += 2;
                                break;
                            case "-h":
                                Usage();
                                i++;
                                break;
                            default:
                                i++;
                                break;

                        }
                    }
                    else
                    {
                        i++;
                    }
                }

                if (args.Length > 0)
                {
                    resourcePath = args[args.Length - 1];
                }
            }
            catch
            {
                throw new Exception("参数错误");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //string arg = "-v 1.0.0.0 -x E:\\Version\\Version -z 1.0.0.1 -n 1.0.0.0-1.0.0.1 -s E:\\Version\\Difference -u http://127.0.0.1/ -i E:\\DemoHero\\config.json|E:\\DemoHero\\lua_project.config|E:\\DemoHero\\lua_project.luaproj -f E:\\DemoHero\\.svn|E:\\DemoHero\\frameworks|E:\\DemoHero\\obj|E:\\DemoHero\\runtime|E:\\DemoHero\\server|E:\\DemoHero\\temp E:\\DemoHero";
                //string arg = "-x E:\\Version\\Version -z 1.0.0.0 -s E:\\Version\\Difference -u http://127.0.0.1/ -i E:\\DemoHero\\config.json|E:\\DemoHero\\lua_project.config|E:\\DemoHero\\lua_project.luaproj -f E:\\DemoHero\\.svn|E:\\DemoHero\\frameworks|E:\\DemoHero\\obj|E:\\DemoHero\\runtime|E:\\DemoHero\\server|E:\\DemoHero\\temp E:\\DemoHero";
                //string arg = "-x E:\\Version\\Version -z 1.0.0.0 -s E:\\Version\\Difference -u http://1.1.1.1 -i  -f E:\\DemoHero\\.svn|E:\\DemoHero\\docs|E:\\DemoHero\\frameworks|E:\\DemoHero\\obj|E:\\DemoHero\\runtime|E:\\DemoHero\\server|E:\\DemoHero\\res|E:\\DemoHero\\src E:\\DemoHero";
                //args = arg.Split(new char[]{ ' ' });

                foreach (string arg in args)
                {
                    Console.WriteLine(arg);
                }

                if (args.Length == 0)
                {
                    Usage();
                }
                else
                {
                    ParseArgs(args);
                    Console.WriteLine("打包中 <- " + resourcePath);
                    VersionUtil.Packer(resourcePath, oldVersion, versionPath, newVersion, newVersionZipName, newVersionPath, password, zipLevel, updaterUrl, ignoreFileList, ignoreFolderList);
                    Console.WriteLine("打包完成 -> " + newVersion);
                }

                //Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
