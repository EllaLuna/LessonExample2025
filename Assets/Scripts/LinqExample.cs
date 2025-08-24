using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LinqExample : MonoBehaviour
{
    [SerializeField] List<string> list = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        list.Add("Blab");
        list.AddRange(list);
        list.Remove("Blab");
       
        var blab = list.FirstOrDefault(x => x.Contains("world"));
        Debug.Log($"the first object that contains world: {blab}");
        list = list.Where(x => x.ToLower().Contains("linq")).ToList();
        Debug.Log($"List now contains:");
        foreach (var item in list)
        {
            Debug.Log($"{item}");
        }
        list.ForEach(x => x = x.ToLower());
        //for (int i = 0; i < list.Count; i++)
        //{
        //    list[i] = list[i].ToLower();
        //}
        Debug.Log($"List now contains:");
        foreach (var item in list)
        {
            Debug.Log($"{item}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
