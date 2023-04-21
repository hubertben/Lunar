

namespace _Lexer {

    public class Lexer {

        public enum Types {
            NUMBER,
            STRING,
            WHITESPACE,
            PLUS,
            MINUS,
            STAR,
            SLASH,
            COMMENT,
            UNKNOWN,
            LEFT_PAREN,
            RIGHT_PAREN,
            EOF
        }

        public class Token {
            public Types type;
            public string value;
            public string text;
            public Token(Types type, string value = "", string text = "") {
                this.type = type;
                this.value = value;
                this.text = text;
            }
            public string __repr__(){
                return string.Format("Token({0}, {1}, {2})", this.type, this.value, this.text);
            }
        }

        private string source;
        private int position;

        public Lexer(string source) {
            this.source = source;
        }

        public char Current {
            get {
                if (this.position >= this.source.Length) {
                    return '\0';
                }
                return this.source[this.position];
            }
        }

        public void Next(){
            this.position ++;
        } 
            
        public Token getNextToken() {

            if (this.position >= this.source.Length || this.Current == '\0') {
                return new Token(Types.EOF);
            }

            int tokenStart = this.position;

            if (char.IsDigit(this.Current)){
                while (char.IsDigit(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.NUMBER, value, "NUMBER");
            }

            if (char.IsLetter(this.Current)) {
                while (char.IsLetter(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.STRING, value, "STRING");
            }

            if (char.IsWhiteSpace(this.Current)) {
                while (char.IsWhiteSpace(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.WHITESPACE, value, "WHITESPACE");
            }

            if (this.Current == '+') {
                this.Next();
                return new Token(Types.PLUS, "+", "PLUS");
            }

            if (this.Current == '-') {
                this.Next();
                return new Token(Types.MINUS, "-", "MINUS");
            }

            if (this.Current == '*') {
                this.Next();
                return new Token(Types.STAR, "*", "STAR");
            }

            if (this.Current == '/') {
                this.Next();
                return new Token(Types.SLASH, "/", "SLASH");
            }

            if (this.Current == '(') {
                this.Next();
                return new Token(Types.LEFT_PAREN, "(", "LEFT_PAREN");
            }

            if (this.Current == ')') {
                this.Next();
                return new Token(Types.RIGHT_PAREN, ")", "RIGHT_PAREN");
            }
            
            if (this.Current == '#') {
                while (this.Current != ' ' && this.Current != '\0') {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.COMMENT, value, "COMMENT");
            }

            return new Token(Types.UNKNOWN, this.Current.ToString(), "UNKNOWN");
            
        }

    }

}