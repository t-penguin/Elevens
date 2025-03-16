using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject _selector;
    
    public bool Selected { get; private set; }
    public bool Active { get; set; }

    #region Pointer Event Callbacks

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (!Active)
            return;

        Selected = !Selected;
        if (Selected)
            ShowSelector();
        else
            HideSelector();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Active || Selected)
            return;

        ShowSelector();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Active || Selected)
            return;

        HideSelector();
    }

    #endregion

    private void ShowSelector() => _selector.SetActive(true);
    private void HideSelector() => _selector.SetActive(false);

    public void Deselect()
    {
        Selected = false;
        HideSelector();
    }
}