using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private StatHolder _holder;
    private Rigidbody2D _rigidbody2D;
    private Dash _dash;
    private Animator _playerAnimator;

    private float _activeMovementSpeed;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _holder = GetComponent<StatHolder>();
        _dash = GetComponent<Dash>();
        _playerAnimator = GameObject.Find("PlayerSprite").GetComponent<Animator>();

        _activeMovementSpeed = _holder.Stat.Speed;
    }

    private void FixedUpdate()
    {
        //player movement
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dir.sqrMagnitude > 1f) dir.Normalize();

        if (dir.Equals(Vector2.zero))
        {
            _playerAnimator.SetBool("Idle", true);
            _playerAnimator.SetBool("Run", false);
        }
        else
        {
            _playerAnimator.SetBool("Idle", false);
            _playerAnimator.SetBool("Run", true);
        }

        _rigidbody2D.MovePosition(_rigidbody2D.position + dir * _activeMovementSpeed);
    }

    void Update()
    {
        //dash handling
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _activeMovementSpeed = _dash.GetDashSpeed();
        }

        if (!_dash.IsDashing)
        {
            _activeMovementSpeed = _holder.Stat.Speed;
        }
    }
}
