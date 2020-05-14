// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.DotNet.Build.Tasks.Feed.Model;
using Microsoft.DotNet.VersionTools.BuildManifest.Model;
using System.Collections.Generic;

namespace Microsoft.DotNet.Build.Tasks.Feed.model
{
    class PublishingContants
    {
        public static readonly string ExpectedFeedUrlSuffix = "index.json";

        // Matches package feeds like
        // https://dotnet-feed-internal.azurewebsites.net/container/dotnet-core-internal/sig/dsdfasdfasdf234234s/se/2020-02-02/darc-int-dotnet-arcade-services-babababababe-08/index.json
        public static readonly string AzureStorageProxyFeedPattern =
            @"(?<feedURL>https://([a-z-]+).azurewebsites.net/container/(?<container>[^/]+)/sig/\w+/se/([0-9]{4}-[0-9]{2}-[0-9]{2})/(?<baseFeedName>darc-(?<type>int|pub)-(?<repository>.+?)-(?<sha>[A-Fa-f0-9]{7,40})-?(?<subversion>\d*)/))index.json";

        // Matches package feeds like the one below. Special case for static internal proxy-backed feed
        // https://dotnet-feed-internal.azurewebsites.net/container/dotnet-core-internal/sig/dsdfasdfasdf234234s/se/2020-02-02/darc-int-dotnet-arcade-services-babababababe-08/index.json
        public static readonly string AzureStorageProxyFeedStaticPattern =
            @"(?<feedURL>https://([a-z-]+).azurewebsites.net/container/(?<container>[^/]+)/sig/\w+/se/([0-9]{4}-[0-9]{2}-[0-9]{2})/(?<baseFeedName>[^/]+/))index.json";

        // Matches package feeds like
        // https://dotnetfeed.blob.core.windows.net/dotnet-core/index.json
        public static readonly string AzureStorageStaticBlobFeedPattern =
            @"https://([a-z-]+).blob.core.windows.net/[^/]+/index.json";

        // Matches package feeds like
        // https://pkgs.dev.azure.com/dnceng/public/_packaging/public-feed-name/nuget/v3/index.json
        // or https://pkgs.dev.azure.com/dnceng/_packaging/internal-feed-name/nuget/v3/index.json
        public static readonly string AzDoNuGetFeedPattern =
            @"https://pkgs.dev.azure.com/(?<account>[a-zA-Z0-9]+)/(?<visibility>[a-zA-Z0-9-]+/)?_packaging/(?<feed>.+)/nuget/v3/index.json";

        #region Target Channel Configs
        private const string FeedForChecksums = "https://dotnetclichecksums.blob.core.windows.net/dotnet/index.json";
        private const string FeedForInstallers = "https://dotnetcli.blob.core.windows.net/dotnet/index.json";

        private const string FeedInternalForChecksums = "https://dotnetclichecksumsmsrc.blob.core.windows.net/dotnet/index.json";
        private const string FeedInternalForInstallers = "https://dotnetclimsrc.blob.core.windows.net/dotnet/index.json";

        private const string FeedGeneralTesting = "https://pkgs.dev.azure.com/dnceng/public/_packaging/general-testing/nuget/v3/index.json";
        private const string FeedGeneralTestingSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/general-testing-symbols/nuget/v3/index.json";

        private const string FeedDotNetExperimental = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-experimental/nuget/v3/index.json";
        private const string FeedDotNetExperimentalSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-experimental-symbols/nuget/v3/index.json";

        private const string FeedDotNetEngShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng/nuget/v3/index.json";
        private const string FeedDotNetEngTransport = FeedDotNetEngShipping;
        private const string FeedDotNetEngSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng-symbols/nuget/v3/index.json";

        private const string FeedDotNetToolsShipping = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools/nuget/v3/index.json";
        private const string FeedDotNetToolsTransport = FeedDotNetToolsShipping;
        private const string FeedDotNetToolsSymbols = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools-symbols/nuget/v3/index.json";

        private const string FeedDotNetToolsInternalShipping = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools-internal/nuget/v3/index.json";
        private const string FeedDotNetToolsInternalTransport = FeedDotNetToolsInternalShipping;
        private const string FeedDotNetToolsInternalSymbols = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools-internal-symbols/nuget/v3/index.json";

        private const string FeedDotNet31Shipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1/nuget/v3/index.json";
        private const string FeedDotNet31Transport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-transport/nuget/v3/index.json";
        private const string FeedDotNet31Symbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-symbols/nuget/v3/index.json";

        private const string FeedDotNet31InternalShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal/nuget/v3/index.json";
        private const string FeedDotNet31InternalTransport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal-transport/nuget/v3/index.json";
        private const string FeedDotNet31InternalSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal-symbols/nuget/v3/index.json";

        private const string FeedDotNet5Shipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json";
        private const string FeedDotNet5Transport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5-transport/nuget/v3/index.json";
        private const string FeedDotNet5Symbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5-symbols/nuget/v3/index.json";

        public static readonly List<TargetChannelConfig> ChannelInfos = new List<TargetChannelConfig>() {
            new TargetChannelConfig(
                131,
                PublishingInfraVersion.All,
                ".NET 5 Dev",
                "net5/dev",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                739,
                PublishingInfraVersion.All,
                ".NET 5 Preview 3",
                "net5/preview3",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                856,
                PublishingInfraVersion.All,
                ".NET 5 Preview 4",
                "net5/preview4",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                857,
                PublishingInfraVersion.All,
                ".NET 5 Preview 5",
                "net5/preview5",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                2,
                PublishingInfraVersion.All,
                ".NET Eng - Latest",
                "eng/daily",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                9,
                PublishingInfraVersion.All,
                ".NET Eng - Validation",
                "eng/validation",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                529,
                PublishingInfraVersion.All,
                "General Testing",
                "generaltesting",
                FeedGeneralTesting,
                FeedGeneralTesting,
                FeedGeneralTestingSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                548,
                PublishingInfraVersion.All,
                ".NET Core Tooling Dev",
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                549,
                PublishingInfraVersion.All,
                ".NET Core Tooling Release",
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                551,
                PublishingInfraVersion.All,
                ".NET Internal Tooling",
                akaMSChannelName: string.Empty,
                FeedDotNetToolsInternalShipping,
                FeedDotNetToolsInternalTransport,
                FeedDotNetToolsInternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers),

            new TargetChannelConfig(
                562,
                PublishingInfraVersion.All,
                ".NET Core Experimental",
                akaMSChannelName: string.Empty,
                FeedDotNetExperimental,
                FeedDotNetExperimental,
                FeedDotNetExperimentalSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                678,
                PublishingInfraVersion.All,
                ".NET Eng Services - Int",
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                679,
                PublishingInfraVersion.All,
                ".NET Eng Services - Prod",
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                921,
                PublishingInfraVersion.All,
                ".NET Core SDK 3.1.4xx",
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                922,
                PublishingInfraVersion.All,
                ".NET Core SDK 3.1.4xx Internal",
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers),

            new TargetChannelConfig(
                759,
                PublishingInfraVersion.All,
                ".NET Core SDK 3.1.3xx",
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers),

            new TargetChannelConfig(
                760,
                PublishingInfraVersion.All,
                ".NET Core SDK 3.1.3xx Internal",
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers),
        };
        #endregion
    }
}
