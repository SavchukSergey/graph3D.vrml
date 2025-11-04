using System.IO;
using System.Linq;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Extern {
    [TestFixture]
    public class ExternInterfaceDeclarationsStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
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
")));
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            Assert.That(statement.EventsIn.Count, Is.EqualTo(2));
            Assert.That(statement.EventsOut.Count, Is.EqualTo(2));
            Assert.That(statement.Fields.Count, Is.EqualTo(2));
            Assert.That(statement.ExposedFields.Count, Is.EqualTo(2));

            var firstEventIn = statement.EventsIn.First();
            Assert.That(firstEventIn.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(firstEventIn.EventId, Is.EqualTo("eventIn1"));

            var secondEventIn = statement.EventsIn.Last();
            Assert.That(secondEventIn.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(secondEventIn.EventId, Is.EqualTo("eventIn2"));

            var firstEventOut = statement.EventsOut.First();
            Assert.That(firstEventOut.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(firstEventOut.EventId, Is.EqualTo("eventOut1"));

            var secondEventOut = statement.EventsOut.Last();
            Assert.That(secondEventOut.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(secondEventOut.EventId, Is.EqualTo("eventOut2"));

            var firstField = statement.Fields.First();
            Assert.That(firstField.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(firstField.FieldId, Is.EqualTo("field1"));

            var secondField = statement.Fields.Last();
            Assert.That(secondField.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(secondField.FieldId, Is.EqualTo("field2"));

            var firstExposedField = statement.ExposedFields.First();
            Assert.That(firstExposedField.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(firstExposedField.FieldId, Is.EqualTo("exposedField1"));

            var secondExposedField = statement.ExposedFields.Last();
            Assert.That(secondExposedField.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(secondExposedField.FieldId, Is.EqualTo("exposedField2"));
        }

        [Test]
        public void ParseEmptyTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
[
]
")));
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            Assert.That(statement.EventsIn.Count, Is.EqualTo(0));
            Assert.That(statement.EventsOut.Count, Is.EqualTo(0));
            Assert.That(statement.Fields.Count, Is.EqualTo(0));
            Assert.That(statement.ExposedFields.Count, Is.EqualTo(0));
        }
    }
}
