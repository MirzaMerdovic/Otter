﻿using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Otter
{
    public class DockerClientConfiguration : IDisposable
    {
        public Uri EndpointBaseUri { get; internal set; }

        public Credentials Credentials { get; internal set; }

        public TimeSpan DefaultTimeout { get; internal set; } = TimeSpan.FromSeconds(100);

        public TimeSpan NamedPipeConnectTimeout { get; set; } = TimeSpan.FromMilliseconds(100);

        public DockerClientConfiguration(Credentials credentials = null, TimeSpan defaultTimeout = default)
            : this(LocalDockerUri(), credentials, defaultTimeout)
        {
        }

        public DockerClientConfiguration(
            Uri endpoint, 
            Credentials credentials = null,
            TimeSpan defaultTimeout = default)
        {
            EndpointBaseUri = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            Credentials = credentials ?? new AnonymousCredentials();

            if (defaultTimeout != TimeSpan.Zero)
            {
                if (defaultTimeout < Timeout.InfiniteTimeSpan)
                    throw new ArgumentException("Timeout must be greater than Timeout.Infinite", nameof(defaultTimeout));
                
                DefaultTimeout = defaultTimeout;
            }
        }

        public DockerClient CreateClient()
        {
            return CreateClient(null);
        }

        public DockerClient CreateClient(Version requestedApiVersion)
        {
            return new DockerClient(this, requestedApiVersion);
        }

        public void Dispose()
        {
            Credentials.Dispose();
        }

        private static Uri LocalDockerUri()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            return isWindows ? new Uri("npipe://./pipe/docker_engine") : new Uri("unix:/var/run/docker.sock");
        }
    }
}