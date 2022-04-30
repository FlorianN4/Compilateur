using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace Compilateur
{
    public class MyErrorListener : IAntlrErrorListener<IToken>
    {
        public bool ErrorHasBeenReported { get; private set; }

        private readonly List<string> errors;

        public MyErrorListener()
        {
            this.errors = new List<string>();
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.ErrorHasBeenReported = true;
            //base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);

            var msgBuilder = "line " + line + ":" + charPositionInLine + ": " + msg;
            this.errors.Add(msgBuilder);
        }

        public override string ToString()
        {
            if (!this.ErrorHasBeenReported)
                return "No error reported.";

            var builder = new StringBuilder();
            this.errors.ForEach(e =>
            {
                builder.Append(e);
                builder.Append(Environment.NewLine);
            });
            return builder.ToString();
        }
    }
}
