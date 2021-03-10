using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using TMPro;

public class Scanner : MonoBehaviour
{
    #region Fields
    private bool camReady;
    private WebCamTexture backCam;
    private Inventory inventory;
    public TextMeshProUGUI text;
    private float waitTime = 2f;
    private float currentTime;
    #endregion

    #region Methods
    private void Start()
    {
        foreach (WebCamDevice cam in WebCamTexture.devices)
        {
            if (!cam.isFrontFacing)
            {
                backCam = new WebCamTexture(cam.name, Screen.width, Screen.height);
                backCam.Play();
                GetComponent<RawImage>().texture = backCam;
                camReady = true;
                break;
            }
        }
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        text.text = inventory.coins.ToString();
    }

    private void Update()
    {
        if (inventory == null) {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            text.text = inventory.coins.ToString();
        }

        if (camReady && Time.time > currentTime + waitTime)
        {
            // Orientation.
            GetComponent<RawImage>().rectTransform.localScale = new Vector3(2f, backCam.videoVerticallyMirrored ? -0.5f : 0.5f, 1f);
            GetComponent<RawImage>().rectTransform.localEulerAngles = new Vector3(0, 0, -backCam.videoRotationAngle);

            // Scan.
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(backCam.GetPixels32(), backCam.width, backCam.height);
                if (result != null)
                {
                    Debug.Log("Result: " + result.Text);
                    int amountOfCoins;
                    int.TryParse(result.Text, out amountOfCoins);
                    inventory.coins += amountOfCoins;
                    text.text = inventory.coins.ToString();
                }
            }
            catch (Exception e) { Debug.Log(e); }
            currentTime = Time.time;
        }
    }
    #endregion
}