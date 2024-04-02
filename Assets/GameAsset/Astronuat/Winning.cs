using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public GameObject confite;
    public GameObject panel;
    public GameObject winText;
    public Animator anim;
    public GameObject losetxt;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            confite.SetActive(true);

            panel.SetActive(true);
            anim.SetBool("Dark", true);
            winText.SetActive(true);
            Destroy(losetxt);
                audioSource.Play();


}
    }
}
