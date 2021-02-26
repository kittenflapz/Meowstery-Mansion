using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEventListener : MonoBehaviour
{
    [SerializeField]
    Kitty kitten;
   public void HereKittyKitty()
    {
        kitten.Free();
    }
}
