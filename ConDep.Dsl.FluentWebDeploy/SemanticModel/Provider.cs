﻿using System;
using Microsoft.Web.Deployment;

namespace ConDep.Dsl.FluentWebDeploy.SemanticModel
{
	public abstract class Provider : IProvide, IWebDeployModel
	{
        public string SourcePath { get; set; }
		public virtual string DestinationPath { get; set; }
		public abstract string Name { get; }
		public int WaitInterval { get; set; }

		public abstract DeploymentProviderOptions GetWebDeployDestinationObject();
		public abstract DeploymentObject GetWebDeploySourceObject(DeploymentBaseOptions sourceBaseOptions);
		public abstract bool IsValid(Notification notification);

        public virtual DeploymentStatus Sync(WebDeployOptions webDeployOptions, DeploymentStatus deploymentStatus)
        {
            var defaultWaitInterval = webDeployOptions.DestBaseOptions.RetryInterval;

            if (WaitInterval > 0)
            {
                webDeployOptions.DestBaseOptions.RetryInterval = WaitInterval * 1000;
            }

            var sourceDepObject = GetWebDeploySourceObject(webDeployOptions.SourceBaseOptions);
            var destProviderOptions = GetWebDeployDestinationObject();

            var summery = sourceDepObject.SyncTo(destProviderOptions, webDeployOptions.DestBaseOptions, webDeployOptions.SyncOptions);

            deploymentStatus.AddSummery(summery);

            webDeployOptions.DestBaseOptions.RetryInterval = defaultWaitInterval;

            if (summery.Errors > 0)
            {
                throw new Exception("The provider reported " + summery.Errors + " during deployment.");
            }
            return deploymentStatus;
        }
	}
}