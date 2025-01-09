using UnityEngine;
using UnityEngine.EventSystems;

/*
    Attach to any UI element that needs to display a tooltip on mouseover.
*/

// TODO: Modify or create a new tooltip trigger for sprites/objects/colliders in 2D/3D space.

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string TooltipHeaderText;
    public string TooltipContentText;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        MouseoverTooltip.Instance.AssignTooltip(TooltipHeaderText, TooltipContentText);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        MouseoverTooltip.Instance.UnassignTooltip();
    }
}
