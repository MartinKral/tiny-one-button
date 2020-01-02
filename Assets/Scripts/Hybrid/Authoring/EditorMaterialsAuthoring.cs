﻿using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class EditorMaterialsAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public Material[] materials;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddSharedComponentData(entity, new MaterialReferences() { Materials = materials });
    }
}