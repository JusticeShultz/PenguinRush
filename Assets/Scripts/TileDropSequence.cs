using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDropSequence : MonoBehaviour
{
    public float WaitToDropTime = 3.0f;
    public GameObject DeathParticle;
    public Rigidbody RB;
    public Animator shaker;

    private bool DoOnce = false;

    public void Drop()
    {
        if (!DoOnce)
        {
            DoOnce = true;

            //Animation logic here. 
            shaker.SetTrigger("Crack");
            Invoke("DoDrop", WaitToDropTime);
        }
    }

    void DoDrop()
    {
        Instantiate(DeathParticle, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
        RB.isKinematic = false;
    }

    //private void OnDrawGizmos()
    //{
    //    shaker = GetComponent<Animator>();
    //}
}
