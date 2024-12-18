using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public Material red;
    public Material green;
    public Material blue;
    public Material yellow;
    public Material orange;
    public Material white;

    Material[] uMap = new Material[9];
    Material[] dMap = new Material[9];
    Material[] fMap = new Material[9];
    Material[] bMap = new Material[9];
    Material[] lMap = new Material[9];
    Material[] rMap = new Material[9];
   
    public MeshRenderer[] down = new MeshRenderer[9];
    public MeshRenderer[] up = new MeshRenderer[9];
    public MeshRenderer[] right = new MeshRenderer[9];
    public MeshRenderer[] left = new MeshRenderer[9];
    public MeshRenderer[] front = new MeshRenderer[9];
    public MeshRenderer[] back = new MeshRenderer[9];
    
    InputAction rightUp, rightDown, leftUp, leftDown, r1, r2, r3, l1, l2, l3, x, xPrime, y, yPrime, z ,zPrime; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightUp = InputSystem.actions.FindAction("RightUp");
        rightDown = InputSystem.actions.FindAction("RightDown");
        leftUp = InputSystem.actions.FindAction("LeftUp");
        leftDown = InputSystem.actions.FindAction("LeftDown");
        r1 = InputSystem.actions.FindAction("R1");
        r2 = InputSystem.actions.FindAction("R2");
        r3 = InputSystem.actions.FindAction("R3");
        l1 = InputSystem.actions.FindAction("L1");
        l2 = InputSystem.actions.FindAction("L2");
        l3 = InputSystem.actions.FindAction("L3");
        x = InputSystem.actions.FindAction("X");
        xPrime = InputSystem.actions.FindAction("XPrime");
        y = InputSystem.actions.FindAction("Y");
        yPrime = InputSystem.actions.FindAction("YPrime");
        z = InputSystem.actions.FindAction("Z");
        zPrime = InputSystem.actions.FindAction("ZPrime");
        
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
        if (r1.WasPressedThisFrame())
        {
            if (rightUp.IsPressed())
            {
                U();
            }
            else if (rightDown.IsPressed())
            {
                
            }
        }
        else if (l1.WasPressedThisFrame())
        {
            if (leftUp.IsPressed())
            {
                UPrime();
            }
            else if (leftDown.IsPressed())
            {
                
            }
        }
        else if (x.WasPressedThisFrame())
        {
            X();
        }
        else if (xPrime.WasPressedThisFrame())
        {
            XPrime();
        }
        else if (y.WasPressedThisFrame())
        {
            Y();
        }
        else if (yPrime.WasPressedThisFrame())
        {
            YPrime();
        }
        else if (z.WasPressedThisFrame())
        {
            Z();
        }
        else if (zPrime.WasPressedThisFrame())
        {
            ZPrime();
        }

        int i = 0;
        while (i < 9)
        {
            up[i].material = uMap[i];
            down[i].material = dMap[i];
            front[i].material = fMap[i];
            back[i].material = bMap[i];
            left[i].material = lMap[i];
            right[i].material = rMap[i];
            i++;
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

    void X()
    {
        rMap = new Material[9]
        {
            rMap[6], rMap[3], rMap[0], 
            rMap[7], rMap[4], rMap[1], 
            rMap[8], rMap[5], rMap[2],
        };
        lMap = new Material[9]
        {
            lMap[2], lMap[5], lMap[8],
            lMap[1], lMap[4], lMap[7],
            lMap[0], lMap[3], lMap[6],
        };
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);

        fMap = dMapPrev;
        
        dMap = new[]
        {
            bMapPrev[8], bMapPrev[7], bMapPrev[6],
            bMapPrev[5], bMapPrev[4], bMapPrev[3],
            bMapPrev[2], bMapPrev[1], bMapPrev[0],
        };

        bMap = new[]
        {
            uMapPrev[8], uMapPrev[7], uMapPrev[6],
            uMapPrev[5], uMapPrev[4], uMapPrev[3],
            uMapPrev[2], uMapPrev[1], uMapPrev[0],
        };
        
        uMap = fMapPrev;
    }

    void XPrime()
    {
        rMap = new Material[9]
        {
            rMap[2], rMap[5], rMap[8], 
            rMap[1], rMap[4], rMap[7], 
            rMap[0], rMap[3], rMap[6],
        };
        lMap = new Material[9]
        {
            lMap[6], lMap[3], lMap[0],
            lMap[7], lMap[4], lMap[1],
            lMap[8], lMap[5], lMap[2],
        };

        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        
        fMap = uMapPrev;

        uMap = new[]
        {
            bMapPrev[8], bMapPrev[7], bMapPrev[6],
            bMapPrev[5], bMapPrev[4], bMapPrev[3],
            bMapPrev[2], bMapPrev[1], bMapPrev[0],
        };

        bMap = new[]
        {
            dMapPrev[8], dMapPrev[7], dMapPrev[6],
            dMapPrev[5], dMapPrev[4], dMapPrev[3],
            dMapPrev[2], dMapPrev[1], dMapPrev[0],
        };
        
        dMap = fMapPrev;
        dMap = fMapPrev;
    }

    void Y()
    {
        uMap = new Material[9]
        {
            uMap[6], uMap[3], uMap[0],
            uMap[7], uMap[4], uMap[1],
            uMap[8], uMap[5], uMap[2],
        };

        dMap = new Material[9]
        {
            dMap[2], dMap[5], dMap[8],
            dMap[1], dMap[4], dMap[7],
            dMap[0], dMap[3], dMap[6],
        };
        
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap = rMapPrev;
        rMap = bMapPrev;
        bMap = lMapPrev;
        lMap = fMapPrev;
    }

    void YPrime()
    {
        uMap = new Material[9]
        {
            uMap[2], uMap[5], uMap[8],
            uMap[1], uMap[4], uMap[7],
            uMap[0], uMap[3], uMap[6],
        };

        dMap = new Material[9]
        {
            dMap[6], dMap[3], dMap[0],
            dMap[7], dMap[4], dMap[1],
            dMap[8], dMap[5], dMap[2],
        };
        
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap = lMapPrev;
        lMap = bMapPrev;
        bMap = rMapPrev;
        rMap = fMapPrev;
    }

    void Z()
    {
        fMap = new Material[9]
        {
            fMap[6], fMap[3], fMap[0],
            fMap[7], fMap[4], fMap[1],
            fMap[8], fMap[5], fMap[2],
        };

        bMap = new Material[9]
        {
            bMap[2], bMap[5], bMap[8],
            bMap[1], bMap[4], bMap[7],
            bMap[0], bMap[3], bMap[6],
        };
        
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);

        uMap = new Material[]
        {
            
        };
    }

    void ZPrime()
    {
        
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
        
        fMap[0] = rMapPrev[0];
        fMap[1] = rMapPrev[1];
        fMap[2] = rMapPrev[2];
        
        rMap[0] = bMapPrev[0];
        rMap[1] = bMapPrev[1];
        rMap[2] = bMapPrev[2];
        
        bMap[0] = lMapPrev[0];
        bMap[1] = lMapPrev[1];
        bMap[2] = lMapPrev[2];
        
        lMap[0] = fMapPrev[0];
        lMap[1] = fMapPrev[1];
        lMap[2] = fMapPrev[2];
    }

    void UPrime()
    {
        uMap = new Material[9]
        {
            uMap[2], uMap[5], uMap[8],
            uMap[1], uMap[4], uMap[7],
            uMap[0], uMap[3], uMap[6]
        };
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap[0] = lMapPrev[0];
        fMap[1] = lMapPrev[1];
        fMap[2] = lMapPrev[2];
        
        lMap[0] = bMapPrev[0];
        lMap[1] = bMapPrev[1];
        lMap[2] = bMapPrev[2];
        
        bMap[0] = rMapPrev[0];
        bMap[1] = rMapPrev[1];
        bMap[2] = rMapPrev[2];
        
        rMap[0] = fMapPrev[0];
        rMap[1] = fMapPrev[1];
        rMap[2] = fMapPrev[2];
    }
}
