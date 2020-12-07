using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootstepAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip[] footstepSounds;

    [SerializeField]
    AudioSource footstepSource;
    
    [Tooltip("Variance with which to pitch footsteps up/down both ways from 1")]
    [SerializeField]
    float pitchVariance = 0.5f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.tag = "Untagged";

        while(col.tag == "Untagged")
        {
            if (col.tag == "Trail")
            {
                footstepSource.clip = footstepSounds[0];
                Debug.Log("T");
                col.tag = "Untagged";
            }
            else
            {
                footstepSource.clip = footstepSounds[1];
                Debug.Log("Grass");
                col.tag = "Untagged";

            }

        }


    }


    public void PlayFootstep()
    {

        //footstepSource.clip = footstepSounds[0];
        //footstepSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
        

        footstepSource.pitch = Random.Range(1.0f - pitchVariance, 1.0f + pitchVariance);

        footstepSource.Play();
    }
    
}
