using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 5f; // Initial speed of the ball
    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        LaunchBall(); // Launch the ball at the beginning
    }

    public void LaunchBall()
{
    float xDirection = Random.Range(-1f, 1f);
    float yDirection = Random.Range(-1f, 1f);

    // Ensure the ball's initial direction is not purely vertical or horizontal
    while (Mathf.Abs(yDirection) < 0.5f || Mathf.Abs(xDirection) < 0.5f)
    {
        xDirection = Random.Range(-1f, 1f);
        yDirection = Random.Range(-1f, 1f);
    }

    Vector2 direction = new Vector2(xDirection, yDirection).normalized;
    rb.velocity = direction * initialSpeed; // Set the ball's velocity
}


    public void ResetBall()
    {
        rb.velocity = Vector2.zero; // Reset the ball's velocity
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerPaddle"))
        {
            // Handle collision with player's paddle
            // Implement paddle reflection logic here
        }
        else if (collision.gameObject.CompareTag("ComputerPaddle"))
        {
            // Handle collision with computer's paddle
            // Implement paddle reflection logic here
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Handle collision with walls
            // Implement wall reflection logic here
        }
        else if (collision.gameObject.CompareTag("PlayerScoringZone"))
        {
            GameManager.instance.HandlePlayerScored();
        }
        else if (collision.gameObject.CompareTag("ComputerScoringZone"))
        {
            GameManager.instance.HandleComputerScored();
        }
    }
}
