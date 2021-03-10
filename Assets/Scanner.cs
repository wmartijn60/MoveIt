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

    public TextMeshProUGUI text;
    #endregion

    #region Methods
    private void Start()
    {
        foreach (WebCamDevice cam in WebCamTexture.devices)
        {
            if (cam.isFrontFacing)
            {
                backCam = new WebCamTexture(cam.name, Screen.width, Screen.height);
                backCam.Play();
                GetComponent<RawImage>().texture = backCam;
                camReady = true;
                break;
            }
        }
    }

    private void Update()
    {
        if (camReady)
        {
            // Orientation.
            GetComponent<RawImage>().rectTransform.localScale = new Vector3(2f, backCam.videoVerticallyMirrored ? -1.0f : 1.0f, 1f);
            GetComponent<RawImage>().rectTransform.localEulerAngles = new Vector3(0, 0, -backCam.videoRotationAngle);

            // Scan.
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(backCam.GetPixels32(), backCam.width, backCam.height);
                if (result != null)
                {
                    Debug.Log("Result: " + result.Text);
                    text.text = result.Text;
                }
            }
            catch (Exception e) { Debug.Log(e); }
        }
    }
    #endregion
}