using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip candySound, playerDeath;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        candySound = Resources.Load<AudioClip>("candySound");
        playerDeath = Resources.Load<AudioClip>("deathSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "candySound":
                audioSrc.PlayOneShot(candySound);
                break;
            case "deathSound":
                audioSrc.PlayOneShot(playerDeath);
                break;
        }
    }
}
