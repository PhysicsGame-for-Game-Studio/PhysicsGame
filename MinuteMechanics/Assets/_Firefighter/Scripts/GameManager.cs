using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;

    public Jetpack jetLeft;
    public Jetpack jetRight;

    public float gravity = -9.81f;

    private void Awake()
    {
        m_Instance = this;
    }
}
