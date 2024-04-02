using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using TMPro;
using Unity.VisualScripting;

public class OxygenBar : MonoBehaviour
{
    public GameObject oxygen;
    public int timer;
    public Animator anim;
    public GameObject loseText;
    public GameObject panel;
    public GameObject wintxt;

    public AudioSource audioSource;
    public AudioClip loseSound;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(oxygen, 1, timer).setOnComplete(Lose);
    }

    public void Lose()
    {
        panel.SetActive(true);
        anim.SetBool("Dark", true);
        loseText.SetActive(true);
        Destroy(wintxt);
        audioSource.Play(); 
    }
}
