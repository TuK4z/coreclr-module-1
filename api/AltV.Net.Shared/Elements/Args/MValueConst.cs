using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's received from events are MValueConst
    /// </summary>
    public readonly struct MValueConst : IDisposable
    {
        public static MValueConst Nil = new MValueConst(null, Type.Nil, IntPtr.Zero);

        public static MValueConst None = new MValueConst(null, Type.None, IntPtr.Zero);

        public enum Type : byte
        {
            None = 0,
            Nil = 1,
            Bool = 2,
            Int = 3,
            Uint = 4,
            Double = 5,
            String = 6,
            List = 7,
            Dict = 8,
            BaseObject = 9,
            Function = 10,
            Vector3 = 11,
            Rgba = 12,
            ByteArray = 13,
            Vector2 = 14,
        }

        public static MValueConst[] CreateFrom(ISharedCore core, IntPtr[] pointers)
        {
            int length = pointers.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(core, pointers[i]);
            }

            return mValues;
        }

        private readonly ISharedCore core;
        public readonly IntPtr nativePointer;
        public readonly Type type;

        public MValueConst(ISharedCore core, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
            if (nativePointer == IntPtr.Zero)
            {
                this.type = Type.Nil;
            }
            else
            {
                unsafe
                {
                    this.type = (Type) core.Library.Shared.MValueConst_GetType(nativePointer);
                }
            }
        }

        public MValueConst(ISharedCore core, Type type, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public bool GetBool()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetBool(nativePointer) == 1;
            }
        }

        public long GetInt()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetInt(nativePointer);
            }
        }

        public ulong GetUint()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetUInt(nativePointer);
            }
        }

        public double GetDouble()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetDouble(nativePointer);
            }
        }

        public string GetString()
        {
            unsafe
            {
                var size = 0;
                var value = core.Library.Shared.MValueConst_GetString(nativePointer, &size);
                return core.PtrToStringUtf8AndFree(value, size);
            }
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            unsafe
            {
                BaseObjectType pType;
                var result = core.Library.Shared.MValueConst_GetEntity(nativePointer, &pType);
                baseObjectType = pType;
                return result;
            }
        }

        public ISharedBaseObject GetBaseObject()
        {
            var baseObjectType = BaseObjectType.Undefined;
            var baseObjectPtr = GetEntityPointer(ref baseObjectType);
            return core.PoolManager.Get(baseObjectPtr, baseObjectType);
        }

        public MValueConst[] GetList()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetListSize(nativePointer);
                if (size == 0) return Array.Empty<MValueConst>();
                var mValuePointers = new IntPtr[size];
                core.Library.Shared.MValueConst_GetList(nativePointer, mValuePointers);
                return CreateFrom(core, mValuePointers);
            }
        }

        public Dictionary<string, MValueConst> GetDictionary()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetDictSize(nativePointer);
                if (size == 0) return new Dictionary<string, MValueConst>();
                var keyPointers = new IntPtr[size];
                var mValuePointers = new IntPtr[size];
                core.Library.Shared.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

                var dictionary = new Dictionary<string, MValueConst>();

                for (ulong i = 0; i < size; i++)
                {
                    var keyPointer = keyPointers[i];
                    var mValue = new MValueConst(core, mValuePointers[i]);
                    dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue;
                    core.Library.Shared.FreeCharArray(keyPointer);
                }

                return dictionary;
            }
        }

        public void CallFunction(MValueConst[] args, out MValueConst result)
        {
            unsafe
            {
                var length = (ulong) args.Length;
                var argsPointers = new IntPtr[length];
                for (ulong i = 0; i < length; i++)
                {
                    argsPointers[i] = args[i].nativePointer;
                }

                result = new MValueConst(core,
                    core.Library.Shared.MValueConst_CallFunction(core.NativePointer, nativePointer, argsPointers,
                        length));
            }
        }

        public void GetVector3(ref Position position)
        {
            unsafe
            {
                Vector3 pos;
                core.Library.Shared.MValueConst_GetVector3(nativePointer, &pos);
                position = pos;
            }
        }

        public Position GetVector3()
        {
            unsafe
            {
                var position = Vector3.Zero;
                core.Library.Shared.MValueConst_GetVector3(nativePointer, &position);
                return position;
            }
        }

        public void GetRgba(ref Rgba rgba)
        {
            unsafe
            {
                Rgba pRgba;
                core.Library.Shared.MValueConst_GetRGBA(nativePointer, &pRgba);
                rgba = pRgba;
            }
        }

        public Rgba GetRgba()
        {
            unsafe
            {
                var rgba = Rgba.Zero;
                core.Library.Shared.MValueConst_GetRGBA(nativePointer, &rgba);
                return rgba;
            }
        }

        public byte[] GetByteArray()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetByteArraySize(nativePointer);
                var sizeInt = (int) size;
                var data = Marshal.AllocHGlobal(sizeInt);
                core.Library.Shared.MValueConst_GetByteArray(nativePointer, size, data);
                var byteArray = new byte[size];
                Marshal.Copy(data, byteArray, 0, sizeInt);
                Marshal.FreeHGlobal(data);

                return byteArray;
            }
        }

        public object ToObject()
        {
            switch (type)
            {
                case Type.None:
                    return None;
                case Type.Nil:
                    return null;
                case Type.Bool:
                    return GetBool();
                case Type.Int:
                    return GetInt();
                case Type.Uint:
                    return GetUint();
                case Type.Double:
                    return GetDouble();
                case Type.String:
                    return GetString();
                case Type.List:
                    unsafe
                    {
                        var listSize = core.Library.Shared.MValueConst_GetListSize(nativePointer);
                        if (listSize == 0) return Array.Empty<MValueConst>();
                        var mValueListPointers = new IntPtr[listSize];
                        core.Library.Shared.MValueConst_GetList(nativePointer, mValueListPointers);
                        var arrayValues = new object[listSize];
                        for (ulong i = 0; i < listSize; i++)
                        {
                            var mValue = new MValueConst(core, mValueListPointers[i]);
                            arrayValues[i] = mValue.ToObject();
                            mValue.Dispose();
                        }

                        return arrayValues;
                    }

                case Type.Dict:
                    unsafe
                    {
                        var size = core.Library.Shared.MValueConst_GetDictSize(nativePointer);
                        if (size == 0) return new Dictionary<string, MValueConst>();
                        var keyPointers = new IntPtr[size];
                        var mValuePointers = new IntPtr[size];
                        if (core.Library.Shared.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers) == 0)
                            return null;

                        var dictionary = new Dictionary<string, object>();

                        for (ulong i = 0; i < size; i++)
                        {
                            var keyPointer = keyPointers[i];
                            var mValue = new MValueConst(core, mValuePointers[i]);
                            dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue.ToObject();
                            core.Library.Shared.FreeCharArray(keyPointer);
                            mValue.Dispose();
                        }

                        return dictionary;
                    }

                case Type.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    // TODO get or create
                    return core.PoolManager.Get(entityPointer, entityType);

                case Type.Function:
                    return null;
                case Type.Vector3:
                    var position = Position.Zero;
                    GetVector3(ref position);
                    return position;
                case Type.Rgba:
                    var rgba = Rgba.Zero;
                    GetRgba(ref rgba);
                    return rgba;
                case Type.ByteArray:
                    return GetByteArray();
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            switch (type)
            {
                case Type.None:
                    return "MValueNone<>";
                case Type.Nil:
                    return "MValueNil<>";
                case Type.Bool:
                    return "MValueBool<" + GetBool().ToString() + ">";
                case Type.Int:
                    return "MValueInt<" + GetInt().ToString() + ">";
                case Type.Uint:
                    return "MValueUInt<" + GetUint().ToString() + ">";
                case Type.Double:
                    return "MValueDouble<" + GetDouble().ToString(CultureInfo.InvariantCulture) + ">";
                case Type.String:
                    return "MValueString<" + GetString() + ">";
                case Type.List:
                    return "MValueList<{" + GetList().Aggregate("", (current, value) =>
                    {
                        var result = current + value.ToString() + ",";
                        value.Dispose();
                        return result;
                    }) + "}>";
                case Type.Dict:
                    return "MValueDict<{" + GetDictionary().Aggregate("",
                               (current, value) =>
                               {
                                   var (key, mValueConst) = value;
                                   var result = current + key.ToString() + "=" + mValueConst.ToString() + ",";
                                   mValueConst.Dispose();
                                   return result;
                               }) + "}>";
                case Type.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var ptr = GetEntityPointer(ref entityType);
                    if (ptr == IntPtr.Zero) return $"MValue<entity:nilptr>";
                    var entity = core.PoolManager.Get(ptr, entityType);
                    if (entity != null)
                    {
                        return $"MValue<{entity.Type.ToString()}>";
                    }

                    return "MValue<Entity>";
                case Type.Function:
                    return "MValue<Function>";
                case Type.Vector3:
                    var position = Position.Zero;
                    GetVector3(ref position);
                    return $"MValue<Vector3<{position.X},{position.Y},{position.Z}>>";
                case Type.Rgba:
                    var rgba = Rgba.Zero;
                    GetRgba(ref rgba);
                    return $"MValue<Rgba<{rgba.R},{rgba.G},{rgba.B},{rgba.A}>>";
                case Type.ByteArray:
                    unsafe
                    {
                        return $"MValueByteArray<{core.Library.Shared.MValueConst_GetByteArraySize(nativePointer)}>";
                    }
            }

            return "MValue<>";
        }

        public void AddRef()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                core.Library.Shared.MValueConst_AddRef(nativePointer);
            }
        }

        public void RemoveRef()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                core.Library.Shared.MValueConst_RemoveRef(nativePointer);
            }
        }

        public void Dispose()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                core.Library.Shared.MValueConst_Delete(nativePointer);
            }
        }
    }
}