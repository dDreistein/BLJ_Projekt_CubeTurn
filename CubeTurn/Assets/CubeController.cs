using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public Material red;
    public Material green;
    public Material blue;
    public Material yellow;
    public Material orange;
    public Material white;

    public Material[] uMap = new Material[9];
    public Material[] dMap = new Material[9];
    public Material[] fMap = new Material[9];
    public Material[] bMap = new Material[9];
    public Material[] lMap = new Material[9];
    public Material[] rMap = new Material[9];
   
    public MeshRenderer[] down;
    public MeshRenderer[] up;
    public MeshRenderer[] right;
    public MeshRenderer[] left;
    public MeshRenderer[] front;
    public MeshRenderer[] back;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            uMap[i] = yellow;
            dMap[i] = white;
            fMap[i] = blue;
            bMap[i] = green;
            lMap[i] = orange;
            rMap[i] = red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
