using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float boundaryY = 4.5f;


    private IPaddleInput _input;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _input = GetComponent<IPaddleInput>();

    }
    private void Update()
    {
        if (_input == null) return;
        Move(_input.GetMovementInput());
    }

    private void Move(float direction)
    {
        Vector3 position = _transform.position;
        position.x += direction * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -boundaryY, boundaryY);

        _transform.position = position;
    }

}
