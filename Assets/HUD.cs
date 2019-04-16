using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image HeartUI;
    private playerMove player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
    }

    private void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}



