using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float maxDistance = 2f;

    void Update()
    {
        // Mencari blok terdekat
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && col.CompareTag("Block"))
            {
                // Mencegah pergerakan objek dan mengaktifkan Rigidbody
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                // Menempelkan objek ke blok terdekat
                transform.parent = col.transform;
                break;
            }
        }
    }
}
