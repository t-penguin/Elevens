using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : Selectable
{
    public Card Card { get; set; }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (Card == null)
            return;

        EventManager.ClickCard(Card, Selected);
    }
}