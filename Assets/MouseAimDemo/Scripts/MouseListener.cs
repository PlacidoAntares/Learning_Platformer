using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseListener : MonoBehaviour
{

    [SerializeField] bool m_isListeningForInput;

    public Vector2 lastKnownMousePosition;

    private void Update()
    {
        if (!m_isListeningForInput)
            return;

        lastKnownMousePosition = Input.mousePosition;
    }

}
