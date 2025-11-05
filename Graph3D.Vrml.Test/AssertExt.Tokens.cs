using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(VRML97Token expected, VRML97Token actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Type, Is.EqualTo(expected.Type), $"{path}/Type must be the same");
            Assert.That(actual.Text, Is.EqualTo(expected.Text), $"{path}/Text must be the same");
       }

    }
}