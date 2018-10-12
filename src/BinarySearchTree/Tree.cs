using System;

namespace BinarySearchTree
{
    public class Tree<T, U> where T : class
    {
        public Tree()
        {
        }

        private Leaf<T, U> Root { get; set; }

        /// <summary>
        /// Adds an element to the tree. If the element exists, an InvalidOperationException is thrown.
        /// </summary>
        /// <param name="key">Unique identifier of the element.</param>
        /// <param name="value">Value of the element.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Add(T key, U value)
        {
            if (key == null || string.IsNullOrWhiteSpace(key.ToString()) == true)
            {
                throw new ArgumentException("The parameter 'key' cannot be null.", nameof(key));
            }

            // Creates an instance of the leaf to represent the data in the binary tree.
            Leaf<T, U> leaf = new Leaf<T, U>(key, value);

            // Set the new leaf as the root, if there is no root.
            if (this.Root == null)
            {
                this.Root = leaf;
                return;
            }

            // Inserts the new leaf.
            this.InsertLeaf(leaf, this.Root, true);
        }
        
        /// <summary>
        /// Adds an element to the tree. If the element exists, its value is updated.
        /// </summary>
        /// <param name="key">Unique identifier of the element.</param>
        /// <param name="value">Value of the element.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddOrUpdate(T key, U value)
        {
            if (key == null || string.IsNullOrWhiteSpace(key.ToString()) == true)
            {
                throw new ArgumentException("The parameter 'key' cannot be null.", nameof(key));
            }

            // Creates an instance of the leaf to represent the data in the binary tree.
            Leaf<T, U> leaf = new Leaf<T, U>(key, value);

            // Set the new leaf as the root, if there is no root.
            if (this.Root == null)
            {
                this.Root = leaf;
                return;
            }

            // Inserts the new leaf.
            this.InsertLeaf(leaf, this.Root, false);
        }

        /// <summary>
        /// Gets an element value by its key. 
        /// </summary>
        /// <param name="key">Key of the element to be retrieved.</param>
        /// <returns>Returns the value of the found element or null (or default value) if the element is not found.</returns>
        /// <exception cref="ArgumentException"></exception>
        public U GetByKey(T key)
        {
            if (key == null || string.IsNullOrWhiteSpace(key.ToString()) == true)
            {
                throw new ArgumentException("The parameter 'key' cannot be null.", nameof(key));
            }

            if (this.Root == null)
            {
                return default(U);
            }

            // Finds the specified leaf.
            Leaf<T, U> leaf = this.GetLeaf(key.ToString(), this.Root);

            return (leaf == null) ? default(U) : leaf.Value;
        }

        /// <summary>
        /// Tries to get the element value by its key.
        /// </summary>
        /// <param name="key">Key of the element to be retrieved.</param>
        /// <param name="output">The retrieved value will be output to this parameter.</param>
        /// <returns>Returns true if the element is found or false otherwise.</returns>
        public bool TryGetByKey(T key, out U output)
        {
            output = default(U);
            
            // TODO: Implementar.

            return false;
        }

        /// <summary>
        /// Returns the total amount of elements in the tree.
        /// </summary>
        /// <returns>Returns an integer representing the total amount of elements in the tree.</returns>
        public int Count()
        {
            if (this.Root == null)
            {
                return 0;
            }

            int totalLeaves = this.ParseLeaves(this.Root, 0);
            
            return totalLeaves;
        }

        private int ParseLeaves(Leaf<T, U> currentLeaf, int currentCount)
        {
            if (currentLeaf == null)
            {
                return currentCount;
            }

            currentCount++;

            currentCount = this.ParseLeaves(currentLeaf.Left, currentCount);
            currentCount = this.ParseLeaves(currentLeaf.Right, currentCount);

            return currentCount;
        }

        private Leaf<T, U> GetLeaf(string internalKey, Leaf<T, U> currentLeaf)
        {
            if (currentLeaf == null)
            {
                return null;
            }
            
            int compareOrdinal = string.CompareOrdinal(internalKey, currentLeaf.InternalKey);
            
            // Checks if the internalKey is equals to parentLeaf's internalKey.
            if (compareOrdinal == 0)
            {
                return currentLeaf;
            }

            return this.GetLeaf(internalKey, (compareOrdinal > 0) ? currentLeaf.Right : currentLeaf.Left);
        }

        private void InsertLeaf(Leaf<T, U> childLeaf, Leaf<T, U> parentLeaf, bool throwExceptionIfExists)
        {
            int compareOrdinal = string.CompareOrdinal(childLeaf.InternalKey, parentLeaf.InternalKey);
            
            // Checks if the internalKey is equals to parentLeaf's internalKey.
            if (compareOrdinal == 0)
            {
                if (throwExceptionIfExists == true)
                {
                    throw new InvalidOperationException($"Element with the key '{childLeaf.InternalKey}' already exists.");
                }
                else
                {
                    // Updates the leaf value.
                    parentLeaf.Value = childLeaf.Value;
                }
            }
            else if (compareOrdinal > 0)
            {
                // Validates the right leaf.

                if (parentLeaf.Right == null)
                {
                    parentLeaf.Right = childLeaf;
                }
                else
                {
                    this.InsertLeaf(childLeaf, parentLeaf.Right, throwExceptionIfExists);
                }
            }
            else
            {
                // Validates the left leaf.

                if (parentLeaf.Left == null)
                {
                    parentLeaf.Left = childLeaf;
                }
                else
                {
                    this.InsertLeaf(childLeaf, parentLeaf.Left, throwExceptionIfExists);
                }
            }
        }
    }
}