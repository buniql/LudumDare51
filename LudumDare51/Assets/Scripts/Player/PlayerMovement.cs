using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = .3f;

    private Rigidbody2D _rigidbody2D;

    public float DashSpeed = 1f;

    private float activeMovementSpeed;

    public float DashLength = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter = 0;
    private float dashCoolCounter = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        activeMovementSpeed = MovementSpeed;
    }

    void Update()
    {
        //player rotation
        if (Input.GetAxis("Horizontal") < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0) transform.rotation = Quaternion.Euler(0, 0, 0);

        //player movement
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        _rigidbody2D.MovePosition(_rigidbody2D.position + dir * activeMovementSpeed);

        //dash handling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMovementSpeed = DashSpeed;
                dashCounter = DashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMovementSpeed = MovementSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
