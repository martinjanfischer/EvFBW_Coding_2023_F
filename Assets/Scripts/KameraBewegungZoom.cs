using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraBewegungZoom : MonoBehaviour
{
    private Camera m_Kamera;
    private BoxCollider2D m_KameraGrenzen;

    public Transform m_Ziel;
    public BoxCollider2D m_LevelGrenzen;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        m_Kamera = GetComponent<Camera>();
        m_KameraGrenzen = GetComponent<BoxCollider2D>();
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        // Aktualisiere Kamera Grenzen
        float groesseY = m_Kamera.orthographicSize * 2;
        float groesseX = groesseY * m_Kamera.aspect;
        m_KameraGrenzen.size = new Vector2(groesseX, groesseY);

        // Folge der Spielerfigur mit der Kamera
        float bildSeitenVerhaeltnis = m_Kamera.aspect * m_Kamera.orthographicSize;
        float kameraPositionX = Mathf.Clamp(
            m_Ziel.position.x,
            m_LevelGrenzen.bounds.min.x + bildSeitenVerhaeltnis,
            m_LevelGrenzen.bounds.max.x - bildSeitenVerhaeltnis
        );
        float kameraPositionY = Mathf.Clamp(
            m_Ziel.position.y,
            m_LevelGrenzen.bounds.min.y + m_Kamera.orthographicSize,
            m_LevelGrenzen.bounds.max.y - m_Kamera.orthographicSize
        );
        const float sanfteGeschwindigkeit = 0.5f;
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            new Vector3(kameraPositionX, kameraPositionY, this.transform.position.z),
            sanfteGeschwindigkeit
        );
    }
}
