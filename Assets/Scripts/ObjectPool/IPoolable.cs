using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    /// <summary>
    /// ����Q�Ыخɽե�
    /// </summary>
    void OnPoolCreate();

    /// <summary>
    /// ����q�������X�ɽե�
    /// </summary>
    void OnPoolGet();

    /// <summary>
    /// �����k�٨�����ɽե�
    /// </summary>
    void OnPoolReturn();
}