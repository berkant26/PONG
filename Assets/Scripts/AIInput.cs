using UnityEngine;

public class AIInput : MonoBehaviour, IPaddleInput
{
    [SerializeField] private Transform ball;
    [SerializeField] private float reactionSpeed = 0.5f;
    [SerializeField] private float errorMargin = 0.5f;
    [SerializeField] private float distance = 0.5f;

    private Transform _transform;
    private void Awake()
    {
        _transform = transform;

    }
    public float GetMovementInput()
    {
        if (ball == null) return 0f;

        float targetX = ball.position.x + Random.Range(-errorMargin, errorMargin);
        float currentX = _transform.position.x;

        if (Mathf.Abs(targetX - currentX) < distance)
            return 0f;

        return targetX > currentX ? reactionSpeed : -reactionSpeed;
    }
}
