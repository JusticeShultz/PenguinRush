using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHandler : MonoBehaviour
{
    public float SpawnY = 0f;
    public GameObject Whale;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    bool _p1 = false;
    bool _p2 = false;
    bool _p3 = false;
    bool _p4 = false;

	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == p1 && !_p1)
        {
            Instantiate(Whale, new Vector3(other.transform.position.x, SpawnY, other.transform.position.z), Quaternion.Euler(0, Random.Range(-180, 180), 0));
            _p1 = true;
            Destroy(other.gameObject, 0.5f);
        }

        if (other.gameObject == p2 && !_p2)
        {
            Instantiate(Whale, new Vector3(other.transform.position.x, SpawnY, other.transform.position.z), Quaternion.Euler(0, Random.Range(-180, 180), 0));
            _p2 = true;
            Destroy(other.gameObject, 0.5f);
        }

        if (other.gameObject == p3 && !_p3)
        {
            Instantiate(Whale, new Vector3(other.transform.position.x, SpawnY, other.transform.position.z), Quaternion.Euler(0, Random.Range(-180, 180), 0));
            _p3 = true;
            Destroy(other.gameObject, 0.5f);
        }

        if (other.gameObject == p4 && !_p4)
        {
            Instantiate(Whale, new Vector3(other.transform.position.x, SpawnY, other.transform.position.z), Quaternion.Euler(0, Random.Range(-180, 180), 0));
            _p4 = true;
            Destroy(other.gameObject, 0.5f);
        }
    }
}
