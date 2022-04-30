using System;
using System.IO;

namespace Compilateur.Generator
{
    /// <summary>
    /// Représente un générateur lexicale d'assembleur sur un flux de sortie
    /// AssemblyPrinter est mutable
    /// De manière générale, AssemblyPrinter est représenté par un fluxdesortie
    /// 
    /// fluxdesortie : StreamWriter //le flux de sortie sur lequel est généré l'assembleur
    ///
    /// 
    /// data segment
    ///     YOUR DECLARATION HERE
    /// data ends
    /// 
    /// code segment
    ///     assume cs:code, ds:data
    /// start:
    ///
    ///     YOU CODE HERE
    /// 
    /// code ends
    /// end start
    /// </summary>
    public class AssemblyPrinter
    {
        private TextWriter writer;

        #region Constructor

        public AssemblyPrinter(StringWriter writer)
        {
            this.writer = writer;
        }
        public AssemblyPrinter(StreamWriter writer)
        {
            this.writer = writer;
        }

        #endregion Constructor

        public void Flush()
        {
            this.writer.Flush();
        }

        public void Close()
        {
            this.writer.Close();
        }


        public void PrintBegin()
        {
            this.writer.WriteLine(".MODEL SMALL");
            this.writer.WriteLine(".STACK 100H");
            this.writer.WriteLine(".DATA");
            this.writer.WriteLine(".CODE");
            this.writer.WriteLine("MAIN PROC FAR");
            this.writer.WriteLine("    MOV AX,@DATA");
            this.writer.WriteLine("    MOV DS,AX");

            this.writer.WriteLine("");
        }

        public void PrintMainEnd()
        {
            // INT 21h / AH=4Ch - return control to the operating system (stop program).
            this.writer.WriteLine("    ;interrupt to exit");
            this.writer.WriteLine("    mov ah, 4ch");
            this.writer.WriteLine("    int 21h");
            this.writer.WriteLine("MAIN ENDP");

            this.PrintPusha();
            this.PrintPopa();
        }

        public void PrintEnd()
        {
            this.PrintProcPrintAX();
            this.PrintProcPrintEndl();
            this.writer.WriteLine("END MAIN");
        }


        public void PrintMov(AssemblyRegister registerLeft, string b)
        {
            this.writer.WriteLine("    MOV " + registerLeft + "," + b);
        }

        public void PrintAdd(AssemblyRegister registerLeft, AssemblyRegister registerRight)
        {
            this.writer.WriteLine($"    ADD {registerLeft}, {registerRight}");
        }

        public void PrintNop()
        {
            this.writer.WriteLine("    NOP " );
        }


        public void PrintComment(string s)
        {
            this.writer.WriteLine($"    ; {s}");
        }


        #region Function : Print, PushA, PopA ...

