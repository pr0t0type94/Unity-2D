using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Use this for initialization

    bool playSound;
    public AudioSource source;
    public static SoundManager instance = null;

    public void PlaySingle(AudioClip clip)
    {
        source.clip = clip;
        source.PlayOneShot(clip);
    }

    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playSound)
        {

        }
	}
}
