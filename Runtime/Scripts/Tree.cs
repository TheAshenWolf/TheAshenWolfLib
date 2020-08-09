using System;

namespace TheAshenWolfLib
{
    [Serializable]
    public class Tree<T>
    {
        public Tree(T data, Tree<T>[] branches)
        {
            Branches = branches;
            Data = data;
        }

        public T Data;
        public Tree<T>[] Branches;
    }
}