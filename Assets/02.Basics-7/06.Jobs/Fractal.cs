//https://catlikecoding.com/unity/tutorials/basics/jobs/
using UnityEngine;

public class Fractal : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    int depth = 4;
    // Start is called before the first frame update
    void Start ()
    {
        gameObject.name = "Fractal" + depth;
        // Application.targetFrameRate = 1;
        if (depth <= 1) {
            return;
        }

        Fractal childA = CreateChild(Vector3.up, Quaternion.identity);
        Fractal childB = CreateChild(Vector3.right, Quaternion.Euler(0f, 0f, -90f));
        Fractal childC = CreateChild(Vector3.left, Quaternion.Euler(0f, 0f, 90f));
        Fractal childD = CreateChild(Vector3.forward, Quaternion.Euler(90f, 0f, 0f));
        Fractal childE = CreateChild(Vector3.back, Quaternion.Euler(-90f, 0f, 0f));
        
        childA.transform.SetParent(transform, false);
        childB.transform.SetParent(transform, false);
        childC.transform.SetParent(transform, false);
        childD.transform.SetParent(transform, false);
        childE.transform.SetParent(transform, false);
        print(Time.time);
    }
    
    Fractal CreateChild (Vector3 direction) {
        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.localPosition = 0.75f * direction;
        child.transform.localScale = 0.5f * Vector3.one;
        return child;
    }
    
    Fractal CreateChild (Vector3 direction, Quaternion rotation) {
        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.localPosition = 0.75f * direction;
        child.transform.localRotation = rotation;
        child.transform.localScale = 0.5f * Vector3.one;
        return child;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 22.5f * Time.deltaTime, 0f);
    }
}
