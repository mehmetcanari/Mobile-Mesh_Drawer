using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicRaycast : MonoBehaviour
{
    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    public bool _allowDraw;
    public RaycastResult _globalResult;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                _globalResult = result;

                if (_globalResult.gameObject.CompareTag("NULL"))
                {
                    AllowDraw = false;
                }

                if (_globalResult.gameObject.CompareTag("ALLOW"))
                {
                    AllowDraw = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _globalResult.Clear();
        }
    }

    public bool AllowDraw
    {
        get
        {
            return _allowDraw;
        }
        set
        {
            _allowDraw = value;
        }
    }
}
