using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerKollisionExplosion : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public float m_ImpulsDerZerstoerung = 25f;
    public GameObject m_PrefabExplosionAnimation;
    Animation m_ExplosionAnimation;

    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        // Hole Rigidbody von dem GameObject an dem dieses Script zugewiesen ist
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // OnCollisionEnter2D wird aufgerufen bei jedem Kollisionsereignis
    void OnCollisionEnter2D(Collision2D kollision)
    {
        if (kollision.gameObject.tag == "Planet")
        {
            //Vector3 kollisionsKraft = kollision.impulse / Time.fixedDeltaTime;
            //Debug.Log("kollisionsKraft : " + kollisionsKraft.ToString());
            float impuls = kollision.relativeVelocity.magnitude * m_Rigidbody.mass;
            Debug.Log("impuls: " + impuls.ToString());
            if (impuls > m_ImpulsDerZerstoerung)
            {
                GameObject objectPrefabExplosionAnimation = Instantiate(m_PrefabExplosionAnimation, transform.position, transform.rotation) as GameObject;
                if (objectPrefabExplosionAnimation.TryGetComponent(out Animation m_ExplosionAnimation))
                {
                    m_ExplosionAnimation.Play("explosion");
                    Destroy(objectPrefabExplosionAnimation, 0.5f);
                }
            }
            kollision.gameObject.SendMessage("Füge Schaden hinzu", 10);
        }
    }
}
