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

    public bool working;
    
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
        if (!working)
        {
            if (x.WasPressedThisFrame() && !working)
            {
                X();
            }
            else if (xPrime.WasPressedThisFrame() && !working)
            {
                XPrime();
            }
            else if (y.WasPressedThisFrame() && !working)
            {
                Y();
            }
            else if (yPrime.WasPressedThisFrame() && !working)
            {
                YPrime();
            }
            else if (z.WasPressedThisFrame() && !working)
            {
                Z();
            }
            else if (zPrime.WasPressedThisFrame() && !working)
            {
                ZPrime();
            }
            else if (r1.WasPressedThisFrame() && !working)
            {
                if (rightUp.IsPressed() && !working)
                {
                    U();
                }
                else if (rightDown.IsPressed() && !working)
                {

                }
            }
            else if (l1.WasPressedThisFrame() && !working)
            {
                if (leftUp.IsPressed() && !working)
                {
                    UPrime();
                }
                else if (leftDown.IsPressed() && !working)
                {

                }
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
    }

    static Material[] DeepCopy(Material[] sourceArray)
    {
        if (sourceArray == null) return null;

        Material[] copiedArray = new Material[sourceArray.Length];
        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (sourceArray[i] != null)
            {
                copiedArray[i] = new Material(sourceArray[i]);
            }
            else
            {
                copiedArray[i] = null;
            }
        }
        return copiedArray;
    }

    void X()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        rMap = new[]
        {
            rMapPrev[6], rMapPrev[3], rMapPrev[0], 
            rMapPrev[7], rMapPrev[4], rMapPrev[1], 
            rMapPrev[8], rMapPrev[5], rMapPrev[2]
        };
        
        lMap = new[]
        {
            lMapPrev[2], lMapPrev[5], lMapPrev[8],
            lMapPrev[1], lMapPrev[4], lMapPrev[7],
            lMapPrev[0], lMapPrev[3], lMapPrev[6]
        };
        
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
        
        working = false;
    }

    void XPrime()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        rMap = new[]
        {
            rMapPrev[2], rMapPrev[5], rMapPrev[8], 
            rMapPrev[1], rMapPrev[4], rMapPrev[7], 
            rMapPrev[0], rMapPrev[3], rMapPrev[6],
        };
        
        lMap = new[]
        {
            lMapPrev[6], lMapPrev[3], lMapPrev[0],
            lMapPrev[7], lMapPrev[4], lMapPrev[1],
            lMapPrev[8], lMapPrev[5], lMapPrev[2],
        };
        
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
        
        working = false;
    }

    void Y()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        uMap = new[]
        {
            uMapPrev[6], uMapPrev[3], uMapPrev[0],
            uMapPrev[7], uMapPrev[4], uMapPrev[1],
            uMapPrev[8], uMapPrev[5], uMapPrev[2],
        };

        dMap = new[]
        {
            dMapPrev[2], dMapPrev[5], dMapPrev[8],
            dMapPrev[1], dMapPrev[4], dMapPrev[7],
            dMapPrev[0], dMapPrev[3], dMapPrev[6],
        };
        
        fMap = rMapPrev;
        
        rMap = bMapPrev;
        
        bMap = lMapPrev;
        
        lMap = fMapPrev;
        
        working = false;
    }

    void YPrime()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        uMap = new[]
        {
            uMapPrev[2], uMapPrev[5], uMapPrev[8],
            uMapPrev[1], uMapPrev[4], uMapPrev[7],
            uMapPrev[0], uMapPrev[3], uMapPrev[6],
        };

        dMap = new[]
        {
            dMapPrev[6], dMapPrev[3], dMapPrev[0],
            dMapPrev[7], dMapPrev[4], dMapPrev[1],
            dMapPrev[8], dMapPrev[5], dMapPrev[2],
        };
        
        fMap = lMapPrev;
        lMap = bMapPrev;
        bMap = rMapPrev;
        rMap = fMapPrev;
        
        working = false;
    }

    void Z()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap = new[]
        {
            fMapPrev[6], fMapPrev[3], fMapPrev[0],
            fMapPrev[7], fMapPrev[4], fMapPrev[1],
            fMapPrev[8], fMapPrev[5], fMapPrev[2],
        };

        bMap = new[]
        {
            bMapPrev[2], bMapPrev[5], bMapPrev[8],
            bMapPrev[1], bMapPrev[4], bMapPrev[7],
            bMapPrev[0], bMapPrev[3], bMapPrev[6],
        };

        uMap = new[]
        {
            lMapPrev[6], lMapPrev[3], lMapPrev[0],
            lMapPrev[7], lMapPrev[4], lMapPrev[1],
            lMapPrev[8], lMapPrev[5], lMapPrev[2],
        };

        lMap = new[]
        {
            dMapPrev[6], dMapPrev[3], dMapPrev[0],
            dMapPrev[7], dMapPrev[4], dMapPrev[1],
            dMapPrev[8], dMapPrev[5], dMapPrev[2],
        };

        dMap = new[]
        {
            rMapPrev[6], rMapPrev[3], rMapPrev[0],
            rMapPrev[7], rMapPrev[4], rMapPrev[1],
            rMapPrev[8], rMapPrev[5], rMapPrev[2],
        };

        rMap = new[]
        {
            uMapPrev[6], uMapPrev[3], uMapPrev[0],
            uMapPrev[7], uMapPrev[4], uMapPrev[1],
            uMapPrev[8], uMapPrev[5], uMapPrev[2],
        };
        working = false;
    }

    void ZPrime()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap = new[]
        {
            fMapPrev[2], fMapPrev[5], fMapPrev[8],
            fMapPrev[1], fMapPrev[4], fMapPrev[7],
            fMapPrev[0], fMapPrev[3], fMapPrev[6],
        };

        bMap = new[]
        {
            bMapPrev[6], bMapPrev[3], bMapPrev[0],
            bMapPrev[7], bMapPrev[4], bMapPrev[1],
            bMapPrev[8], bMapPrev[5], bMapPrev[2],
        };
        
        dMap = new[]
        {
            lMapPrev[2], lMapPrev[5], lMapPrev[8],
            lMapPrev[1], lMapPrev[4], lMapPrev[7],
            lMapPrev[0], lMapPrev[3], lMapPrev[6],
        };
        
        lMap = new[]
        {
            uMapPrev[2], uMapPrev[5], uMapPrev[8],
            uMapPrev[1], uMapPrev[4], uMapPrev[7],
            uMapPrev[0], uMapPrev[3], uMapPrev[6],
        };
        
        uMap = new[]
        {
            rMapPrev[2], rMapPrev[5], rMapPrev[8],
            rMapPrev[1], rMapPrev[4], rMapPrev[7],
            rMapPrev[0], rMapPrev[3], rMapPrev[6],
        };
        
        rMap = new[]
        {
            dMapPrev[2], dMapPrev[5], dMapPrev[8],
            dMapPrev[1], dMapPrev[4], dMapPrev[7],
            dMapPrev[0], dMapPrev[3], dMapPrev[6],
        };
        
        working = false;
    }

    void U()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        uMap = new[] {
            uMapPrev[6], uMapPrev[3], uMapPrev[0], 
            uMapPrev[7], uMapPrev[4], uMapPrev[1],
            uMapPrev[8], uMapPrev[5], uMapPrev[2],
        };

        
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
        
        working = false;
    }

    void UPrime()
    {
        working = true;
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        uMap = new[]
        {
            uMapPrev[2], uMapPrev[5], uMapPrev[8],
            uMapPrev[1], uMapPrev[4], uMapPrev[7],
            uMapPrev[0], uMapPrev[3], uMapPrev[6]
        };
        
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
        
        working = false;
    }
}
