using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound _instance;
    public static Sound instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<Sound>();
            }
            return _instance;
        }
    }

    public AudioSource pCamera;
    public AudioSource p;
    public AudioSource doggi;

    //pCamera
    public AudioClip BGM;
    public AudioClip fail;
    public AudioClip success;


    //p
    public AudioClip jump;
    public AudioClip getRope;
    public AudioClip getBone;
    public AudioClip btn;


    public AudioClip bark;
    //doggi
    public AudioClip throwItem;

    private void Start()
    {
        Bmusic();
    }
    //pCamera method
    public void Bmusic()
    {
        pCamera.PlayOneShot(BGM);
    }
    public void GameOver()
    {
        pCamera.PlayOneShot(fail);
    }
    public void GameEnd()
    {
        p.PlayOneShot(success);
    }
    

    //p method
    public void Jump()
    {
        p.PlayOneShot(jump);
    }

    public void GetRope()
    {
        p.PlayOneShot(getRope);
    }

    public void GetBone()
    {
        p.PlayOneShot(getBone);
    }

    public void DoggiBark()
    {
        p.PlayOneShot(bark);
    }
    public void UIBtn()
    {
        p.PlayOneShot(btn);
    }

    //doggi method
    public void DoggiThrow()
    {
        doggi.PlayOneShot(throwItem);
    }
}
