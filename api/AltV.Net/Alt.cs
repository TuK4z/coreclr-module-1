using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Mock2")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net
{
    public static partial class Alt
    {
        internal static ICore CoreImpl;

        public static bool CacheEntities { get => AltShared.CacheEntities; set => AltShared.CacheEntities = value; }
        public static bool ThrowIfEntityDoesNotExist = false;

        public static bool IsDebug => CoreImpl.IsDebug;

        public static void Emit(string eventName, params object[] args) => CoreImpl.TriggerLocalEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            CoreImpl.TriggerClientEventForAll(eventName, args);

        public static void EmitClients(IPlayer[] clients, string eventName, params object[] args) =>
            CoreImpl.TriggerClientEventForSome(clients, eventName, args);

        public static void EmitEventUnreliableAllClients(string eventName, params object[] args) =>
            CoreImpl.TriggerClientEventUnreliableForAll(eventName, args);

        public static void EmitUnreliableClients(IPlayer[] clients, string eventName, params object[] args) =>
            CoreImpl.TriggerClientEventUnreliableForSome(clients, eventName, args);

        public static IEnumerable<string> GetRegisteredClientEvents() => CoreImpl.GetRegisteredClientEvents();
        public static IEnumerable<string> GetRegisteredServerEvents() => CoreImpl.GetRegisteredServerEvents();

        public static void Log(string message) => CoreImpl.LogInfo(message);

        public static IReadOnlyCollection<IPlayer> GetAllPlayers() => CoreImpl.PoolManager.Player.GetAllEntities();

        public static IReadOnlyCollection<IVehicle> GetAllVehicles() =>CoreImpl.PoolManager.Vehicle.GetAllEntities();

        public static IReadOnlyCollection<IPed> GetAllPeds() =>CoreImpl.PoolManager.Ped.GetAllEntities();

        public static IReadOnlyCollection<IBlip> GetAllBlips() =>CoreImpl.PoolManager.Blip.GetAllObjects();

        public static IReadOnlyCollection<IObject> GetAllNetworkObjects() =>CoreImpl.PoolManager.Object.GetAllEntities();

        public static IReadOnlyCollection<ICheckpoint> GetAllCheckpoints() =>CoreImpl.PoolManager.Checkpoint.GetAllObjects();

        public static IReadOnlyCollection<IVoiceChannel> GetAllVoiceChannels() =>CoreImpl.PoolManager.VoiceChannel.GetAllObjects();

        public static IReadOnlyCollection<IColShape> GetAllColShapes() =>CoreImpl.PoolManager.ColShape.GetAllObjects();

        public static IReadOnlyCollection<IMarker> GetAllMarkers() =>CoreImpl.PoolManager.Marker.GetAllObjects();

        public static IReadOnlyCollection<IConnectionInfo> GetAllConnectionInfos() => CoreImpl.PoolManager.ConnectionInfo.GetAllObjects();

        public static IReadOnlyCollection<IVirtualEntity> GetAllVirtualEntities() => CoreImpl.PoolManager.VirtualEntity.GetAllObjects();

        public static IReadOnlyCollection<IVirtualEntityGroup> GetAllVirtualEntityGroups() => CoreImpl.PoolManager.VirtualEntityGroup.GetAllObjects();

        public static KeyValuePair<IntPtr, IPlayer>[] GetPlayersArray() => CoreImpl.PoolManager.Player.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IVehicle>[] GetVehiclesArray() => CoreImpl.PoolManager.Vehicle.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IPed>[] GetPedsArray() => CoreImpl.PoolManager.Ped.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IBlip>[] GetBlipsArray() => CoreImpl.PoolManager.Blip.GetObjectsArray();

        public static KeyValuePair<IntPtr, ICheckpoint>[] GetCheckpointsArray() => CoreImpl.PoolManager.Checkpoint.GetObjectsArray();

        public static KeyValuePair<IntPtr, IVoiceChannel>[] GetVoiceChannelsArray() => CoreImpl.PoolManager.VoiceChannel.GetObjectsArray();

        public static KeyValuePair<IntPtr, IColShape>[] GetColShapesArray() => CoreImpl.PoolManager.ColShape.GetObjectsArray();
        public static KeyValuePair<IntPtr, IConnectionInfo>[] GetConnectionInfoArray() => CoreImpl.PoolManager.ConnectionInfo.GetObjectsArray();

        public static void ForEachPlayers(IBaseObjectCallback<IPlayer> baseObjectCallback) =>
            CoreImpl.PoolManager.Player.ForEach(baseObjectCallback);

        public static Task ForEachPlayers(IAsyncBaseObjectCallback<IPlayer> baseObjectCallback) =>
            CoreImpl.PoolManager.Player.ForEach(baseObjectCallback);

        public static void ForEachVehicles(IBaseObjectCallback<IVehicle> baseObjectCallback) =>
            CoreImpl.PoolManager.Vehicle.ForEach(baseObjectCallback);

        public static Task ForEachVehicles(IAsyncBaseObjectCallback<IVehicle> baseObjectCallback) =>
            CoreImpl.PoolManager.Vehicle.ForEach(baseObjectCallback);

        public static void ForEachPeds(IBaseObjectCallback<IPed> baseObjectCallback) =>
            CoreImpl.PoolManager.Ped.ForEach(baseObjectCallback);

        public static Task ForEachPeds(IAsyncBaseObjectCallback<IPed> baseObjectCallback) =>
            CoreImpl.PoolManager.Ped.ForEach(baseObjectCallback);

        public static void ForEachBlips(IBaseObjectCallback<IBlip> baseObjectCallback) =>
            CoreImpl.PoolManager.Blip.ForEach(baseObjectCallback);

        public static Task ForEachBlips(IAsyncBaseObjectCallback<IBlip> baseObjectCallback) =>
            CoreImpl.PoolManager.Blip.ForEach(baseObjectCallback);

        public static void ForEachCheckpoints(IBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            CoreImpl.PoolManager.Checkpoint.ForEach(baseObjectCallback);

        public static Task ForEachCheckpoints(IAsyncBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            CoreImpl.PoolManager.Checkpoint.ForEach(baseObjectCallback);

        public static void ForEachVoiceChannels(IBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            CoreImpl.PoolManager.VoiceChannel.ForEach(baseObjectCallback);

        public static Task ForEachVoiceChannels(IAsyncBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            CoreImpl.PoolManager.VoiceChannel.ForEach(baseObjectCallback);

        public static void ForEachColShapes(IBaseObjectCallback<IColShape> baseObjectCallback) =>
            CoreImpl.PoolManager.ColShape.ForEach(baseObjectCallback);

        public static Task ForEachColShapes(IAsyncBaseObjectCallback<IColShape> baseObjectCallback) =>
            CoreImpl.PoolManager.ColShape.ForEach(baseObjectCallback);

        public static VehicleModelInfo GetVehicleModelInfo(uint hash) => CoreImpl.GetVehicleModelInfo(hash);
        public static VehicleModelInfo GetVehicleModelInfo(string name) => CoreImpl.GetVehicleModelInfo(Hash(name));
        public static PedModelInfo? GetPedModelInfo(uint hash) => CoreImpl.GetPedModelInfo(hash);
        public static PedModelInfo? GetPedModelInfo(string name) => CoreImpl.GetPedModelInfo(Hash(name));

        public static uint Hash(string stringToHash) => CoreImpl.Hash(stringToHash);
        public static ulong HashPassword(string password) => CoreImpl.HashPassword(password);

        public static bool FileExists(string path) => CoreImpl.FileExists(path);
        public static string ReadFile(string path) => CoreImpl.FileRead(path);
        public static byte[] ReadFileBinary(string path) => CoreImpl.FileReadBinary(path);

        public static IConfig GetServerConfig() => CoreImpl.GetServerConfig();
        public static IBaseObject GetBaseObjectById(BaseObjectType type, uint id) => CoreImpl.GetBaseObjectById(type, id);

        public static IMetric RegisterMetric(string name, MetricType type = MetricType.MetricTypeGauge, Dictionary<string, string> dataDict = default) => CoreImpl.RegisterMetric(name, type, dataDict);
        public static void UnregisterMetric(IMetric metric) => CoreImpl.UnregisterMetric(metric);
        public static IReadOnlyCollection<IMetric> GetAllMetrics() => CoreImpl.GetAllMetrics();
        public static VoiceConnectionState GetVoiceConnectionState() => CoreImpl.GetVoiceConnectionState();

        public static void SetWorldProfiler(bool state) => CoreImpl.SetWorldProfiler(state);

        public static IBaseObject[] GetClosestEntities(Position position, int range, int dimension, int limit, EntityType allowedTypes, Order order = Order.Default) =>
            CoreImpl.GetClosestEntities(position, range, dimension, limit, allowedTypes, order);

        public static IBaseObject[] GetEntitiesInDimension(int dimension, EntityType allowedTypes) =>  CoreImpl.GetEntitiesInDimension(dimension, allowedTypes);

        public static IBaseObject[] GetEntitiesInRange(Position position, int range, int dimension, EntityType allowedTypes) => CoreImpl.GetEntitiesInRange(position, range, dimension, allowedTypes);

        public static int NetTime => CoreImpl.NetTime;

        public static void AddClientConfigKey(string key) => CoreImpl.AddClientConfigKey(key);

        public static ushort MaxStreamingPeds
        {
            get => CoreImpl.MaxStreamingPeds;
            set => CoreImpl.MaxStreamingPeds = value;
        }

        public static ushort MaxStreamingObjects
        {
            get => CoreImpl.MaxStreamingObjects;
            set => CoreImpl.MaxStreamingObjects = value;
        }
        public static ushort MaxStreamingVehicles
        {
            get => CoreImpl.MaxStreamingVehicles;
            set => CoreImpl.MaxStreamingVehicles = value;
        }
        public static byte StreamerThreadCount
        {
            get => CoreImpl.StreamerThreadCount;
            set => CoreImpl.StreamerThreadCount = value;
        }
        public static uint StreamingTickRate
        {
            get => CoreImpl.StreamingTickRate;
            set => CoreImpl.StreamingTickRate = value;
        }
        public static uint StreamingDistance
        {
            get => CoreImpl.StreamingDistance;
            set => CoreImpl.StreamingDistance = value;
        }
        public static uint ColShapeTickRate
        {
            get => CoreImpl.ColShapeTickRate;
            set => CoreImpl.ColShapeTickRate = value;
        }
        public static uint MigrationDistance
        {
            get => CoreImpl.MigrationDistance;
            set => CoreImpl.MigrationDistance = value;
        }
        public static byte MigrationThreadCount
        {
            get => CoreImpl.MigrationThreadCount;
            set => CoreImpl.MigrationThreadCount = value;
        }
        public static uint MigrationTickRate
        {
            get => CoreImpl.MigrationTickRate;
            set => CoreImpl.MigrationTickRate = value;
        }
        public static byte SyncReceiveThreadCount
        {
            get => CoreImpl.SyncReceiveThreadCount;
            set => CoreImpl.SyncReceiveThreadCount = value;
        }
        public static byte SyncSendThreadCount
        {
            get => CoreImpl.SyncSendThreadCount;
            set => CoreImpl.SyncSendThreadCount = value;
        }

        public static bool HasBenefit(Benefit benefit) => CoreImpl.HasBenefit(benefit);

        public static void StopServer() => CoreImpl.StopServer();
        public static WeaponModelInfo? GetWeaponModelInfo(uint hash) => CoreImpl.GetWeaponModelInfo(hash);
    }
}