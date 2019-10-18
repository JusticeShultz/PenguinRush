using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAdjuster : MonoBehaviour
{
    public Collider MyCollider;
    public Collider TheirCollider;

    void Start ()
    {
        Physics.IgnoreCollision(MyCollider, TheirCollider);
	}

    //private void OnDrawGizmos()
    //{
    //    MyCollider = GetComponent<Collider>();
    //}
}