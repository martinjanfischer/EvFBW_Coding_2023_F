using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyOnExit : MonoBehaviour
{
    // Start wird aufgerufen bevor das erste Bild aktualisiert wird
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
