using System.Runtime.Loader;
using AltV.Net.CApi;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;

namespace AltV.Net.Client.Async
{
    public abstract class AsyncResource : Resource
    {
        private readonly AltVAsync altVAsync;

        public AsyncResource() : this(new DefaultTickSchedulerFactory())
        {
        }

        public AsyncResource(ITickSchedulerFactory tickSchedulerFactory)
        {
            altVAsync = new AltVAsync(tickSchedulerFactory);
        }

        public override void OnTick()
        {
            altVAsync.TickDelegate();
        }

        //
        // public override IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool,
        //     IEntityPool<IVehicle> vehiclePool)
        // {
        //     return new AsyncBaseBaseObjectPool(playerPool, vehiclePool);
        // }
        //
        // public override IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        // {
        //     return new AsyncPlayerPool(playerFactory);
        // }
        //
        // public override IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        // {
        //     return new AsyncVehiclePool(vehicleFactory);
        // }
        //
        // public override IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory)
        // {
        //     return new AsyncBlipPool(blipFactory);
        // }
        //
        // public override IBaseObjectPool<ICheckpoint> GetCheckpointPool(
        //     IBaseObjectFactory<ICheckpoint> checkpointFactory)
        // {
        //     return new AsyncCheckpointPool(checkpointFactory);
        // }
        //
        // public override IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(
        //     IBaseObjectFactory<IVoiceChannel> voiceChannelFactory)
        // {
        //     return new AsyncVoiceChannelPool(voiceChannelFactory);
        // }
        //
        // public override IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory)
        // {
        //     return new AsyncColShapePool(colShapeFactory);
        // }
        //
    }
}