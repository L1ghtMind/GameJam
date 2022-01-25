using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
  [SerializeField] private float Speed = 8f;
  private float Vertical;
  private bool IsLadder;
  private bool IsClimbing;

  [SerializeField] private Rigidbody2D PlayerRB;

  private void Update()
  {
    Vertical = Input.GetAxis("Vertical");
    if (IsLadder && Mathf.Abs(Vertical) > 0f)
    {
      IsClimbing = true;
    }
  }

  private void FixedUpdate()
  {
    if (IsClimbing)
    {
      PlayerRB.gravityScale = 0f;
      PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, Vertical * Speed);
    }
    else
    {
      PlayerRB.gravityScale = 4f;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ladder"))
    {
      IsLadder = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Ladder"))
    {
      IsLadder = false;
      IsClimbing = false;
    }
  }
}
