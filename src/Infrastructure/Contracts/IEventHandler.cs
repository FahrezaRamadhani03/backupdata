// <copyright file="IEventHandler.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Infrastructure.Contracts
{
    public interface IEventHandler
    {
        int Priority { get; }

        void HandleEvent();
    }

    public interface IEventHandler<TEventArgument>
    {
        int Priority { get; }

        void HandleEvent(TEventArgument argument);
    }

    public interface IEventHandler<TEventArgument1, TEventArgument2>
    {
        int Priority { get; }

        void HandleEvent(TEventArgument1 argument1, TEventArgument2 argument2);
    }

    public interface IEventHandler<TEventArgument1, TEventArgument2, TEventArgument3>
    {
        int Priority { get; }

        void HandleEvent(TEventArgument1 argument1, TEventArgument2 argument2, TEventArgument3 argument3);
    }
}