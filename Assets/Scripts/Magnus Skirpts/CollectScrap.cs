using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScrap : MonoBehaviour
{
    public AudioSource collectSound;   

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
}
