using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Extern {
    [TestFixture]
    public class ExternInterfaceDeclarationsStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(@"
[
    eventIn SFInt32 eventIn1
    eventOut SFInt32 eventOut1
    eventIn SFInt32 eventIn2
    eventOut SFInt32 eventOut2
    field SFInt32 field1
    exposedField SFInt32 exposedField1
    field SFInt32 field2
    exposedField SFInt32 exposedField2
]
"));
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            Assert.That(statement.EventsOut.Count, Is.EqualTo(2));
            Assert.That(statement.Fields.Count, Is.EqualTo(2));
            Assert.That(statement.ExposedFields.Count, Is.EqualTo(2));

            AssertExt.AreEqual([new ExternEventInStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventIn1"
            }, new ExternEventInStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventIn2"
            }], statement.EventsIn);

            AssertExt.AreEqual([new ExternEventOutStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventOut1"
            }, new ExternEventOutStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventOut2"
            }], statement.EventsOut);

            AssertExt.AreEqual([new ExternFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "field1",
            }, new ExternFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "field2",
            }], statement.Fields);

            AssertExt.AreEqual([new ExternExposedFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "exposedField1",
            }, new ExternExposedFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "exposedField2",
            }], statement.ExposedFields);
        }

        [Test]
        public void ParseEmptyTest() {
            var context = new ParserContext(new Vrml97Tokenizer(@"
[
]
"));
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            Assert.That(statement.EventsIn.Count, Is.EqualTo(0));
            Assert.That(statement.EventsOut.Count, Is.EqualTo(0));
            Assert.That(statement.Fields.Count, Is.EqualTo(0));
            Assert.That(statement.ExposedFields.Count, Is.EqualTo(0));
        }
    }
}
