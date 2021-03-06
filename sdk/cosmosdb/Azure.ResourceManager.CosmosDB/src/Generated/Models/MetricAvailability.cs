// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> The availability of the metric. </summary>
    public partial class MetricAvailability
    {
        /// <summary> Initializes a new instance of MetricAvailability. </summary>
        internal MetricAvailability()
        {
        }

        /// <summary> Initializes a new instance of MetricAvailability. </summary>
        /// <param name="timeGrain"> The time grain to be used to summarize the metric values. </param>
        /// <param name="retention"> The retention for the metric values. </param>
        internal MetricAvailability(string timeGrain, string retention)
        {
            TimeGrain = timeGrain;
            Retention = retention;
        }

        /// <summary> The time grain to be used to summarize the metric values. </summary>
        public string TimeGrain { get; }
        /// <summary> The retention for the metric values. </summary>
        public string Retention { get; }
    }
}
