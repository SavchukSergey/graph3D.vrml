namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternExposedFieldStatement {

        public string FieldType { get; set; }
        
        public string FieldId { get; set; }

        public static ExternExposedFieldStatement Parse(ParserContext context) {
            context.ReadKeyword("exposedField");

            var fieldType = context.ParseFieldType();
            var fieldId = context.ParseFieldId();

            return new ExternExposedFieldStatement {
                FieldType = fieldType,
                FieldId = fieldId,
            };
        }
    }
}
