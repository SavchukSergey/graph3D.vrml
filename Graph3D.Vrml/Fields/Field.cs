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

        public static Field CreateField(FieldType fieldType) {
            return fieldType switch {
                FieldType.MFColor => new MFColor(),
                FieldType.MFFloat => new MFFloat(),
                FieldType.MFInt32 => new MFInt32(),
                FieldType.MFNode => new MFNode(),
                FieldType.MFRotation => new MFRotation(),
                FieldType.MFString => new MFString(),
                FieldType.MFTime => new MFTime(),
                FieldType.MFVec2f => new MFVec2f(),
                FieldType.MFVec3f => new MFVec3f(),

                FieldType.SFBool => new SFBool(),
                FieldType.SFColor => new SFColor(),
                FieldType.SFFloat => new SFFloat(),
                FieldType.SFImage => new SFImage(),
                FieldType.SFInt32 => new SFInt32(),
                FieldType.SFNode => new SFNode(),
                FieldType.SFRotation => new SFRotation(),
                FieldType.SFString => new SFString(),
                FieldType.SFVec2f => new SFVec2f(),
                FieldType.SFVec3f => new SFVec3f(),
                _ => throw new InvalidVRMLSyntaxException("Unknown fieldType: '" + fieldType + "'"),
            };

        }
    }
}
