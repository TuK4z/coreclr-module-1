﻿using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class PedPool : EntityPool<IPed>
{
    public PedPool(IEntityFactory<IPed> pedFactory) : base(pedFactory)
    {
    }

    public override uint GetId(IntPtr entityPointer)
    {
        unsafe
        {
            return Alt.CoreImpl.Library.Shared.Ped_GetID(entityPointer);
        }
    }
}