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

    MeshRenderer[] down = new MeshRenderer[9];
    MeshRenderer[] up = new MeshRenderer[9];
    MeshRenderer[] right = new MeshRenderer[9];
    MeshRenderer[] left = new MeshRenderer[9];
    MeshRenderer[] front = new MeshRenderer[9];
    MeshRenderer[] back = new MeshRenderer[9];
    
    InputAction rightUp, rightDown, leftUp, leftDown, r1, r2, r3, l1, l2, l3, x, xPrime, y, yPrime, z ,zPrime;
    
    void Start()
    {
        up = new []
        {
            GameObject.Find("Up1").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up2").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up3").GetComponent<MeshRenderer>(),
            GameObject.Find("Up4").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up5").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up6").GetComponent<MeshRenderer>(),
            GameObject.Find("Up7").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up8").GetComponent<MeshRenderer>(), 
            GameObject.Find("Up9").GetComponent<MeshRenderer>(),
        };

        down = new[]
        {
            GameObject.Find("Down1").GetComponent<MeshRenderer>(),
            GameObject.Find("Down2").GetComponent<MeshRenderer>(),
            GameObject.Find("Down3").GetComponent<MeshRenderer>(),
            GameObject.Find("Down4").GetComponent<MeshRenderer>(),
            GameObject.Find("Down5").GetComponent<MeshRenderer>(),
            GameObject.Find("Down6").GetComponent<MeshRenderer>(),
            GameObject.Find("Down7").GetComponent<MeshRenderer>(),
            GameObject.Find("Down8").GetComponent<MeshRenderer>(),
            GameObject.Find("Down9").GetComponent<MeshRenderer>(),
        };

        right = new[]
        {
            GameObject.Find("Right1").GetComponent<MeshRenderer>(),
            GameObject.Find("Right2").GetComponent<MeshRenderer>(),
            GameObject.Find("Right3").GetComponent<MeshRenderer>(),
            GameObject.Find("Right4").GetComponent<MeshRenderer>(),
            GameObject.Find("Right5").GetComponent<MeshRenderer>(),
            GameObject.Find("Right6").GetComponent<MeshRenderer>(),
            GameObject.Find("Right7").GetComponent<MeshRenderer>(),
            GameObject.Find("Right8").GetComponent<MeshRenderer>(),
            GameObject.Find("Right9").GetComponent<MeshRenderer>(),
        };

        left = new[]
        {
            GameObject.Find("Left1").GetComponent<MeshRenderer>(),
            GameObject.Find("Left2").GetComponent<MeshRenderer>(),
            GameObject.Find("Left3").GetComponent<MeshRenderer>(),
            GameObject.Find("Left4").GetComponent<MeshRenderer>(),
            GameObject.Find("Left5").GetComponent<MeshRenderer>(),
            GameObject.Find("Left6").GetComponent<MeshRenderer>(),
            GameObject.Find("Left7").GetComponent<MeshRenderer>(),
            GameObject.Find("Left8").GetComponent<MeshRenderer>(),
            GameObject.Find("Left9").GetComponent<MeshRenderer>(),
        };

        front = new[]
        {
            GameObject.Find("Front1").GetComponent<MeshRenderer>(),
            GameObject.Find("Front2").GetComponent<MeshRenderer>(),
            GameObject.Find("Front3").GetComponent<MeshRenderer>(),
            GameObject.Find("Front4").GetComponent<MeshRenderer>(),
            GameObject.Find("Front5").GetComponent<MeshRenderer>(),
            GameObject.Find("Front6").GetComponent<MeshRenderer>(),
            GameObject.Find("Front7").GetComponent<MeshRenderer>(),
            GameObject.Find("Front8").GetComponent<MeshRenderer>(),
            GameObject.Find("Front9").GetComponent<MeshRenderer>(),
        };

        back = new[]
        {
            GameObject.Find("Back1").GetComponent<MeshRenderer>(),
            GameObject.Find("Back2").GetComponent<MeshRenderer>(),
            GameObject.Find("Back3").GetComponent<MeshRenderer>(),
            GameObject.Find("Back4").GetComponent<MeshRenderer>(),
            GameObject.Find("Back5").GetComponent<MeshRenderer>(),
            GameObject.Find("Back6").GetComponent<MeshRenderer>(),
            GameObject.Find("Back7").GetComponent<MeshRenderer>(),
            GameObject.Find("Back8").GetComponent<MeshRenderer>(),
            GameObject.Find("Back9").GetComponent<MeshRenderer>(),
        };
        
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

    void Update()
    {
        if (x.WasPressedThisFrame())
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
        else if (r1.WasPressedThisFrame())
        {
            if (rightUp.IsPressed())
            {
                U();
            }
            else if (rightDown.IsPressed())
            {

            }
        }
        else if (r2.WasPressedThisFrame())
        {
            if (rightUp.IsPressed())
            {
                EPrime();
            }
            else if (rightDown.IsPressed())
            {
                
            }
        }
        else if (r3.WasPressedThisFrame())
        {
            if (rightUp.IsPressed())
            {
                DPrime();
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
        else if (l2.WasPressedThisFrame())
        {
            if (leftUp.IsPressed())
            {
                E();
            }
            else if (leftDown.IsPressed())
            {
                
            }
        }
        else if (l3.WasPressedThisFrame())
        {
            if (leftUp.IsPressed())
            {
                D();
            }
            else if (leftDown.IsPressed())
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
    }

    void XPrime()
    {
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
    }

    void Y()
    {
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
    }

    void YPrime()
    {
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
    }

    void Z()
    {
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
    }

    void ZPrime()
    {
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
    }

    void U()
    {
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
    }

    void UPrime()
    {
        
        
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
    }

    void E()
    {
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap[3] = lMapPrev[3];
        fMap[4] = lMapPrev[4];
        fMap[5] = lMapPrev[5];
        
        lMap[3] = bMapPrev[3];
        lMap[4] = bMapPrev[4];
        lMap[5] = bMapPrev[5];
        
        bMap[3] = rMapPrev[3];
        bMap[4] = rMapPrev[4];
        bMap[5] = rMapPrev[5];
        
        rMap[3] = fMapPrev[3];
        rMap[4] = fMapPrev[4];
        rMap[5] = fMapPrev[5];
    }

    void EPrime()
    {
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        fMap[3] = rMapPrev[3];
        fMap[4] = rMapPrev[4];
        fMap[5] = rMapPrev[5];
        
        rMap[3] = bMapPrev[3];
        rMap[4] = bMapPrev[4];
        rMap[5] = bMapPrev[5];
        
        bMap[3] = lMapPrev[3];
        bMap[4] = lMapPrev[4];
        bMap[5] = lMapPrev[5];
        
        lMap[3] = fMapPrev[3];
        lMap[4] = fMapPrev[4];
        lMap[5] = fMapPrev[5];
    }

    void D()
    {
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);

        dMap = new[]
        {
            dMapPrev[6], dMapPrev[3], dMapPrev[0],
            dMapPrev[7], dMapPrev[4], dMapPrev[1],
            dMapPrev[8], dMapPrev[5], dMapPrev[2]
        };
        
        fMap[6] = lMapPrev[6];
        fMap[7] = lMapPrev[7];
        fMap[8] = lMapPrev[8];
        
        lMap[6] = bMapPrev[6];
        lMap[7] = bMapPrev[7];
        lMap[8] = bMapPrev[8];
        
        bMap[6] = rMapPrev[6];
        bMap[7] = rMapPrev[7];
        bMap[8] = rMapPrev[8];
        
        rMap[6] = fMapPrev[6];
        rMap[7] = fMapPrev[7];
        rMap[8] = fMapPrev[8];
    }

    void DPrime()
    {
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);

        dMap = new[]
        {
            dMapPrev[2], dMapPrev[5], dMapPrev[8],
            dMapPrev[1], dMapPrev[4], dMapPrev[7],
            dMapPrev[0], dMapPrev[3], dMapPrev[6]
        };
        
        fMap[6] = rMapPrev[6];
        fMap[7] = rMapPrev[7];
        fMap[8] = rMapPrev[8];
        
        rMap[6] = bMapPrev[6];
        rMap[7] = bMapPrev[7];
        rMap[8] = bMapPrev[8];
        
        bMap[6] = lMapPrev[6];
        bMap[7] = lMapPrev[7];
        bMap[8] = lMapPrev[8];
        
        lMap[6] = fMapPrev[6];
        lMap[7] = fMapPrev[7];
        lMap[8] = fMapPrev[8];
    }
}
