using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class lasergun : MonoBehaviour
{
    [SerializeField] private Animator LaserAnimator;
    [SerializeField] private AudioClip LaserSFX;
    [SerializeField] private Transform raycastorigin;

    private RaycastHit hit;
    private AudioSource LaserAudioSource;

    private void Awake()
    {

        LaserAudioSource=GetComponent<AudioSource>();
    }
    public void LaserGunFired()
    {
        LaserAnimator.SetTrigger("Fire");
        LaserAudioSource.PlayOneShot(LaserSFX);
        if(Physics.Raycast(raycastorigin.position, raycastorigin.forward, out hit, 800f))
        {
            if (hit.transform.GetComponent<AsteroidHit>() != null)
            {
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
            }
            else if (hit.transform.GetComponent<IRaycastInterface>() != null)
            {
                hit.transform.GetComponent<IRaycastInterface>().HitByRaycast();
            }
            
        }
    }
}
