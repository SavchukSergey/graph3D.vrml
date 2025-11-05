using System;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    [TestFixture, TestOf(typeof(TokensSourceExt))]
    public class StringContantTokenTest {
        [Test]
        public void ConsumeStringConstantTokenTest() {
            var source = new TokensSource("\"dfasdf\"");
            var token = source.ConsumeStringConstantToken();
            AssertExt.AreEqual(new VRML97Token("dfasdf".AsMemory(), VRML97TokenType.Word), token);
        }
    }
}