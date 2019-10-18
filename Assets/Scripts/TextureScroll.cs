using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public Vector2 ScrollDirection;
    public MeshRenderer MaterialInstanceToScroll;

    private Vector2 currentOffset;

	void Update ()
    {
        if (!MaterialInstanceToScroll) return;

        currentOffset += (Time.deltaTime * ScrollDirection);
        MaterialInstanceToScroll.material.SetTextureOffset("_MainTex", currentOffset);
    }
}
