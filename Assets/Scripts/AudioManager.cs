using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{
    public GameManager gm;
    public Score guiManager;
    private AudioSource audio;

    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioClip jump;
    public AudioClip enemyDie;
    public AudioClip collect;
    public AudioClip superCollect;

    private static AudioManager instance = null;
    public static AudioManager Instance { get { return instance; } }
	// Use this for initialization
	void Awake () 
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        audio = GetComponent<AudioSource>();
	}
}
