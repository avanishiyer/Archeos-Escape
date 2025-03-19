using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background1;
    public AudioClip background2;
    public AudioClip background3;
    public AudioClip menuBackground;
    public AudioClip menuClick;

    public AudioClip invSwap1;
    public AudioClip invSwap2;

    public AudioClip swordFling1;
    public AudioClip swordFling2;

    public AudioClip gunShoot1;
    public AudioClip gunShoot2;

    public AudioClip takeDamage;
    public AudioClip enemyDeath;
    public AudioClip enemyHit;

    public AudioClip playerDeath;
    public AudioClip bossDeath;

    public AudioClip finalDeath;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            musicSource.clip = menuBackground;

        else
        {
            int rand = Random.Range(1, 4);

            if (rand == 1)
                musicSource.clip = background1;
            else if (rand == 2)
                musicSource.clip = background2;
            else
                musicSource.clip = background3;
        }

        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void AdjustMusic(float volume)
    {
        musicSource.volume = volume;
    }

    public void AdjustSFX(float volume)
    {
        musicSource.volume = volume;
    }
}
