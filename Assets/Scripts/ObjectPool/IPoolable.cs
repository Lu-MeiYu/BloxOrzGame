using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    /// <summary>
    /// 物件被創建時調用
    /// </summary>
    void OnPoolCreate();

    /// <summary>
    /// 物件從池中取出時調用
    /// </summary>
    void OnPoolGet();

    /// <summary>
    /// 物件歸還到池中時調用
    /// </summary>
    void OnPoolReturn();
}