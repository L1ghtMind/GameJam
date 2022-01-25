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

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        CurrentSpeed = WalkSpeed;
    }

    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (move > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
            Debug.Log(isFacingRight);
        }
        else if(move<0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
            Debug.Log(isFacingRight);
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
}
