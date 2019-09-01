using System;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public Transform inputPoint;
    public LineDrower line;
    public float maxDistance;

    private Vector2 zeroPoint;
    private Vector2 throwForce;

    public GameObject test;

    public event Action<Vector2> OnThrow;


    void Start()
    {
        zeroPoint = transform.position;
        line.Init(transform, inputPoint);
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputPoint.position = zeroPoint + Vector2.ClampMagnitude(mousePosition2D - zeroPoint, maxDistance);
        line.DrawLine();
    }

    private void OnMouseUp()
    {
        AddThrowForce();
        inputPoint.position = zeroPoint;
        line.ClearLine();
    }

    private void AddThrowForce()
    {
        throwForce = test.transform.position - inputPoint.position;
        LeanTween.move(test, throwForce, 0.5f);
        test.GetComponent<Animator>().Play("Jump");
        LeanTween.scale(test, test.transform.localScale * 1.25f, 0.25f).setOnComplete(() => LeanTween.scale(test, test.transform.localScale / 1.25f, 0.25f));

    }

}
