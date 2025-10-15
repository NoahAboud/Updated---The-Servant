using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headbob : MonoBehaviour
{
    public Animator camAnim;
    public AudioSource walkingSound;


    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            camAnim.ResetTrigger("idle");
            camAnim.SetTrigger("walk");

            walkingSound.enabled = true;
        }
        else
        {
            camAnim.ResetTrigger("walk");
            camAnim.SetTrigger("idle");

            walkingSound.enabled = false;
        }
    }
}
