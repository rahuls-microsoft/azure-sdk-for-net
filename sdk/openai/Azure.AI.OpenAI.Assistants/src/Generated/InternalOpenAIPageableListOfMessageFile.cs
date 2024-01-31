// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants
{
    /// <summary> The response data for a requested list of items. </summary>
    internal partial class InternalOpenAIPageableListOfMessageFile
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="InternalOpenAIPageableListOfMessageFile"/>. </summary>
        /// <param name="data"> The requested list of items. </param>
        /// <param name="firstId"> The first ID represented in this list. </param>
        /// <param name="lastId"> The last ID represented in this list. </param>
        /// <param name="hasMore"> A value indicating whether there are additional values available not captured in this list. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/>, <paramref name="firstId"/> or <paramref name="lastId"/> is null. </exception>
        internal InternalOpenAIPageableListOfMessageFile(IEnumerable<MessageFile> data, string firstId, string lastId, bool hasMore)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(firstId, nameof(firstId));
            Argument.AssertNotNull(lastId, nameof(lastId));

            Data = data.ToList();
            FirstId = firstId;
            LastId = lastId;
            HasMore = hasMore;
        }

        /// <summary> Initializes a new instance of <see cref="InternalOpenAIPageableListOfMessageFile"/>. </summary>
        /// <param name="object"> The object type, which is always list. </param>
        /// <param name="data"> The requested list of items. </param>
        /// <param name="firstId"> The first ID represented in this list. </param>
        /// <param name="lastId"> The last ID represented in this list. </param>
        /// <param name="hasMore"> A value indicating whether there are additional values available not captured in this list. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalOpenAIPageableListOfMessageFile(OpenAIPageableListOfMessageFileObject @object, IReadOnlyList<MessageFile> data, string firstId, string lastId, bool hasMore, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Data = data;
            FirstId = firstId;
            LastId = lastId;
            HasMore = hasMore;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalOpenAIPageableListOfMessageFile"/> for deserialization. </summary>
        internal InternalOpenAIPageableListOfMessageFile()
        {
        }

        /// <summary> The object type, which is always list. </summary>
        public OpenAIPageableListOfMessageFileObject Object { get; } = OpenAIPageableListOfMessageFileObject.List;

        /// <summary> The requested list of items. </summary>
        public IReadOnlyList<MessageFile> Data { get; }
        /// <summary> The first ID represented in this list. </summary>
        public string FirstId { get; }
        /// <summary> The last ID represented in this list. </summary>
        public string LastId { get; }
        /// <summary> A value indicating whether there are additional values available not captured in this list. </summary>
        public bool HasMore { get; }
    }
}
