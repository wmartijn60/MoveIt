using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScanner : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    private float startTime;
    private float endTime = 200f;

    void Start()
    {
        startTime = Time.time;
    }

    private void FixedUpdate() {
        if (startTime > endTime) {
            sceneSwitcher.Switchscene();
        } else {
            int minutes;
            int seconds;
            startTime += Time.fixedDeltaTime;
            minutes = Mathf.FloorToInt((endTime - startTime) / 60);
            seconds = (int)((endTime - startTime) % 60);
            text.text = minutes.ToString() + ":" + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
    }
}
