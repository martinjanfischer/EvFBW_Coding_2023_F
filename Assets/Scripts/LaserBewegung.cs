using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBewegung : MonoBehaviour
{
    public float m_Geschwindigkeit = 10f;
    public BoxCollider2D m_LevelGrenzen;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        transform.Translate(Vector2.up * m_Geschwindigkeit * Time.deltaTime);

        if (transform.position.x < m_LevelGrenzen.bounds.min.x
            || transform.position.x > m_LevelGrenzen.bounds.max.x
            || transform.position.y < m_LevelGrenzen.bounds.min.y
            || transform.position.y > m_LevelGrenzen.bounds.max.y)
        {
            // gameObject ist eine Mitgliedvariable von der Basisklasse MonoBehaviour
			// und ist das Spielobjekt des Laserstrahls zu dem diese Skript Komponente gehört
            Destroy(gameObject);
        }
    }
}
