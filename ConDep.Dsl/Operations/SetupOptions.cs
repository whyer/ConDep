﻿using ConDep.Dsl.Operations;

namespace ConDep.Dsl.Builders
{
	public class SetupOptions
	{
		private readonly SetupOperation _setupOperation;

		public SetupOptions(SetupOperation setupOperation)
		{
			_setupOperation = setupOperation;
		}

		public void AddOperation(IOperateConDep operation)
		{
			_setupOperation.AddOperation(operation);
		}
	}
}