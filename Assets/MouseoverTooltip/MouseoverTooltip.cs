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
    
    [SerializeField]
    GameObject _tooltipPanel;
    [SerializeField]
    TextMeshPro _text;
    RectTransform _panelRect;
    bool _isHovering;
    
    void Start()
    {
        Instance = this;
        _tooltipPanel = gameObject;
    }

    void Update ()
    {
        _tooltipPanel.SetActive(_isHovering);

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
        _text.text = tooltipString;
        _isHovering = true;
    }

    public void UnassignTooltip()
    {
        _text.text = "NoTooltip";
        _isHovering = false;
    }
}
