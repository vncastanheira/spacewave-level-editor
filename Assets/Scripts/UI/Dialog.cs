using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Canvas))]
public class Dialog : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }
}
