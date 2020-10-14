using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    [SerializeField] ArmController m_armController;
    [SerializeField] Transform m_bodyTransform;


    private void Update()
    {
        if (m_armController.isFacingRight)
            m_bodyTransform.localScale = Vector3.one;

        else
            m_bodyTransform.localScale = new Vector3(-1, 1, 1);
    }
}
