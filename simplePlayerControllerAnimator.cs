using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlayerControllerAnimator : MonoBehaviour
{
    public Animator animator;
    public string paramNameTranslate, paramNameRotate;
    public bool sendTranslateParam, sendRotateParam;
    public bool translateRoot, rotateRoot;
    public KeyCode slowModifierKey;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public KeyCode triggerKey;

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        if (translateRoot)
            transform.Translate(0, 0, 0);
        if (rotateRoot)
            transform.Rotate(0, x * 3f, 0);

        float slowModifierVal = 0.4f;
        if (Input.GetKey(slowModifierKey))
            slowModifierVal = 0.5f;

        if (sendTranslateParam && z != 0)
            animator.SetFloat(paramNameTranslate, z * slowModifierVal);
        if (sendRotateParam && x != 0)
            animator.SetFloat(paramNameRotate, x * 2.0f);

        //Debug.Log("Horizontal " + x);
    }

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            Fire();
        }
    }

    void Fire()
    {
        var bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

        Destroy(bullet, 2.0f);
    }
}
