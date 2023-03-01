using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private GameObject paintMask;
    [SerializeField] GameObject maskParticles;
    [SerializeField] GameObject tintParticles;
    [SerializeField] Transform posToSpawnParticles;
    private MeshRenderer _rendererChaser;
    private Cinemachine.CinemachineImpulseSource _cameraShake;
    
    void Start()
    {
        _rendererChaser = GetComponentInChildren<MeshRenderer>();
        _cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }
}
