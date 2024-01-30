using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSoundBehaviour : StateMachineBehaviour
{

    public AudioClip[] clip;


    private float lastPlayTime;
    public float soundInterval = 0.2f; // Adjust this value to set the interval in seconds

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if enough time has passed since the last sound play
        if (Time.time - lastPlayTime >= soundInterval)
        {
            animator.gameObject.GetComponent<AudioSource>().PlayOneShot(clip[0]);

            // Update the last play time
            lastPlayTime = Time.time;
        }
    }
}
