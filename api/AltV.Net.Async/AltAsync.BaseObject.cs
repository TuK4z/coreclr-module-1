using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        [Obsolete("Use async entities instead")]
        public static Task<bool> ExistsAsync(this IBaseObject baseObject) =>
            AltVAsync.Schedule(() => baseObject.Exists);

        [Obsolete("Use async entities instead")]
        public static Task<BaseObjectType> GetTypeAsync(this IBaseObject baseObject) =>
            AltVAsync.Schedule(() => baseObject.Type);

        [Obsolete("Use async entities instead")]
        public static async Task SetMetaDataAsync(this IBaseObject baseObject, string key, object value)
        {
            Alt.CoreImpl.CreateMValue(out var mValue, value);
            await AltVAsync.Schedule(() => baseObject.SetMetaData(key, in mValue));
            mValue.Dispose();
        }

        [Obsolete("Use async entities instead")]
        public static Task<T> GetMetaDataAsync<T>(this IBaseObject baseObject, string key) =>
            AltVAsync.Schedule(() =>
            {
                baseObject.GetMetaData<T>(key, out var value);
                return value;
            });
    }
}