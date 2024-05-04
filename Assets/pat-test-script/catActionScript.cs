using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catActionScript : MonoBehaviour
{

    /// <summary>
    /// Handle Player Interaction to Objects
    /// </summary>

    [SerializeField] private float interactRadius;

    public LayerMask puddleMask;
    public bool isInsidePuddle = false;

    private void Update()
    {
        puddleCheck();
    }

    #region check if playe is inside the puddle
    void puddleCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius, puddleMask);

        if (colliders.Length > 0)
        {
            isInsidePuddle = true;
            //Debug.Log("Player is inside the puddle!");
        }
        else
        {
            isInsidePuddle = false;
            //Debug.Log("Player is not inside the puddle.");
        }
    }
    #endregion

    public void puddleInteraction()
    {
        if(isInsidePuddle)
        {
            Debug.Log("can interact");
        }
        else
        {
            Debug.Log("can't interact");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
