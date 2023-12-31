using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpielerEingabe))]
public class SpielerBewegungSteuerung3D : MonoBehaviour
{
    SpielerEingabe m_SpielerEingabe;

    Rigidbody m_Rigidbody;
    Vector3 m_WinkelGeschwindigkeit3D;
    public float m_Schub;
    public float m_WinkelGeschwindigkeit;

    public GameObject m_PrefabLaser;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        // Hole Script Komponente SpielerEingabe von dem GameObject an dem dieses Script zugewiesen ist
        m_SpielerEingabe = GetComponent<SpielerEingabe>();

        // Hole Rigidbody von dem GameObject an dem dieses Script zugewiesen ist
        m_Rigidbody = GetComponent<Rigidbody>();

        // Setze Winkel Geschwindigkeit des Rigidbody (drehe um die Y Achse, 100 Grad pro Sekunde)
        m_WinkelGeschwindigkeit3D = new Vector3(0, 0, m_WinkelGeschwindigkeit);
    }

    // Update wird einmal pro Bild aufgerufen
    void Update()
    {
        //Transform nachbrenner = transform.GetChild(1);
        //nachbrenner.GetComponent<Renderer>().enabled = m_SpielerEingabe.m_Beschleunige;

        if (m_SpielerEingabe.m_LaserAbfeuern)
        {
            //Transform muendungsfeuer = transform.GetChild(3);
            //muendungsfeuer.GetComponent<Renderer>().enabled = true;
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
            //Transform muendungsfeuer = transform.GetChild(3);
            //muendungsfeuer.GetComponent<Renderer>().enabled = false;
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
            Quaternion deltaRotation = Quaternion.Euler(0, 0, -m_WinkelGeschwindigkeit);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }
        else if (m_SpielerEingabe.m_DreheImUZS)
        {

            Quaternion deltaRotation = Quaternion.Euler(0, 0, m_WinkelGeschwindigkeit);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        }
    }
}
