using UnityEngine;

public class Dash : MonoBehaviour
{
    private StatHolder _holder;

    private float _dashCounter = 0;
    private float _dashCoolCounter = 0;

    public bool IsDashing { get; private set; }

    void Start()
    {
        _holder = GetComponent<StatHolder>();
    }

    void Update()
    {
        if (_dashCounter > 0)
        {
            _dashCounter -= Time.deltaTime;

            if (_dashCounter <= 0)
            {
                _dashCoolCounter = _holder.Stat.DashCooldown;
                IsDashing = false;
            }
        }

        if (_dashCoolCounter > 0)
        {
            _dashCoolCounter -= Time.deltaTime;
        }
    }

    public float GetDashSpeed()
    {
        if (_dashCoolCounter <= 0 && _dashCounter <= 0)
        {
            IsDashing = true;
            _dashCounter = _holder.Stat.DashLength;

            return _holder.Stat.DashSpeed;
        }

        return 0;
    }
}
