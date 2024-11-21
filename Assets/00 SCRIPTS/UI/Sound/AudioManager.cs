using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }

    public AudioSource audioSource;
    public AudioSource vfxSource;

    public AudioClip musicClip;
    public AudioClip jumpClip;
    public AudioClip slashClip;
    public AudioClip knifeClip;
    public AudioClip dieClip;
    public AudioClip enemyDieClip;
    public AudioClip knife2Clip;
    public AudioClip monsterDieClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource.clip = musicClip;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        vfxSource.clip = sfxClip;
        vfxSource.PlayOneShot(sfxClip);
    }
}
