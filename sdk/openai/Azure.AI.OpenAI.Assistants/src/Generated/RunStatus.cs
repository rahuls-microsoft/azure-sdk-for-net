// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI.Assistants
{
    /// <summary> Possible values for the status of an assistant thread run. </summary>
    public readonly partial struct RunStatus : IEquatable<RunStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string QueuedValue = "queued";
        private const string InProgressValue = "in_progress";
        private const string RequiresActionValue = "requires_action";
        private const string CancellingValue = "cancelling";
        private const string CancelledValue = "cancelled";
        private const string FailedValue = "failed";
        private const string CompletedValue = "completed";
        private const string ExpiredValue = "expired";

        /// <summary> Represents a run that is queued to start. </summary>
        public static RunStatus Queued { get; } = new RunStatus(QueuedValue);
        /// <summary> Represents a run that is in progress. </summary>
        public static RunStatus InProgress { get; } = new RunStatus(InProgressValue);
        /// <summary> Represents a run that needs another operation, such as tool output submission, to continue. </summary>
        public static RunStatus RequiresAction { get; } = new RunStatus(RequiresActionValue);
        /// <summary> Represents a run that is in the process of cancellation. </summary>
        public static RunStatus Cancelling { get; } = new RunStatus(CancellingValue);
        /// <summary> Represents a run that has been cancelled. </summary>
        public static RunStatus Cancelled { get; } = new RunStatus(CancelledValue);
        /// <summary> Represents a run that failed. </summary>
        public static RunStatus Failed { get; } = new RunStatus(FailedValue);
        /// <summary> Represents a run that successfully completed. </summary>
        public static RunStatus Completed { get; } = new RunStatus(CompletedValue);
        /// <summary> Represents a run that expired before it could otherwise finish. </summary>
        public static RunStatus Expired { get; } = new RunStatus(ExpiredValue);
        /// <summary> Determines if two <see cref="RunStatus"/> values are the same. </summary>
        public static bool operator ==(RunStatus left, RunStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStatus"/> values are not the same. </summary>
        public static bool operator !=(RunStatus left, RunStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStatus"/>. </summary>
        public static implicit operator RunStatus(string value) => new RunStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
