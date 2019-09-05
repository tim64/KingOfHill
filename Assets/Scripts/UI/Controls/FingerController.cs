using UnityEngine;
using UnityEngine.EventSystems;

public class FingerController : MonoBehaviour, IPointerClickHandler , IDragHandler, IPointerEnterHandler, IPointerUpHandler
{
    public Canvas canvas;
    public Transform pad;
    public float maxDistance;

    private Vector2 defaultPosition;
    private Vector2 padPosition;

    public Player player;
    private Vector2 jumpVector;

    void Awake()
    {
        defaultPosition = transform.position;
        padPosition = pad.position;
    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Camera eventCam = eventData.pressEventCamera;
        Vector2 worldPoint = eventCam.ScreenToWorldPoint(eventData.position);
        jumpVector = canvas.transform.InverseTransformPoint(worldPoint);

        transform.localPosition = jumpVector;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.VectorJump(jumpVector);
        transform.position = pad.position;
    }
}