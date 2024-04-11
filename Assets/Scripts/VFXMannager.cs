using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    [SerializeField] List<ParticleSystem> vfxList = new List<ParticleSystem>();

    public void SpawnParticle(int particleID, Transform location)
    {
        print("Spawn Partical Called");
       // if (particleID < 0 || particleID >= vfxList.Count || vfxList[particleID] == null)
        //{
           // Debug.LogError("Invalid particle ID or particle system is null.");
            //return;
       // }

       // ParticleSystem particleSystemInstance = Instantiate(vfxList[particleID], location.position, location.rotation);
        //particleSystemInstance.transform.parent = location; // Make the particle system a child of the provided transform
       // particleSystemInstance.Play();

        // Assuming the particle system has a main module and it's not null
       // Destroy(particleSystemInstance.gameObject, particleSystemInstance.main.duration);
    }
}
