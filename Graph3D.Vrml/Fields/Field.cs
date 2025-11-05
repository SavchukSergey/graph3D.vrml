namespace Graph3D.Vrml.Fields {
    public abstract class Field {

        protected Field()
            : this(FieldAccessType.ExposedField) {
        }

        protected Field(FieldAccessType accessType) {
            this.accessType = accessType;
        }

        public abstract FieldType Type { get; }

        private readonly FieldAccessType accessType;

        public FieldAccessType GetAccessType() {
            return accessType;
        }

        public abstract void AcceptVisitor(IFieldVisitor visitor);

        public abstract Field Clone();

        public static Field CreateField(string fieldType) {
            return fieldType switch {
                "SFColor" => new SFColor(),
                "SFFloat" => new SFFloat(),
                "SFInt32" => new SFInt32(),
                _ => throw new InvalidVRMLSyntaxException("Unknown fieldType: '" + fieldType + "'"),
            };

        }
    }
}
