﻿using ConDep.Dsl.FluentWebDeploy.Builders;

namespace ConDep.Dsl.FluentWebDeploy
{
	public class CopyDirOptions : IProvideOptions<CopyDirOptions>
	{
		private readonly CopyDirProvider _copyDirProvider;

		public CopyDirOptions(CopyDirProvider copyDirProvider)
		{
			_copyDirProvider = copyDirProvider;
		}

		public IProvideOptions<CopyDirOptions> DestinationDir(string remotePath)
		{
			_copyDirProvider.DestinationPath = remotePath;
			return this;
		}
	}
}