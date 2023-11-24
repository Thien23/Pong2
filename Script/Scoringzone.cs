using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    public bool isPlayerZone; // Check if this is a player's scoring zone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isPlayerZone)
            {
                GameManager.instance.HandlePlayerScored();
                Debug.Log("Player Scored!");
            }
            else
            {
                GameManager.instance.HandleComputerScored();
                Debug.Log("Computer Scored!");
            }
        }
    }
}
