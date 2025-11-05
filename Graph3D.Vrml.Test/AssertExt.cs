using System.Collections.Generic;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Parser.Statements.Proto;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(IList<ProtoEventInStatement> expected, IList<ProtoEventInStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ProtoEventOutStatement> expected, IList<ProtoEventOutStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ProtoFieldStatement> expected, IList<ProtoFieldStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ProtoExposedFieldStatement> expected, IList<ProtoExposedFieldStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(ProtoEventInStatement expected, ProtoEventInStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.EventId, Is.EqualTo(expected.EventId), $"{path}.EventId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }

        public static void AreEqual(ProtoEventOutStatement expected, ProtoEventOutStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.EventId, Is.EqualTo(expected.EventId), $"{path}.EventId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }

        public static void AreEqual(ProtoFieldStatement expected, ProtoFieldStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.FieldId, Is.EqualTo(expected.FieldId), $"{path}.FieldId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
            AreEqual(expected.Value, actual.Value, $"{path}.Value");
        }

        public static void AreEqual(ProtoExposedFieldStatement expected, ProtoExposedFieldStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.FieldId, Is.EqualTo(expected.FieldId), $"{path}.FieldId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
            AreEqual(expected.Value, actual.Value, $"{path}.Value");
        }



        public static void AreEqual(IList<ExternEventInStatement> expected, IList<ExternEventInStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ExternEventOutStatement> expected, IList<ExternEventOutStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ExternFieldStatement> expected, IList<ExternFieldStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(IList<ExternExposedFieldStatement> expected, IList<ExternExposedFieldStatement> actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Count, Is.EqualTo(expected.Count), $"{path}.Count");

            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], $"{path}[{i}]");
            }
        }

        public static void AreEqual(ExternEventInStatement expected, ExternEventInStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.EventId, Is.EqualTo(expected.EventId), $"{path}.EventId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }

        public static void AreEqual(ExternEventOutStatement expected, ExternEventOutStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.EventId, Is.EqualTo(expected.EventId), $"{path}.EventId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }

        public static void AreEqual(ExternFieldStatement expected, ExternFieldStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.FieldId, Is.EqualTo(expected.FieldId), $"{path}.FieldId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }

        public static void AreEqual(ExternExposedFieldStatement expected, ExternExposedFieldStatement actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.FieldId, Is.EqualTo(expected.FieldId), $"{path}.FieldId");
            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType), $"{path}.FieldType");
        }
    }
}