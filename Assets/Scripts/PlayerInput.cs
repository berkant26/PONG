using UnityEngine;

public class PlayerInput : MonoBehaviour, IPaddleInput
{
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;

    public float GetMovementInput()
    {
        if (Input.GetKey(leftKey))
        {
            return -1f;
        }
        else if (Input.GetKey(rightKey))
        {
            return 1f;
        }
        return 0f;
    }
}
