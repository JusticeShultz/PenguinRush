using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float Lifetime = 6.0f;

	void Start ()
    {
        Destroy(gameObject, Lifetime);
	}
}
