using System.Linq;

using NUnit.Framework;

using Sodium;

namespace Tests
{
    [TestFixture]
    public class ScalarMultTests
    {
        [Test]
        public void ScalarMult1()
        {
            var aliceSk = new byte[] {
                0x77,0x07,0x6d,0x0a,0x73,0x18,0xa5,0x7d,
                0x3c,0x16,0xc1,0x72,0x51,0xb2,0x66,0x45,
                0xdf,0x4c,0x2f,0x87,0xeb,0xc0,0x99,0x2a,
                0xb1,0x77,0xfb,0xa5,0x1d,0xb9,0x2c,0x2a
            };

            var alicePk = ScalarMult.Base(aliceSk);

            var result = new byte[] {
                0x85,0x20,0xf0,0x09,0x89,0x30,0xa7,0x54,
                0x74,0x8b,0x7d,0xdc,0xb4,0x3e,0xf7,0x5a,
                0x0d,0xbf,0x3a,0x0d,0x26,0x38,0x1a,0xf4,
                0xeb,0xa4,0xa9,0x8e,0xaa,0x9b,0x4e,0x6a
            };

            Assert.That(alicePk.SequenceEqual(result));
        }

        [Test]
        public void ScalarMult2()
        {
            var bobSk = new byte[] {
                0x5d,0xab,0x08,0x7e,0x62,0x4a,0x8a,0x4b,
                0x79,0xe1,0x7f,0x8b,0x83,0x80,0x0e,0xe6,
                0x6f,0x3b,0xb1,0x29,0x26,0x18,0xb6,0xfd,
                0x1c,0x2f,0x8b,0x27,0xff,0x88,0xe0,0xeb
            };

            var bobPk = ScalarMult.Base(bobSk);

            var result = new byte[] {
                0xde,0x9e,0xdb,0x7d,0x7b,0x7d,0xc1,0xb4,
                0xd3,0x5b,0x61,0xc2,0xec,0xe4,0x35,0x37,
                0x3f,0x83,0x43,0xc8,0x5b,0x78,0x67,0x4d,
                0xad,0xfc,0x7e,0x14,0x6f,0x88,0x2b,0x4f
            };

            Assert.That(bobPk.SequenceEqual(result));
        }

        [Test]
        public void ScalarMult5()
        {
            var aliceSk = new byte[] {
                0x77,0x07,0x6d,0x0a,0x73,0x18,0xa5,0x7d,
                0x3c,0x16,0xc1,0x72,0x51,0xb2,0x66,0x45,
                0xdf,0x4c,0x2f,0x87,0xeb,0xc0,0x99,0x2a,
                0xb1,0x77,0xfb,0xa5,0x1d,0xb9,0x2c,0x2a
            };

            var bobPk = new byte[] {
                0xde,0x9e,0xdb,0x7d,0x7b,0x7d,0xc1,0xb4,
                0xd3,0x5b,0x61,0xc2,0xec,0xe4,0x35,0x37,
                0x3f,0x83,0x43,0xc8,0x5b,0x78,0x67,0x4d,
                0xad,0xfc,0x7e,0x14,0x6f,0x88,0x2b,0x4f
            };

            var k = ScalarMult.Mult(aliceSk, bobPk);

            var result = new byte[] {
                0x4a,0x5d,0x9d,0x5b,0xa4,0xce,0x2d,0xe1,
                0x72,0x8e,0x3b,0xf4,0x80,0x35,0x0f,0x25,
                0xe0,0x7e,0x21,0xc9,0x47,0xd1,0x9e,0x33,
                0x76,0xf0,0x9b,0x3c,0x1e,0x16,0x17,0x42
            };

            Assert.That(k.SequenceEqual(result));
        }

        [Test]
        public void ScalarMult6()
        {
            var bobSk = new byte[] {
                0x5d,0xab,0x08,0x7e,0x62,0x4a,0x8a,0x4b,
                0x79,0xe1,0x7f,0x8b,0x83,0x80,0x0e,0xe6,
                0x6f,0x3b,0xb1,0x29,0x26,0x18,0xb6,0xfd,
                0x1c,0x2f,0x8b,0x27,0xff,0x88,0xe0,0xeb
            };

            var alicePk = new byte[] {
                0x85,0x20,0xf0,0x09,0x89,0x30,0xa7,0x54,
                0x74,0x8b,0x7d,0xdc,0xb4,0x3e,0xf7,0x5a,
                0x0d,0xbf,0x3a,0x0d,0x26,0x38,0x1a,0xf4,
                0xeb,0xa4,0xa9,0x8e,0xaa,0x9b,0x4e,0x6a
            };

            var k = ScalarMult.Mult(bobSk, alicePk);

            var result = new byte[] {
                0x4a,0x5d,0x9d,0x5b,0xa4,0xce,0x2d,0xe1,
                0x72,0x8e,0x3b,0xf4,0x80,0x35,0x0f,0x25,
                0xe0,0x7e,0x21,0xc9,0x47,0xd1,0x9e,0x33,
                0x76,0xf0,0x9b,0x3c,0x1e,0x16,0x17,0x42
            };

            Assert.That(k.SequenceEqual(result));
        }
    }
}
