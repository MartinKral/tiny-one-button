﻿using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class IcosphereSpawnerAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject IcospherePrefab;
    public GameObject spike;
    public float delay;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity prefabEntity = conversionSystem.GetPrimaryEntity(IcospherePrefab);

        dstManager.AddComponentData(prefabEntity, new SpikeReference { Entity = conversionSystem.GetPrimaryEntity(spike) });
        dstManager.AddComponentData(entity, new SphereSpawner()
        {
            Prefab = prefabEntity,
            Delay = delay,
            SecondsUntilSpawn = 0
        });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(IcospherePrefab);
    }
}