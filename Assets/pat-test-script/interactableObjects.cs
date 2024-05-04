using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObjects : MonoBehaviour
{
    [SerializeField]private float puddleRadius;
    public LayerMask playerMask;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,puddleRadius);
    }

    private void Update()
    {
        checkPlayer();
    }

    void checkPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, puddleRadius, playerMask);

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                Debug.Log("Player is standing on: " + collider.gameObject.name);
            }
        }
    }
}
