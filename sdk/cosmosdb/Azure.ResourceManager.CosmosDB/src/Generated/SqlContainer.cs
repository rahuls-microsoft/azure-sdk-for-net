// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary> A Class representing a SqlContainer along with the instance operations that can be performed on it. </summary>
    public partial class SqlContainer : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SqlContainer"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _sqlContainerSqlResourcesClientDiagnostics;
        private readonly SqlResourcesRestOperations _sqlContainerSqlResourcesRestClient;
        private readonly SqlContainerData _data;

        /// <summary> Initializes a new instance of the <see cref="SqlContainer"/> class for mocking. </summary>
        protected SqlContainer()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SqlContainer"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SqlContainer(ArmClient client, SqlContainerData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SqlContainer"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SqlContainer(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sqlContainerSqlResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CosmosDB", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string sqlContainerSqlResourcesApiVersion);
            _sqlContainerSqlResourcesRestClient = new SqlResourcesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sqlContainerSqlResourcesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SqlContainerData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets an object representing a DatabaseAccountSqlDatabaseContainerThroughputSetting along with the instance operations that can be performed on it in the SqlContainer. </summary>
        /// <returns> Returns a <see cref="DatabaseAccountSqlDatabaseContainerThroughputSetting" /> object. </returns>
        public virtual DatabaseAccountSqlDatabaseContainerThroughputSetting GetDatabaseAccountSqlDatabaseContainerThroughputSetting()
        {
            return new DatabaseAccountSqlDatabaseContainerThroughputSetting(Client, new ResourceIdentifier(Id.ToString() + "/throughputSettings/default"));
        }

        /// <summary> Gets a collection of SqlStoredProcedures in the SqlStoredProcedure. </summary>
        /// <returns> An object representing collection of SqlStoredProcedures and their operations over a SqlStoredProcedure. </returns>
        public virtual SqlStoredProcedureCollection GetSqlStoredProcedures()
        {
            return GetCachedClient(Client => new SqlStoredProcedureCollection(Client, Id));
        }

        /// <summary>
        /// Gets the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual async Task<Response<SqlStoredProcedure>> GetSqlStoredProcedureAsync(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            return await GetSqlStoredProcedures().GetAsync(storedProcedureName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the SQL storedProcedure under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/storedProcedures/{storedProcedureName}
        /// Operation Id: SqlResources_GetSqlStoredProcedure
        /// </summary>
        /// <param name="storedProcedureName"> Cosmos DB storedProcedure name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storedProcedureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storedProcedureName"/> is null. </exception>
        public virtual Response<SqlStoredProcedure> GetSqlStoredProcedure(string storedProcedureName, CancellationToken cancellationToken = default)
        {
            return GetSqlStoredProcedures().Get(storedProcedureName, cancellationToken);
        }

        /// <summary> Gets a collection of SqlUserDefinedFunctions in the SqlUserDefinedFunction. </summary>
        /// <returns> An object representing collection of SqlUserDefinedFunctions and their operations over a SqlUserDefinedFunction. </returns>
        public virtual SqlUserDefinedFunctionCollection GetSqlUserDefinedFunctions()
        {
            return GetCachedClient(Client => new SqlUserDefinedFunctionCollection(Client, Id));
        }

        /// <summary>
        /// Gets the SQL userDefinedFunction under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/userDefinedFunctions/{userDefinedFunctionName}
        /// Operation Id: SqlResources_GetSqlUserDefinedFunction
        /// </summary>
        /// <param name="userDefinedFunctionName"> Cosmos DB userDefinedFunction name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="userDefinedFunctionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="userDefinedFunctionName"/> is null. </exception>
        public virtual async Task<Response<SqlUserDefinedFunction>> GetSqlUserDefinedFunctionAsync(string userDefinedFunctionName, CancellationToken cancellationToken = default)
        {
            return await GetSqlUserDefinedFunctions().GetAsync(userDefinedFunctionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the SQL userDefinedFunction under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/userDefinedFunctions/{userDefinedFunctionName}
        /// Operation Id: SqlResources_GetSqlUserDefinedFunction
        /// </summary>
        /// <param name="userDefinedFunctionName"> Cosmos DB userDefinedFunction name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="userDefinedFunctionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="userDefinedFunctionName"/> is null. </exception>
        public virtual Response<SqlUserDefinedFunction> GetSqlUserDefinedFunction(string userDefinedFunctionName, CancellationToken cancellationToken = default)
        {
            return GetSqlUserDefinedFunctions().Get(userDefinedFunctionName, cancellationToken);
        }

        /// <summary> Gets a collection of SqlTriggers in the SqlTrigger. </summary>
        /// <returns> An object representing collection of SqlTriggers and their operations over a SqlTrigger. </returns>
        public virtual SqlTriggerCollection GetSqlTriggers()
        {
            return GetCachedClient(Client => new SqlTriggerCollection(Client, Id));
        }

        /// <summary>
        /// Gets the SQL trigger under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/triggers/{triggerName}
        /// Operation Id: SqlResources_GetSqlTrigger
        /// </summary>
        /// <param name="triggerName"> Cosmos DB trigger name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="triggerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="triggerName"/> is null. </exception>
        public virtual async Task<Response<SqlTrigger>> GetSqlTriggerAsync(string triggerName, CancellationToken cancellationToken = default)
        {
            return await GetSqlTriggers().GetAsync(triggerName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the SQL trigger under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/triggers/{triggerName}
        /// Operation Id: SqlResources_GetSqlTrigger
        /// </summary>
        /// <param name="triggerName"> Cosmos DB trigger name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="triggerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="triggerName"/> is null. </exception>
        public virtual Response<SqlTrigger> GetSqlTrigger(string triggerName, CancellationToken cancellationToken = default)
        {
            return GetSqlTriggers().Get(triggerName, cancellationToken);
        }

        /// <summary>
        /// Gets the SQL container under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SqlContainer>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.Get");
            scope.Start();
            try
            {
                var response = await _sqlContainerSqlResourcesRestClient.GetSqlContainerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the SQL container under an existing Azure Cosmos DB database account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SqlContainer> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.Get");
            scope.Start();
            try
            {
                var response = _sqlContainerSqlResourcesRestClient.GetSqlContainer(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlContainer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing Azure Cosmos DB SQL container.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_DeleteSqlContainer
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.Delete");
            scope.Start();
            try
            {
                var response = await _sqlContainerSqlResourcesRestClient.DeleteSqlContainerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new CosmosDBArmOperation(_sqlContainerSqlResourcesClientDiagnostics, Pipeline, _sqlContainerSqlResourcesRestClient.CreateDeleteSqlContainerRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing Azure Cosmos DB SQL container.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_DeleteSqlContainer
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.Delete");
            scope.Start();
            try
            {
                var response = _sqlContainerSqlResourcesRestClient.DeleteSqlContainer(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new CosmosDBArmOperation(_sqlContainerSqlResourcesClientDiagnostics, Pipeline, _sqlContainerSqlResourcesRestClient.CreateDeleteSqlContainerRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves continuous backup information for a container resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/retrieveContinuousBackupInformation
        /// Operation Id: SqlResources_RetrieveContinuousBackupInformation
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The name of the continuous backup restore location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public virtual async Task<ArmOperation<BackupInformation>> RetrieveContinuousBackupInformationAsync(WaitUntil waitUntil, ContinuousBackupRestoreLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(location, nameof(location));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.RetrieveContinuousBackupInformation");
            scope.Start();
            try
            {
                var response = await _sqlContainerSqlResourcesRestClient.RetrieveContinuousBackupInformationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, location, cancellationToken).ConfigureAwait(false);
                var operation = new CosmosDBArmOperation<BackupInformation>(new BackupInformationOperationSource(), _sqlContainerSqlResourcesClientDiagnostics, Pipeline, _sqlContainerSqlResourcesRestClient.CreateRetrieveContinuousBackupInformationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, location).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves continuous backup information for a container resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}/retrieveContinuousBackupInformation
        /// Operation Id: SqlResources_RetrieveContinuousBackupInformation
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The name of the continuous backup restore location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public virtual ArmOperation<BackupInformation> RetrieveContinuousBackupInformation(WaitUntil waitUntil, ContinuousBackupRestoreLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(location, nameof(location));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.RetrieveContinuousBackupInformation");
            scope.Start();
            try
            {
                var response = _sqlContainerSqlResourcesRestClient.RetrieveContinuousBackupInformation(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, location, cancellationToken);
                var operation = new CosmosDBArmOperation<BackupInformation>(new BackupInformationOperationSource(), _sqlContainerSqlResourcesClientDiagnostics, Pipeline, _sqlContainerSqlResourcesRestClient.CreateRetrieveContinuousBackupInformationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, location).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<SqlContainer>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _sqlContainerSqlResourcesRestClient.GetSqlContainerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<SqlContainer> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _sqlContainerSqlResourcesRestClient.GetSqlContainer(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<SqlContainer>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _sqlContainerSqlResourcesRestClient.GetSqlContainerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<SqlContainer> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _sqlContainerSqlResourcesRestClient.GetSqlContainer(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<SqlContainer>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _sqlContainerSqlResourcesRestClient.GetSqlContainerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlDatabases/{databaseName}/containers/{containerName}
        /// Operation Id: SqlResources_GetSqlContainer
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<SqlContainer> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _sqlContainerSqlResourcesClientDiagnostics.CreateScope("SqlContainer.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _sqlContainerSqlResourcesRestClient.GetSqlContainer(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new SqlContainer(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