        public void PrintProcPrintAX()
        {
            var v = Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    ";  Affiche la valeur entiere de AX " + Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    "PRINT_AX PROC" + Environment.NewLine +
                    "    cmp ax, 0" + Environment.NewLine +
                    "    jne label0" + Environment.NewLine +
                    "    ;print 0 if ax is 0" + Environment.NewLine +
                    "    mov dx, 48" + Environment.NewLine +
                    "    mov ah, 02h" + Environment.NewLine +
                    "    int 21h" + Environment.NewLine +
                    "    jmp exit" + Environment.NewLine +
                    "    " + Environment.NewLine +
                    "    label0:" + Environment.NewLine +
                    ";initilize count" + Environment.NewLine +
                    "mov cx,0" + Environment.NewLine +
                    "mov dx,0" + Environment.NewLine +
                    "label1:" + Environment.NewLine +
                    "    ; if ax is zero" + Environment.NewLine +
                    "    cmp ax,0" + Environment.NewLine +
                    "    je print1	" + Environment.NewLine +
                    "    ;initilize bx to 10" + Environment.NewLine +
                    "    mov bx,10" + Environment.NewLine +
                    "    ; extract the last digit" + Environment.NewLine +
                    "    div bx" + Environment.NewLine +
                    "    ;push it in the stack" + Environment.NewLine +
                    "    push dx" + Environment.NewLine +
                    "    ;increment the count" + Environment.NewLine +
                    "    inc cx" + Environment.NewLine +
                    "    ;set dx to 0" + Environment.NewLine +
                    "    xor dx,dx" + Environment.NewLine +
                    "    jmp label1" + Environment.NewLine +
                    "print1:" + Environment.NewLine +
                    "    ;check if count" + Environment.NewLine +
                    "    ;is greater than zero" + Environment.NewLine +
                    "    cmp cx,0" + Environment.NewLine +
                    "    je exit" + Environment.NewLine +
                    "    ;pop the top of stack" + Environment.NewLine +
                    "    pop dx" + Environment.NewLine +
                    "    ;add 48 so that it" + Environment.NewLine +
                    "    ;represents the ASCII" + Environment.NewLine +
                    "    ;value of digits" + Environment.NewLine +
                    "    add dx,48" + Environment.NewLine +
                    "    ;interuppt to print a" + Environment.NewLine +
                    "    ;character" + Environment.NewLine +
                    "    mov ah,02h" + Environment.NewLine +
                    "    int 21h" + Environment.NewLine +
                    "    ;decrease the count" + Environment.NewLine +
                    "    dec cx" + Environment.NewLine +
                    "    jmp print1" + Environment.NewLine +
                    "exit:" + Environment.NewLine +
                    "    ret" + Environment.NewLine +
                    "PRINT_AX ENDP " + Environment.NewLine;
            this.writer.WriteLine(v);
        }        
        
        public void PrintProcPrintEndl()
        {
            var v = Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    ";  Affiche une nouvelle ligne" + Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    "print_nl PROC " + Environment.NewLine +
                    "    PUSH AX  " + Environment.NewLine +
                    "    PUSH DX " + Environment.NewLine +
                    "    MOV AH, 2" + Environment.NewLine +
                    "    MOV DL, 0Dh" + Environment.NewLine +
                    "    INT 21h" + Environment.NewLine +
                    "    MOV DL, 0Ah" + Environment.NewLine +
                    "    INT 21h" + Environment.NewLine +
                    "    POP DX " + Environment.NewLine +
                    "    POP AX" + Environment.NewLine +
                    "    RET" + Environment.NewLine +
                    "print_nl ENDP" + Environment.NewLine;
            this.writer.WriteLine(v);
        }

        public void PrintPusha()
        {
            var v = Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    ";  PUSH tout les registres" + Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    "PUSHA    MACRO" + Environment.NewLine +
                    "    push ax" + Environment.NewLine +
                    "    push bx" + Environment.NewLine +
                    "    push cx" + Environment.NewLine +
                    "    push dx" + Environment.NewLine +
                    "    push bp" + Environment.NewLine +
                    "    push si" + Environment.NewLine +
                    "    push di" + Environment.NewLine +
                    "ENDM" + Environment.NewLine;
            this.writer.WriteLine(v);
        }

        public void PrintPopa()
        {
            var v = Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    ";  POP tout les registres" + Environment.NewLine +
                    ";------------------------------------------------" + Environment.NewLine +
                    "POPA MACRO" + Environment.NewLine +
                    "    pop di" + Environment.NewLine +
                    "    pop si" + Environment.NewLine +
                    "    pop bp" + Environment.NewLine +
                    "    pop dx" + Environment.NewLine +
                    "    pop cx" + Environment.NewLine +
                    "    pop bx" + Environment.NewLine +
                    "    pop ax" + Environment.NewLine +
                    "ENDM" + Environment.NewLine;
            this.writer.WriteLine(v);
        }

        public void PrintCallPrintAX()
        {
            this.writer.WriteLine("    CALL print_ax");
        }


        #endregion Print PopA ...

    }
}
