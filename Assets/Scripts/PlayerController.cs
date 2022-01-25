using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float WalkSpeed = 1f;
    [SerializeField] private float SpeedBooster = 1.5f;
    private float CurrentSpeed;
    
    private Rigidbody2D Rigidbody;
    private float move;
    [HideInInspector] public bool isFacingRight = true;

    private bool isSprinting = false;
    private bool isMoving = false;

    private AudioSource FootSteps;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        FootSteps = GetComponent<AudioSource>();
        CurrentSpeed = WalkSpeed;
    }

    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        isMoving = false;
        if (move > 0f)
        {
            isMoving = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
            Debug.Log(isFacingRight);
        }
        else if(move<0f)
        {
            isMoving = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
            Debug.Log(isFacingRight);
        }

        if (isMoving)
        {
            if (!FootSteps.isPlaying)
            {
                PlayFootsteps();
            }
        }
        else
        {
            StopFootsteps();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            Sprint();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            Sprint();
        }
    }

    private void FixedUpdate()
    {
        Vector2 Movement = new Vector2(move * WalkSpeed, Rigidbody.velocity.y);
        Rigidbody.velocity = Movement;
    }

    private void Sprint()
    {
        if (isSprinting)
        {
            WalkSpeed = WalkSpeed * SpeedBooster;
        }
        else
        {
            WalkSpeed = CurrentSpeed;
        }
    }

    private void PlayFootsteps()
    {
        FootSteps.Play();
    }
    
    private void StopFootsteps()
    {
        FootSteps.Stop();
    }
}
