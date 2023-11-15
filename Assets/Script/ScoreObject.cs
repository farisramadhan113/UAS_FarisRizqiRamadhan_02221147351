using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int scoreValue; // Adjust the score value as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming you have a Score script on an object in the scene
            Score scoreManager = FindObjectOfType<Score>();

            // Check if the Score script is found
            if (scoreManager != null)
            {
                // Call the method to add score
                scoreManager.AddScore(scoreValue);
            }

            // You can add additional logic here, such as destroying the object
            Destroy(gameObject);
        }
    }
}
