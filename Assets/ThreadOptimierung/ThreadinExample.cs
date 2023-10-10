using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ThreadinExample : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUI;

    private string _text;

    private object _lock = new();

    // Start is called before the first frame update
    void Start()
    {
        _textUI.text = "Loading...";
        Task task = Task.Factory.StartNew(() => DoWork());
        task.ContinueWith((t =>
        {
            lock (_lock)
            {
                _textUI.text = "Continou Work on Thread " + Thread.CurrentThread.ManagedThreadId;
            }
            TaskScheduler.FromCurrentSynchronizationContext();
        }));
    }

    private void DoWork()
    {
        Debug.Log("Doing Work on Thread " + Thread.CurrentThread.ManagedThreadId);

        Thread.Sleep(5000);

        lock (_lock)
        {
            _textUI.text = "Work Done on Thread " + Thread.CurrentThread.ManagedThreadId;
        }

        //Unity ist NICHT Threadsave!!!
        //GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
