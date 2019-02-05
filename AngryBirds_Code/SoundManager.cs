using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour {

    public AudioSource source;
    public static SoundManager instance = null; 
	// Use this for initialization


	void Awake () {

        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySingle (AudioClip clip)
    {
        source.clip = clip;
        source.PlayOneShot(clip,3f);
    }
}