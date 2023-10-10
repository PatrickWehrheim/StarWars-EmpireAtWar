using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleMono : MonoBehaviour
{
    [ContextMenu("A")] //Erscheint im ContextMenu des Scripts und f�hrt die Funktion aus
    private void DoStuff()
    {

    }

    [BitMask(typeof(ExampleEnum))]
    public ExampleEnum bitMask;
}
