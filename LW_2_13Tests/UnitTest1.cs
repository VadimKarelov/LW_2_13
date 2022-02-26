using LW_2_13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LW_2_13Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Random _rn = new();

        // Journal
        [TestMethod]
        public void JournalAddToCollection()
        {
            Journal<Organization> j = new();
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            st.CollectionCountChanged += j.CollectionCountChanged;
            st.Push(new Organization("A", "A", 100));

            string expected = "A in A, salary:100 push on qwe\n";
            string actual = j.Show();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void JournalRemoveFromCollection()
        {
            Journal<Organization> j = new();
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "A", 100));
            st.Name = "qwe";

            st.CollectionCountChanged += j.CollectionCountChanged;
            st.Remove();

            string expected = "A in A, salary:100 delete on qwe\n";
            string actual = j.Show();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void JournalRemoveByIndexFromCollection()
        {
            Journal<Organization> j = new();
            MyNewStack<Organization> st = new();
            st.Push(new Organization("A", "A", 100));
            st.Name = "qwe";

            st.CollectionCountChanged += j.CollectionCountChanged;
            st.Remove(0);

            string expected = "A in A, salary:100 delete on position 0 on qwe\n";
            string actual = j.Show();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void JournalChangeElement()
        {
            Journal<Organization> j = new();
            MyNewStack<Organization> st = new();
            st.Name = "qwe";
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));

            st.CollectionReferenceChanged += j.CollectionReferenceChanged;

            st.Sort();

            string expected = "B in B, salary:100 swap 1 on qwe\nA in A, salary:100 swap 2 on qwe\n";
            string actual = j.Show();

            Assert.AreEqual(expected, actual);
        }

        // MyNewStack
        [TestMethod]
        public void MyNewStackPushMany()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = {new Organization(ref _rn), new Organization(ref _rn)};
            st.Push(t);

            int expected = 2;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveEmpty()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            bool expected = false;
            bool actual = st.Remove(0);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveCorrect()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = { new Organization(ref _rn), new Organization(ref _rn),
            new Organization(ref _rn) };
            st.Push(t);

            st.Remove(1);

            int expected = 2;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveUpperBound()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = { new Organization(ref _rn), new Organization(ref _rn),
            new Organization(ref _rn) };
            st.Push(t);

            st.Remove(2);

            int expected = 2;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveLowerBound()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = { new Organization(ref _rn), new Organization(ref _rn),
            new Organization(ref _rn) };
            st.Push(t);

            st.Remove(0);

            int expected = 2;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveMoreIndex()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = { new Organization(ref _rn), new Organization(ref _rn),
            new Organization(ref _rn) };
            st.Push(t);

            bool expected = false;
            bool actual = st.Remove(5);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackRemoveLessIndex()
        {
            MyNewStack<Organization> st = new();
            st.Name = "qwe";

            Organization[] t = { new Organization(ref _rn), new Organization(ref _rn),
            new Organization(ref _rn) };
            st.Push(t);

            bool expected = false;
            bool actual = st.Remove(-2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorGetMiddle()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("A", "A", 100);
            Organization actual = st[1];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorGetFirst()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("C", "C", 100);
            Organization actual = st[0];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorGetLast()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("B", "B", 100);
            Organization actual = st[2];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorGetLessIndex()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Assert.ThrowsException<IndexOutOfRangeException>(() => st[-1]);
        }
        [TestMethod]
        public void MyNewStackIndexatorGetMoreIndex()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Assert.ThrowsException<IndexOutOfRangeException>(() => st[5]);
        }
        [TestMethod]
        public void MyNewStackIndexatorSetMiddle()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("D", "D", 100);

            st[1] = expected;

            Organization actual = st[1];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorSetFirst()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("D", "D", 100);

            st[0] = expected;

            Organization actual = st[0];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorSetLast()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Organization expected = new Organization("D", "D", 100);

            st[2] = expected;

            Organization actual = st[2];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyNewStackIndexatorSetLessIndex()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Assert.ThrowsException<IndexOutOfRangeException>(() => st[-1] = new Organization(ref _rn));
        }
        [TestMethod]
        public void MyNewStackIndexatorSetMoreIndex()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            Assert.ThrowsException<IndexOutOfRangeException>(() => st[5] = new Organization(ref _rn));
        }
        [TestMethod]
        public void MyNewStackDispose()
        {
            MyNewStack<Organization> st = new();
            st.Push(new Organization("B", "B", 100));
            st.Push(new Organization("A", "A", 100));
            st.Push(new Organization("C", "C", 100));

            st.Dispose();

            int expected = 0;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}