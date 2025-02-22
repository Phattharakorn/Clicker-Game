using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float destroyTime = 5f; // Time before destruction
    public AudioClip moveSound; // Assign in Inspector

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.Play(); // Play sound on start
        }


        // Destroy the GameObject after 'destroyTime' seconds
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        // Move the object to the left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
