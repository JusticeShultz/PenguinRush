using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WallDropEvent : MonoBehaviour
{
    public float DropTime = 10;
    public Text countdownText;
    public UnityEvent OnDrop = new UnityEvent();

	void Update ()
    {
        if (!Rewired.Demos.PressAnyButtonToJoinExample_Assigner.GameStarted) return;

        if(DropTime <= 0)
        {
            OnDrop.Invoke();
            Destroy(countdownText.gameObject);
            Destroy(this);
        }
        else
        {
            DropTime -= Time.deltaTime;
            countdownText.text = "Walls Fall In " + Mathf.CeilToInt(DropTime);
        }
	}
}