﻿using System.Linq;

using AzureBlobs.Models;
using AzureBlobsCore.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTests.TestHelpers;

namespace AzureBlobs.Shared.Tests
{
    [TestClass()]
    public class SerializerTests
    {
        // sample serialized output
        // resultJson = "{\"Id\":\"HS-2019.07.29.06.51.28.568649\",\"LeftCornerPosition\":{\"X\":110,\"Y\":201,\"Z\":117},\"Tracks\":[{\"Id\":\"T01\"},{\"Id\":\"T04\"}]}"
        [TestMethod()]
        public void SerializeAndDeserializeObject_WhenObjectHasDataContractAttributes_ShouldGetTheObjectBack()
        {
            TrackContainer trackContainer = GetMock.TrackContainer();
            var resultJson = Serializer.WriteFromObject(typeof(TrackContainer), trackContainer);

            Assert.IsNotNull(resultJson);

            var deserializedTrackContainer = Serializer.ReadToTrackObject<TrackContainer>(resultJson);

            Assert.IsNotNull(deserializedTrackContainer);
            Assert.AreEqual(trackContainer.Id, deserializedTrackContainer.Id);
            Assert.AreEqual(trackContainer.LeftCornerPosition.X, deserializedTrackContainer.LeftCornerPosition.X);
            Assert.AreEqual(trackContainer.LeftCornerPosition.Y, deserializedTrackContainer.LeftCornerPosition.Y);
            Assert.AreEqual(trackContainer.LeftCornerPosition.Z, deserializedTrackContainer.LeftCornerPosition.Z);
            Assert.AreEqual(trackContainer.Tracks.ElementAt(0).Id, deserializedTrackContainer.Tracks.ElementAt(0).Id);
            Assert.AreEqual(trackContainer.Tracks.ElementAt(1).Id, deserializedTrackContainer.Tracks.ElementAt(1).Id);
        }
    }
}