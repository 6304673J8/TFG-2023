using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{
    Renderer renderer { get; }
    void UpdateColor(Renderer renderer);
    //Play SFX
}