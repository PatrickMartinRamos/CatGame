using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObjects : MonoBehaviour
{
    /// <summary>
    /// Handle Interactable Objects Data
    /// Handle checker for shadow and water puddles
    /// </summary>

    private catActionScript _catActionScript;
    public Transform playerTransform;

    //public var
    public LayerMask puddleMask;
    public LayerMask shadowMask;

    private void Awake()
    {
        _catActionScript = FindObjectOfType<catActionScript>();
    }

    private void Update()
    {
        puddleCheck();
        shadowCheck();
    }

    #region check if playe is inside the puddle
    void puddleCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position,_catActionScript.interactRadius, puddleMask);

        if (colliders.Length > 0)
        {
            _catActionScript.isInsidePuddle = true;
            //Debug.Log("Player is inside the puddle!");
        }
        else
        {
            _catActionScript.isInsidePuddle = false;
            //Debug.Log("Player is not inside the puddle.");
        }
    }
    #endregion

    #region check if player is inside the shadow
    void shadowCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, _catActionScript.interactRadius, shadowMask);

        if (colliders.Length > 0)
        {
            _catActionScript.isInsideShadow = true;
            if(_catActionScript.isInsideShadow)
            {
                Debug.Log("Player is inside the shadow!");
            }
        }
        else
        {
            _catActionScript.isInsideShadow = false;
            if(!_catActionScript.isInsideShadow)
            {
                Debug.Log("Player is not inside the shadow!");
            }
        }
    }
    #endregion


}
