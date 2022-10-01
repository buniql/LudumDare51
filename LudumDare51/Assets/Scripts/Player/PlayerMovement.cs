using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private StatHolder _holder;
    private Rigidbody2D _rigidbody2D;

    private float _activeMovementSpeed;
    private float _dashCounter = 0;
    private float _dashCoolCounter = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _holder = GetComponent<StatHolder>();

        _activeMovementSpeed = _holder.Stat.speed;
    }

    void Update()
    {
        // Player rotation
        if (Input.GetAxis("Horizontal") < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0) transform.rotation = Quaternion.Euler(0, 0, 0);

        //player movement
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        _rigidbody2D.MovePosition(_rigidbody2D.position + dir * _activeMovementSpeed);

        //dash handling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_dashCoolCounter <= 0 && _dashCounter <= 0)
            {
                _activeMovementSpeed = _holder.Stat.dashSpeed;
                _dashCounter = _holder.Stat.dashLength;
            }
        }

        if (_dashCounter > 0)
        {
            _dashCounter -= Time.deltaTime;

            if (_dashCounter <= 0)
            {
                _activeMovementSpeed = _holder.Stat.speed;
                _dashCoolCounter = _holder.Stat.dashCooldown;
            }
        }

        if (_dashCoolCounter > 0)
        {
            _dashCoolCounter -= Time.deltaTime;
        }
    }
}
