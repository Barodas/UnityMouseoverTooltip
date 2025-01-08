using UnityEngine;
using UnityEngine.EventSystems;

/*
    Attach to any UI element that needs to display a tooltip on mouseover.
*/

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string TooltipText;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //TooltipController.Instance.AssignTooltip(TooltipText);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //TooltipController.Instance.UnassignTooltip();
    }
}
