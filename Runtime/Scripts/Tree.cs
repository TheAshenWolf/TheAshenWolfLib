using System;

namespace TheAshenWolfLib
{
    [Serializable]
    public class Tree<T>
    {
        public Tree(T data, Tree<T>[] options)
        {
            Options = options;
            Data = data;
        }

        public T Data;
        public Tree<T>[] Options;
    }
}