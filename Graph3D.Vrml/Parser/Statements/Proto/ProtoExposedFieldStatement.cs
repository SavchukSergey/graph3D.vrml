using System;
using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoExposedFieldStatement {

        public FieldType FieldType { get; set; }
        
        public string FieldId { get; set; }

        public Field Value { get; set; }

        //todo: remove second argument
        public static ProtoExposedFieldStatement Parse(ParserContext context, Action<ParserContext> nodeStatementParser) {
            context.ReadKeyword("exposedField");

            var fieldType = context.ParseFieldType();
            var fieldId = context.ParseFieldId();

            var field = Field.CreateField(fieldType);
            var fieldParser = new FieldParser(context, nodeStatementParser);
            field.AcceptVisitor(fieldParser);

            return new ProtoExposedFieldStatement {
                FieldType = fieldType,
                FieldId = fieldId,
                Value = field
            };
        }
    }
}
