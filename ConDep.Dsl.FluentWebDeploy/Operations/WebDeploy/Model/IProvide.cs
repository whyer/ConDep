﻿namespace ConDep.Dsl.FluentWebDeploy.Operations.WebDeploy.Model
{
    public interface IProvide
    {
        bool IsValid(Notification notification);
		int WaitInterval { get; set; }
        WebDeploymentStatus Sync(WebDeployOptions webDeployOptions, WebDeploymentStatus deploymentStatus);
    }
}