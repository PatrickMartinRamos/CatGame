using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catActionScript : MonoBehaviour
{

    /// <summary>
    /// Handle Player Interaction to Objects
    /// </summary>
  
    //system var
    [SerializeField] private float interactRadius;
    private bool isInsidePuddle = false;
    private bool isPlayerMoving = false;
    private Vector3 previousPOS;

    //public var
    public LayerMask puddleMask;

    private void Start()
    {
        previousPOS = transform.position;
    }

    private void Update()
    {
        isPlayerMoving = IsPlayerMoving();

        puddleCheck();
    }

    bool IsPlayerMoving()
    {
        bool moving = transform.position != previousPOS;

        // Update the previous position
        previousPOS = transform.position;

        return moving;
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
        if(isInsidePuddle && !isPlayerMoving)
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
