using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlayerControllerAnimator2d : MonoBehaviour {
    //We don't have moveSpeed and AngleSpeed here, because turn, walk, run animations are "not in place" animations,
    //which move the character root node with their own speed
    public Animator animator;

    int hHash = Animator.StringToHash("velx");
    int vHash = Animator.StringToHash("vely");


    void FixedUpdate () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat(hHash, x, 0.1f, Time.deltaTime);
        animator.SetFloat(vHash, z, 0.11f, Time.deltaTime);

    }
}
