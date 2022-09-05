// <copyright file="Event.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Garuda.Infrastructure.Events
{
    public static class Event<TEventHandler>
        where TEventHandler : IEventHandler
    {
        public static IEnumerable<TEventHandler> Broadcast()
        {
            IEnumerable<TEventHandler> eventHandlers = ExtensionManager.GetInstances<TEventHandler>().OrderBy(eh => eh.Priority);

            foreach (TEventHandler eventHandler in eventHandlers)
            {
                eventHandler.HandleEvent();
            }

            return eventHandlers;
        }
    }

    public static class Event<TEventHandler, TEventArgument>
        where TEventHandler : IEventHandler<TEventArgument>
    {
        public static IEnumerable<TEventHandler> Broadcast(TEventArgument argument)
        {
            IEnumerable<TEventHandler> eventHandlers = ExtensionManager.GetInstances<TEventHandler>().OrderBy(eh => eh.Priority);

            foreach (TEventHandler eventHandler in eventHandlers)
            {
                eventHandler.HandleEvent(argument);
            }

            return eventHandlers;
        }
    }

    public static class Event<TEventHandler, TEventArgument1, TEventArgument2>
        where TEventHandler : IEventHandler<TEventArgument1, TEventArgument2>
    {
        public static IEnumerable<TEventHandler> Broadcast(TEventArgument1 argument1, TEventArgument2 argument2)
        {
            IEnumerable<TEventHandler> eventHandlers = ExtensionManager.GetInstances<TEventHandler>().OrderBy(eh => eh.Priority);

            foreach (TEventHandler eventHandler in eventHandlers)
            {
                eventHandler.HandleEvent(argument1, argument2);
            }

            return eventHandlers;
        }
    }

    public static class Event<TEventHandler, TEventArgument1, TEventArgument2, TEventArgument3>
        where TEventHandler : IEventHandler<TEventArgument1, TEventArgument2, TEventArgument3>
    {
        public static IEnumerable<TEventHandler> Broadcast(TEventArgument1 argument1, TEventArgument2 argument2, TEventArgument3 argument3)
        {
            IEnumerable<TEventHandler> eventHandlers = ExtensionManager.GetInstances<TEventHandler>().OrderBy(eh => eh.Priority);

            foreach (TEventHandler eventHandler in eventHandlers)
            {
                eventHandler.HandleEvent(argument1, argument2, argument3);
            }

            return eventHandlers;
        }
    }
}