using System;

namespace BinarySearchTree
{
    public class Leaf<T, U> where T : class
    {
        public Leaf(T key, U value)
        {
            this.Key = key;
            this.Value = value;
        }

        private string _internalKey;

        /// <summary>
        /// Gets the leaf internal identifier.
        /// </summary>
        internal string InternalKey
        {
            get {
                if (string.IsNullOrWhiteSpace(this._internalKey) == true)
                {
                    this._internalKey = this.Key.ToString();
                }

                return this._internalKey;
            }
        }

        /// <summary>
        /// Gets the key of the leaf.
        /// </summary>
        public T Key { get; private set; }

        /// <summary>
        /// Gets the value of the leaf.
        /// </summary>
        public U Value { get; internal set; }

        internal Leaf<T, U> Parent { get; set; }

        internal Leaf<T, U> Left { get; set; }

        internal Leaf<T, U> Right { get; set; }
    }
}