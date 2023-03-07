using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> pooledObjects = new List<T>();
    private T prefab;

    public ObjectPool(T prefab, int preGenerateCount)
    {
        this.prefab = prefab;

        for (int i = 0; i < preGenerateCount; i++)
        {
            T newObj = Object.Instantiate(prefab);
            pooledObjects.Add(newObj);
            newObj.gameObject.SetActive(false);
        }
    }

    // ������Ʈ�� Ǯ���� �������ų�, �����ؼ� ��ȯ�մϴ�.
    public T GetObject()
    {
        foreach (T obj in pooledObjects)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        T newObj = Object.Instantiate(prefab);
        pooledObjects.Add(newObj);
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    // ������Ʈ�� ��Ȱ��ȭ�ؼ� Ǯ�� ��ȯ�մϴ�.
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}