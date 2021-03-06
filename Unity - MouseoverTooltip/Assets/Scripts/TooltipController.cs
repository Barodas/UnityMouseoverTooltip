﻿using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    public static TooltipController Instance;

    public GameObject TooltipPanel;
    public Text TooltipText;
    public float PaddingFromMouse;

    private RectTransform _panelRect;
    private bool _isHovering;

	void Start ()
    {
        Instance = this;
        _panelRect = TooltipPanel.GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        TooltipPanel.SetActive(_isHovering);

        if(_isHovering)
        {
            float width = _panelRect.rect.width;
            float height = _panelRect.rect.height;

            bool flipVertical = false;
            bool flipHorizontal = false;
            if(Input.mousePosition.x + width > Screen.width)
            {
                flipHorizontal = true;
            }
            if(Input.mousePosition.y - height < 0)
            {
                flipVertical = true;
            }

            Vector3 offset = new Vector2();
            if(!flipHorizontal)
            {
                offset.x = PaddingFromMouse;
            }
            else
            {
                offset.x = -width + -PaddingFromMouse;
            }
            if (!flipVertical)
            {
                offset.y = -PaddingFromMouse;
            }
            else
            {
                offset.y = height + PaddingFromMouse;
            }

            transform.position = Input.mousePosition + offset;
        }        
	}

    public void AssignTooltip(string tooltipString)
    {
        TooltipText.text = tooltipString;
        _isHovering = true;
    }

    public void UnassignTooltip()
    {
        TooltipText.text = "NoTooltip";
        _isHovering = false;
    }
}
