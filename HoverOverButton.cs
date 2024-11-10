using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Button button;
    private Color OriginalColor;
    public Color HoverColor = Color.blue;

    private void Start() {
        button = GetComponent<Button>();
        OriginalColor = button.image.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        button.image.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        button.image.color = OriginalColor;
    }
}
