using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImLazy : MonoBehaviour
{
    public GameObject child;
    public GameObject child_yeeet;
    public Animator anim;

    private void OnDrawGizmos()
    {
        if (!anim)
            anim = gameObject.AddComponent<Animator>();

        if(child)
        {
            if(!child_yeeet)
            {
                child_yeeet = Instantiate(child, transform.position, transform.rotation);
                child_yeeet.transform.parent = transform;
                child_yeeet.transform.position = Vector3.zero;
                child_yeeet.transform.rotation = Quaternion.identity;
                child_yeeet.transform.localScale = Vector3.one;
                MeshFilter filter = child_yeeet.AddComponent<MeshFilter>();
                filter.sharedMesh = GetComponent<MeshFilter>().sharedMesh;
                MeshRenderer renderer_ = child_yeeet.AddComponent<MeshRenderer>();
                renderer_.sharedMaterials = GetComponent<MeshRenderer>().sharedMaterials;

            }
            else
            {
                child_yeeet.transform.localPosition = Vector3.zero;
                child_yeeet.transform.localRotation = Quaternion.identity;
                child_yeeet.transform.localScale = Vector3.one;
            }
        }
    }
}
