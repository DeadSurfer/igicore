﻿using CitizenFX.Core;
using IgiCore.Client.Diagnostics;
using IgiCore.SDK.Client.Rpc;
using IgiCore.SDK.Core.Rpc;

namespace IgiCore.Client.Rpc
{
	public static class RpcManager
	{
		private static readonly Logger Logger;
		private static readonly Serializer Serializer;
		private static readonly RpcTrigger Trigger;
		private static ServerHandler handler;

		static RpcManager()
		{
			Logger = new Logger("RPC");
			Serializer = new Serializer();
			Trigger = new RpcTrigger(Logger, Serializer);
		}

		public static void Configure(EventHandlerDictionary events)
		{
			handler = new ServerHandler(events);
		}

		public static IRpc Event(string @event) => new Rpc(@event, Logger, handler, Trigger, Serializer);
	}
}
