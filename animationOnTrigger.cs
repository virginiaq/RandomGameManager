using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Same as animationOnKey.cs, but with Triggers
public class animationOnTrigger : MonoBehaviour {
    public Animator    animator;
    public string   paramName;
    public bool     setBool, invertBool, setBoolOnlyWhenInsideTrigger;
    public bool     newBoolVal;
    public bool     setInt;
    public int      newIntVal;
    public bool     setFloat;
    public float    newFloatVal;
    public bool     setTrigger;

	void OnTriggerEnter () {
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

	void OnTriggerStay () {
		if (setBoolOnlyWhenInsideTrigger)
		{
			animator.SetBool(paramName, newBoolVal);
		}
	}

	void OnTriggerExit () {
		if (setBoolOnlyWhenInsideTrigger)
			animator.SetBool(paramName, !newBoolVal);
	}
}
