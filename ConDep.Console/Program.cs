﻿using System;
using System.IO;
using System.Net;
using System.Reflection;
using ConDep.Dsl;
using ConDep.Dsl.Config;
using ConDep.Dsl.Logging;
using ConDep.Dsl.SemanticModel;
using ConDep.Dsl.SemanticModel.WebDeploy;

namespace ConDep.Console
{
    sealed internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = 0;
            try
            {
                new LogConfigLoader().Load();

                var optionHandler = new CommandLineOptionHandler(args);

                var configAssemblyLoader = new ConDepAssemblyHandler(optionHandler.Params.AssemblyName);
                var assembly = configAssemblyLoader.GetAssembly();

                var conDepOptions = new ConDepOptions(optionHandler.Params.DeployAllApps, optionHandler.Params.Application, optionHandler.Params.DeployOnly, optionHandler.Params.InfraOnly, optionHandler.Params.WebDeployExist, optionHandler.Params.StopAfterMarkedServer, optionHandler.Params.ContinueAfterMarkedServer);
                var envSettings = GetEnvConfig(optionHandler.Params, assembly);

                var status = new WebDeploymentStatus();
                Logger.LogSectionStart("ConDep");
                ConDepConfigurationExecutor.ExecuteFromAssembly(assembly, envSettings, conDepOptions, status);

                if(status.HasErrors)
                {
                    exitCode = 1;
                }
                else
                {
                    status.EndTime = DateTime.Now;
                    status.PrintSummery();
                }
            }
            catch (Exception ex)
            {
                exitCode = 1;
                Logger.Error("ConDep reported a fatal error:");
                Logger.Error("Message: " + ex.Message);
                Logger.Error("Stack trace:\n" + ex.StackTrace);
            }
            finally
            {
                Logger.LogSectionEnd("ConDep");
                Environment.Exit(exitCode);
            }
        }

        private static ConDepConfig GetEnvConfig(CommandLineParams cmdParams, Assembly assembly)
        {
            var envFileName = string.Format("{0}.Env.json", cmdParams.Environment);
            var envFilePath = Path.Combine(Path.GetDirectoryName(assembly.Location), envFileName);

            var jsonConfigParser = new EnvConfigParser();
            var envConfig = jsonConfigParser.GetEnvConfig(envFilePath);
            envConfig.EnvironmentName = cmdParams.Environment;

            if (cmdParams.BypassLB)
            {
                envConfig.LoadBalancer = null;
            }
            return envConfig;
        }
    }
}
