using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerLevelGrenzen : MonoBehaviour
{
    public BoxCollider2D m_LevelGrenzen;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (HatUeberschrittenRechteGrenze(x)) { x = BewegeZurLinkenGrenze(x); }
        if (HatUeberschrittenLinkeGrenze(x)) { x = BewegeZurRechtenGrenze(x); }
        if (HatUeberschrittenObereGrenze(y)) { y = BewegeZurUnterenGrenze(y); }
        if (HatUeberschrittenUntereGrenze(y)) { y = BewegeZurOberenGrenze(y); }

        transform.position = new Vector2(x, y);
    }

    bool HatUeberschrittenLinkeGrenze(float x)
    {
        return (x < m_LevelGrenzen.bounds.min.x);
    }

    bool HatUeberschrittenRechteGrenze(float x)
    {
        return (x > m_LevelGrenzen.bounds.max.x);
    }

    bool HatUeberschrittenObereGrenze(float y)
    {
        return (y > m_LevelGrenzen.bounds.max.y);
    }

    bool HatUeberschrittenUntereGrenze(float y)
    {
        return (y < m_LevelGrenzen.bounds.min.y);
    }

    float BewegeZurLinkenGrenze(float x)
    {
        return (x - (m_LevelGrenzen.bounds.max.x - m_LevelGrenzen.bounds.min.x));
    }

    float BewegeZurRechtenGrenze(float x)
    {
        return (x + (m_LevelGrenzen.bounds.max.x - m_LevelGrenzen.bounds.min.x));
    }

    float BewegeZurOberenGrenze(float y)
    {
        return (y + (m_LevelGrenzen.bounds.max.y - m_LevelGrenzen.bounds.min.y));
    }

    float BewegeZurUnterenGrenze(float y)
    {
        return (y - (m_LevelGrenzen.bounds.max.y - m_LevelGrenzen.bounds.min.y));
    }
}
