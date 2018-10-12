using System;
using Xunit;

namespace BinarySearchTree.Test
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void ShouldAddTenElements()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            translatorTree.Add("book", "livro");
            translatorTree.Add("table", "mesa");
            translatorTree.Add("onion", "cebola");
            translatorTree.Add("banana", "banana");
            translatorTree.Add("pants", "calça");
            translatorTree.Add("boat", "barco");
            translatorTree.Add("amusement", "diversão");
            translatorTree.Add("10", "10");
            translatorTree.Add("fifteen", "quinze");
            translatorTree.Add("chicken", "galinha");

            int actual = translatorTree.Count();
            int expected = 10;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldThrowExceptionWhenAddingElementWithEmptyKeyInMethodAdd()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.Add("", "livro"));
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenAddingElementWithNullKeyInMethodAdd()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.Add(null, "livro"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenAddingDuplicatedElementWithMethodAdd()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            translatorTree.Add("book", "livro");
            translatorTree.Add("table", "mesa");
            translatorTree.Add("onion", "cebola");
            
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => translatorTree.Add("table", "mesa"));
        }

        [Fact]
        public void ShouldUpdateWhenAddingDuplicatedElementWithMethodAddOrUpdate()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            translatorTree.AddOrUpdate("book", "livro");
            translatorTree.AddOrUpdate("table", "mesa");
            translatorTree.AddOrUpdate("onion", "cebola");
            translatorTree.AddOrUpdate("table", "tabela");

            string actual = translatorTree.GetByKey("table");
            string expected = "tabela";
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenAddingElementWithEmptyKeyInMethodAddOrUpdate()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.AddOrUpdate("", "livro"));
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenAddingElementWithNullKeyInMethodAddOrUpdate()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.AddOrUpdate(null, "livro"));
        }

        [Fact]
        public void ShouldReturnZeroCountForEmptyTree()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();

            int actual = translatorTree.Count();
            int expected = 0;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnNullForNonExistingKeyWithMethodGetByKey()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();
            
            translatorTree.AddOrUpdate("book", "livro");

            string actual = translatorTree.GetByKey("table");
            
            Assert.Null(actual);
        }
        
        [Fact]
        public void ShouldReturnNullForSearchInAnEmptyTreeWithMethodGetByKey()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();

            string actual = translatorTree.GetByKey("table");
            
            Assert.Null(actual);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenSearchingWithEmptyKeyInMethodGetByKey()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();

            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.GetByKey(""));
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenSearchingWithNullKeyInMethodGetByKey()
        {
            Tree<string, string> translatorTree = new Tree<string, string>();

            ArgumentException exception = Assert.Throws<ArgumentException>(() => translatorTree.GetByKey(null));
        }
    }
}