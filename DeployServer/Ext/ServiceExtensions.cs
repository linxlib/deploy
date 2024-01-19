using Entity;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ext
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static ServiceStatus GetStatus(this Service service)
        {
            switch (service.ServiceType)
            {
                //IIS项目
                // 1. 获取网站是否是运行中
                // 2. 获取对应网站的端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.IIS:
                    var manager = new ServerManager();
                    var site = manager.Sites.Where(e => e.Name == service.ServiceName).FirstOrDefault();
                    if (site != null)
                    {
                        try
                        {
                            if (site.State == ObjectState.Started)
                            {
                                return new Entity.ServiceStatus
                                {
                                    Status = Status.Running,
                                    PID = -1,
                                    CmdLine = ""
                                };
                            }
                            else
                            {
                                return new Entity.ServiceStatus
                                {
                                    Status = Status.Stoped,
                                    PID = -1,
                                    CmdLine = ""
                                };
                            }
                        }
                        catch (Exception)
                        {
                            return new Entity.ServiceStatus
                            {
                                Status = Status.NotFound,
                                PID = -1,
                                CmdLine = ""
                            };

                        }
                    }
                    else
                    {
                        return new Entity.ServiceStatus
                        {
                            Status = Status.NotFound,
                            PID = -1,
                            CmdLine = ""
                        };
                    }


                //Console
                // 1. 对应的进程是否能找到(进程ID)
                // 2. 端口是否在监听(没有地方获取, 可根据PID查找其LISTEN列表)
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Console:
                    var proc = Process.GetProcessesByName(service.ServiceName).FirstOrDefault();
                    if (proc != null)
                    {
                        return new ServiceStatus
                        {
                            Status = Status.Running,
                            PID = proc.Id,
                            CmdLine = proc.StartInfo.FileName + " " + proc.StartInfo.Arguments
                        };

                    }
                    else
                    {
                        return new ServiceStatus
                        {
                            Status = Status.Stoped,
                            PID = -1,
                            CmdLine = ""
                        };
                    }

                //Service
                // 1. 服务状态是否正在运行
                // 其他同Console
                case Entity.ServiceType.Service:
                    var ctl = new ServiceController(service.ServiceName);
                    switch (ctl.Status)
                    {
                        case ServiceControllerStatus.Running:
                            return new ServiceStatus
                            {
                                Status = Status.Running,
                                PID = -1,
                                CmdLine = ctl.DisplayName
                            };
             

                        default:
                            return new ServiceStatus
                            {
                                Status = Status.Stoped,
                                PID = -1,
                                CmdLine = ctl.DisplayName
                            };
                      
                    }

                //Systemd
                // 1. 服务是否状态是running
                // 2. 端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Systemd:
                    return new ServiceStatus
                    {
                        Status = Status.Stoped,
                        PID = -1,
                        CmdLine = service.ServiceName
                    };
         
                case Entity.ServiceType.Dir:
                    return new ServiceStatus
                    {
                        Status = Status.Running,
                        PID = -1,
                        CmdLine = service.ServiceName
                    };

                default:
                    return new ServiceStatus
                    {
                        Status = Status.Running,
                        PID = -1,
                        CmdLine = service.ServiceName
                    };

            }
        }
        /// <summary>
        /// 停止服务, 如果服务已停止则直接返回
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static bool Stop(this Service service)
        {
            if (service.GetStatus().Status == Status.Stoped)
            {
                return false;
            }
            switch (service.ServiceType)
            {
                //IIS项目
                // 1. 获取网站是否是运行中
                // 2. 获取对应网站的端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.IIS:
                    var manager = new ServerManager();
                    var site = manager.Sites.Where(e => e.Name == service.ServiceName).FirstOrDefault();
                    if (site != null && site.State==ObjectState.Started)
                    {
                        
                        var s = site.Stop();
                        //manager.CommitChanges();
                        var appPool = manager.ApplicationPools.Where(e => e.Name.Equals(service.ServiceName)).FirstOrDefault();
                        if (appPool!=null)
                        {
                            appPool.Recycle();
                        }
                        return s == ObjectState.Stopped;
                    }
                    return false;
                //Console
                // 1. 对应的进程是否能找到(进程ID)
                // 2. 端口是否在监听(没有地方获取, 可根据PID查找其LISTEN列表)
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Console:
                    var proc = Process.GetProcessesByName(service.ServiceName).FirstOrDefault();
                    if (proc != null)
                    {
                       proc.Kill();
                       return true;

                    }
                    return false;
                //Service
                // 1. 服务状态是否正在运行
                // 其他同Console
                case Entity.ServiceType.Service:
                    var ctl = new ServiceController(service.ServiceName);
                    switch (ctl.Status)
                    {
                        case ServiceControllerStatus.Running:
                           ctl.Stop();
                            return ctl.Status == ServiceControllerStatus.Stopped;
                        
                        default:
                            return false;
                    }

                //Systemd
                // 1. 服务是否状态是running
                // 2. 端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Systemd:
                    return false;
                case Entity.ServiceType.Dir:
                    return true;
                default:
                    return false;
            }

        }
        
        /// <summary>
        /// 覆盖服务文件
        /// </summary>
        /// <param name="service"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool OverwriteFrom(this Service service,string dir)
        {
            return CopyDir(dir, service.RealPath);
        }
        public static bool CopyDir(string srcPath,string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {

                        if (!Directory.Exists(Path.Join(destPath, i.Name)))
                        {
                            Directory.CreateDirectory(Path.Join(destPath, i.Name));   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDir(i.FullName, Path.Join(destPath, i.Name));    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, Path.Join(destPath, i.Name), true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"  "+ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 启动服务
        /// 需要服务为停止状态
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static bool Start(this Service service)
        {
            if (service.GetStatus().Status == Status.Running)
            {
                return false;
            }
            switch (service.ServiceType)
            {
                //IIS项目
                // 1. 获取网站是否是运行中
                // 2. 获取对应网站的端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.IIS:
                    var manager = new ServerManager();
                    var site = manager.Sites.Where(e => e.Name == service.ServiceName).FirstOrDefault();
                    if (site != null && site.State == ObjectState.Stopped)
                    {
                        site.Start();
                        
                        return site .State == ObjectState.Started;
                    }
                    return false;
                //Console
                // 1. 对应的进程是否能找到(进程ID)
                // 2. 端口是否在监听(没有地方获取, 可根据PID查找其LISTEN列表)
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Console:
                    var proc = Process.GetProcessesByName(service.ServiceName).FirstOrDefault();
                    if (proc == null)
                    {
                        //run process
                        if (File.Exists(service.RealPath+"/"+service.ServiceName))
                        {
                            var p = new Process();
                           
                            p.StartInfo = new ProcessStartInfo
                            {
                               Arguments =service.Arg,
                               WorkingDirectory = service.RealPath,
                                FileName = service.RealPath + "/" + service.ServiceName,
                                UseShellExecute = true
                            };
                            p.Start();

                            return true;
                        } else
                        {
                            return false;
                        }



                    }
                    return false;
                //Service
                // 1. 服务状态是否正在运行
                // 其他同Console
                case Entity.ServiceType.Service:
                    var ctl = new System.ServiceProcess.ServiceController(service.ServiceName);
                    switch (ctl.Status)
                    {
                        case ServiceControllerStatus.Stopped:
                            ctl.Start();
                            return ctl.Status == ServiceControllerStatus.Running;

                        default:
                            return false;
                    }

                //Systemd
                // 1. 服务是否状态是running
                // 2. 端口是否在监听
                // 3. 请求 /healthz 是否返回200的状态码(请求路径可配置)
                case Entity.ServiceType.Systemd:
                    return false;
                case Entity.ServiceType.Dir:
                    return true;
                default:
                    return false;
            }

        }
    }
}
