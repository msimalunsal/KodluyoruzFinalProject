using System.Collections.Generic;

public interface ISubscribe<T>
{
    void AddList(T t);
    void RemoveList(T t);
}
