using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXMannager : Singleton<VFXMannager>
{
    [SerializeField] List<ParticleSystem> vfxList = new List<ParticleSystem>();

    private void Start()
    {
        InitializeParticles();
    }

    void InitializeParticles()
    {

    }

    public void SpawnPartical(int particleID, Transform location)
    {
        ParticleSystem particleSystemInstance = Instantiate(vfxList[particleID], location.position, location.rotation);

        particleSystemInstance.Play();

        Destroy(particleSystemInstance.gameObject, particleSystemInstance.main.duration);

    }

}
