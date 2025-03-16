using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject _selector;
    
    public bool Selected { get; private set; }

    #region Pointer Event Callbacks

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Selected = !Selected;
        if (Selected)
            ShowSelector();
        else
            HideSelector();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Selected)
            return;

        ShowSelector();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Selected)
            return;

        HideSelector();
    }

    #endregion

    private void ShowSelector() => _selector.SetActive(true);
    private void HideSelector() => _selector.SetActive(false);
}