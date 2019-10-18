using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public static bool GameWon = false;

    public GameObject WinScreen;
    public UnityEngine.UI.Text WinText;
    public UnityEngine.UI.RawImage Pengu;
    public RenderTexture pengu1;
    public RenderTexture pengu2;
    public RenderTexture pengu3;
    public RenderTexture pengu4;
    public RenderTexture lose;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    private void Start()
    {
        GameWon = false;
    }

    void Update ()
    {
        if (GameWon) return;

        if (p1 && !p2 && !p3 && !p4)
        {
            GameWon = true;
            WinScreen.SetActive(true);
            WinText.text = "Player 1 Wins!";
            Pengu.texture = pengu1;
        } else if (!p1 && p2 && !p3 && !p4)
        {
            GameWon = true;
            WinScreen.SetActive(true);
            WinText.text = "Player 2 Wins!";
            Pengu.texture = pengu2;
        } else if (!p1 && !p2 && p3 && !p4)
        {
            GameWon = true;
            WinScreen.SetActive(true);
            WinText.text = "Player 3 Wins!";
            Pengu.texture = pengu3;
        } else if (!p1 && !p2 && !p3 && p4)
        {
            GameWon = true;
            WinScreen.SetActive(true);
            WinText.text = "Player 4 Wins!";
            Pengu.texture = pengu4;
        } else if (!p1 && !p2 && !p3 && !p4)
        {
            GameWon = true;
            WinScreen.SetActive(true);
            WinText.text = "No one won...";
            Pengu.texture = lose;
        }
    }
}
