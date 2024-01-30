using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSoundBehaviour : StateMachineBehaviour
{

    public AudioClip[] clip;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

            animator.gameObject.GetComponent<AudioSource>().PlayOneShot(clip[0]);

    }
}
