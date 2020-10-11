using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Same as animationOnTriggers.cs, but with Keys
public class animationOnKey : MonoBehaviour
{
    public Animator animator;
    public string paramName;
    public bool setBool, invertBool, setBoolOnlyWhenPressed, setBoolLol;
    public bool newBoolVal;
    public bool setInt;
    public int newIntVal;
    public bool setFloat;
    public float newFloatVal;
    public bool setTrigger;

    public KeyCode triggerKey;


    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

    }
    void Update()
    {
        if (Input.GetKey(triggerKey))
        {
            if (invertBool)
                animator.SetBool(paramName, !animator.GetBool(paramName));
            else if (setBool)
                animator.SetBool(paramName, newBoolVal);
            else if (setInt)
                animator.SetInteger(paramName, newIntVal);
            else if (setFloat)
                animator.SetFloat(paramName, newFloatVal);
            else if (setTrigger)
                animator.SetTrigger(paramName);
        }


        if (setBoolOnlyWhenPressed)
        {
            if (Input.GetKey(triggerKey))
                animator.SetBool(paramName, newBoolVal);
            else
                animator.SetBool(paramName, !newBoolVal);
        }

        if(setBoolLol){
            if (Input.GetKeyDown(triggerKey))
                animator.SetBool(paramName, newBoolVal);
            else
                animator.SetBool(paramName, !newBoolVal);
        }

    }

}