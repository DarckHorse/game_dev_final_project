using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WBehavior
{
    void Activate(WeaponAgent w_agent);
    void Update();
}
