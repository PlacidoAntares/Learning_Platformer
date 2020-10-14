using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{

    const float LEFT_FACING_OFFSET = 90;

    [Header("[Object Refs]")]
    [SerializeField] MouseListener m_mouseListener;
    [SerializeField] Transform m_armToRotate;


    Vector3 m_refVector_FacingRight = Vector3.right;
    Vector3 m_refVector_FacingLeft = Vector3.left;


    [Header("[Limits]")]
    [SerializeField] float m_maxAngle = 90;
    [SerializeField] float m_minAngle = -90;


    float m_absoluteAngle; //readOnly. 
    float m_currentActiveAngle; //readOnly.


    [Header("[Should be set by a different script]")]
    public bool isFacingRight = true;

    [Header("[Internally set at runtime]")]

    [SerializeField] bool m_isAimingDown;


    #region Vector Determinants
    Vector2 GetScreenPos_OfArm()
    {
        return Camera.main.WorldToScreenPoint(m_armToRotate.position);
    }
    Vector3 GetVectorToMousePosition()
    {
        return m_mouseListener.lastKnownMousePosition - GetScreenPos_OfArm();
    }
    #endregion

    #region Angle Determinants
    float Get_AbsoluteMouseAngle()
    {
        return Vector2.Angle(GetMouseAimAngle(), m_refVector_FacingRight);
    }

    float Get_RightFacingAngle()
    {
        return Get_AbsoluteMouseAngle();
    }
    float Get_LeftFacingAngle()
    {
        return Vector2.Angle(GetMouseAimAngle(), m_refVector_FacingLeft);
    }

    float Get_ActiveAngle()
    {
        if (isFacingRight)
            return Get_RightFacingAngle();
        else
            return Get_LeftFacingAngle();
    }

    #endregion

    Vector3 GetMouseAimAngle()
    {
        return GetVectorToMousePosition().normalized;
    }



    Vector3 Get_MaxAngle_Vector()
    {

        float rad = Mathf.Deg2Rad * m_maxAngle;


        float x = 0;
        float y = 0;




        x = Mathf.Cos(rad);
        y = Mathf.Sin(rad);

        if (!isFacingRight)
            x *= -1;

        return new Vector3(x, y, 0);
    }


    Vector3 Get_MinAngle_vector()
    {

        float rad = Mathf.Deg2Rad * m_minAngle;



        float x = 0;
        float y = 0;


        x = Mathf.Cos(rad);
        y = Mathf.Sin(rad);

        if (!isFacingRight)
            x *= -1;

        return new Vector3(x, y, 0);
    }

    Vector3 GetMouseAimAngle_WithFacing()
    {
        if (isFacingRight)
            return GetClamped_MouseAimAngle();
        else
            return -GetClamped_MouseAimAngle();
    }



    Vector3 GetClamped_MouseAimAngle()
    {


        if (m_currentActiveAngle >= m_maxAngle && !m_isAimingDown)
        {
            return Get_MaxAngle_Vector();
        }

        if (m_currentActiveAngle >= Mathf.Abs(m_minAngle) && m_isAimingDown)
        {
            return Get_MinAngle_vector();
        }

        return GetMouseAimAngle();
    }


    bool Get_IsFacingRight()
    {
        if (GetMouseAimAngle().x > 0)
            return true;
        else
            return false;
    }

    bool Get_IsFacingDown()
    {
        if (GetMouseAimAngle().y > 0)
            return false;
        else
            return true;
    }




    private void Update()
    {
        m_absoluteAngle = Get_AbsoluteMouseAngle();
        m_currentActiveAngle = Get_ActiveAngle();
        // isFacingRight = Get_IsFacingRight();

        m_isAimingDown = Get_IsFacingDown();


        m_armToRotate.right = GetMouseAimAngle_WithFacing();


    }







    //Visualizers.
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(m_armToRotate.position, m_armToRotate.position + m_refVector_FacingRight * 100);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(m_armToRotate.position, m_armToRotate.position + m_refVector_FacingLeft * 100);



        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(m_armToRotate.position, m_armToRotate.position + Get_MaxAngle_Vector() * 100);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(m_armToRotate.position, m_armToRotate.position + Get_MinAngle_vector() * 100);


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(m_armToRotate.position, m_armToRotate.position + GetVectorToMousePosition() * 50);
    }
}

