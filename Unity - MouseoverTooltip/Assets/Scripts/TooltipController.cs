using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    public Text TooltipText;

    private RectTransform _rect;
    private bool _isHovering;
    private Vector3 _offset;

	void Start ()
    {
        _rect = GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        _offset = new Vector3(_rect.rect.width * 0.5f, -(_rect.rect.height * 0.5f), 0);
        transform.position = Input.mousePosition + _offset;
	}
}
