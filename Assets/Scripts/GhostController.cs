using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Vector3[] Positions;
    [SerializeField] private AudioSource GhostSound;
    [SerializeField] private float GhostSoundDelay;
    private int Index;
    private bool IsFacingRight;

    private void Start()
    {
        GhostSound = GetComponent<AudioSource>();
        StartCoroutine(PlayGhostHowl());
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Positions[Index], Time.deltaTime * MoveSpeed);

        if (transform.position == Positions[Index])
        {
            if (Index == Positions.Length - 1)
            {
                IsFacingRight = true;
                Flip();
                Index = 0;
            }
            else
            {
                Index++;
                IsFacingRight = false;
                Flip();
            }
            
        }
    }

    private void Flip()
    {
        if (IsFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //NeedToAttack = true;
        }
    }

    private void PlayGhostSound()
    {
        GhostSound.Play();
    }
    
    IEnumerator PlayGhostHowl()
    {
        while (true)
        {
            PlayGhostSound();
            yield return new WaitForSeconds(GhostSoundDelay);
        }
    }
}
