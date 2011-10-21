using System;
using System.Collections.Generic;
using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class CopyObjectTests : UnitTestBase
    {
        [Test]
        public void Deep_WhenNestedSerializableHierarchyExists_NoObjectInHierarchyIsReferenceEquals()
        {
            var orgHierarchy = CreateHierarchy();

            var copiedHierarchy = CopyObject.Deep(orgHierarchy);

            Assert.AreNotSame(orgHierarchy, copiedHierarchy);
            Assert.AreNotSame(orgHierarchy.Children, copiedHierarchy.Children);
            Assert.AreNotSame(orgHierarchy.Children[0], copiedHierarchy.Children[0]);
            Assert.AreNotSame(orgHierarchy.Children[1], copiedHierarchy.Children[1]);
        }

        [Test]
        public void Deep_WhenNestedSerializableHierarchyExists_ValuesAreCopied()
        {
            var orgHierarchy = CreateHierarchy();

            var copiedHierarchy = CopyObject.Deep(orgHierarchy);

            Assert.AreEqual(orgHierarchy.Int1, copiedHierarchy.Int1);
            Assert.AreEqual(orgHierarchy.String1, copiedHierarchy.String1);
            Assert.AreEqual(orgHierarchy.Children[0].ChildInt1, copiedHierarchy.Children[0].ChildInt1);
            Assert.AreEqual(orgHierarchy.Children[0].ChildString1, copiedHierarchy.Children[0].ChildString1);
            Assert.AreEqual(orgHierarchy.Children[1].ChildInt1, copiedHierarchy.Children[1].ChildInt1);
            Assert.AreEqual(orgHierarchy.Children[1].ChildString1, copiedHierarchy.Children[1].ChildString1);
        }

        private static Root CreateHierarchy()
        {
            var root = new Root
            {
                Int1 = 1,
                String1 = "Root string"
            };

            root.Children.Add(new Child { ChildInt1 = 11, ChildString1 = "Child string 1" });
            root.Children.Add(new Child { ChildInt1 = 12, ChildString1 = "Child string 2" });

            return root;
        }

        [Serializable]
        private class Root
        {
            public Root()
            {
                Children = new List<Child>();
            }

            public int Int1 { get; set; }

            public string String1 { get; set; }

            public IList<Child> Children { get; private set; }
        }

        [Serializable]
        private class Child
        {
            public int ChildInt1 { get; set; }

            public string ChildString1 { get; set; }
        }
    }
}