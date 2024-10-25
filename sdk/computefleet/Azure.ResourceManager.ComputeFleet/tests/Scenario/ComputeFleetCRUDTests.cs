// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ComputeFleet.Models;

using Microsoft.Extensions.Azure;

using NUnit.Framework;

namespace Azure.ResourceManager.ComputeFleet.Tests
{
    internal class ComputeFleetCRUDTests : ComputeFleetTestBase
    {
        public ComputeFleetCRUDTests(bool isAsync)
            : base(isAsync)
        {
        }

        // To enable record - set AZURE_TEST_MODE=Record to record the test.
        [TestCase]
        [RecordedTest]
        public async Task TestCreateComputeFleet()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            var computeFleetCollection = await GetComputeFleetCollectionAsync();
            var vnet = await CreateVirtualNetwork();
            var computeFleetName = Recording.GenerateAssetName("testFleetViaSDK-");
            var computeFleetData = GetBasicComputeFleetData(DefaultLocation, computeFleetName, GetSubnetId(vnet));

            computeFleetData.Properties.RegularPriorityProfile.Capacity = 1996;
            var locationProfileList = new List<LocationProfile>();

            /*
             ComputeFleetVmProfile(ComputeFleetVmssOSProfile osProfile, ComputeFleetVmssStorageProfile storageProfile, ComputeFleetVmssNetworkProfile networkProfile, ComputeFleetSecurityProfile securityProfile, ComputeFleetDiagnosticsProfile diagnosticsProfile, ComputeFleetVmssExtensionProfile extensionProfile, string licenseType, ComputeFleetScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, ComputeFleetApplicationProfile applicationProfile, ComputeFleetVmssHardwareProfile hardwareProfile, WritableSubResource serviceArtifactReference, ComputeFleetSecurityPostureReference securityPostureReference, DateTimeOffset? createdOn, IDictionary<string, BinaryData> serializedAdditionalRawData)
             */

            ComputeFleetVmProfile baseVmProfile =  new ComputeFleetVmProfile(computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.OSProfile,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.StorageProfile,
                  computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.NetworkProfile,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.SecurityProfile,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.DiagnosticsProfile,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.ExtensionProfile,
                "None", //LicenseType
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.ScheduledEventsProfile,
                 null, //userData
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.CapacityReservation,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.ApplicationProfile,
                 computeFleetData.Properties.ComputeProfile.BaseVirtualMachineProfile.HardwareProfile,
                 null,
                 null,
                 null,
                 null);

            var locationProfile1 = new LocationProfile()
            {
                Location = "westus",
                VirtualMachineProfileOverride = baseVmProfile
            };

            locationProfile1.VirtualMachineProfileOverride = null;

            var locationProfile2 = new LocationProfile()
            {
                Location = "westus2",
                VirtualMachineProfileOverride = baseVmProfile
            };

            locationProfile2.VirtualMachineProfileOverride = null;
            var locationProfile3 = new LocationProfile()
            {
                Location = "eastus2",
                VirtualMachineProfileOverride = baseVmProfile
            };
            locationProfile3.VirtualMachineProfileOverride = null;

            var locationProfile4 = new LocationProfile()
            {
                Location = "westus3",
                VirtualMachineProfileOverride = baseVmProfile
            };
            locationProfile4.VirtualMachineProfileOverride = null;

            locationProfileList.Add(locationProfile1);
            locationProfileList.Add(locationProfile2);
            locationProfileList.Add(locationProfile3);
            locationProfileList.Add(locationProfile4);

            var locationsProfile = new AdditionalLocationsProfile(locationProfileList);
            computeFleetData.Properties.AdditionalLocationsProfile = locationsProfile;

            computeFleetData.Properties.SpotPriorityProfile.Capacity = 10;
            computeFleetData.Properties.SpotPriorityProfile.MinCapacity = 5;

            // Create the compute fleet
            var createFleetResult = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName, computeFleetData);
            Assert.AreEqual(computeFleetName, createFleetResult.Value.Data.Name);
            Assert.AreEqual(DefaultLocation, createFleetResult.Value.Data.Location);

            stopWatch.Stop();

            // Get the compute fleet
            var getComputeFleet = await computeFleetCollection.GetAsync(computeFleetName);
            Assert.AreEqual(computeFleetName, getComputeFleet.Value.Data.Name);

            System.Diagnostics.Trace.WriteLine($"Time taken to create fleet: {stopWatch.ElapsedMilliseconds} MS for VM location: {getComputeFleet.Value.Data.Location}, state: { getComputeFleet.Value.Data.Properties.ProvisioningState}");
            // Check if Fleet exists.
            var isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.IsTrue(isExists);

            // Delete the compute fleet
            await createFleetResult.Value.DeleteAsync(WaitUntil.Completed);

            // Check if Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.IsFalse(isExists);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateMultipleComputeFleetsAndCheck()
        {
            Console.WriteLine("Stating Test TestCreateMultipleComputeFleetsAndCheck");
            var computeFleetCollection = await GetComputeFleetCollectionAsync();
            var vnet = await CreateVirtualNetwork();
            var computeFleetName = Recording.GenerateAssetName("testFleetViaSDK-");
            var computeFleetData = GetBasicComputeFleetData(DefaultLocation, computeFleetName, GetSubnetId(vnet));

            // Create the compute fleet
            var createFleetResult = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName, computeFleetData);
            Assert.AreEqual(computeFleetName, createFleetResult.Value.Data.Name);
            Assert.AreEqual(DefaultLocation, createFleetResult.Value.Data.Location);

            // Get the compute fleet
            var getComputeFleet = await computeFleetCollection.GetAsync(computeFleetName);
            Assert.AreEqual(computeFleetName, getComputeFleet.Value.Data.Name);

            // Check if Fleet exists.
            var isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.IsTrue(isExists);

            // Create 2nd Fleet
            var computeFleetName2nd = Recording.GenerateAssetName("testFleetViaSDK-", "multi");
            var computeFleetData2nd = GetBasicComputeFleetData(DefaultLocation, computeFleetName2nd, GetSubnetId(vnet));
            var createFleetResult2nd = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName2nd, computeFleetData2nd);
            Assert.AreEqual(computeFleetName2nd, createFleetResult2nd.Value.Data.Name);
            Assert.AreEqual(DefaultLocation, createFleetResult2nd.Value.Data.Location);

            // Check if 2nd Fleet exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName2nd);
            Assert.IsTrue(isExists);

            var fleet2nd = await computeFleetCollection.GetIfExistsAsync(computeFleetName2nd);
            Assert.NotNull(fleet2nd);

            // Delete the 1st compute fleet
            await createFleetResult.Value.DeleteAsync(WaitUntil.Completed);

            // Check if 1st Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.IsFalse(isExists);

            // Delete the 2nd compute fleet
            await createFleetResult2nd.Value.DeleteAsync(WaitUntil.Completed);

            // Check if 2nd Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName2nd);
            Assert.IsFalse(isExists);
        }
    }
}
