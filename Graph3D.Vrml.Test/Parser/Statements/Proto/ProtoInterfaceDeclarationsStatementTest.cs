using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Parser.Statements.Proto;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Proto {
    [TestFixture]
    public class ProtoInterfaceDeclarationsStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(@"
[
    eventIn SFInt32 eventIn1
    eventOut SFInt32 eventOut1
    eventIn SFInt32 eventIn2
    eventOut SFInt32 eventOut2
    field SFInt32 field1 1
    exposedField SFInt32 exposedField1 2
    field SFInt32 field2 3
    exposedField SFInt32 exposedField2 4
]
"));
            var statement = ProtoInterfaceDeclarationsStatement.Parse(context, c => { });
            Assert.That(statement.Fields.Count, Is.EqualTo(2));
            Assert.That(statement.ExposedFields.Count, Is.EqualTo(2));

            AssertExt.AreEqual([new ProtoEventInStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventIn1"
            }, new ProtoEventInStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventIn2"
            }], statement.EventsIn);

            AssertExt.AreEqual([new ProtoEventOutStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventOut1"
            }, new ProtoEventOutStatement {
                FieldType = FieldType.SFInt32,
                EventId = "eventOut2"
            }], statement.EventsOut);

            AssertExt.AreEqual([new ProtoFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "field1",
                Value = new SFInt32(1)
            }, new ProtoFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "field2",
                Value = new SFInt32(3)
            }], statement.Fields);

            AssertExt.AreEqual([new ProtoExposedFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "exposedField1",
                Value = new SFInt32(2)
            }, new ProtoExposedFieldStatement {
                FieldType = FieldType.SFInt32,
                FieldId = "exposedField2",
                Value = new SFInt32(4)
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
