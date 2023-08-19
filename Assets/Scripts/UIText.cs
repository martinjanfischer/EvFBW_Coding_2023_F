using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public BoxCollider2D m_LevelGrenzen;

    [SerializeField]
    private Text m_UIText;
    private Camera m_Kamera = null;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        m_UIText = GetComponent<Text>();
        m_UIText.text = "Koordinaten";
		//Nimm die erste Kamera die Du kriegen kannst
        GameObject[] kameras = GameObject.FindGameObjectsWithTag("MainCamera");
        if (kameras != null && kameras.Length > 0)
        {
            m_Kamera = kameras[0].GetComponent<Camera>();
        }
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        //Prüfe ob das auführende Gerät ein Desktop PC ist
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButton(0))
            {
                m_UIText.text = Input.mousePosition.ToString();
            }
            else
            {
                m_UIText.text = "Koordinaten";
            }
        }

        //Prüfe ob das auführende Gerät ein Mobilgerät ist
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            // https://docs.unity3d.com/ScriptReference/Input.GetTouch.html
            // Behandle Bildschirm Touch Gesten.
            if (Input.touchCount > 0)
            {
                Touch touch0 = Input.GetTouch(0);
                m_UIText.text = touch0.position.ToString();
            }
            else
            {
                m_UIText.text = "Koordinaten";
            }
        }

        if (m_Kamera != null)
        {
            m_UIText.text += "\nAspect: " + m_Kamera.aspect.ToString();
            m_UIText.text += "\nOrthSize: " + m_Kamera.orthographicSize.ToString();
        }
        if (m_LevelGrenzen != null)
        {
            float xMin = m_LevelGrenzen.bounds.min.x;
            float xMax = m_LevelGrenzen.bounds.max.x;
            float yMin = m_LevelGrenzen.bounds.min.y;
            float yMax = m_LevelGrenzen.bounds.max.y;
            m_UIText.text += "\nImage: " + xMin + " " + xMax + " " + yMin + " " + yMax;
        }
    }
}
