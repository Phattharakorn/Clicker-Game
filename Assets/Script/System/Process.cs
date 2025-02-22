using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class ItemProcessor : MonoBehaviour
{
    public GameObject spawnPrefab; // Prefab to spawn
    public Image[] progressImages; // Progress bar images (changes color)
    public Image processImage; // The main process image (changes per click)
    public Sprite[] processSprites; // Array of sprites for the process images
    public Color completedColor = Color.green; // Color when a stage is completed
    public Color defaultColor = Color.red; // Default color (red)
    public string productname;
    public Transform spawnParent; // The selected GameObject where it should spawn

    public int expReward = 100; // EXP reward
    public int cashReward = 500; // Cash reward
    public TextMeshProUGUI feedbackText; // Displays current progress

    private int clickCount = 0;
    private const int totalClicks = 7;
    public float autoProcessInterval = 5f; // Interval for auto-processing in seconds

    public AudioClip moveSound; // Assign in Inspector
    private AudioSource audioSource;

    private Coroutine autoProcessCoroutine; // To store the reference to the auto process coroutine
    private bool isAutoProcessing = false; // Flag to control auto-processing

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        ResetProcess();
    }

    public void OnProcessButtonClick()
    {
        if (isAutoProcessing)
        {
            // If auto-processing is already active, stop it
            StopAutoProcess();
            return; // Exit the method if we stop auto-processing
        }

        // Proceed with manual processing
        ManualProcess();
    }

    public void ManualProcess()
    {
        audioSource.clip = moveSound;
        audioSource.Play();

        if (clickCount < totalClicks)
        {
            clickCount++;

            // Change Progress Image color (1-5)
            if (clickCount > 0 && clickCount <= 6)
            {
                progressImages[clickCount - 1].color = completedColor;
            }

            // Change Process Image (1-6), 0 shows nothing
            if (clickCount > 0 && clickCount <= 6)
            {
                processImage.enabled = true;
                processImage.sprite = processSprites[clickCount - 1]; // Change image step by step
            }

            // Check if the process is complete
            if (clickCount == totalClicks)
            {
                CompleteProcess();
            }
        }
        else
        {
            // If the process is already complete, we can reset the process
            ResetProcess();
        }
    }

    public void StartAutoProcess()
    {
        if (!isAutoProcessing)
        {
            isAutoProcessing = true; // Set the flag to true
            autoProcessCoroutine = StartCoroutine(AutoProcess()); // Start the auto-processing coroutine
        }
    }

    private IEnumerator AutoProcess()
    {
        while (isAutoProcessing) // Continue while auto-processing is enabled
        {
            yield return new WaitForSeconds(autoProcessInterval); // Wait for the specified interval
            ManualProcess(); // Automatically call the manual process method
        }
    }

    public void StopAutoProcess()
    {
        if (isAutoProcessing)
        {
            isAutoProcessing = false; // Set the flag to false
            if (autoProcessCoroutine != null)
            {
                StopCoroutine(autoProcessCoroutine); // Stop the coroutine
                autoProcessCoroutine = null; // Clear the reference
            }
        }
    }

    public void CompleteProcess()
    {
        // Add EXP & Cash
        PlayerData.Instance.AddCash(cashReward);
        PlayerData.Instance.AddExperience(amount: expReward);
        GameObject spawnedObject = Instantiate(spawnPrefab, spawnParent);
        spawnedObject.transform.localPosition = Vector3.zero;
        // Reset process
        ResetProcess();
    }

    private void ResetProcess()
    {
        clickCount = 0;

        // Reset progress images to red
        foreach (var img in progressImages)
        {
            img.color = defaultColor;
        }

        // Reset process image
        processImage.enabled = false;
        processImage.sprite = null;

        feedbackText.text = productname;
    }

    public void upgradefood(int income)
    {
        cashReward *= income;
        productname = PlayerData.Instance.foodname;
    }
}
