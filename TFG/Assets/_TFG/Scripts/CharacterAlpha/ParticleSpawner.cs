using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
	[SerializeField] private Transform leftFootSpawn;
    [SerializeField] private Transform rightFootSpawn;
    [SerializeField] private GameObject runParticles;
//    [SerializeField] TrailRenderer[] trails;

    #region ParticleSpawning

    void SpawnLeftFootParticle()
    {
        Instantiate(runParticles, leftFootSpawn.position, Quaternion.identity);
    }

    void SpawnRightFootParticle()
    {
        Instantiate(runParticles, rightFootSpawn.position, Quaternion.identity);
    }
    #endregion
}
