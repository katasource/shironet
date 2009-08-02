using System;

using NUnit.Framework;

namespace Apache.Shiro.Codec
{
    [TestFixture]
    public class HexTests
    {
        [Test]
        public void TestFromHexCharArray()
        {
            char[] chars = new char[]
            {
                '0', '0', '0', '1', '0', '2', '0', '3',
                '0', '4', '0', '5', '0', '6', '0', '7',
                '0', '8', '0', '9', '0', 'A', '0', 'B',
                '0', 'C', '0', 'D', '0', 'E', '0', 'F'
            };

            byte[] expectedBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            byte[] actualBytes = Hex.FromHexCharArray(chars);
            Assert.NotNull(actualBytes);
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length);

            for (int i = 0; i < expectedBytes.Length; ++i)
            {
                Assert.AreEqual(expectedBytes[i], actualBytes[i]);
            }
        }

        [Test]
        public void TestFromHexString()
        {
            byte[] expectedBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            byte[] actualBytes = Hex.FromHexString("000102030405060708090A0B0C0D0E0F");
            Assert.NotNull(actualBytes);
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length);

            for (int i = 0; i < expectedBytes.Length; ++i)
            {
                Assert.AreEqual(expectedBytes[i], actualBytes[i]);
            }
        }

        [Test]
        public void TestToHexCharArray()
        {
            byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            char[] expectedChars = new char[]
            {
                '0', '0', '0', '1', '0', '2', '0', '3',
                '0', '4', '0', '5', '0', '6', '0', '7',
                '0', '8', '0', '9', '0', 'A', '0', 'B',
                '0', 'C', '0', 'D', '0', 'E', '0', 'F'
            };
            char[] actualChars = Hex.ToHexCharArray(bytes);
            Assert.NotNull(actualChars);
            Assert.AreEqual(expectedChars.Length, actualChars.Length);

            for (int i = 0; i < expectedChars.Length; ++i)
            {
                Assert.AreEqual(expectedChars[i], actualChars[i]);
            }
        }

        [Test]
        public void TestToHexString()
        {
            byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            string actual = Hex.ToHexString(bytes);
            Assert.NotNull(actual);
            Assert.AreEqual("000102030405060708090A0B0C0D0E0F", actual);
        }
    }
}