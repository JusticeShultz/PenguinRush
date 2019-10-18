using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLogic : MonoBehaviour
{
    public float MapXStart;
    public float MapYStart;
    public float MapXSize;
    public float MapYSize;
    public float MinTimeBeforeDrop;
    public float MaxTimeBeforeDrop;

    public GameObject TilePrefab;
    public List<TileDropSequence> Tiles;

    private float PickedTime = 0f;
    private float CurrentTime = 0f;

	void Start ()
    {
        PickedTime = Random.Range(MinTimeBeforeDrop, MaxTimeBeforeDrop);

        //for (int x = 0; x < MapXSize; x++)
        //    for (int y = 0; y < MapYSize; y++)
        //        Tiles.Add(Instantiate(TilePrefab, new Vector3(MapXStart + (x * 2), 0, MapYStart + (y * 2)), 
        //                                              Quaternion.identity).GetComponent<TileDropSequence>());
    }
	
	void Update ()
    {
        if (!Rewired.Demos.PressAnyButtonToJoinExample_Assigner.GameStarted && !WinState.GameWon) return;

        if (Tiles.Count <= 0) return;

        CurrentTime += Time.deltaTime;

        if (CurrentTime >= PickedTime)
        {
            PickedTime = Random.Range(MinTimeBeforeDrop, MaxTimeBeforeDrop);
            CurrentTime = 0f;

            int index = Random.Range(0, Tiles.Count);
            Tiles[index].Drop();
            Tiles.Remove(Tiles[index]);
        }
    }
}