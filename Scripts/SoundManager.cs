using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerhitsound, deathsound, enemydeathsound, coinsound, jumpsound;
    static AudioSource AudSrc;
    // Start is called before the first frame update
    void Start()
    { 
        playerhitsound = Resources.Load<AudioClip>("playerhitsound");
        deathsound = Resources.Load<AudioClip>("deathsound");
        enemydeathsound = Resources.Load<AudioClip>("enemydeathsound");
        coinsound = Resources.Load<AudioClip>("coinsound");
        jumpsound = Resources.Load<AudioClip>("jumpsound");

        AudSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "playerhitsound":
                AudSrc.PlayOneShot(playerhitsound);
                break;
            case "deathsound":
                AudSrc.PlayOneShot(deathsound);
                break;
            case "enemydeathsound":
                AudSrc.PlayOneShot(enemydeathsound);
                break;
            case "coinsound":
                AudSrc.PlayOneShot(coinsound);
                break;
            case "jumpsound":
                AudSrc.PlayOneShot(jumpsound);
                break;
        }
    }
}
