﻿using System;
using SimpleInjector;
using SlackNet.Handlers;

namespace SlackNet.SimpleInjector
{
    class SimpleInjectorSlackServiceProvider : ISlackServiceProvider
    {
        private readonly ISlackServiceProvider _baseProvider;
        private readonly Container _container;

        public SimpleInjectorSlackServiceProvider(Func<ISlackServiceProvider, ISlackServiceProvider> createBaseProvider, Container container)
        {
            _baseProvider = createBaseProvider(this);
            _container = container;
        }

        public TService GetInstance<TService>() where TService : class => _container.GetInstance<TService>();

        public IHttp GetHttp() => _baseProvider.GetHttp();
        public SlackJsonSettings GetJsonSettings() => _baseProvider.GetJsonSettings();
        public ISlackTypeResolver GetTypeResolver() => _baseProvider.GetTypeResolver();
        public ISlackUrlBuilder GetUrlBuilder() => _baseProvider.GetUrlBuilder();
        public IWebSocketFactory GetWebSocketFactory() => _baseProvider.GetWebSocketFactory();
        public ISlackRequestContextFactory GetRequestContextFactory() => _baseProvider.GetRequestContextFactory();
        public ISlackRequestListener GetRequestListener() => _baseProvider.GetRequestListener();
        public ISlackHandlerFactory GetHandlerFactory() => _baseProvider.GetHandlerFactory();
        public ISlackApiClient GetApiClient() => _baseProvider.GetApiClient();
        public ISlackSocketModeClient GetSocketModeClient() => _baseProvider.GetSocketModeClient();
    }
}