grammar KIWI;

import KiwiWords;

// Program
kiwi: BEGIN 
        (vardecl | CONSTANTE | fctdecl)*
        instruction+
      END                  
      ;

instruction: PRINT LPAR exprd RPAR          
           | NOP                            
           | exprd
           | exprg EQUAL exprd
           ;



exprd: ID
    | ENTIER
    | LPAR exprd RPAR
    | ID( (exprd (COMMA exprd)*)?)
    | exprd op=(DIV|MUL|MODULO) exprd
    | exprd op=(PLUS|MINUS) exprd
    | exprd op=(PLUSPLUS|MINUSMINUS)
    | exprd op=(OR|AND|XOR) exprd
    | exprd op=(SHIFTD|SHIFTG) exprd 
    | NOT exprd
    ;

exprg: ID                                            
    ;

fctdecl: TYPE ID ( (vardecl (COMMA vardecl) * )? ) LBRACE (instruction)* RBRACE
        ;

vardecl: TYPE ID 
        | TYPE ID EQUAL (NUMBER|ENTIER|STRINGLITTERAL)
       ;