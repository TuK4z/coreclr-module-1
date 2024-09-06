using System;
using AltV.Net.Async.Events;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Function OnServer(string eventName, Action action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1>(string eventName, Action<T1> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2>(string eventName, Action<T1, T2> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1>(string eventName, Func<T1> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2>(string eventName, Func<T1, T2> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            CoreImpl.OnServer(eventName, Function.Create(CoreImpl, action));


        public static Function OnClient(string eventName, Action action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1>(string eventName, Action<T1> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2>(string eventName, Action<T1, T2> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1>(string eventName, Func<T1> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2>(string eventName, Func<T1, T2> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            CoreImpl.OnClient(eventName, Function.Create(CoreImpl, action));
    }
}