using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFeetOrientation : MonoBehaviour
{
    public Animator animator;
    public float rayLenght, hitPointOffset;
    Vector3 leftFoot, rightFoot;
    Ray ray;
    RaycastHit hitInfo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnAnimatorIK()
    {
        leftFoot = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        rightFoot = animator.GetIKPosition(AvatarIKGoal.RightFoot);

        SetFootIfOnGround(leftFoot, AvatarIKGoal.LeftFoot);
        SetFootIfOnGround(rightFoot, AvatarIKGoal.RightFoot);
    }

    void SetFootIfOnGround(Vector3 foot, AvatarIKGoal goal)
    {
        ray = new Ray(foot, Vector3.down);
        if (Physics.Raycast(ray, out hitInfo, rayLenght))
        {
            animator.SetIKPosition(goal, hitInfo.point + hitInfo.normal * hitPointOffset);
            animator.SetIKRotation(goal, Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation);
            animator.SetIKPositionWeight(goal, 1);
            animator.SetIKRotationWeight(goal, 1);
        }
        else
        {
            animator.SetIKPositionWeight(goal, 0);
            animator.SetIKRotationWeight(goal, 0);
        }

        Debug.DrawRay(ray.origin, ray.direction * rayLenght, Color.red);
    }
}
