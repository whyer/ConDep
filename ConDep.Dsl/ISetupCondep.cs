﻿using System;
using System.Diagnostics;
using ConDep.Dsl.WebDeploy;

namespace ConDep.Dsl
{
    public interface ISetupConDep
    {
        bool IsValid(Notification notification);
        WebDeploymentStatus Execute(ConDepOptions options, EventHandler<WebDeployMessageEventArgs> onMessage, EventHandler<WebDeployMessageEventArgs> onErrorMessage, WebDeploymentStatus status);
        void PrintExecutionSequence(ConDepOptions options);
    }
}