/***************************************************************************
*   Problem Name:   Printer Queue
*   Problem Link :  http://www.spoj.com/problems/PQUEUE/
*   Date        :   Oct 13, 2015
*
*   Author      :   Atiq Rahman
*   Status      :   Time Limit Exceeded on spoj
*   Notes       :   Attempted Generic implementation, works locally, has to test for large inputs
    Lesson: If we don't set a field/member using set the property does not return the value
        using get

    ref: PropertyInfo.GetValue https://msdn.microsoft.com/en-us/library/b05d59ty(v=vs.110).aspx
    PropertyInfo.GetValue https://msdn.microsoft.com/en-us/library/hh194385(v=vs.110).aspx
* meta        :   tag-priority-queue
***************************************************************************/
using System;
using System.Collections.Generic;

class PrintItem
{
    public int Index { get; set; }
    public int Priority { get; set; }
}

class PriorityQueue<T>
{
    private int heapSize;
    List<T> itemList;

    /* Use when necessary
    public List<T> GetItemList
    {
        get
        {
            return itemList;
        }
    }

    // not planning to use this one right now
    public PriorityQueue(List<T> nl)
    {
        heapSize = nl.Count;
        itemList = new List<T>();

        for (int i = 0; i < nl.Count; i++)
            itemList.Add(nl[i]);
    } */

    public PriorityQueue()
    {
        heapSize = 0;
        itemList = new List<T>();
    }

    public void Enqueue(T item)   // requires public
    {
        heapSize++;
        itemList.Add(item);
    }

    void exchange(int i, int j)
    {
        T temp = itemList[i];

        itemList[i] = itemList[j];
        itemList[j] = temp;
    }

    void heapify(int i)
    {
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        int largest = -1;
        // > impllies smaller number will have higher priority
        if (l < heapSize && ((int)itemList[l].GetType().GetProperty("Priority").GetValue(itemList[l]) < (int)itemList[i].GetType().GetProperty("Priority").GetValue(itemList[i])))
            largest = l;
        else
            largest = i;
        if (r < heapSize && ((int)itemList[r].GetType().GetProperty("Priority").GetValue(itemList[r]) < (int)itemList[largest].GetType().GetProperty("Priority").GetValue(itemList[largest])))
            largest = r;
        if (largest != i)
        {
            exchange(i, largest);
            heapify(largest);
        }
    }

    // call before extract min
    public void buildHeap()    // requires public
    {
        for (int i = heapSize / 2; i >= 0; i--)
            heapify(i);
    }

    int heapSearch(T item)
    {
        for (int i = 0; i < heapSize; i++)
        {
            T aItem = itemList[i];

            if ((int)item.GetType().GetProperty("Index").GetValue(item) == (int)aItem.GetType().GetProperty("Index").GetValue(aItem))
                return i;
        }

        return -1;
    }

    public int Count
    {
        get { return heapSize; }
    }

    public T elementAt(int i)
    {
        return (T)itemList[i];
    }

    void heapSort()
    {
        int temp = heapSize;

        buildHeap();

        for (int i = heapSize - 1; i >= 1; i--)
        {
            exchange(0, i);
            heapSize--;
            heapify(0);
        }

        heapSize = temp;
    }

    public T extractMin()   // requires public
    {
        if (heapSize < 1)
            return default(T);

        heapSort();

        exchange(0, heapSize - 1);
        heapSize--;
        return itemList[heapSize];
    }

    public int find(T item)
    {
        return heapSearch(item);
    }
}

// Test is name of class for SPOJ
public class Test
{
    public static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            tokens = Console.ReadLine().Split();
            Queue<PrintItem> queue = new Queue<PrintItem>();
            PriorityQueue<PrintItem> priority_queue = new PriorityQueue<PrintItem>();

            for (int i = 0; i < n; i++)
            {
                PrintItem item = new PrintItem();
                item.Index = i;
                item.Priority = int.Parse(tokens[i]);
                queue.Enqueue(item);
                priority_queue.Enqueue(item);
            }
            priority_queue.buildHeap();

            int count = 0;
            PrintItem highPItem = priority_queue.extractMin(); ;
            while (queue.Count > 0)
            {
                PrintItem item = queue.Dequeue();
                if (item.Priority == highPItem.Priority)
                { // add its print time
                    count++;
                    if (item.Index == m)
                        break;
                    highPItem = priority_queue.extractMin();
                }
                else // we did not get high priority item push into queue
                {
                    queue.Enqueue(item);
                }
            }
            Console.WriteLine(count);
        }
    }
}
