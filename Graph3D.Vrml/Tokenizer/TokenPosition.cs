namespace Graph3D.Vrml.Tokenizer {
    public struct TokenizerPosition {

        public TokenizerPosition() {
            LineIndex = 1;
            ColumnIndex = 1;
        }

        public int LineIndex { get; set; }

        public int ColumnIndex { get; set; }

    }
}