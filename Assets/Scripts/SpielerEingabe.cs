using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DisplayMetricsAndroid;

public class SpielerEingabe : MonoBehaviour
{
    [HideInInspector]
    public bool m_Beschleunige;
    [HideInInspector]
    public bool m_DreheGegenUZS;
    [HideInInspector]
    public bool m_DreheImUZS;
    [HideInInspector]
    public bool m_LaserAbfeuern;
    string m_GeraeteTyp;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        m_Beschleunige = false;
        m_DreheGegenUZS = false;
        m_DreheImUZS = false;
        m_LaserAbfeuern = false;

        //Pruefe ob das Geraet eine Konsole ist
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            m_GeraeteTyp = "Console";
        }

        //Pruefe ob das Geraet ein Desktop Computer ist
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            m_GeraeteTyp = "Desktop";
        }

        //Pruefe ob das Geraet ein Mobilgeraet ist
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_GeraeteTyp = "Handheld";
        }

        //Pruefe ob das Geraet unbekannt ist
        if (SystemInfo.deviceType == DeviceType.Unknown)
        {
            m_GeraeteTyp = "Unknown";
        }

        //Gebe das Geraet in der Kommandozeile aus
        Debug.Log("Device type : " + m_GeraeteTyp);

        DisplayMetricsAndroid.Initialize();
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        // https://docs.unity3d.com/ScriptReference/DeviceType.html

        //Pruefe ob das Geraet eine Konsole ist
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            m_Beschleunige = false;
            m_DreheImUZS = false;
            m_DreheGegenUZS = false;
            m_LaserAbfeuern = false;
        }

        //Pruefe ob das Geraet ein Desktop Computer ist
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            m_Beschleunige = (Input.GetMouseButton(0) && Input.GetMouseButton(1)) || Input.GetKey(KeyCode.W);
            m_DreheImUZS = (Input.GetMouseButton(0) && !Input.GetMouseButton(1)) || Input.GetKey(KeyCode.A);
            m_DreheGegenUZS = (!Input.GetMouseButton(0) && Input.GetMouseButton(1)) || Input.GetKey(KeyCode.D);
            m_LaserAbfeuern = Input.GetKey(KeyCode.Space);
        }

        //Pruefe ob das Geraet ein Mobilgeraet ist
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_Beschleunige = BehandleTouchBeschleunige();
            m_DreheImUZS = BehandleTouchDreheImUZS();
            m_DreheGegenUZS = BehandleTouchDreheGegenUZS();
            m_LaserAbfeuern = BehandleTouchLaserAbfeuern();
        }

        //Pruefe ob das Geraet unbekannt ist
        if (SystemInfo.deviceType == DeviceType.Unknown)
        {
            m_Beschleunige = false;
            m_DreheImUZS = false;
            m_DreheGegenUZS = false;
            m_LaserAbfeuern = false;
        }
    }
    
    // https://docs.unity3d.com/ScriptReference/Input.GetTouch.html
    // Behandle Touch Ereignisse.
    private bool BehandleTouchBeschleunige()
    {
        if (Input.touchCount >= 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Vector2 pos0Normalized = new Vector2(touch0.position.x / Screen.width, touch0.position.y / Screen.height);
            Touch touch1 = Input.GetTouch(1);
            if ((touch0.phase == TouchPhase.Moved || touch0.phase == TouchPhase.Stationary)
                && (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Stationary))
            {
                // ist in unterer Haelfte touch0 && ist in unterer Haelfte touch1
                if (touch0.position.y >= 0 && touch0.position.y <= DisplayMetricsAndroid.YDPI
                    && touch1.position.y >= 0 && touch1.position.y <= DisplayMetricsAndroid.YDPI)
                {
                    // Beschleunige
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool BehandleTouchDreheImUZS()
    {
        if (Input.touchCount > 0)
        {
            Touch touch0 = Input.GetTouch(0);
            Vector2 pos0Normalized = new Vector2(touch0.position.x / Screen.width, touch0.position.y / Screen.height);
            if (touch0.phase == TouchPhase.Moved || touch0.phase == TouchPhase.Stationary)
            {
                if (Input.touchCount == 2)
                {
                    Touch touch1 = Input.GetTouch(1);
                    if (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Stationary)
                    {
                        // ist in unterer Haelfte touch0 && ist in oberer Haelfte touch1
                        if (touch0.position.y >= 0 && touch0.position.y <= DisplayMetricsAndroid.YDPI
                            && touch1.position.y >= DisplayMetricsAndroid.YDPI && touch1.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI)
                        {
                            // Drehe Raumschiff und Laser Abfeuern
                            // ist in linker Haelfte
                            if (touch0.position.x >= 0 && touch0.position.x <= DisplayMetricsAndroid.WidthPixels / 2)
                            {
                                // Drehe im Uhrzeigersinn
                                return true;
                            }
                        }
                        // ist in oberer Haelfte touch0 && ist in unterer Haelfte touch1
                        else if (touch0.position.y >= DisplayMetricsAndroid.YDPI && touch0.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI
                            && touch1.position.y >= 0 && touch1.position.y <= DisplayMetricsAndroid.YDPI)
                        {
                            // Drehe Raumschiff und Laser Abfeuern
                            // ist in linker Haelfte
                            if (touch1.position.x >= 0 && touch1.position.x <= DisplayMetricsAndroid.WidthPixels / 2)
                            {
                                // Drehe im Uhrzeigersinn
                                return true;
                            }
                        }
                    }
                }
                else if (Input.touchCount == 1)
                {
                    // ist in unterer Haelfte
                    if (touch0.position.y >= 0 && touch0.position.y <= DisplayMetricsAndroid.YDPI)
                    {
                        // ist in linker Haelfte
                        if (touch0.position.x >= 0 && touch0.position.x <= DisplayMetricsAndroid.WidthPixels / 2)
                        {
                            // Drehe im Uhrzeigersinn
                            return true;
                        }
                    }
                }
            }
        }
        // Tue nichts
        return false;
    }
    
    private bool BehandleTouchDreheGegenUZS()
    {
        if (Input.touchCount > 0)
        {
            Touch touch0 = Input.GetTouch(0);
            Vector2 pos0Normalized = new Vector2(touch0.position.x / Screen.width, touch0.position.y / Screen.height);
            if (touch0.phase == TouchPhase.Moved || touch0.phase == TouchPhase.Stationary)
            {
                if (Input.touchCount == 2)
                {
                    Touch touch1 = Input.GetTouch(1);
                    if (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Stationary)
                    {
                        // ist in unterer Haelfte touch0 && ist in oberer Haelfte touch1
                        if (touch0.position.y >= 0 && touch0.position.y <= DisplayMetricsAndroid.YDPI
                            && touch1.position.y >= DisplayMetricsAndroid.YDPI && touch1.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI)
                        {
                            // Drehe Raumschiff
                            // ist nicht in linker Haelfte
                            if (touch0.position.x < 0 || touch0.position.x > DisplayMetricsAndroid.WidthPixels / 2)
                            {
                                // Drehe gegen Uhrzeigersinn
                                return true;
                            }
                        }
                        // ist in oberer Haelfte touch0 && ist in unterer Haelfte touch1
                        else if (touch0.position.y >= DisplayMetricsAndroid.YDPI && touch0.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI
                            && touch1.position.y >= 0 && touch1.position.y <= DisplayMetricsAndroid.YDPI)
                        {
                            // Drehe Raumschiff
                            // ist nicht in linker Haelfte
                            if (touch1.position.x < 0 || touch1.position.x > DisplayMetricsAndroid.WidthPixels / 2)
                            {
                                // Drehe gegen Uhrzeigersinn
                                return true;
                            }
                        }
                    }
                }
                else if (Input.touchCount == 1)
                {
                    // ist in unterer Haelfte
                    if (touch0.position.y >= 0 && touch0.position.y <= DisplayMetricsAndroid.YDPI)
                    {
                        // ist nicht in linker Haelfte
                        if (touch0.position.x < 0 || touch0.position.x > DisplayMetricsAndroid.WidthPixels / 2)
                        {
                            // Drehe gegen Uhrzeigersinn
                            return true;
                        }
                    }
                }
            }
        }
        // Tue nichts
        return false;
    }
    
    private bool BehandleTouchLaserAbfeuern()
    {
        if (Input.touchCount > 0)
        {
            Touch touch0 = Input.GetTouch(0);
            Vector2 pos0Normalized = new Vector2(touch0.position.x / Screen.width, touch0.position.y / Screen.height);
            if (touch0.phase == TouchPhase.Moved || touch0.phase == TouchPhase.Stationary)
            {
                if (Input.touchCount == 2)
                {
                    Touch touch1 = Input.GetTouch(1);
                    if (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Stationary)
                    {
                        // touch0 und touch1 sind beide in der oberen Haelfte
                        if ((touch0.position.y >= DisplayMetricsAndroid.YDPI && touch0.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI)
                            || (touch1.position.y >= DisplayMetricsAndroid.YDPI && touch1.position.y <= DisplayMetricsAndroid.HeightPixels - DisplayMetricsAndroid.YDPI))
                        {
                            // Laser Abfeuern
                            return true;
                        }
                    }
                }
                else if (Input.touchCount == 1)
                {
                    // touch0 ist in der oberen Haelfte
                    if (touch0.position.y < 0 || touch0.position.y > DisplayMetricsAndroid.YDPI)
                    {
                        // Laser Abfeuern
                        return true;
                    }
                }
            }
        }
        // Tue nichts
        return false;
    }
}
