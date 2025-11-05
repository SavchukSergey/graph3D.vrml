namespace Graph3D.Vrml.Tokenizer {
    public struct TokenPosition {

        public TokenPosition() {
            LineIndex = 1;
            ColumnIndex = 1;
        }

        public int LineIndex { get; set; }

        public int ColumnIndex { get; set; }

    }
}