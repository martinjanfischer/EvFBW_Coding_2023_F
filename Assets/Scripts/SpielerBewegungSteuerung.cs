using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpielerEingabe))]
public class SpielerBewegungSteuerung : MonoBehaviour
{
    SpielerEingabe m_SpielerEingabe;

    Rigidbody2D m_Rigidbody;
    Vector3 m_WinkelGeschwindigkeit3D;
    public float m_Schub;
    public float m_WinkelGeschwindigkeit;

    public GameObject m_PrefabLaser;
    public GameObject m_PrefabNachbrenner;
    public GameObject m_PrefabMuendungsFeuer;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        // Hole Script Komponente SpielerEingabe von dem GameObject an dem dieses Script zugewiesen ist
        m_SpielerEingabe = GetComponent<SpielerEingabe>();

        // Hole Rigidbody von dem GameObject an dem dieses Script zugewiesen ist
        m_Rigidbody = GetComponent<Rigidbody2D>();

        // Setze Winkel Geschwindigkeit des Rigidbody (drehe um die Y Achse, 100 Grad pro Sekunde)
        m_WinkelGeschwindigkeit3D = new Vector3(0, 0, m_WinkelGeschwindigkeit);
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        m_PrefabNachbrenner.GetComponent<Renderer>().enabled = m_SpielerEingabe.m_Beschleunige;

        if (m_SpielerEingabe.m_LaserAbfeuern)
        {
            m_PrefabMuendungsFeuer.GetComponent<Renderer>().enabled = true;
            GameObject objectPrefabLaser = Instantiate(m_PrefabLaser, transform.position, transform.rotation) as GameObject;
            LaserBewegung laserBewegung = objectPrefabLaser.GetComponent("LaserBewegung") as LaserBewegung;
            GameObject[] hintergrundBilder = GameObject.FindGameObjectsWithTag("Background");
            foreach (GameObject hintergrundBild in hintergrundBilder)
            {
                if (hintergrundBild != null)
                {
                    BoxCollider2D kollidiererHintergrundBild = hintergrundBild.GetComponent<BoxCollider2D>();
                    if (kollidiererHintergrundBild != null)
                    {
                        laserBewegung.m_LevelGrenzen = kollidiererHintergrundBild;
                        break;
                    }
                }
            }
        }
        else
        {
            m_PrefabMuendungsFeuer.GetComponent<Renderer>().enabled = false;
        }
    }

    // FixedUpdate wird einmal pro Bild aufgerufen 
    // und zwar zu einem bestimmten Zeitpunkt 
    // in Zusammenhang mit Physik und RigidBody
    void FixedUpdate()
    {
        Vector3 kraftSchub = new Vector3(0, 0, 0);
        if (m_SpielerEingabe.m_Beschleunige)
        {
            kraftSchub = transform.up * m_Schub;
        }
        m_Rigidbody.AddForce(kraftSchub);

        if (m_SpielerEingabe.m_DreheGegenUZS)
        {
            m_Rigidbody.rotation -= m_WinkelGeschwindigkeit;
        }
        else if (m_SpielerEingabe.m_DreheImUZS)
        {
            m_Rigidbody.rotation += m_WinkelGeschwindigkeit;
        }
    }
}
