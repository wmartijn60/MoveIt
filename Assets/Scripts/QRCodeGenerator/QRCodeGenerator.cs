using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRCodeGenerator : MonoBehaviour {
    [SerializeField]
    private int  points;



    void OnGUI() {

        Texture2D myQR = generateQR(points);
        if (GUI.Button(new Rect(300, 300, 256, 256), myQR, GUIStyle.none)) { }
    }

    public Texture2D generateQR(int punt)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(punt, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private static Color32[] Encode(int textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding.ToString()) ;
    }
}
