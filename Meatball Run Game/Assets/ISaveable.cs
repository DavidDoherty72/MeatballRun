using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISaveable  
{
    object SaveState();
    void LoadState(object state);

}
