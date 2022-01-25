using System;
using UnityEngine;

public class TrappConrtoller : MonoBehaviour
{
    [SerializeField] private Transform GrabDetect;
    [SerializeField] private Transform TrappHolder;
    [SerializeField] private float RayDist;
    [SerializeField] private float ThrowPower;

    private PlayerController _PlayerController;
    private int count = 0;
    
    private void Update()
    {
        
        RaycastHit2D PickUpChack =
            Physics2D.Raycast(GrabDetect.position, -Vector2.right * transform.localScale, RayDist);
        if (PickUpChack.collider != null && PickUpChack.collider.tag == "Trapp")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                count++;
            }

            if (count == 1)
            {
                Grab(PickUpChack);
            }

            if (count == 2)
            {
                Throw(PickUpChack);
                count = 0;
            }
            
        }
    }

    private void Grab(RaycastHit2D raycast)
    {
        raycast.collider.gameObject.transform.parent = TrappHolder;
        raycast.collider.gameObject.transform.position = TrappHolder.position;
        raycast.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void Throw(RaycastHit2D raycast)
    {
        raycast.collider.gameObject.transform.parent = null;
        raycast.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        raycast.collider.gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(transform.localScale.x, 1) * ThrowPower;
    }
    
}

