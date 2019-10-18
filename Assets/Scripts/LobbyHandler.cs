using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class LobbyHandler : MonoBehaviour
{
    public static Player Player1;
    public static Player Player2;
    public static Player Player3;
    public static Player Player4;
    
    void Start ()
    {
        Player1 = ReInput.players.GetPlayer(0);
        Player2 = ReInput.players.GetPlayer(1);
        Player3 = ReInput.players.GetPlayer(2);
        Player4 = ReInput.players.GetPlayer(3);
    }
	
	void Update ()
    {
        //print("Player1: " + Player1.GetAxis("Move Horizontal"));
        //print("Player1: " + Player1.GetAxis("Move Vertical"));

        //print("Player2: " + Player2.GetAxis("Move Horizontal"));
        //print("Player2: " + Player2.GetAxis("Move Vertical"));

        //print("Player3: " + Player3.GetAxis("Move Horizontal"));
        //print("Player3: " + Player3.GetAxis("Move Vertical"));

        //print("Player4: " + Player4.GetAxis("Move Horizontal"));
        //print("Player4: " + Player4.GetAxis("Move Vertical"));
    }
}
