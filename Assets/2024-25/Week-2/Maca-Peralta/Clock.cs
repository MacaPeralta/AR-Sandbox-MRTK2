using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
public class Clock : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // TextMesh for displaying the time
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject resetButton;

    private float timer = 0f;
    private bool isTimerRunning = false;

    void Start()
    {
        // Initialize the buttons with the respective event listeners
        startButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StartTimer);
        stopButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StopTimer);
        resetButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ResetTimer);

        UpdateTimerDisplay();
    }

    void Update()
    {
        // If the timer is running, update it every frame
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void StartTimer()
    {
        isTimerRunning = true;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void ResetTimer()
    {
        isTimerRunning = false;
        timer = 0f;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        // Convert timer to a readable format (HH:mm:ss)
        System.TimeSpan time = System.TimeSpan.FromSeconds(timer);
        timerText.text = time.ToString(@"hh\:mm\:ss");
    }
}
