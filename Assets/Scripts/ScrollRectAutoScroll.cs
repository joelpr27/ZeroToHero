using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectAutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scrollSpeed = 10f;
    private bool mouseOver = false;

    private List<Selectable> m_Selectables = new List<Selectable>();
    private ScrollRect m_ScrollRect;

    private Vector2 m_NextScrollPosition = Vector2.up;
    public int RewiredPlayerID = 0;

    void Awake()
    {
        m_ScrollRect = GetComponent<ScrollRect>();
    }

    void OnEnable()
    {
        UpdateSelectables();
    }

    void Start()
    {
        UpdateSelectables();
        ScrollToSelected(true);
    }

    void Update()
    {
        InputScroll();
        
        if (!mouseOver)
        {
            // Suaviza el desplazamiento
            m_ScrollRect.normalizedPosition = Vector2.Lerp(m_ScrollRect.normalizedPosition, m_NextScrollPosition, scrollSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            m_NextScrollPosition = m_ScrollRect.normalizedPosition;
        }
    }

    void InputScroll()
    {
        if (m_Selectables.Count > 0)
        {
            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f || 
                Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") || 
                Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                ScrollToSelected(false);
            }
        }
    }

    void ScrollToSelected(bool quickScroll)
    {
        GameObject selectedObj = EventSystem.current?.currentSelectedGameObject;
        if (!selectedObj) return;

        Selectable selectedElement = selectedObj.GetComponent<Selectable>();
        if (!selectedElement) return;

        int selectedIndex = m_Selectables.IndexOf(selectedElement);
        if (selectedIndex > -1 && m_Selectables.Count > 1)
        {
            float targetPosition = 1 - (selectedIndex / ((float)m_Selectables.Count - 1));
            if (quickScroll)
            {
                m_ScrollRect.normalizedPosition = new Vector2(0, targetPosition);
            }
            m_NextScrollPosition = new Vector2(0, targetPosition);
        }
    }

    void UpdateSelectables()
    {
        if (m_ScrollRect && m_ScrollRect.content)
        {
            m_Selectables = new List<Selectable>(m_ScrollRect.content.GetComponentsInChildren<Selectable>());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        ScrollToSelected(false);
    }
}
