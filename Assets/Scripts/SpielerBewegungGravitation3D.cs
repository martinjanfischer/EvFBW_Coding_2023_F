using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerBewegungGravitation3D : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        // Hole Rigidbody von dem GameObject an dem dieses Script zugewiesen ist
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Korrekte Gravitations Konstante. Einheiten dyne-m^2/kg^2
    //private const double GravitationsKonstante = 6.6743e-11;
    // Korrekte Gravitations Konstante. Einheiten dyne-cm^2/g^2
    //private const double GravitationsKonstante = 6.6743e-08;
    // Veraenderte Gravitations Konstante. Einheiten dyne-cm^2/g^2 skaliert um Faktor 100
    public double GravitationsKonstante = 6.6743e-06;

    // FixedUpdate wird einmal pro Bild aufgerufen 
    // und zwar zu einem bestimmten Zeitpunkt 
    // in Zusammenhang mit Physik und RigidBody
    void FixedUpdate()
    {
        Vector3 kraftGravitation = BerechneGravitationsKraft();
        m_Rigidbody.AddForce(kraftGravitation);
    }

    Vector3 BerechneGravitationsKraft()
    {
        Vector3 kraftGravitation = new Vector3(0, 0, 0);
        GameObject[] planeten = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planeten)
        {
            if (planet != null)
            {
                //Debug.Log("Planet : ");
                
                Rigidbody rigidBodyPlanet = planet.GetComponent<Rigidbody>();
                if (rigidBodyPlanet != null)
                {
                    //Debug.Log("RigidBody Planet : " + rigidBodyPlanet.mass);
                    kraftGravitation += BerechneGravitationsKraft(rigidBodyPlanet);
                    //Debug.Log("kraftGravitation : " + kraftGravitation.ToString());
                }
                
            }
        }
        return kraftGravitation;
    }

    
    Vector3 BerechneGravitationsKraft(Rigidbody gravitationalSource)
    {
		Vector3 gravitationalSource3D;
		gravitationalSource3D.x = gravitationalSource.position.x;
		gravitationalSource3D.y = gravitationalSource.position.y;
		gravitationalSource3D.z = m_Rigidbody.position.z;
        Vector3 kraftRichtung = (gravitationalSource3D - m_Rigidbody.position);
        float sqrDst = kraftRichtung.sqrMagnitude;
        Vector3 kraftGravitation = kraftRichtung.normalized;
        kraftGravitation *= (float)(GravitationsKonstante * gravitationalSource.mass * m_Rigidbody.mass / sqrDst);
        return kraftGravitation;
    }
    
}
