using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    public Transform ball; // Reference to the ball GameObject
    public float speed = 2f; // Adjust the speed of the computer paddle

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            // Ensure the computer paddle is always moving towards the ball's y position
            float moveDirection = Mathf.Sign(ball.position.y - transform.position.y);
            transform.Translate(0f, moveDirection * speed * Time.deltaTime, 0f);

            // Limit paddle's movement to the screen boundaries (adjust according to your game)
            Vector3 currentPosition = transform.position;
            currentPosition.y = Mathf.Clamp(currentPosition.y, -4.5f, 4.5f); // Adjust the Y boundaries
            transform.position = currentPosition;
        }
    }
}
