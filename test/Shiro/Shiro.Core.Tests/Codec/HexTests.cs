using NUnit.Framework;

namespace Apache.Shiro.Codec
{
    [TestFixture]
    public class HexTests
    {
        [Test]
        public void TestFromHexCharArray()
        {
            var chars = new[]
            {
                '0', '0', '0', '1', '0', '2', '0', '3',
                '0', '4', '0', '5', '0', '6', '0', '7',
                '0', '8', '0', '9', '0', 'A', '0', 'B',
                '0', 'C', '0', 'D', '0', 'E', '0', 'F'
            };

            var expectedBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var actualBytes = Hex.FromHexCharArray(chars);
            Assert.NotNull(actualBytes);
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length);

            for (var i = 0; i < expectedBytes.Length; ++i)
            {
                Assert.AreEqual(expectedBytes[i], actualBytes[i]);
            }
        }

        [Test]
        public void TestFromHexString()
        {
            var expectedBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var actualBytes = Hex.FromHexString("000102030405060708090A0B0C0D0E0F");
            Assert.NotNull(actualBytes);
            Assert.AreEqual(expectedBytes.Length, actualBytes.Length);

            for (var i = 0; i < expectedBytes.Length; ++i)
            {
                Assert.AreEqual(expectedBytes[i], actualBytes[i]);
            }
        }

        [Test]
        public void TestToHexCharArray()
        {
            var bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var expectedChars = new[]
            {
                '0', '0', '0', '1', '0', '2', '0', '3',
                '0', '4', '0', '5', '0', '6', '0', '7',
                '0', '8', '0', '9', '0', 'A', '0', 'B',
                '0', 'C', '0', 'D', '0', 'E', '0', 'F'
            };
            var actualChars = Hex.ToHexCharArray(bytes);
            Assert.NotNull(actualChars);
            Assert.AreEqual(expectedChars.Length, actualChars.Length);

            for (var i = 0; i < expectedChars.Length; ++i)
            {
                Assert.AreEqual(expectedChars[i], actualChars[i]);
            }
        }

        [Test]
        public void TestToHexString()
        {
            var bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var actual = Hex.ToHexString(bytes);
            Assert.NotNull(actual);
            Assert.AreEqual("000102030405060708090A0B0C0D0E0F", actual);
        }
    }
}