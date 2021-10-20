using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestWindow : EditorWindow
{
[MenuItem("Window/Zadanka")]
    public static void OpenWindow()
    {
        GetWindow<TestWindow>();
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Zadanie 1 - utwórz 10 kostek na scenie"))
        {
            GameObject cube = Resources.Load<GameObject>("Cube");
            for (int i = 0; i < 10; i++)
            {
                PrefabUtility.InstantiatePrefab(cube);
            }
        }

        Vector3 GetRandomPosition()
        {
            float min_x = -9f;
            float max_x = 9f;
            float min_y = -4;
            float max_y = 2;
            return new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y), 0);
        }

        float GetRandomNumber() => Random.Range(0.1f, 2f);
        
        Vector3 GetRandomScale()
        {
            return new Vector3(GetRandomNumber(),GetRandomNumber(),GetRandomNumber());
        }
        
        Vector3 GetRandomScale_2()
        {
            float scale = GetRandomNumber();
            return new Vector3(scale,scale,scale);
        }
        
        if (GUILayout.Button("Zadanie 2 - dzieciom Kostki ustaw losowe pozycje"))
        { 
             GameObject rodzic = GameObject.Find("Kostki");
             for (int i = 0; i < rodzic.transform.childCount; i++)
             {
                 rodzic.transform.GetChild(i).transform.position = GetRandomPosition();
             }
        }
        
        if (GUILayout.Button("Zadanie 3 - dzieciom Kostki ustaw losowe skale"))
        { 
            GameObject rodzic = GameObject.Find("Kostki");
            for (int i = 0; i < rodzic.transform.childCount; i++)
            {
                rodzic.transform.GetChild(i).transform.localScale = GetRandomScale_2();
            }
        }
        
        if (GUILayout.Button("Zadanie 4 - największa kostka ma mieć zielony kolor"))
        {
            var greenMat = Resources.Load<Material>("GreenMaterial");
            GameObject rodzic = GameObject.Find("Kostki");
            Transform childWithMaxScale = rodzic.transform.GetChild(0);
            for (int i = 0; i < rodzic.transform.childCount; i++)
            {
                Transform child = rodzic.transform.GetChild(i);
                PrefabUtility.RevertPrefabInstance(child.gameObject, InteractionMode.AutomatedAction);                
                child.localScale = GetRandomScale_2();

                if (child.localScale.x > childWithMaxScale.localScale.x)
                {
                    childWithMaxScale= child;
                }
            }  
            childWithMaxScale.GetComponent<Renderer>().material = greenMat;
        }
    }
}
