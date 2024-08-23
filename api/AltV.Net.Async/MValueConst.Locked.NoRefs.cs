using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async;

  public static class MValueConstLockedNoRefs
    {
        public static void CreateLocked(IPlayer player, out MValueConst mValue)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.CoreImpl.CreateMValueBaseObject(out mValue, player);
            }
        }

        public static void CreateLocked(IVehicle vehicle, out MValueConst mValue)
        {
            lock (vehicle)
            {
                if (!vehicle.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.CoreImpl.CreateMValueBaseObject(out mValue, vehicle);
            }
        }

        public static void CreateLocked(IBlip blip, out MValueConst mValue)
        {
            lock (blip)
            {
                if (!blip.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.CoreImpl.CreateMValueBaseObject(out mValue, blip);
            }
        }

        public static void CreateLocked(IPed ped, out MValueConst mValue)
        {
            lock (ped)
            {
                if (!ped.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.CoreImpl.CreateMValueBaseObject(out mValue, ped);
            }
        }

        public static void CreateLocked(ICheckpoint checkpoint, out MValueConst mValue)
        {
            lock (checkpoint)
            {
                if (!checkpoint.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.CoreImpl.CreateMValueBaseObject(out mValue, checkpoint);
            }
        }

        public static void CreateFromObjectLocked(object obj, out MValueConst mValue)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;
            MValueWriter2 writer;

            switch (obj)
            {
                case IPlayer player:
                    CreateLocked(player, out mValue);
                    return;
                case IVehicle vehicle:
                    CreateLocked(vehicle, out mValue);
                    return;
                case IBlip blip:
                    CreateLocked(blip, out mValue);
                    return;
                case IPed ped:
                    CreateLocked(ped, out mValue);
                    return;
                case ICheckpoint checkpoint:
                    CreateLocked(checkpoint, out mValue);
                    return;
                case bool value:
                    Alt.CoreImpl.CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    Alt.CoreImpl.CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    Alt.CoreImpl.CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    Alt.CoreImpl.CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    Alt.CoreImpl.CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    Alt.CoreImpl.CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    Alt.CoreImpl.CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    Alt.CoreImpl.CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    Alt.CoreImpl.CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                case Invoker value:
                    Alt.CoreImpl.CreateMValueFunction(out mValue, value.NativePointer);
                    return;
                case MValueFunctionCallback value:
                    Alt.CoreImpl.CreateMValueFunction(out mValue, Alt.CoreImpl.Resource.CSharpResourceImpl.CreateInvoker(value));
                    return;
                case Function function:
                    Alt.CoreImpl.CreateMValueFunction(out mValue,
                        Alt.CoreImpl.Resource.CSharpResourceImpl.CreateInvoker(function.Call));
                    return;
                case byte[] byteArray:
                    Alt.CoreImpl.CreateMValueByteArray(out mValue, byteArray);
                    break;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateFromObjectLocked(value, out var elementMValue);
                        dictValues[i++] = elementMValue;
                    }

                    Alt.CoreImpl.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        CreateFromObjectLocked(value, out var elementMValue);
                        listValues[i++] = elementMValue;
                    }

                    Alt.CoreImpl.CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }
                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateFromObjectLocked(value, out var elementMValue);
                        dictValues[i++] = elementMValue;
                    }

                    Alt.CoreImpl.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictValues.Length; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case IWritable writable:
                    writer = Alt.CreateMValueWriter();
                    writable.OnWrite(writer);
                    writer.ToMValue(out mValue);
                    return;
                case IMValueConvertible convertible:
                    writer = Alt.CreateMValueWriter();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    writer.ToMValue(out mValue);
                    return;
                case Position position:
                    Alt.CoreImpl.CreateMValueVector3(out mValue, position);
                    return;
                case Rotation rotation:
                    Alt.CoreImpl.CreateMValueVector3(out mValue, rotation);
                    return;
                case Rgba rgba:
                    Alt.CoreImpl.CreateMValueRgba(out mValue, rgba);
                    return;
                case short value:
                    Alt.CoreImpl.CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    Alt.CoreImpl.CreateMValueUInt(out mValue, value);
                    return;
                case Vector3 position:
                    Alt.CoreImpl.CreateMValueVector3(out mValue, position);
                    return;
                default:
                    var type = obj?.GetType();
                    if (type != null && Alt.IsMValueConvertible(obj.GetType()))
                    {
                        Alt.ToMValue(obj, type, out mValue);
                        return;
                    }

                    Alt.LogInfo("can't convert type:" + type);
                    mValue = MValueConst.Nil;
                    return;
            }
        }

        internal static void CreateFromObjectsLocked(object[] objects, MValueConst[] mValues)
        {
            var length = objects.Length;
            for (var i = 0; i < length; i++)
            {
                CreateFromObjectLocked(objects[i], out var mValueElement);
                mValues[i] = mValueElement;
            }
        }
    }