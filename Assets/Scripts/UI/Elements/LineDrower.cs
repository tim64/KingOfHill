using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrower : MonoBehaviour
{
    private LineRenderer line;
    private Transform targetFirst;
    private Transform targetSecond;

    private bool init;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void Init(Transform firstObject, Transform secondObject)
    {
        init = true;
        targetFirst = firstObject;
        targetSecond = secondObject;
    }

    public void DrawLine()
    {
        if (init)
        {
            line.SetPosition(0, transform.position + targetFirst.position);
            line.SetPosition(1, transform.position + targetSecond.position);
        }
        
    }

    public void ClearLine()
    {
        if (init)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position);
        }
            
    }
}
