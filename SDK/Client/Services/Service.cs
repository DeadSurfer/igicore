﻿using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using IgiCore.Models.Player;
using IgiCore.SDK.Client.Events;
using IgiCore.SDK.Client.Rpc;
using IgiCore.SDK.Core.Diagnostics;
using JetBrains.Annotations;

namespace IgiCore.SDK.Client.Services
{
	[UsedImplicitly]
	public abstract class Service
	{
		protected readonly ILogger Logger;
		protected readonly ITickManager Ticks;
		protected readonly IEventManager Events;
		protected readonly IRpcHandler Rpc;
		protected readonly User User;

		protected Service(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, User user)
		{
			this.Logger = logger;
			this.Ticks = ticks;
			this.Events = events;
			this.Rpc = rpc;
			this.User = user;
		}

		public virtual Task Loaded() => Task.FromResult(0);

		public virtual Task Started() => Task.FromResult(0);

		protected async Task Delay(int msec)
		{
			await BaseScript.Delay(msec);
		}

		protected async Task Delay(TimeSpan delay)
		{
			await BaseScript.Delay((int)delay.TotalMilliseconds);
		}
	}
}
