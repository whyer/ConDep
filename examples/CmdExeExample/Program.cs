﻿using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using ConDep.Dsl;

namespace TestWebDeployApp
{
    public class Program : ConDepConsoleApp<Program, ISettings>
    {
        static void Main(string[] args)
        {
            Initialize(args);
        }

        protected override void Execute(ISettings settings)
        {
            // ReSharper disable ConvertToLambdaExpression

            
            
            
            //SetupInfrastructure
            //DeployContent
            Setup(setup =>
                      
                          //setup.TransformConfig("", "web.config", "web.dev.config");
                          //setup.PreCompile("MyApp", @"C:\", "C:\temp");
                          //setup.ApplicationRequestRouting("MyNLBServer")
                          //    .LoadBalancer
                          //    .Farm("Sikker")
                          //    .TakeServerOffline("10.0.0.12");

                          setup.Deployment("127.0.0.1", serverSetup =>
                                    {
                                        //serverSetup.IIS.SyncFromExistingServer("jat-web02", sync =>
                                        //{
                                        //    sync.WebSite("ConDep", "MyNewDestSite", @"C:\Web\MyWebSite", options =>
                                        //    {
                                        //        options.Include.AppPools();
                                        //        options.Include.Certificates();
                                        //    });

                                        //});

                                        //serverSetup.Windows.InstallIIS();
                                        //                                   {
                                        //                                   });
                                        //serverSetup.Windows.InstallMSMQ();
                                        //serverSetup.Windows.InstallMSDTC();
                                        //serverSetup.SqlServer.MigrateTo2012();
                                        //serverSetup.Windows.Install();
                                        serverSetup.Certificate(@"C:\temp\myCert.cer");
                                        serverSetup.Certificate("71ce12870b7517d04dbb7497de992a6a8c69a435", X509FindType.FindByThumbprint);
                                        
                                        
                                        
                                        
                                        
                                        //serverSetup.IIS.Define(iis =>
                                        //    {
                                        //        iis.WebSite("ConDepSite1", 2, @"C:\Web\MyFirstCustomWebSite", options =>
                                        //            {
                                        //                options.HttpBinding(8080, o => o.HostHeader("blog.torresdal.net").Ip("10.0.0.11"));
                                        //                options.HttpsBinding(444, "localhost", o => o.HostHeader("www.con-dep.net").Ip("10.0.0.12"));
                                        //                options.ApplicationPool("MyFirstCustomAppPool", o =>
                                        //                                                                    {
                                        //                                                                        o.NetFrameworkVersion(NetFrameworkVersion.Net4_0);
                                        //                                                                        o.Enable32Bit = true;
                                        //                                                                        o.ManagedPipeline(ManagedPipeline.Integrated);
                                        //                                                                        o.Identity.UserName("torresdal\\jat").Password("asdfasdf");
                                        //                                                                        o.IdleTimeoutInMinutes = 10;
                                        //                                                                        o.LoadUserProfile = false;
                                        //                                                                        o.RecycleTimeIntervalInMinutes = 1000;
                                        //                                                                    });
                                        //                options.WebApp("MyWebApp");
                                        //                options.WebApp("MyWebApp2", o =>
                                        //                                                {
                                        //                                                    o.PhysicalPath = @"C:\Web\MyWebApp2_2";
                                        //                                                    o.ApplicationPool = "MyFirstCustomAppPool";
                                        //                                                });
                                        //            });

                                        //        iis.WebSite("ConDepSite2", 3, @"C:\Web\MySecondCustomWebSite", o=>
                                        //                                          {
                                        //                                              o.HttpBinding(81);
                                        //                                          });
                                        //        iis.WebApp("MyWebApp3", "ConDepSite2");
                                        //    });








        // ReSharper restore ConvertToLambdaExpression


                                        //serverSetup.IIS.Define(customIisDefinition =>
                                        //{
                                        //    //iisSetup.AppPool("", "", "");
                                        //    customIisDefinition.WebApp("MyWebApp", "MyWebSite", "");
                                        //    customIisDefinition.WebSite("MyWebSite", "", options =>
                                        //    {
                                        //        //options.Binding("type","ipAddress","port","hostName","certificate");
                                        //        //options.AppPool("MyAppPool","classic","4.0");
                                        //        //options.WebApp("","","",waOptions=>
                                        //        //{
                                        //        //    waOptions.AppPool("","");
                                        //        //});
                                        //    });
                                        //});

                                        //serverSetup.IIS.SyncFromExistingServer("127.0.0.1", sync =>
                                        //                                    {
                                        //                                        sync.WebApp("Default Web Site", "MailChimpIntegration", "Default Web Site", "ConDepTestMailChimp");
                                        //                                        //sync.WebSite("MySite", "MyNewDestSite");
                                        //                                    });


                                        //serverSetup.Certificate(@"C:\cert.cer");
                                        ////serverSetup.Certificate("srcServer", "thumbprint");
                                        ////serverSetup.CopyDir("srcServer", "srcDir", "dstDir");
                                        ////serverSetup.CopyDir("srcDir", "dstDir");
                                        ////serverSetup.CopyFile("srcServer", "srcFile", "dstFile");
                                        ////serverSetup.CopyFile("srcFile", "dstFile");
                                        //serverSetup.RunCmd("ipconfig /flushdns");
                                        //serverSetup.PowerShell("Get-IPConfig");
                                        //serverSetup.SetAcl("", o => o.Permissions(FileSystemRights.Read, ""));
                                        //serverSetup.NServiceBus("", "", o => o.DestinationDir(""));
                                        ////serverSetup.WindowsService("");


                                    } )

                      );
        }
    }
}
