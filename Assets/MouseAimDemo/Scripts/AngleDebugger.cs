using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleDebugger : MonoBehaviour
{

    [SerializeField] Vector3 m_startPos;
    [SerializeField] float m_angle;



    Vector3 GetVectorFromAngle()
    {

        float rad = m_angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(m_startPos, m_startPos + GetVectorFromAngle() * 25);
    }
}
