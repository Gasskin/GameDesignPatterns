using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Mono1 : MonoBehaviour
{
    public Button record;

    private void Awake ()
    {
        record.onClick.AddListener((() =>
        {
            StartCoroutine (Record ());
        }));
    }

    private IEnumerator Record ()
    {
        yield return new WaitForSeconds (1);
        for (int i = commands.Count - 1; i >= 0; i--)
        {
            commands[i].Undo ();
            yield return new WaitForSeconds (1);
        }
    }
    

    private List<ICommand> commands = new List<ICommand> ();

    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            Ray        rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.transform.name.Contains ("Cube"))  
                {
                    var command = new ClickCommand(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    commands.Add(command);
                    command.Execute();
                }
            }
        }
    }
}
