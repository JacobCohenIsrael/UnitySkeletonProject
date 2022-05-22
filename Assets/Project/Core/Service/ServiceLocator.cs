using System;
using System.Collections.Generic;
using UnityEngine;

namespace JCI.Core.Service
{
    /// <summary>
    /// Simple service locator for <see cref="IGameService"/> instances.
    /// </summary>
    public class ServiceLocator
    {
        private ServiceLocator() { }

        /// <summary>
        /// currently registered services.
        /// </summary>
        private readonly Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();

        /// <summary>
        /// Gets the currently active service locator instance.
        /// </summary>
        public static ServiceLocator Current { get; private set; }
        
        /// <summary>
        /// Initalizes the service locator with a new instance.
        /// </summary>
        public static void Initialize()
        {
            if (Current != null)
                return;
            
            Current = new ServiceLocator();
        }


        public static T GetS<T>() where T : IGameService
        {
            if (Current == null)
                return default;
            return Current.Get<T>();
        }


        /// <summary>
        /// Gets the service instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type of the service to lookup.</typeparam>
        /// <returns>The service instance.</returns>
        public T Get<T>() where T : IGameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError(new Exception($"{key} not registered with {GetType().Name}"));
                throw new InvalidOperationException();
            }

            return (T)services[key];
        }

        /// <summary>
        /// Registers the service with the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        /// <param name="service">Service instance.</param>
        public void Register<T>(T service) where T : IGameService
        {
            string key = typeof(T).Name;
            if (services.ContainsKey(key))
            {
                Debug.LogError(new Exception($"Attempted to register service of type {key} which is already registered with the {GetType().Name}."));
                return;
            }

            services.Add(key, service);
        }

        /// <summary>
        /// Unregisters the service from the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        public void Unregister<T>() where T : IGameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError(new Exception($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}."));
                return;
            }

            services.Remove(key);
        }

    }
}

