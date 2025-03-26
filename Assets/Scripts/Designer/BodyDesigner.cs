using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyDesigner : MonoBehaviour
{
    public static BodyDesigner Instance { get; private set; }

    [SerializeField]
    private int baseConstraintCount = 3;

    [Header("Body")]
    [Space(5)]
    [SerializeField]
    private GridLayoutGroup bodyBlockParent;

    [SerializeField]
    private BodyBlock bodyBlock;

    private BodyBlock[,] bodyBlocks;

    private int constraintCount;

    public int ConstraintCount
    {
        get => constraintCount;
    }

    [Header("Room")]
    [Space(5)]
    [SerializeField]
    private List<Room> rooms;

    [SerializeField]
    private List<RoomCard> roomCards;

    private RoomCard roomCard;

    public RoomCard ClickedRoomCard
    {
        get => roomCard;
        set => roomCard = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        constraintCount = bodyBlockParent.constraintCount;

        switch (constraintCount - baseConstraintCount)
        {
            case 2:
            case 4:
                bodyBlockParent.cellSize -= new Vector2(20, 20) * (constraintCount - baseConstraintCount);
                break;
            case 6:
                bodyBlockParent.cellSize = new Vector2(90, 90);
                break;
            case 8:
                bodyBlockParent.cellSize = new Vector2(75, 75);
                break;
        }

        InitializeBodyBlocks();
    }

    private void OnEnable()
    {
        foreach (var roomCard in roomCards)
        {
            // TODO: Oda say�s� art�nca tekrars�z dizi yarat
            roomCard.Initialize(rooms[Random.Range(0, rooms.Count)]);
        }
    }

    private void InitializeBodyBlocks()
    {
        bodyBlocks = new BodyBlock[constraintCount, constraintCount];
        for (int i = 0; i < constraintCount; i++)
        {
            for (int j = 0; j < constraintCount; j++)
            {
                BodyBlock bb = Instantiate(bodyBlock, bodyBlockParent.transform);
                bb.Position = new Vector2Int(i, j);
                bodyBlocks[i, j] = bb;
            }
        }

        int center = constraintCount / 2;
        bodyBlocks[center, center].IsDroppable = true;
    }

    public void DroppableActivator(int x, int y)
    {
        if (x + 1 < constraintCount)
            bodyBlocks[x + 1, y].IsDroppable = true;
        if (x - 1 >= 0)
            bodyBlocks[x - 1, y].IsDroppable = true;
        if (y + 1 < constraintCount)
            bodyBlocks[x, y + 1].IsDroppable = true;
        if (y - 1 >= 0)
            bodyBlocks[x, y - 1].IsDroppable = true;
    }

    public void CheckForCombos(Room room, int x, int y)
    {
                    Debug.Log(room.GetType().Name);

        if (x + 1 < constraintCount)
            if (bodyBlocks[x + 1, y].room != null)
            {

                if (bodyBlocks[x + 1, y].room.attack.GetType().Name == room.attack.GetType().Name)
                {
                }
            }
        if (x - 1 >= 0)
            bodyBlocks[x - 1, y].IsDroppable = true;
        if (y + 1 < constraintCount)
            bodyBlocks[x, y + 1].IsDroppable = true;
        if (y - 1 >= 0)
            bodyBlocks[x, y - 1].IsDroppable = true;
    }
}
