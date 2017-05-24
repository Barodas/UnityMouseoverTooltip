using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    public static TooltipController Instance;

    public GameObject TooltipPanel;
    public Text TooltipText;

    private RectTransform _rect;
    private bool _isHovering;
    private Vector3 _offset;

	void Start ()
    {
        Instance = this;
        _rect = GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        TooltipPanel.SetActive(_isHovering);

        //_offset = new Vector3(_rect.rect.width * 0.5f, -(_rect.rect.height * 0.5f), 0);
        transform.position = Input.mousePosition/* + _offset*/;
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
