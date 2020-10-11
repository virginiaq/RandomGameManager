using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKCtrl : MonoBehaviour {
	public Animator anim;
	public float posWeight, rotWeight;
	public Transform targetObjT;
	public AvatarIKGoal IKGoal;

	//Callback for setting up animation IK (inverse kinematics).
	//is called by the Animator Component immediately before it updates its internal IK system.
	//This callback can be used to set the positions of the IK goals and their respective weights.
	void OnAnimatorIK(){
		anim.SetIKPositionWeight (IKGoal, posWeight);
		anim.SetIKPosition (IKGoal, targetObjT.position);
		anim.SetIKRotationWeight (IKGoal, rotWeight);
		anim.SetIKRotation(IKGoal, targetObjT.rotation);
	}
}
