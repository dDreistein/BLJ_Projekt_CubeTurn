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
        for (int i = 0; i < 9; i++)
        {
            up[i].material = uMap[i];
            down[i].material = dMap[i];
            front[i].material = fMap[i];
            back[i].material = bMap[i];
            left[i].material = lMap[i];
            right[i].material = rMap[i];
        }
    }

    static Material[] DeepCopy(Material[] original)
    {
        Material[] copy = new Material[original.Length];
        int i = 0;
        foreach (var material in original)
        {
            copy[i] = material;
            i++;
        }
        return copy;
    }

    void U()
    {
        uMap = new Material[9] {uMap[6], uMap[3], uMap[0], 
                                uMap[7], uMap[4], uMap[1],
                                uMap[8], uMap[5], uMap[2],
        };
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
    }
}
