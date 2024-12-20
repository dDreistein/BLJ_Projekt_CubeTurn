using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
    
    InputAction rightUp, rightDown, leftUp, leftDown, r1, r2, r3, l1, l2, l3, x, xPrime, y, yPrime, z ,zPrime, r, rPrime, l, lPrime;
    
    public Animator animator;

    public GameObject timer;
    
    public bool solved;
    
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
        r = InputSystem.actions.FindAction("R");
        rPrime = InputSystem.actions.FindAction("RPrime");
        l = InputSystem.actions.FindAction("L");
        lPrime = InputSystem.actions.FindAction("LPrime");
        
        for (int i = 0; i < 9; i++)
        {
            uMap[i] = yellow;
            dMap[i] = white;
            fMap[i] = blue;
            bMap[i] = green;
            lMap[i] = orange;
            rMap[i] = red;
        }
        
        Scramble();
    }

    void Update()
    {
        if (!solved)
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
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (rightDown.IsPressed())
                {
                    F();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (r2.WasPressedThisFrame())
            {
                if (rightUp.IsPressed())
                {
                    EPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (rightDown.IsPressed())
                {
                    S();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (r3.WasPressedThisFrame())
            {
                if (rightUp.IsPressed())
                {
                    DPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (rightDown.IsPressed())
                {
                    B();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (l1.WasPressedThisFrame())
            {
                if (leftUp.IsPressed())
                {
                    UPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (leftDown.IsPressed())
                {
                    FPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (l2.WasPressedThisFrame())
            {
                if (leftUp.IsPressed())
                {
                    E();
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (leftDown.IsPressed())
                {
                    SPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (l3.WasPressedThisFrame())
            {
                if (leftUp.IsPressed())
                {
                    D();
                    timer.GetComponent<Timer>().StartTimer();
                }
                else if (leftDown.IsPressed())
                {
                    BPrime();
                    timer.GetComponent<Timer>().StartTimer();
                }
            }
            else if (r.WasPressedThisFrame())
            {
                R();
                timer.GetComponent<Timer>().StartTimer();
            }
            else if (rPrime.WasPressedThisFrame())
            {
                RPrime();
                timer.GetComponent<Timer>().StartTimer();
            }
            else if (l.WasPressedThisFrame())
            {
                L();
                timer.GetComponent<Timer>().StartTimer();
            }
            else if (lPrime.WasPressedThisFrame())
            {
                LPrime();
                timer.GetComponent<Timer>().StartTimer();
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

        solved = IsSolved(up, down, front, back, left, right);

        if (solved)
        {
            timer.GetComponent<Timer>().StopTimer();
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

    void Scramble()
    {
        int moves = RandomNumber(25, 50);
        int[] scramble = new int[moves];
        scramble[0] = RandomNumber(1, 18);
        scramble[1] = RandomNumber(1, 18);
        int i = 2;
        while (i < moves)
        {
            int move = RandomNumber(1, 12);
            while (true)
            {
                if (move == scramble[i-1] && move == scramble[i-2])
                {
                    move = RandomNumber(1, 12);
                }
                else
                {
                    break;
                }
            }
            
            scramble[i] = move;
            
            i++;
        }
        
        foreach (var move in scramble)
        {
            switch (move)
            {
                case 1:
                    U();
                    break;
                case 2:
                    UPrime();
                    break;
                case 3:
                    D();
                    break;
                case 4:
                    DPrime();
                    break;
                case 5:
                    R();
                    break;
                case 6:
                    RPrime();
                    break;
                case 7:
                    L();
                    break;
                case 8:
                    LPrime();
                    break;
                case 9:
                    F();
                    break;
                case 10:
                    FPrime();
                    break;
                case 11:
                    B();
                    break;
                case 12:
                    BPrime();
                    break;
            }
        }
    }

    static bool IsSolved(MeshRenderer[] up, MeshRenderer[] down, MeshRenderer[] front, MeshRenderer[] back, MeshRenderer[] left, MeshRenderer[] right)
    {
        for (int i = 0; i < up.Length-1; i++)
        {
            if (up[i].material.name != up[i+1].material.name)
            {
                Console.WriteLine("up");
                return false;
            }
            if (down[i].material.name != down[i + 1].material.name)
            {
                Console.WriteLine("down");
                return false;
            }
            
            if (front[i].material.name != front[i + 1].material.name)
            {
                Console.WriteLine("front");
                return false;
            }

            if (back[i].material.name != back[i + 1].material.name)
            {
                Console.WriteLine("back");
                return false;
            }

            if (left[i].material.name != left[i + 1].material.name)
            {
                Console.WriteLine("left");
                return false;
            }

            if (right[i].material.name != right[i + 1].material.name)
            {
                Console.WriteLine("right");
                return false;
            }
        }
        Console.WriteLine("solved");
        return true;
    }

    int RandomNumber(int min, int max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }

    void X()
    {
        animator.Play("X");
        
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
        animator.Play("XPrime");
        
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
        animator.Play("Y");
        
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
        animator.Play("YPrime");
        
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
        animator.Play("Z");
        
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
        animator.Play("ZPrime");
        
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
        animator.Play("U");
        
        Material[] uMapPrev = DeepCopy(uMap);
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
        animator.Play("UPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
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
        animator.Play("E");
        
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
        animator.Play("EPrime");
        
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
        animator.Play("D");
        
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
        animator.Play("DPrime");
        
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

    void F()
    {
        animator.Play("F");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);

        fMap = new[]
        {
            fMapPrev[6], fMapPrev[3], fMapPrev[0],
            fMapPrev[7], fMapPrev[4], fMapPrev[1],
            fMapPrev[8], fMapPrev[5], fMapPrev[2]
        };

        uMap[6] = lMapPrev[8];
        uMap[7] = lMapPrev[5];
        uMap[8] = lMapPrev[2];
        
        lMap[2] = dMapPrev[0];
        lMap[5] = dMapPrev[1];
        lMap[8] = dMapPrev[2];

        dMap[0] = rMapPrev[6];
        dMap[1] = rMapPrev[3];
        dMap[2] = rMapPrev[0];
        
        rMap[0] = uMapPrev[6];
        rMap[3] = uMapPrev[7];
        rMap[6] = uMapPrev[8];
    }

    void FPrime()
    {
        animator.Play("FPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);

        fMap = new[]
        {
            fMapPrev[2], fMapPrev[5], fMapPrev[8],
            fMapPrev[1], fMapPrev[4], fMapPrev[7],
            fMapPrev[0], fMapPrev[3], fMapPrev[6],
        };
        
        uMap[6] = rMapPrev[0];
        uMap[7] = rMapPrev[3];
        uMap[8] = rMapPrev[6];
        
        rMap[0] = dMapPrev[2];
        rMap[3] = dMapPrev[1];
        rMap[6] = dMapPrev[0];
        
        dMap[2] = lMapPrev[8];
        dMap[1] = lMapPrev[5];
        dMap[0] = lMapPrev[2];
        
        lMap[8] = uMapPrev[6];
        lMap[5] = uMapPrev[7];
        lMap[2] = uMapPrev[8];
    }

    void S()
    {
        animator.Play("S");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);

        uMap[3] = lMapPrev[7];
        uMap[4] = lMapPrev[4];
        uMap[5] = lMapPrev[1];
        
        lMap[1] = dMapPrev[3];
        lMap[4] = dMapPrev[4];
        lMap[7] = dMapPrev[5];
        
        dMap[3] = rMapPrev[7];
        dMap[4] = rMapPrev[4];
        dMap[5] = rMapPrev[1];
        
        rMap[1] = uMapPrev[3];
        rMap[4] = uMapPrev[4]; //GHG
        rMap[7] = uMapPrev[5];
    }

    void SPrime()
    {
        animator.Play("SPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        uMap[3] = rMapPrev[1];
        uMap[4] = rMapPrev[4];
        uMap[5] = rMapPrev[7];
        
        rMap[7] = dMapPrev[3];
        rMap[4] = dMapPrev[4];
        rMap[1] = dMapPrev[5];
        
        dMap[3] = lMapPrev[1];
        dMap[4] = lMapPrev[4];
        dMap[5] = lMapPrev[7];
        
        lMap[7] = uMapPrev[3];
        lMap[4] = uMapPrev[4];
        lMap[1] = uMapPrev[5];
    }

    void B()
    {
        animator.Play("B");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        bMap = new[]
        {
            bMapPrev[6], bMapPrev[3], bMapPrev[0],
            bMapPrev[7], bMapPrev[4], bMapPrev[1],
            bMapPrev[8], bMapPrev[5], bMapPrev[2],
        };
        
        dMap[6] = lMapPrev[0];
        dMap[7] = lMapPrev[3];
        dMap[8] = lMapPrev[6];
        
        lMap[0] = uMapPrev[2];
        lMap[3] = uMapPrev[1];
        lMap[6] = uMapPrev[0];

        uMap[0] = rMapPrev[2];
        uMap[1] = rMapPrev[5];
        uMap[2] = rMapPrev[8];
        
        rMap[2] = dMapPrev[8];
        rMap[5] = dMapPrev[7];
        rMap[8] = dMapPrev[6];
    }

    void BPrime()
    {
        animator.Play("BPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        bMap = new[]
        {
            bMapPrev[2], bMapPrev[5], bMapPrev[8],
            bMapPrev[1], bMapPrev[4], bMapPrev[7],
            bMapPrev[0], bMapPrev[3], bMapPrev[6],
        };
        
        uMap[0] = lMapPrev[6];
        uMap[1] = lMapPrev[3];
        uMap[2] = lMapPrev[0];
        
        lMap[0] = dMapPrev[6];
        lMap[3] = dMapPrev[7];
        lMap[6] = dMapPrev[8];
        
        dMap[6] = rMapPrev[8];
        dMap[7] = rMapPrev[5];
        dMap[8] = rMapPrev[2];
        
        rMap[2] = uMapPrev[0];
        rMap[5] = uMapPrev[1];
        rMap[8] = uMapPrev[2];
    }

    void R()
    {
        animator.Play("R");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        rMap = new[]
        {
            rMapPrev[6], rMapPrev[3], rMapPrev[0], 
            rMapPrev[7], rMapPrev[4], rMapPrev[1], 
            rMapPrev[8], rMapPrev[5], rMapPrev[2]
        };
        
        uMap[2] = fMapPrev[2];
        uMap[5] = fMapPrev[5];
        uMap[8] = fMapPrev[8];
        
        fMap[2] = dMapPrev[2];
        fMap[5] = dMapPrev[5];
        fMap[8] = dMapPrev[8];
        
        dMap[2] = bMapPrev[6];
        dMap[5] = bMapPrev[3];
        dMap[8] = bMapPrev[0];
        
        bMap[0] = uMapPrev[8];
        bMap[3] = uMapPrev[5];
        bMap[6] = uMapPrev[2];
    }

    void RPrime()
    {
        animator.Play("RPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        rMap = new[]
        {
            rMapPrev[2], rMapPrev[5], rMapPrev[8], 
            rMapPrev[1], rMapPrev[4], rMapPrev[7], 
            rMapPrev[0], rMapPrev[3], rMapPrev[6],
        };
        
        uMap[8] = bMapPrev[0];
        uMap[5] = bMapPrev[3];
        uMap[2] = bMapPrev[6];
        
        bMap[6] = dMapPrev[2];
        bMap[3] = dMapPrev[5];
        bMap[0] = dMapPrev[8];
        
        dMap[2] = fMapPrev[2];
        dMap[5] = fMapPrev[5];
        dMap[8] = fMapPrev[8];
        
        fMap[2] = uMapPrev[2];
        fMap[5] = uMapPrev[5];
        fMap[8] = uMapPrev[8];
    }

    void L()
    {
        animator.Play("L");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        lMap = new[]
        {
            lMapPrev[6], lMapPrev[3], lMapPrev[0],
            lMapPrev[7], lMapPrev[4], lMapPrev[1],
            lMapPrev[8], lMapPrev[5], lMapPrev[2],
        };
        
        uMap[0] = bMapPrev[8];
        uMap[3] = bMapPrev[5];
        uMap[6] = bMapPrev[2];
        
        bMap[2] = dMapPrev[6];
        bMap[5] = dMapPrev[3];
        bMap[8] = dMapPrev[0];

        dMap[0] = fMapPrev[0];
        dMap[3] = fMapPrev[3];
        dMap[6] = fMapPrev[6];

        fMap[0] = uMapPrev[0];
        fMap[3] = uMapPrev[3];
        fMap[6] = uMapPrev[6];
    }

    void LPrime()
    {
        animator.Play("LPrime");
        
        Material[] uMapPrev = DeepCopy(uMap);
        Material[] dMapPrev = DeepCopy(dMap);
        Material[] bMapPrev = DeepCopy(bMap);
        Material[] fMapPrev = DeepCopy(fMap);
        Material[] lMapPrev = DeepCopy(lMap);
        Material[] rMapPrev = DeepCopy(rMap);
        
        lMap = new[]
        {
            lMapPrev[2], lMapPrev[5], lMapPrev[8],
            lMapPrev[1], lMapPrev[4], lMapPrev[7],
            lMapPrev[0], lMapPrev[3], lMapPrev[6]
        };

        uMap[0] = fMapPrev[0];
        uMap[3] = fMapPrev[3];
        uMap[6] = fMapPrev[6];
        
        fMap[0] = dMapPrev[0];
        fMap[3] = dMapPrev[3];
        fMap[6] = dMapPrev[6];
        
        dMap[0] = bMapPrev[8];
        dMap[3] = bMapPrev[5];
        dMap[6] = bMapPrev[2];
        
        bMap[2] = uMapPrev[6];
        bMap[5] = uMapPrev[3];
        bMap[8] = uMapPrev[0];
    }
}
