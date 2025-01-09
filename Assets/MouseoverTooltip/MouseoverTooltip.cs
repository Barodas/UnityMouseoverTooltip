using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
    Controller script for Tooltip Prefab.
    Receives information from TooltipTrigger on mouseover.
*/

public class MouseoverTooltip : MonoBehaviour
{
    public static MouseoverTooltip Instance;
    
    public float PaddingFromMouse;
    
    RectTransform _background;
    LayoutElement _layoutElement;
    TextMeshProUGUI _headerText;
    TextMeshProUGUI _contentText;
    
    bool _isHovering;
    
    void Start()
    {
        Instance = this;
        _background = transform.Find("Background").GetComponent<RectTransform>();
        _layoutElement = _background.GetComponent<LayoutElement>();
        _headerText = _background.transform.Find("HeaderText").GetComponent<TextMeshProUGUI>();
        _contentText = _background.transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate ()
    {
        // TODO: Add a delay before showing the tooltip when a mouseover event is received.
        
        if(_isHovering)
        {
            float width = _background.rect.width;
            float height = _background.rect.height;

            bool flipVertical = false;
            bool flipHorizontal = false;
            if(Input.mousePosition.x + (width + PaddingFromMouse) > Screen.width)
            {
                flipHorizontal = true;
            }
            if(Input.mousePosition.y - (height + PaddingFromMouse) < 0)
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
        
        _background.gameObject.SetActive(_isHovering);
	}

    public void AssignTooltip(string header, string content)
    {
        _headerText.gameObject.SetActive(!string.IsNullOrEmpty(header));
        _contentText.gameObject.SetActive(!string.IsNullOrEmpty(content));
        _headerText.SetText(header);
        _contentText.SetText(content);
        _isHovering = true;
        _layoutElement.enabled = Math.Max(_headerText.preferredWidth, _contentText.preferredWidth) >= _layoutElement.preferredWidth;
    }

    public void UnassignTooltip()
    {
        _headerText.SetText("");
        _contentText.SetText("");
        _isHovering = false;
    }
}
