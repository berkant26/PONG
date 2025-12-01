using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedIncrement = 0.5f;
    [SerializeField] private float maxSpeed = 15f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip paddleHitSound;
    [SerializeField] private AudioClip wallHitSound;


    private Vector2 _velocity;
    private Transform _transform;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Launch();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _velocity;
    }

    public void Launch()
    {
        gameObject.SetActive(true);

        float y = Random.Range(-1f, 1f);
        _velocity = new Vector2(0, y).normalized * speed;
    }

    public void ResetBall()
    {
        gameObject.SetActive(false);
        _transform.position = Vector3.zero;
        _velocity = Vector2.zero;
        Invoke(nameof(Launch), 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource.PlayOneShot(paddleHitSound);
            HandlePaddleCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(wallHitSound);

            HandleWallCollision();
        }
    }

    private void HandleWallCollision()
    {
        _velocity.x *= -1f;   
    }

    private void HandlePaddleCollision(Collision2D collision)
    {
        float paddleY = collision.transform.position.x;
        float ballY = _transform.position.x;
        float paddleHeight = collision.collider.bounds.size.x;

        float hitOffset = (ballY - paddleY) / (paddleHeight / 2f);
        hitOffset = Mathf.Clamp(hitOffset, -1f, 1f);

        float maxBounceAngle = 120 * Mathf.Deg2Rad;
        float bounceAngle = hitOffset * maxBounceAngle;

        float direction = Mathf.Sign(_velocity.y) * -1f;

        float currentSpeed = Mathf.Min(_velocity.magnitude + speedIncrement, maxSpeed);

        _velocity = new Vector2(
            Mathf.Sin(bounceAngle) * currentSpeed,
            direction * Mathf.Cos(bounceAngle) * currentSpeed
        );

        float minYSpeed = currentSpeed * 0.5f;
        if (Mathf.Abs(_velocity.y) < minYSpeed)
        {
            _velocity.y = direction * minYSpeed;
            _velocity = _velocity.normalized * currentSpeed;
        }
    }
}
