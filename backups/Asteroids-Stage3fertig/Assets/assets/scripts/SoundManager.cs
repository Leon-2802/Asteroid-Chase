
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip seismicCharge;
    public static SoundManager sManagerInstance; //gibt immer nur eine einzige Instanz, daher die Abfrage in Awake
    private void Awake() 
    {
        if(sManagerInstance != null && sManagerInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sManagerInstance = this;
        DontDestroyOnLoad(this);
    }
}
