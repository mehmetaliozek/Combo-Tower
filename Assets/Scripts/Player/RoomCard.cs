using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Image dragImage;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private RectTransform dragImageRectTransform;
    private Transform originalParent;

    private Room room;

    private void Awake()
    {
        dragImageRectTransform = dragImage.GetComponent<RectTransform>();
        originalParent = dragImageRectTransform.parent;
    }

    public void Initialize(Room room)
    {
        this.room = room;
        image.sprite = room.GetComponent<SpriteRenderer>().sprite;
        dragImage.sprite = image.sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragImage.gameObject.SetActive(true);
        dragImageRectTransform.SetParent(BodyDesigner.Instance.transform);
        canvasGroup.alpha = 0.8f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragImageRectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragImage.gameObject.SetActive(false);
        dragImageRectTransform.SetParent(originalParent);
        dragImageRectTransform.anchoredPosition = image.GetComponent<RectTransform>().anchoredPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        BodyDesigner.Instance.ClickedRoomCard = this;
    }

    public Room GetRoom() => room;
    public Sprite GetRoomSprite() => image.sprite;
}
