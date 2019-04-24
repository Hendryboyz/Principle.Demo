using NSubstitute;
using NUnit.Framework;
using Principle.Demo.Domain;
using Principle.Demo.Domain.Serializer;
using System.Collections;
using System.Collections.Generic;

namespace Principle.Demo.Test
{
    [TestFixture]
    public class PhpSerializerTests
    {
        private PhpSerializer serializer;

        [Test]
        public void CanCreate()
        {
            serializer = new PhpSerializer();
            Assert.NotNull(serializer);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void GivenString_WhenSerialize_ThenReturnParseResult()
        {
            string str = "string";

            string result = serializer.Serialize(str);

            Assert.AreEqual("s:6:\"string\";", result);
        }

        [Test]
        public void GivenInt_WhenSerialize_ThenReturnParseResult()
        {
            int integer = 1234;

            string result = serializer.Serialize(integer);

            Assert.AreEqual("i:1234;", result);
        }

        [Test]
        public void GivenLong_WhenSerialize_ThenReturnParseResult()
        {
            long longer = 1234;

            string result = serializer.Serialize(longer);

            Assert.AreEqual("i:1234;", result);
        }

        [Test]
        public void GivenDouble_WhenSerialize_ThenReturnParseResult()
        {
            double doubleNum = 1234.22;

            string result = serializer.Serialize(doubleNum);

            Assert.AreEqual("d:1234.22;", result);
        }

        [TestCase(true, "b:1;")]
        [TestCase(false, "b:0;")]
        public void GivenBoolean_WhenSerialize_ThenReturnParseResult(bool boolean, string expected)
        {
            string result = serializer.Serialize(boolean);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenNull_WhenSerialize_ThenReturnParseResult()
        {
            string result = serializer.Serialize(null);

            Assert.AreEqual("N;", result);
        }

        [Test]
        public void GivenIntArray_WhenSerialize_ThenReturnParseResult()
        {
            string result = serializer.Serialize(new ArrayList(new int[] { 1, 2, 3 }));

            Assert.AreEqual("a:3:{i:0;i:1;i:1;i:2;i:2;i:3;}", result);
        }

        [Test]
        public void GivenHashTable_WhenSerialize_ThenReturnParseResult()
        {
            string result = serializer.Serialize(new Hashtable()
            {
                { 1, "string" },
                { "string", null }
            });

            StringAssert.Contains("i:1;", result);
            StringAssert.Contains("s:6:\"string\"", result);
            StringAssert.Contains("a:2:{", result);
            StringAssert.Contains("N;", result);
        }

        [Test]
        public void GivenIdpMetaData_WhenSerialize_ThenReturnParseResult()
        {
            IdpMetaDataResponse idpMetadata = new IdpMetaDataResponse()
            {
                AuthId = "my_auth_id",
                AuthName = "my_auth_name",
                Protocol = 1,
                IdPIssuer = "my_issuer",
                IdPSsoUrl = "sso_url",
                IdPCertificate = "idp_cert",
                SpCertificate = "sp_cert",
                SignatureAlgorithm = "algorithm",
                Status = 1
            };

            string result = serializer.Serialize(idpMetadata);

            StringAssert.Contains("s:7:\"auth_id\"", result);
            StringAssert.Contains("s:10:\"my_auth_id\"", result);

            StringAssert.Contains("s:9:\"auth_name\"", result);
            StringAssert.Contains("s:12:\"my_auth_name\"", result);

            StringAssert.Contains("s:8:\"protocol\"", result);
            StringAssert.Contains("i:1;", result);

            StringAssert.Contains("s:10:\"idp_issuer\"", result);
            StringAssert.Contains("s:9:\"my_issuer\"", result);

            StringAssert.Contains("s:11:\"idp_sso_url\"", result);
            StringAssert.Contains("s:7:\"sso_url\"", result);

            StringAssert.Contains("s:15:\"idp_certificate\"", result);
            StringAssert.Contains("s:8:\"idp_cert\"", result);

            StringAssert.Contains("s:14:\"sp_certificate\"", result);
            StringAssert.Contains("s:7:\"sp_cert\"", result);

            StringAssert.Contains("s:19:\"signature_algorithm\"", result);
            StringAssert.Contains("s:9:\"algorithm\"", result);

            StringAssert.Contains("s:6:\"status\"", result);
            StringAssert.Contains("i:1;", result);
        }
    }
}
