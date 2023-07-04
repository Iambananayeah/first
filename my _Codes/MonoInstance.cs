using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoInstance<T> :MonoBehaviour where T: MonoInstance<T>
{
    private static T instance;
    public static T Instance
    {
        get 
        {  
            if(instance==null)
            {
                T t = FindObjectOfType<T>();
                if (t == null)
                {
                    GameObject obj = new GameObject("MonoSingleton " + typeof(T));
                    instance = obj.AddComponent(typeof(T)) as T;
                }
                else instance = t;
                instance.init();
   
            }
            return instance;
 
        }
    }


    public virtual void init()
    {

    }

    protected void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }



}
