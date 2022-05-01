using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehavior
{
    void Activate(Agent agent);
    void Update();
}
