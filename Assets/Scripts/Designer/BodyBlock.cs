using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BodyBlock : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    [SerializeField]
    private Image image;

    private Vector2Int position;

    public Vector2Int Position
    {
        get => position;
        set => position = value;
    }

    private bool isDroppable = false;

    public bool IsDroppable
    {
        get => isDroppable;
        set
        {
            if (image.sprite != null) return;
            if (value)
            {
                image.color = new Color(1, 1, 1, 0.5f);
            }
            isDroppable = value;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        RoomCard roomCard = eventData.pointerDrag.GetComponent<RoomCard>();
        Drop(roomCard);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RoomCard roomCard = BodyDesigner.Instance.ClickedRoomCard;
        Drop(roomCard);
    }

    private void Drop(RoomCard roomCard)
    {
        if (isDroppable && roomCard != null)
        {
            image.sprite = roomCard.GetRoomSprite();
            image.color = Color.white;
            isDroppable = false;
            BodyDesigner.Instance.DroppableActivator(position.x, position.y);
            Player.Instance.AddRoom(roomCard.GetRoom(), position.x, position.y, BodyDesigner.Instance.ConstraintCount);
        }
    }
}
