using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private bool isPlayerZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            GameManager.Instance.OnScoreZoneHit(isPlayerZone);
        }
    }
}
